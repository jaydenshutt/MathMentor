using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class WelcomeViewModel : ViewModelBase
{
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;

    public WelcomeViewModel(IProgressService progress, INavigationService nav)
    {
        _progress = progress;
        _nav = nav;
        Title = "Welcome";
    }

    [RelayCommand]
    private void StartLearning()
    {
        _progress.Progress.HasCompletedWelcome = true;
        _progress.Save();
        _nav.NavigateToDashboard();
    }

    [RelayCommand]
    private void BrowseCurriculum()
    {
        _progress.Progress.HasCompletedWelcome = true;
        _progress.Save();
        _nav.NavigateToCurriculum();
    }
}
