using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MathMentor.Controls;

/// <summary>
/// Educational place-value chart for whole numbers (ones through hundred thousands).
/// ExampleNumber property drives which digits appear in each column.
/// </summary>
public partial class PlaceValueChart : UserControl
{
    public static readonly DependencyProperty ExampleNumberProperty =
        DependencyProperty.Register(
            nameof(ExampleNumber),
            typeof(string),
            typeof(PlaceValueChart),
            new PropertyMetadata("3472", OnExampleChanged));

    private static readonly string[] PlaceNames =
    [
        "Hundred Thousands",
        "Ten Thousands",
        "Thousands",
        "Hundreds",
        "Tens",
        "Ones"
    ];

    private static readonly string[] PowerLabels =
    [
        "× 100,000",
        "× 10,000",
        "× 1,000",
        "× 100",
        "× 10",
        "× 1"
    ];

    private static readonly int[] PlaceValues = [100_000, 10_000, 1_000, 100, 10, 1];

    public string? ExampleNumber
    {
        get => (string?)GetValue(ExampleNumberProperty);
        set => SetValue(ExampleNumberProperty, value);
    }

    public PlaceValueChart()
    {
        InitializeComponent();
        Loaded += (_, _) => Rebuild();
    }

    private static void OnExampleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is PlaceValueChart chart)
            chart.Rebuild();
    }

    private void Rebuild()
    {
        var raw = (ExampleNumber ?? "3472").Trim().Replace(",", "", StringComparison.Ordinal);
        if (!long.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var n) || n < 0)
            n = 3472;

        // Cap display to 6 places for readability
        if (n > 999_999) n %= 1_000_000;

        var digits = n.ToString("D6", CultureInfo.InvariantCulture);
        var columns = new ObservableCollection<PlaceColumn>();
        var parts = new List<string>();

        // Start at first non-zero digit, but always show at least Ones→Thousands (4 columns)
        var start = 0;
        while (start < 2 && digits[start] == '0') // keep Ten Thousands+ only when needed
            start++;
        // Ensure we never start after the thousands column index (2)
        start = Math.Min(start, 2);

        for (var i = start; i < 6; i++)
        {
            var d = digits[i] - '0';
            var value = d * PlaceValues[i];
            columns.Add(new PlaceColumn
            {
                PlaceName = PlaceNames[i],
                PowerLabel = PowerLabels[i],
                Digit = d.ToString(CultureInfo.InvariantCulture),
                ValueLabel = d == 0
                    ? "0"
                    : value.ToString("N0", CultureInfo.InvariantCulture)
            });
            if (d != 0)
                parts.Add($"{d} × {PlaceValues[i]:N0}");
        }

        Columns.ItemsSource = columns;
        ExampleCaption.Text = $"Example: {n.ToString("N0", CultureInfo.InvariantCulture)}";
        ExpandedForm.Text = parts.Count == 0
            ? "0"
            : $"{n.ToString("N0", CultureInfo.InvariantCulture)}  =  " + string.Join("  +  ", parts);
    }

    private sealed class PlaceColumn
    {
        public string PlaceName { get; init; } = "";
        public string PowerLabel { get; init; } = "";
        public string Digit { get; init; } = "0";
        public string ValueLabel { get; init; } = "";
    }
}
