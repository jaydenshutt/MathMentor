using System.Text;
using System.Text.RegularExpressions;
using WpfMath.Parsers;
using XamlMath.Exceptions;

namespace MathMentor.Services;

/// <summary>
/// Normalizes curriculum LaTeX into the subset supported by WpfMath / XamlMath.
/// </summary>
public static partial class LatexHelper
{
    public static string Sanitize(string? latex)
    {
        if (string.IsNullOrWhiteSpace(latex))
            return "";

        // Strip UTF-8 BOM / weird whitespace from files that were edited by scripts
        var s = latex.Trim().Trim('\uFEFF', '\u200B', '\u00A0');

        s = s.Replace(@"\dfrac", @"\frac", StringComparison.Ordinal);
        s = s.Replace(@"\iff", @"\Leftrightarrow", StringComparison.Ordinal);
        s = s.Replace(@"\quad", @"\;", StringComparison.Ordinal);
        s = s.Replace(@"\qquad", @"\;\;", StringComparison.Ordinal);
        s = s.Replace(@"\mid", @"|", StringComparison.Ordinal);
        s = s.Replace(@"\vert", @"|", StringComparison.Ordinal);

        s = s.Replace(@"\bigl", @"\left", StringComparison.Ordinal);
        s = s.Replace(@"\bigr", @"\right", StringComparison.Ordinal);
        s = s.Replace(@"\Bigl", @"\left", StringComparison.Ordinal);
        s = s.Replace(@"\Bigr", @"\right", StringComparison.Ordinal);
        s = s.Replace(@"\big|", @"|", StringComparison.Ordinal);
        s = s.Replace(@"\Big|", @"|", StringComparison.Ordinal);
        s = s.Replace(@"\bigg|", @"|", StringComparison.Ordinal);
        s = s.Replace(@"\Bigg|", @"|", StringComparison.Ordinal);
        s = s.Replace(@"\big", "", StringComparison.Ordinal);
        s = s.Replace(@"\Big", "", StringComparison.Ordinal);
        s = s.Replace(@"\bigg", "", StringComparison.Ordinal);
        s = s.Replace(@"\Bigg", "", StringComparison.Ordinal);

        s = s.Replace(@"+\-", "+-", StringComparison.Ordinal);
        s = LoneHyphenEscapeRegex().Replace(s, "-");

        s = s.Replace(@"\hline", "", StringComparison.Ordinal);
        s = ArrayBeginRegex().Replace(s, @"\begin{pmatrix}");
        s = s.Replace(@"\end{array}", @"\end{pmatrix}", StringComparison.Ordinal);

        // Normalize unicode math symbols that sometimes sneak into data
        s = s.Replace("−", "-", StringComparison.Ordinal);
        s = s.Replace("×", @"\times ", StringComparison.Ordinal);
        s = s.Replace("÷", @"\div ", StringComparison.Ordinal);
        s = s.Replace("·", @"\cdot ", StringComparison.Ordinal);
        s = s.Replace("≤", @"\le ", StringComparison.Ordinal);
        s = s.Replace("≥", @"\ge ", StringComparison.Ordinal);
        s = s.Replace("≠", @"\neq ", StringComparison.Ordinal);
        s = s.Replace("≈", @"\approx ", StringComparison.Ordinal);
        s = s.Replace("→", @"\rightarrow ", StringComparison.Ordinal);
        s = s.Replace("⇒", @"\Rightarrow ", StringComparison.Ordinal);
        s = s.Replace("°", @"^\circ ", StringComparison.Ordinal);
        s = s.Replace("π", @"\pi ", StringComparison.Ordinal);
        s = s.Replace("θ", @"\theta ", StringComparison.Ordinal);
        s = s.Replace("∞", @"\infty ", StringComparison.Ordinal);
        s = s.Replace("±", @"\pm ", StringComparison.Ordinal);

        s = MultiSpaceRegex().Replace(s, " ");
        return s.Trim();
    }

    public static bool TryValidate(string sanitizedLatex, out string? error)
    {
        error = null;
        if (string.IsNullOrWhiteSpace(sanitizedLatex))
        {
            error = "empty";
            return false;
        }

        try
        {
            WpfTeXFormulaParser.Instance.Parse(sanitizedLatex);
            return true;
        }
        catch (TexException ex)
        {
            error = ex.Message;
            return false;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            return false;
        }
    }

