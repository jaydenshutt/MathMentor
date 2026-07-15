using System.Globalization;
using MathMentor.Models;

namespace MathMentor.Services;

public static class AnswerChecker
{
    public static bool IsCorrect(PracticeQuestion question, string? userAnswer)
    {
        if (string.IsNullOrWhiteSpace(userAnswer))
            return false;

        var user = Normalize(userAnswer);
        var correct = Normalize(question.CorrectAnswer);

        if (question.Type == QuestionType.MultipleChoice)
            return string.Equals(user, correct, StringComparison.OrdinalIgnoreCase)
                   || string.Equals(userAnswer.Trim(), question.CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);

        // Exact string match for fractions like 2/3 after normalize
        if (string.Equals(user, correct, StringComparison.OrdinalIgnoreCase))
            return true;

        // Mixed numbers like "3 1/2"
        if (TryParseFlexible(user, out var u) && TryParseFlexible(correct, out var c))
            return Math.Abs(u - c) <= Math.Max(question.Tolerance, 1e-9);

        return false;
    }

    private static string Normalize(string s)
    {
        s = s.Trim().Replace(" ", "", StringComparison.Ordinal);
        s = s.Replace(",", "", StringComparison.Ordinal);
        s = s.Replace("%", "", StringComparison.Ordinal);
        s = s.Replace("°", "", StringComparison.Ordinal);
        s = s.ToLowerInvariant();
        return s;
    }

    public static bool TryParseFlexible(string input, out double value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input)) return false;

        var s = Normalize(input);

        // Mixed number: 3 1/2 already lost space → try 3+1/2 patterns or "31/2" bad.
        // Support "3_1/2" or re-parse original with space
        var original = input.Trim().Replace(",", "", StringComparison.Ordinal);

        // mixed: "3 1/2"
        var parts = original.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2 &&
            double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var whole) &&
            TryParseFraction(parts[1], out var frac))
        {
            value = whole + Math.CopySign(frac, whole == 0 ? 1 : whole);
            if (whole < 0) value = whole - frac;
            else value = whole + frac;
            return true;
        }

        if (TryParseFraction(s, out value))
            return true;

        return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    private static bool TryParseFraction(string s, out double value)
    {
        value = 0;
        var idx = s.IndexOf('/');
        if (idx <= 0) return false;
        var numPart = s[..idx];
        var denPart = s[(idx + 1)..];
        if (!double.TryParse(numPart, NumberStyles.Float, CultureInfo.InvariantCulture, out var num))
            return false;
        if (!double.TryParse(denPart, NumberStyles.Float, CultureInfo.InvariantCulture, out var den) || Math.Abs(den) < 1e-12)
            return false;
        value = num / den;
        return true;
    }
}
