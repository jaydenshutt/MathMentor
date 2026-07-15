using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Models;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;

    [ObservableProperty] private double _overallMastery;
    [ObservableProperty] private string _masteryLabel = "";
    [ObservableProperty] private string _continueTitle = "Browse curriculum";
    [ObservableProperty] private string _continueSubtitle = "Pick any lesson to start learning.";
    [ObservableProperty] private string? _continueLessonId;
    [ObservableProperty] private int _completedCount;
    [ObservableProperty] private int _totalLessons;
    [ObservableProperty] private int _lessonsStarted;

    public ObservableCollection<CategoryProgressItem> Categories { get; } = [];
    public ObservableCollection<LessonListItem> WeakAreas { get; } = [];
    public ObservableCollection<ActivityDisplayItem> RecentActivity { get; } = [];

    public DashboardViewModel(
        ICurriculumService curriculum,
        IProgressService progress,
        INavigationService nav)
    {
        _curriculum = curriculum;
        _progress = progress;
        _nav = nav;
        Title = "Dashboard";
        Load();
    }

    private void Load()
    {
        TotalLessons = _curriculum.AllLessons.Count;
        OverallMastery = _progress.GetOverallMasteryPercent();
        MasteryLabel = $"{OverallMastery:0}% mastery";
        CompletedCount = _curriculum.AllLessons.Count(l => _progress.GetLessonProgress(l.Id).IsCompleted);
        LessonsStarted = _curriculum.AllLessons.Count(l =>
        {
            var p = _progress.GetLessonProgress(l.Id);
            return p.Attempts > 0 || p.ExplanationViewed;
        });

        Categories.Clear();
        foreach (var cat in _curriculum.Categories)
        {
            var mastery = _progress.GetCategoryMasteryPercent(cat.Id, cat.Lessons.Count);
            var done = cat.Lessons.Count(l => _progress.GetLessonProgress(l.Id).IsCompleted);
            Categories.Add(new CategoryProgressItem
            {
                Id = cat.Id,
                Title = cat.Title,
                Description = cat.Description,
                Mastery = mastery,
                MasteryLabel = $"{mastery:0}%",
                ProgressLabel = $"{done}/{cat.Lessons.Count} lessons",
                LessonCount = cat.Lessons.Count
            });
        }

        var lastId = _progress.Progress.LastLessonId;
        if (!string.IsNullOrEmpty(lastId))
        {
            var lesson = _curriculum.GetLesson(lastId);
            if (lesson is not null)
            {
                ContinueLessonId = lesson.Id;
                ContinueTitle = lesson.Title;
                ContinueSubtitle = "Continue where you left off";
            }
        }
        else
        {
            var first = _curriculum.AllLessons.FirstOrDefault();
            if (first is not null)
            {
                ContinueLessonId = first.Id;
                ContinueTitle = first.Title;
                ContinueSubtitle = "Start your math journey";
            }
        }

        WeakAreas.Clear();
        foreach (var p in _progress.GetWeakLessons(6))
        {
            var lesson = _curriculum.GetLesson(p.LessonId);
            if (lesson is null) continue;
            var cat = _curriculum.GetCategory(lesson.CategoryId);
            WeakAreas.Add(new LessonListItem
            {
                LessonId = lesson.Id,
                Title = lesson.Title,
                Subtitle = $"{cat?.Title} · Best {p.BestScorePercent}%",
                Score = p.BestScorePercent,
                Stars = p.Stars
            });
        }

        foreach (var p in _progress.GetNeedsReview(6))
        {
            if (WeakAreas.Any(w => w.LessonId == p.LessonId)) continue;
            var lesson = _curriculum.GetLesson(p.LessonId);
            if (lesson is null) continue;
            if (WeakAreas.Count >= 6) break;
            var cat = _curriculum.GetCategory(lesson.CategoryId);
            WeakAreas.Add(new LessonListItem
            {
                LessonId = lesson.Id,
                Title = lesson.Title,
                Subtitle = $"{cat?.Title} · Needs review",
                Score = p.BestScorePercent,
                Stars = p.Stars
            });
        }

        RecentActivity.Clear();
        foreach (var a in _progress.Progress.RecentActivity.Take(8))
        {
            RecentActivity.Add(new ActivityDisplayItem
            {
                Title = a.LessonTitle,
                Detail = a.ScorePercent is int s ? $"{a.Action} · {s}%" : a.Action,
                When = a.Timestamp.ToLocalTime().ToString("MMM d · h:mm tt")
            });
        }
    }

    [RelayCommand]
    private void ContinueLearning()
    {
        if (!string.IsNullOrEmpty(ContinueLessonId))
            _nav.NavigateToLesson(ContinueLessonId);
        else
            _nav.NavigateToCurriculum();
    }

    [RelayCommand]
    private void OpenLesson(string? lessonId)
    {
        if (!string.IsNullOrEmpty(lessonId))
            _nav.NavigateToLesson(lessonId);
    }

    [RelayCommand]
    private void OpenCategory(string? categoryId)
    {
        _nav.NavigateTo(new CurriculumViewModel(_curriculum, _progress, _nav, null, categoryId));
    }

    [RelayCommand]
    private void BrowseAll() => _nav.NavigateToCurriculum();

    [RelayCommand]
    private void OpenReview() => _nav.NavigateToReview();
}

public sealed class CategoryProgressItem
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public double Mastery { get; set; }
    public string MasteryLabel { get; set; } = "";
    public string ProgressLabel { get; set; } = "";
    public int LessonCount { get; set; }
}

public sealed class LessonListItem
{
    public string LessonId { get; set; } = "";
    public string Title { get; set; } = "";
    public string Subtitle { get; set; } = "";
    public int Score { get; set; }
    public int Stars { get; set; }
}

public sealed class ActivityDisplayItem
{
    public string Title { get; set; } = "";
    public string Detail { get; set; } = "";
    public string When { get; set; } = "";
}
