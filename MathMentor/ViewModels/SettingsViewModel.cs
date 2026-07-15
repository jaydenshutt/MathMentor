using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace MathMentor.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    private readonly ISettingsService _settings;
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;

    [ObservableProperty] private bool _isDarkTheme;
    [ObservableProperty] private double _fontScale;
    [ObservableProperty] private string _fontScaleLabel = "";
    [ObservableProperty] private string _statusMessage = "";

    public SettingsViewModel(
        ISettingsService settings,
        IProgressService progress,
        INavigationService nav)
    {
        _settings = settings;
        _progress = progress;
        _nav = nav;
        Title = "Settings";
        IsDarkTheme = settings.Settings.IsDarkTheme;
        FontScale = settings.Settings.FontScale;
        UpdateFontLabel();
    }

    partial void OnIsDarkThemeChanged(bool value)
    {
        _settings.Settings.IsDarkTheme = value;
        _settings.Save();
        _settings.ApplyTheme();
        StatusMessage = value ? "Dark theme applied." : "Light theme applied.";
    }

    partial void OnFontScaleChanged(double value)
    {
        var clamped = Math.Clamp(value, 0.85, 1.4);
        if (Math.Abs(clamped - value) > 0.001)
        {
            FontScale = clamped;
            return;
        }
        _settings.Settings.FontScale = clamped;
        _settings.Save();
        _settings.ApplyFontScale();
        UpdateFontLabel();
    }

    private void UpdateFontLabel() => FontScaleLabel = $"Font scale: {FontScale:0.00}×";

    [RelayCommand]
    private void ExportProgress()
    {
        var dlg = new SaveFileDialog
        {
            Filter = "JSON (*.json)|*.json",
            FileName = "mathmentor-progress.json"
        };
        if (dlg.ShowDialog() == true)
        {
            File.WriteAllText(dlg.FileName, _progress.ExportJson());
            StatusMessage = "Progress exported.";
        }
    }

    [RelayCommand]
    private void ImportProgress()
    {
        var dlg = new OpenFileDialog { Filter = "JSON (*.json)|*.json" };
        if (dlg.ShowDialog() == true)
        {
            try
            {
                _progress.ImportJson(File.ReadAllText(dlg.FileName));
                StatusMessage = "Progress imported.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Import failed: {ex.Message}";
            }
        }
    }

    [RelayCommand]
    private void ResetProgress()
    {
        var result = MessageBox.Show(
            "Reset all lesson progress and activity? This cannot be undone.",
            "MathMentor",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);
        if (result == MessageBoxResult.Yes)
        {
            _progress.ResetAll();
            StatusMessage = "All progress has been reset.";
        }
    }

    [RelayCommand]
    private void ShowWelcome() => _nav.NavigateToWelcome();

    [RelayCommand]
    private void OpenAbout() => _nav.NavigateToAbout();
}
