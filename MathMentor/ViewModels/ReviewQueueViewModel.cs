using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class ReviewQueueViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;

    public ObservableCollection<LessonListItem> Items { get; } = [];

    public ReviewQueueViewModel(
        ICurriculumService curriculum,
        IProgressService progress,
        INavigationService nav)
    {
        _curriculum = curriculum;
        _progress = progress;
        _nav = nav;
        Title = "Needs Review";
        Load();
    }

    private void Load()
    {
        Items.Clear();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        void Add(LessonListItem item)
        {
            if (seen.Add(item.LessonId))
                Items.Add(item);
        }

        foreach (var p in _progress.GetNeedsReview(20))
        {
            var lesson = _curriculum.GetLesson(p.LessonId);
            if (lesson is null) continue;
            var cat = _curriculum.GetCategory(lesson.CategoryId);
            var days = p.LastSuccessfulReview.HasValue
                ? (int)(DateTimeOffset.Now - p.LastSuccessfulReview.Value).TotalDays
                : p.LastReviewed.HasValue
                    ? (int)(DateTimeOffset.Now - p.LastReviewed.Value).TotalDays
                    : -1;
            var when = days < 0 ? "Not completed yet" : days == 0 ? "Reviewed today" : $"{days} day(s) since strong review";
            Add(new LessonListItem
            {
                LessonId = lesson.Id,
                Title = lesson.Title,
                Subtitle = $"{cat?.Title} · Best {p.BestScorePercent}% · {when}",
                Score = p.BestScorePercent,
                Stars = p.Stars
            });
        }

        foreach (var p in _progress.GetWeakLessons(10))
        {
            var lesson = _curriculum.GetLesson(p.LessonId);
            if (lesson is null) continue;
            var cat = _curriculum.GetCategory(lesson.CategoryId);
            Add(new LessonListItem
            {
                LessonId = lesson.Id,
                Title = lesson.Title,
                Subtitle = $"{cat?.Title} · Best {p.BestScorePercent}% · Improve this score",
                Score = p.BestScorePercent,
                Stars = p.Stars
            });
        }
    }

    [RelayCommand]
    private void OpenLesson(string? id)
    {
        if (!string.IsNullOrEmpty(id))
            _nav.NavigateToLesson(id);
    }

    [RelayCommand]
    private void Practice(string? id)
    {
        if (!string.IsNullOrEmpty(id))
            _nav.NavigateToQuiz(id);
    }
}
