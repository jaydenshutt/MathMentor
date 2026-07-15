using MathMentor.Models;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MathMentor.Services;

public static class PlotFactory
{
    public static PlotModel? Create(VisualKind kind, bool dark)
    {
        return kind switch
        {
            VisualKind.LineGraph => LineDemo(dark),
            VisualKind.UnitCircle => UnitCircle(dark),
            VisualKind.Parabola => Parabola(dark),
            VisualKind.IntegralArea => IntegralArea(dark),
            VisualKind.FunctionTransform => FunctionTransform(dark),
            VisualKind.ExponentialGrowth => ExponentialGrowth(dark),
            VisualKind.LogGraph => LogGraph(dark),
            _ => null
        };
    }

    private static PlotModel Base(string title, bool dark)
    {
        var bg = dark ? OxyColor.FromRgb(30, 34, 42) : OxyColor.FromRgb(250, 251, 252);
        var fg = dark ? OxyColors.LightGray : OxyColors.DimGray;
        var grid = dark ? OxyColor.FromRgb(55, 60, 72) : OxyColor.FromRgb(220, 224, 230);

        var model = new PlotModel
        {
            Title = title,
            TitleColor = fg,
            Background = bg,
            PlotAreaBorderColor = grid,
            TextColor = fg
        };
        model.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Bottom,
            Title = "x",
            TextColor = fg,
            TitleColor = fg,
            AxislineColor = fg,
            TicklineColor = fg,
            MajorGridlineStyle = LineStyle.Solid,
            MajorGridlineColor = grid,
            MinorGridlineStyle = LineStyle.Dot,
            MinorGridlineColor = OxyColor.FromAColor(80, grid)
        });
        model.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Left,
            Title = "y",
            TextColor = fg,
            TitleColor = fg,
            AxislineColor = fg,
            TicklineColor = fg,
            MajorGridlineStyle = LineStyle.Solid,
            MajorGridlineColor = grid,
            MinorGridlineStyle = LineStyle.Dot,
            MinorGridlineColor = OxyColor.FromAColor(80, grid)
        });
        return model;
    }

    private static PlotModel LineDemo(bool dark)
    {
        var m = Base("Linear example: y = 2x - 1", dark);
        var s = new FunctionSeries(x => 2 * x - 1, -3, 3, 0.05, "y = 2x - 1")
        {
            Color = OxyColor.FromRgb(45, 212, 191)
        };
        m.Series.Add(s);
        return m;
    }

    private static PlotModel UnitCircle(bool dark)
    {
        var m = Base("Unit circle: (cos θ, sin θ)", dark);
        m.Axes[0].Minimum = -1.5;
        m.Axes[0].Maximum = 1.5;
        m.Axes[1].Minimum = -1.5;
        m.Axes[1].Maximum = 1.5;
        m.Series.Add(new FunctionSeries(
            t => Math.Cos(t), t => Math.Sin(t), 0, 2 * Math.PI, 0.02, "Unit circle")
        {
            Color = OxyColor.FromRgb(129, 140, 248)
        });
        m.Annotations.Add(new PointAnnotation
        {
            X = Math.Cos(Math.PI / 3),
            Y = Math.Sin(Math.PI / 3),
            Text = "60°",
            Fill = OxyColor.FromRgb(45, 212, 191)
        });
        return m;
    }

    private static PlotModel Parabola(bool dark)
    {
        var m = Base("Parabola: y = x² − 4x + 1", dark);
        m.Series.Add(new FunctionSeries(x => x * x - 4 * x + 1, -1, 5, 0.05, "y = x² − 4x + 1")
        {
            Color = OxyColor.FromRgb(251, 191, 36)
        });
        m.Annotations.Add(new PointAnnotation
        {
            X = 2,
            Y = -3,
            Text = "vertex",
            Fill = OxyColor.FromRgb(45, 212, 191)
        });
        return m;
    }

    private static PlotModel IntegralArea(bool dark)
    {
        var m = Base("Area under y = x² on [0, 2]", dark);
        var area = new AreaSeries
        {
            Title = "Area",
            Color = OxyColor.FromAColor(160, OxyColor.FromRgb(45, 212, 191)),
            Fill = OxyColor.FromAColor(80, OxyColor.FromRgb(45, 212, 191))
        };
        for (double x = 0; x <= 2.0001; x += 0.05)
        {
            area.Points.Add(new DataPoint(x, x * x));
            area.Points2.Add(new DataPoint(x, 0));
        }
        m.Series.Add(area);
        m.Series.Add(new FunctionSeries(x => x * x, -0.5, 2.5, 0.05, "y = x²")
        {
            Color = OxyColor.FromRgb(129, 140, 248)
        });
        return m;
    }

    private static PlotModel FunctionTransform(bool dark)
    {
        var m = Base("Transformations of y = x²", dark);
        m.Series.Add(new FunctionSeries(x => x * x, -3, 3, 0.05, "parent")
        {
            Color = OxyColor.FromRgb(148, 163, 184)
        });
        m.Series.Add(new FunctionSeries(x => (x - 2) * (x - 2) + 1, -1, 5, 0.05, "right 2, up 1")
        {
            Color = OxyColor.FromRgb(45, 212, 191)
        });
        return m;
    }

    private static PlotModel ExponentialGrowth(bool dark)
    {
        var m = Base("Growth vs decay: y = a·b^x", dark);
        m.Series.Add(new FunctionSeries(x => Math.Pow(2, x), -2, 3, 0.05, "y = 2^x (growth)")
        {
            Color = OxyColor.FromRgb(45, 212, 191)
        });
        m.Series.Add(new FunctionSeries(x => Math.Pow(0.5, x), -2, 3, 0.05, "y = (1/2)^x (decay)")
        {
            Color = OxyColor.FromRgb(251, 191, 36)
        });
        m.Annotations.Add(new LineAnnotation
        {
            Type = LineAnnotationType.Horizontal,
            Y = 0,
            Color = OxyColor.FromAColor(120, dark ? OxyColors.LightGray : OxyColors.Gray),
            LineStyle = LineStyle.Dash
        });
        return m;
    }

    private static PlotModel LogGraph(bool dark)
    {
        var m = Base("y = log₁₀(x) and its inverse feel", dark);
        m.Axes[0].Minimum = -0.5;
        m.Axes[0].Maximum = 8;
        m.Axes[1].Minimum = -2;
        m.Axes[1].Maximum = 2;
        m.Series.Add(new FunctionSeries(x => Math.Log10(x), 0.05, 8, 0.02, "y = log₁₀ x")
        {
            Color = OxyColor.FromRgb(129, 140, 248)
        });
        m.Series.Add(new FunctionSeries(x => Math.Pow(10, x), -1.5, 1, 0.02, "y = 10^x")
        {
            Color = OxyColor.FromRgb(45, 212, 191)
        });
        return m;
    }
}
