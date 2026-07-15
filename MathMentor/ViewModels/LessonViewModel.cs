using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Models;
using MathMentor.Services;
using OxyPlot;

namespace MathMentor.ViewModels;

public partial class LessonViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly ISettingsService _settings;
    private readonly INavigationService _nav;
    private readonly Lesson _lesson;

    [ObservableProperty] private string _subtitle = "";
    [ObservableProperty] private string _categoryTitle = "";
    [ObservableProperty] private string _minutes = "";
    [ObservableProperty] private string _progressSummary = "";
    [ObservableProperty] private PlotModel? _plot;
    [ObservableProperty] private string? _visualCaption;
    [ObservableProperty] private bool _hasPlot;
    [ObservableProperty] private bool _hasPrevious;
    [ObservableProperty] private bool _hasNext;
    [ObservableProperty] private string _breadcrumb = "";

    public ObservableCollection<SectionDisplay> Sections { get; } = [];
    public ObservableCollection<FormulaDisplay> Formulas { get; } = [];
    public ObservableCollection<ExampleDisplay> Examples { get; } = [];
    public ObservableCollection<string> Mistakes { get; } = [];
    public ObservableCollection<string> KeyTakeaways { get; } = [];
    public bool HasKeyTakeaways => KeyTakeaways.Count > 0;

    public LessonViewModel(
        string lessonId,
        ICurriculumService curriculum,
        IProgressService progress,
        ISettingsService settings,
        INavigationService nav)
    {
        _curriculum = curriculum;
        _progress = progress;
        _settings = settings;
        _nav = nav;

        _lesson = curriculum.GetLesson(lessonId)
                  ?? throw new InvalidOperationException($"Lesson '{lessonId}' not found.");

        Title = _lesson.Title;
        Subtitle = _lesson.Subtitle;
        Minutes = _lesson.EstimatedMinutes;
        var cat = curriculum.GetCategory(_lesson.CategoryId);
        CategoryTitle = cat?.Title ?? "";
        Breadcrumb = $"{CategoryTitle}  /  {_lesson.Title}";

        var p = progress.GetLessonProgress(lessonId);
        ProgressSummary = p.Attempts == 0
            ? "Not practiced yet"
            : $"Best score {p.BestScorePercent}% · {p.Attempts} attempt(s) · {p.Stars}★";

        foreach (var s in _lesson.Sections)
            Sections.Add(new SectionDisplay(s));
        foreach (var f in _lesson.Formulas)
            Formulas.Add(new FormulaDisplay(f.Name, f.Latex, f.Description));
        foreach (var e in _lesson.Examples)
            Examples.Add(new ExampleDisplay(e));
        foreach (var m in _lesson.CommonMistakes)
            Mistakes.Add(m);
        if (_lesson.KeyTakeaways is not null)
        {
            foreach (var t in _lesson.KeyTakeaways)
                KeyTakeaways.Add(t);
        }

        VisualCaption = _lesson.VisualCaption;
        Plot = PlotFactory.Create(_lesson.Visual, settings.Settings.IsDarkTheme);
        HasPlot = Plot is not null;

        HasPrevious = curriculum.GetPrevious(lessonId) is not null;
        HasNext = curriculum.GetNext(lessonId) is not null;

        progress.MarkExplanationViewed(lessonId, _lesson.Title);
    }

    [RelayCommand]
    private void StartPractice() => _nav.NavigateToQuiz(_lesson.Id);

    [RelayCommand]
    private void GoPrevious()
    {
        var prev = _curriculum.GetPrevious(_lesson.Id);
        if (prev is not null) _nav.NavigateToLesson(prev.Id);
    }

    [RelayCommand]
    private void GoNext()
    {
        var next = _curriculum.GetNext(_lesson.Id);
        if (next is not null) _nav.NavigateToLesson(next.Id);
    }

    [RelayCommand]
    private void BackToCurriculum() => _nav.NavigateToCurriculum();
}

public sealed class SectionDisplay
{
    public string Heading { get; }
    public string Body { get; }
    public string? Latex { get; }
    public bool HasLatex { get; }
    public bool HasPlaceValueChart { get; }
    public string PlaceValueExample { get; }
    public string? SimpleRestate { get; }
    public bool HasSimpleRestate { get; }
    public string? PriorLink { get; }
    public bool HasPriorLink { get; }

    public SectionDisplay(ContentSection section)
    {
        Heading = section.Heading;
        Body = section.Body;
        // Never feed chart-like pseudo-LaTeX into FormulaBlock (causes empty bars)
        Latex = section.Diagram == SectionDiagramKind.None ? section.FormulaLatex : null;
        HasLatex = !string.IsNullOrWhiteSpace(Latex);
        HasPlaceValueChart = section.Diagram == SectionDiagramKind.PlaceValueChart;
        PlaceValueExample = string.IsNullOrWhiteSpace(section.DiagramData) ? "3472" : section.DiagramData!;
        SimpleRestate = section.SimpleRestate;
        HasSimpleRestate = !string.IsNullOrWhiteSpace(section.SimpleRestate);
        PriorLink = section.PriorLink;
        HasPriorLink = !string.IsNullOrWhiteSpace(section.PriorLink);
    }
}

public sealed class FormulaDisplay(string name, string latex, string description)
{
    public string Name { get; } = name;
    public string Latex { get; } = latex;
    public string Description { get; } = description;
}

public sealed class ExampleDisplay
{
    public string Title { get; }
    public string Problem { get; }
    public string? ProblemLatex { get; }
    public bool HasProblemLatex { get; }
    public ObservableCollection<ExampleStepDisplay> Steps { get; } = [];
    public string? SolutionLatex { get; }
    public bool HasSolutionLatex { get; }
    public string Closing { get; }
    public string? ClosingLatex { get; }
    public bool HasClosingLatex { get; }

    public ExampleDisplay(WorkedExample e)
    {
        Title = e.Title;
        Problem = e.Problem;
        ProblemLatex = e.ProblemLatex;
        HasProblemLatex = !string.IsNullOrWhiteSpace(e.ProblemLatex);
        foreach (var s in e.Steps)
            Steps.Add(new ExampleStepDisplay(s.Text, s.Latex));
        SolutionLatex = e.SolutionLatex;
        HasSolutionLatex = !string.IsNullOrWhiteSpace(e.SolutionLatex);
        Closing = e.Closing;
        ClosingLatex = e.ClosingLatex;
        HasClosingLatex = !string.IsNullOrWhiteSpace(e.ClosingLatex);
    }
}

public sealed class ExampleStepDisplay(string text, string? latex)
{
    public string Text { get; } = text;
    public string? Latex { get; } = latex;
    public bool HasLatex => !string.IsNullOrWhiteSpace(Latex);
}
