using System.IO;
using System.Text.Json;
using System.Windows;
using MathMentor.Models;

namespace MathMentor.Services;

public sealed class SettingsService : ISettingsService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly string _filePath;

    public AppSettings Settings { get; private set; }
    public event EventHandler? SettingsChanged;

    public SettingsService()
    {
        var dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MathMentor");
        Directory.CreateDirectory(dir);
        _filePath = Path.Combine(dir, "settings.json");
        Settings = Load();
    }

    public void Save()
    {
        try
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(Settings, JsonOptions));
        }
        catch { /* ignore */ }
        SettingsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ApplyTheme()
    {
        var app = Application.Current;
        if (app is null) return;

        var dicts = app.Resources.MergedDictionaries;
        // Remove previous theme dictionaries we control
        for (var i = dicts.Count - 1; i >= 0; i--)
        {
            var src = dicts[i].Source?.OriginalString ?? "";
            if (src.Contains("ThemeDark", StringComparison.OrdinalIgnoreCase) ||
                src.Contains("ThemeLight", StringComparison.OrdinalIgnoreCase))
                dicts.RemoveAt(i);
        }

        var theme = Settings.IsDarkTheme ? "Themes/ThemeDark.xaml" : "Themes/ThemeLight.xaml";
        dicts.Insert(0, new ResourceDictionary
        {
            Source = new Uri(theme, UriKind.Relative)
        });
    }

    public void ApplyFontScale()
    {
        var app = Application.Current;
        if (app is null) return;
        app.Resources["AppFontScale"] = Settings.FontScale;
        app.Resources["AppFontSize"] = 14.0 * Settings.FontScale;
        app.Resources["AppFontSizeTitle"] = 22.0 * Settings.FontScale;
        app.Resources["AppFontSizeHeader"] = 18.0 * Settings.FontScale;
        app.Resources["AppFontSizeSmall"] = 12.0 * Settings.FontScale;
    }

    private AppSettings Load()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<AppSettings>(json, JsonOptions) ?? new AppSettings();
            }
        }
        catch { /* ignore */ }
        return new AppSettings();
    }
}
