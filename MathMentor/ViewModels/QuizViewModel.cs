using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Models;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class QuizViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;
    private readonly Lesson _lesson;
    private readonly List<QuestionResult> _results = [];

    [ObservableProperty] private int _index;
    [ObservableProperty] private int _total;
    [ObservableProperty] private string _progressText = "";
    [ObservableProperty] private string _prompt = "";
    [ObservableProperty] private string? _promptLatex;
    [ObservableProperty] private bool _hasPromptLatex;
    [ObservableProperty] private bool _isMultipleChoice;
    [ObservableProperty] private bool _isNumeric;
    [ObservableProperty] private string _numericAnswer = "";
    [ObservableProperty] private string? _selectedChoice;
    [ObservableProperty] private bool _isAnswered;
    [ObservableProperty] private bool _isCorrect;
    [ObservableProperty] private string _feedbackTitle = "";
    [ObservableProperty] private string _feedbackBody = "";
    [ObservableProperty] private string? _explanationLatex;
    [ObservableProperty] private bool _hasExplanationLatex;
    [ObservableProperty] private string _hintText = "";
    [ObservableProperty] private bool _showHint;
    [ObservableProperty] private int _hintLevel;
    [ObservableProperty] private string _lessonTitle = "";

    public ObservableCollection<string> Choices { get; } = [];

    private PracticeQuestion Current => _lesson.Questions[Index];

    public QuizViewModel(
        string lessonId,
        ICurriculumService curriculum,
        IProgressService progress,
        INavigationService nav)
    {
        _curriculum = curriculum;
        _progress = progress;
        _nav = nav;
        _lesson = curriculum.GetLesson(lessonId)
                  ?? throw new InvalidOperationException($"Lesson '{lessonId}' not found.");

        Title = "Practice";
        LessonTitle = _lesson.Title;
        Total = _lesson.Questions.Count;
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        IsAnswered = false;
        IsCorrect = false;
        FeedbackTitle = "";
        FeedbackBody = "";
        ExplanationLatex = null;
        HasExplanationLatex = false;
        NumericAnswer = "";
        SelectedChoice = null;
        HintLevel = 0;
        ShowHint = false;
        HintText = "";
        ProgressText = $"Question {Index + 1} of {Total}";

        var q = Current;
        Prompt = q.Prompt;
        PromptLatex = q.PromptLatex;
        HasPromptLatex = !string.IsNullOrWhiteSpace(q.PromptLatex);
        IsMultipleChoice = q.Type == QuestionType.MultipleChoice;
        IsNumeric = q.Type == QuestionType.Numeric;

        Choices.Clear();
        if (q.Choices is not null)
        {
            foreach (var c in q.Choices)
                Choices.Add(c);
        }
    }

    [RelayCommand]
    private void SelectChoice(string? choice)
    {
        if (IsAnswered || choice is null) return;
        SelectedChoice = choice;
    }

    [RelayCommand]
    private void Submit()
    {
        if (IsAnswered) return;

        var answer = IsMultipleChoice ? SelectedChoice : NumericAnswer;
        if (string.IsNullOrWhiteSpace(answer))
        {
            FeedbackTitle = "Enter an answer";
            FeedbackBody = "Choose an option or type a value, then submit.";
            return;
        }

        var correct = AnswerChecker.IsCorrect(Current, answer);
        IsCorrect = correct;
        IsAnswered = true;
        FeedbackTitle = correct ? "Correct, nice work!" : "Not quite";
        FeedbackBody = Current.Explanation;
        ExplanationLatex = Current.ExplanationLatex;
        HasExplanationLatex = !string.IsNullOrWhiteSpace(Current.ExplanationLatex);

        _results.Add(new QuestionResult
        {
            Question = Current,
            UserAnswer = answer!,
            IsCorrect = correct
        });
    }

    [RelayCommand]
    private void ShowNextHint()
    {
        if (IsAnswered) return;
        var hints = Current.Hints;
        if (hints.Count == 0) return;
        HintLevel = Math.Min(HintLevel + 1, hints.Count);
        HintText = string.Join("\n\n", hints.Take(HintLevel).Select((h, i) => $"Hint {i + 1}: {h}"));
        ShowHint = true;
    }

    [RelayCommand]
    private void Next()
    {
        if (!IsAnswered) return;

        if (Index >= Total - 1)
        {
            var result = _progress.RecordQuizAttempt(_lesson.Id, _lesson.Title, _results);
            _nav.NavigateToQuizResult(result);
            return;
        }

        Index++;
        LoadQuestion();
    }

    [RelayCommand]
    private void ExitToLesson() => _nav.NavigateToLesson(_lesson.Id);
}
