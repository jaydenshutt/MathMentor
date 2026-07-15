using MathMentor.ViewModels;

namespace MathMentor.Services;

public interface INavigationService
{
    event EventHandler<ViewModelBase>? Navigated;
    ViewModelBase? Current { get; }
    void NavigateTo(ViewModelBase viewModel);
    void NavigateToDashboard();
    void NavigateToCurriculum(string? search = null);
    void NavigateToLesson(string lessonId, bool practiceMode = false);
    void NavigateToQuiz(string lessonId);
    void NavigateToQuizResult(Models.QuizAttemptResult result);
    void NavigateToReview();
    void NavigateToSettings();
    void NavigateToWelcome();
    void NavigateToAbout();
}
