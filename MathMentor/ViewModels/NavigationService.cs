using MathMentor.Models;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public sealed class NavigationService : INavigationService
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly ISettingsService _settings;
    private readonly Func<MainViewModel?> _getMain;

    public event EventHandler<ViewModelBase>? Navigated;
    public ViewModelBase? Current { get; private set; }

    public NavigationService(
        ICurriculumService curriculum,
        IProgressService progress,
        ISettingsService settings,
        Func<MainViewModel?> getMain)
    {
        _curriculum = curriculum;
        _progress = progress;
        _settings = settings;
        _getMain = getMain;
    }

    public void NavigateTo(ViewModelBase viewModel)
    {
        Current = viewModel;
        var main = _getMain();
        if (main is not null)
        {
            main.CurrentViewModel = viewModel;
        }
        // If main is still null, App.Start() / the caller must set CurrentViewModel
        // after MainViewModel is fully assigned (see App.OnStartup).
        Navigated?.Invoke(this, viewModel);
    }

    public void NavigateToDashboard() =>
        NavigateTo(new DashboardViewModel(_curriculum, _progress, this));

    public void NavigateToCurriculum(string? search = null) =>
        NavigateTo(new CurriculumViewModel(_curriculum, _progress, this, search));

    public void NavigateToLesson(string lessonId, bool practiceMode = false)
    {
        if (practiceMode)
        {
            NavigateToQuiz(lessonId);
            return;
        }
        NavigateTo(new LessonViewModel(lessonId, _curriculum, _progress, _settings, this));
    }

    public void NavigateToQuiz(string lessonId) =>
        NavigateTo(new QuizViewModel(lessonId, _curriculum, _progress, this));

    public void NavigateToQuizResult(QuizAttemptResult result) =>
        NavigateTo(new QuizResultViewModel(result, _curriculum, this));

    public void NavigateToReview() =>
        NavigateTo(new ReviewQueueViewModel(_curriculum, _progress, this));

    public void NavigateToSettings() =>
        NavigateTo(new SettingsViewModel(_settings, _progress, this));

    public void NavigateToWelcome() =>
        NavigateTo(new WelcomeViewModel(_progress, this));

    public void NavigateToAbout() =>
        NavigateTo(new AboutViewModel(this));
}
