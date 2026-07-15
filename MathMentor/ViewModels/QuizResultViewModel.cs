using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Models;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class QuizResultViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly INavigationService _nav;
    private readonly QuizAttemptResult _result;

    [ObservableProperty] private string _headline = "";
    [ObservableProperty] private string _scoreLabel = "";
    [ObservableProperty] private string _detail = "";
    [ObservableProperty] private string _recommendation = "";
    [ObservableProperty] private bool _isPassing;
    [ObservableProperty] private bool _isNewBest;

    public ObservableCollection<ResultRow> Rows { get; } = [];

    public QuizResultViewModel(
        QuizAttemptResult result,
        ICurriculumService curriculum,
        INavigationService nav)
    {
        _result = result;
        _curriculum = curriculum;
        _nav = nav;
        Title = "Practice results";

        ScoreLabel = $"{result.ScorePercent}%";
        Detail = $"{result.CorrectCount} of {result.TotalCount} correct";
        IsPassing = result.ScorePercent >= 70;
        IsNewBest = result.IsNewBest;
        Headline = result.ScorePercent switch
        {
            >= 95 => "Outstanding mastery!",
            >= 85 => "Great work, strong grasp.",
            >= 70 => "Solid pass, a little review will lock it in.",
            >= 50 => "Getting there, revisit the explanation, then retry.",
            _ => "Tough round, review the lesson carefully and try again."
        };

        Recommendation = result.ScorePercent >= 85
            ? "You're ready for the next lesson, or challenge yourself with a retake for a perfect score."
            : "Open the lesson explanation, focus on missed items, then retake when ready. You can retry anytime.";

        var i = 1;
        foreach (var r in result.Results)
        {
            Rows.Add(new ResultRow
            {
                Number = i++,
                Prompt = r.Question.Prompt,
                UserAnswer = r.UserAnswer,
                CorrectAnswer = r.Question.CorrectAnswer,
                IsCorrect = r.IsCorrect,
                Explanation = r.Question.Explanation
            });
        }
    }

    [RelayCommand]
    private void Retake() => _nav.NavigateToQuiz(_result.LessonId);

    [RelayCommand]
    private void ReviewLesson() => _nav.NavigateToLesson(_result.LessonId);

    [RelayCommand]
    private void NextLesson()
    {
        var next = _curriculum.GetNext(_result.LessonId);
        if (next is not null)
            _nav.NavigateToLesson(next.Id);
        else
            _nav.NavigateToDashboard();
    }

    [RelayCommand]
    private void Dashboard() => _nav.NavigateToDashboard();
}

public sealed class ResultRow
{
    public int Number { get; set; }
    public string Prompt { get; set; } = "";
    public string UserAnswer { get; set; } = "";
    public string CorrectAnswer { get; set; } = "";
    public bool IsCorrect { get; set; }
    public string Explanation { get; set; } = "";
    public string Status => IsCorrect ? "Correct" : "Incorrect";
}