    /// <summary>
    /// Sanitize and validate. Returns empty string only if input is empty.
    /// Never invents garbage, falls back to a structured plain-text TeX form.
    /// </summary>
    public static string Prepare(string? latex)
    {
        var sanitized = Sanitize(latex);
        if (string.IsNullOrWhiteSpace(sanitized))
            return "";

        if (TryValidate(sanitized, out _))
            return sanitized;

        var simplified = EnvironmentRegex().Replace(sanitized, " ");
        simplified = MultiSpaceRegex().Replace(simplified, " ").Trim();
        if (TryValidate(simplified, out _))
            return simplified;

        // Last resort: readable \text, still valid TeX, not stripped garbage
        var plain = ToPlainText(latex ?? "");
        var asText = @"\text{" + EscapeForTextCommand(plain) + "}";
        if (TryValidate(asText, out _))
            return asText;

        return @"\text{(see explanation)}";
    }

    /// <summary>Unicode-friendly plain text for TextBlock fallback (never strips into garbage).</summary>
    public static string ToPlainText(string latex)
    {
        if (string.IsNullOrWhiteSpace(latex))
            return "";

        var s = Sanitize(latex);

        // Ordered replacements, longest commands first to avoid \le eating \left
        var map = new (string From, string To)[]
        {
            (@"\Leftrightarrow", "⇔"),
            (@"\rightarrow", "→"),
            (@"\Rightarrow", "⇒"),
            (@"\leftarrow", "←"),
            (@"\Leftarrow", "⇐"),
            (@"\infty", "∞"),
            (@"\approx", "≈"),
            (@"\neq", "≠"),
            (@"\leq", "≤"),
            (@"\geq", "≥"),
            (@"\times", "×"),
            (@"\cdot", "·"),
            (@"\div", "÷"),
            (@"\pm", "±"),
            (@"\mp", "∓"),
            (@"\sqrt", "√"),
            (@"\frac", ""),
            (@"\left", ""),
            (@"\right", ""),
            (@"\text", ""),
            (@"\mathrm", ""),
            (@"\operatorname", ""),
            (@"\overline", ""),
            (@"\underline", ""),
            (@"\angle", "∠"),
            (@"\circ", "°"),
            (@"\pi", "π"),
            (@"\theta", "θ"),
            (@"\alpha", "α"),
            (@"\beta", "β"),
            (@"\gamma", "γ"),
            (@"\delta", "δ"),
            (@"\Delta", "Δ"),
            (@"\sin", "sin"),
            (@"\cos", "cos"),
            (@"\tan", "tan"),
            (@"\log", "log"),
            (@"\ln", "ln"),
            (@"\lim", "lim"),
            (@"\int", "∫"),
            (@"\sum", "Σ"),
            (@"\partial", "∂"),
            (@"\to", "→"),
            (@"\le", "≤"),
            (@"\ge", "≥"),
            (@"\,", " "),
            (@"\;", " "),
            (@"\!", ""),
            (@"\ ", " "),
        };

        foreach (var (from, to) in map)
            s = s.Replace(from, to, StringComparison.Ordinal);

        s = s.Replace("{", "", StringComparison.Ordinal);
        s = s.Replace("}", "", StringComparison.Ordinal);
        s = s.Replace("^", "", StringComparison.Ordinal);
        s = s.Replace("_", "", StringComparison.Ordinal);
        // Strip any remaining TeX commands
        s = ResidualCommandRegex().Replace(s, "");
        s = MultiSpaceRegex().Replace(s, " ").Trim();
        return s;
    }

    private static string EscapeForTextCommand(string s)
    {
        var sb = new StringBuilder(s.Length);
        foreach (var ch in s)
        {
            if (ch is '\\' or '{' or '}' or '#' or '%' or '&' or '_' or '^' or '$')
                sb.Append(' ');
            else
                sb.Append(ch);
        }
        var result = MultiSpaceRegex().Replace(sb.ToString(), " ").Trim();
        if (result.Length > 100)
            result = string.Concat(result.AsSpan(0, 100), ".");
        return result;
    }

    [GeneratedRegex(@"\\begin\{array\}\{[^}]*\}", RegexOptions.CultureInvariant)]
    private static partial Regex ArrayBeginRegex();

    [GeneratedRegex(@"\\begin\{[^}]+\}|\\end\{[^}]+\}", RegexOptions.CultureInvariant)]
    private static partial Regex EnvironmentRegex();

    [GeneratedRegex(@"\s+", RegexOptions.CultureInvariant)]
    private static partial Regex MultiSpaceRegex();

    [GeneratedRegex(@"\\-(?![a-zA-Z])", RegexOptions.CultureInvariant)]
    private static partial Regex LoneHyphenEscapeRegex();

    [GeneratedRegex(@"\\[a-zA-Z]+", RegexOptions.CultureInvariant)]
    private static partial Regex ResidualCommandRegex();
}
