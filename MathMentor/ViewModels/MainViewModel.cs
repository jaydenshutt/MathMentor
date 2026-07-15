using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly INavigationService _nav;
    private readonly IProgressService _progress;
    private readonly ISettingsService _settings;

    [ObservableProperty]
    private ViewModelBase? _currentViewModel;

    [ObservableProperty]
    private string _selectedNav = "Dashboard";

    public MainViewModel(
        INavigationService nav,
        IProgressService progress,
        ISettingsService settings)
    {
        _nav = nav;
        _progress = progress;
        _settings = settings;
        Title = "MathMentor";
        // Do not navigate here. App assigns this instance first, then calls Start().
        // Navigating during construction left CurrentViewModel unset (blank main area).
    }

    /// <summary>
    /// Call after MainViewModel is fully constructed and registered with NavigationService.
    /// Always opens the Dashboard so the main area is never blank.
    /// </summary>
    public void Start()
    {
        SelectedNav = "Dashboard";
        _nav.NavigateToDashboard();

        // Mark first-run welcome as completed so progress is initialized cleanly.
        // Users can still open the welcome tour from Settings anytime.
        if (!_progress.Progress.HasCompletedWelcome)
        {
            _progress.Progress.HasCompletedWelcome = true;
            _progress.Save();
        }
    }

    [RelayCommand]
    private void GoDashboard()
    {
        SelectedNav = "Dashboard";
        _nav.NavigateToDashboard();
    }

    [RelayCommand]
    private void GoCurriculum()
    {
        SelectedNav = "Curriculum";
        _nav.NavigateToCurriculum();
    }

    [RelayCommand]
    private void GoReview()
    {
        SelectedNav = "Review";
        _nav.NavigateToReview();
    }

    [RelayCommand]
    private void GoSettings()
    {
        SelectedNav = "Settings";
        _nav.NavigateToSettings();
    }

    [RelayCommand]
    private void GoAbout()
    {
        SelectedNav = "About";
        _nav.NavigateToAbout();
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        _settings.Settings.IsDarkTheme = !_settings.Settings.IsDarkTheme;
        _settings.Save();
        _settings.ApplyTheme();
    }
}
