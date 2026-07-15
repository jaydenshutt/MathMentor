using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MathMentor.Services;
using WpfMath.Parsers;
using WpfMath.Rendering;
using XamlMath;

namespace MathMentor.Controls;

/// <summary>
/// Renders LaTeX via WpfMath to a theme-colored bitmap.
/// Important: WpfMath Scale is absolute TeX point size (~20), NOT a 1.x font multiplier.
/// </summary>
public partial class FormulaBlock : UserControl
{
    /// <summary>WpfMath TeX scale, values like 1.5 produce near-invisible glyphs.</summary>
    private const double TeXScale = 22.0;

    public static readonly DependencyProperty FormulaProperty =
        DependencyProperty.Register(
            nameof(Formula),
            typeof(string),
            typeof(FormulaBlock),
            new PropertyMetadata(null, OnFormulaChanged));

    public static readonly DependencyProperty ShowChromeProperty =
        DependencyProperty.Register(
            nameof(ShowChrome),
            typeof(bool),
            typeof(FormulaBlock),
            new PropertyMetadata(true, OnShowChromeChanged));

    public string? Formula
    {
        get => (string?)GetValue(FormulaProperty);
        set => SetValue(FormulaProperty, value);
    }

    public bool ShowChrome
    {
        get => (bool)GetValue(ShowChromeProperty);
        set => SetValue(ShowChromeProperty, value);
    }

    public FormulaBlock()
    {
        InitializeComponent();
        Loaded += (_, _) => ApplyFormula(Formula);
        // Re-render when theme brushes change (light/dark toggle)
        IsVisibleChanged += (_, _) =>
        {
            if (IsVisible && !string.IsNullOrWhiteSpace(Formula))
                ApplyFormula(Formula);
        };
    }

    private static void OnFormulaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FormulaBlock block)
            block.ApplyFormula(e.NewValue as string);
    }

    private static void OnShowChromeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FormulaBlock block)
            block.ApplyChromeStyle();
    }

    private void ApplyChromeStyle()
    {
        if (ShowChrome)
        {
            Chrome.Background = TryFindResource("FormulaBgBrush") as Brush
                                ?? new SolidColorBrush(Color.FromRgb(0x15, 0x1A, 0x24));
            Chrome.BorderThickness = new Thickness(1);
            Chrome.Padding = new Thickness(16, 14, 16, 14);
            Chrome.Margin = new Thickness(0, 8, 0, 6);
        }
        else
        {
            Chrome.Background = Brushes.Transparent;
            Chrome.BorderThickness = new Thickness(0);
            Chrome.Padding = new Thickness(0, 4, 0, 4);
            Chrome.Margin = new Thickness(0, 4, 0, 4);
        }
    }

    private void ApplyFormula(string? latex)
    {
        ApplyChromeStyle();

        if (string.IsNullOrWhiteSpace(latex))
        {
            FormulaImage.Source = null;
            FormulaImage.Visibility = Visibility.Collapsed;
            Fallback.Visibility = Visibility.Collapsed;
            Visibility = Visibility.Collapsed;
            return;
        }

        Visibility = Visibility.Visible;

        var prepared = LatexHelper.Prepare(latex);
        if (string.IsNullOrWhiteSpace(prepared))
        {
            ShowFallback(latex);
            return;
        }

        try
        {
            var bmp = RenderLatex(prepared);
            if (bmp is null || bmp.PixelWidth < 2 || bmp.PixelHeight < 2)
            {
                ShowFallback(latex);
                return;
            }

            FormulaImage.Source = bmp;
            FormulaImage.Visibility = Visibility.Visible;
            Fallback.Visibility = Visibility.Collapsed;
        }
        catch
        {
            ShowFallback(latex);
        }
    }

    private BitmapSource? RenderLatex(string preparedLatex)
    {
        // Bake theme color into the formula so glyphs are never black-on-black
        var colorName = ResolveThemeColorName();
        var colored = $@"\color{{{colorName}}}{{{preparedLatex}}}";

        var parser = WpfTeXFormulaParser.Instance;
        TexFormula formula;
        try
        {
            formula = parser.Parse(colored);
        }
        catch
        {
            // Color wrap failed, try without color
            formula = parser.Parse(preparedLatex);
        }

        // Arial is universally available; TeX fonts still come from WpfMath resources
        var env = WpfTeXEnvironment.Create(TexStyle.Display, TeXScale, "Arial");
        var bmp = formula.RenderToBitmap(env);

        // Freeze for cross-thread/UI safety
        if (bmp.CanFreeze)
            bmp.Freeze();
        return bmp;
    }

    private string ResolveThemeColorName()
    {
        // Prefer reading the app's text brush; fall back by luminance of background
        if (TryFindResource("TextPrimaryBrush") is SolidColorBrush text)
        {
            var c = text.Color;
            // WpfMath named colors are limited; map light/dark to white/black
            var luminance = (0.299 * c.R + 0.587 * c.G + 0.114 * c.B) / 255.0;
            return luminance > 0.5 ? "white" : "black";
        }

        if (TryFindResource("BgBrush") is SolidColorBrush bg)
        {
            var c = bg.Color;
            var luminance = (0.299 * c.R + 0.587 * c.G + 0.114 * c.B) / 255.0;
            return luminance < 0.5 ? "white" : "black";
        }

        return "white";
    }

    private void ShowFallback(string latex)
    {
        FormulaImage.Source = null;
        FormulaImage.Visibility = Visibility.Collapsed;
        Fallback.Text = LatexHelper.ToPlainText(latex);
        Fallback.Visibility = Visibility.Visible;
        Visibility = Visibility.Visible;

        if (TryFindResource("TextPrimaryBrush") is Brush brush)
            Fallback.Foreground = brush;
    }
}
