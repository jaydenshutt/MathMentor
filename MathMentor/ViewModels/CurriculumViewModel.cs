using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class CurriculumViewModel : ViewModelBase
{
    private readonly ICurriculumService _curriculum;
    private readonly IProgressService _progress;
    private readonly INavigationService _nav;

    [ObservableProperty]
    private string _searchText = "";

    [ObservableProperty]
    private string? _selectedCategoryId;

    public ObservableCollection<CategoryFilterItem> CategoryFilters { get; } = [];
    public ObservableCollection<CurriculumGroup> Groups { get; } = [];

    public CurriculumViewModel(
        ICurriculumService curriculum,
        IProgressService progress,
        INavigationService nav,
        string? initialSearch = null,
        string? categoryId = null)
    {
        _curriculum = curriculum;
        _progress = progress;
        _nav = nav;
        Title = "Curriculum";
        SearchText = initialSearch ?? "";
        SelectedCategoryId = categoryId;

        CategoryFilters.Add(new CategoryFilterItem { Id = null, Title = "All topics" });
        foreach (var c in _curriculum.Categories)
            CategoryFilters.Add(new CategoryFilterItem { Id = c.Id, Title = c.Title });

        Refresh();
    }

    partial void OnSearchTextChanged(string value) => Refresh();
    partial void OnSelectedCategoryIdChanged(string? value) => Refresh();

    private void Refresh()
    {
        Groups.Clear();
        var summaries = _curriculum.Search(SearchText, SelectedCategoryId).ToList();
        foreach (var cat in _curriculum.Categories)
        {
            var lessons = summaries.Where(s => s.CategoryId == cat.Id).ToList();
            if (lessons.Count == 0) continue;

            var group = new CurriculumGroup
            {
                CategoryId = cat.Id,
                Title = cat.Title,
                Description = cat.Description
            };
            foreach (var s in lessons)
            {
                var p = _progress.GetLessonProgress(s.Id);
                group.Lessons.Add(new CurriculumLessonItem
                {
                    LessonId = s.Id,
                    Title = s.Title,
                    Subtitle = s.Subtitle,
                    Meta = $"{s.QuestionCount} questions · Best {p.BestScorePercent}%",
                    Stars = p.Stars,
                    IsCompleted = p.IsCompleted,
                    Score = p.BestScorePercent
                });
            }
            Groups.Add(group);
        }
    }

    [RelayCommand]
    private void OpenLesson(string? lessonId)
    {
        if (!string.IsNullOrEmpty(lessonId))
            _nav.NavigateToLesson(lessonId);
    }

    [RelayCommand]
    private void SelectCategory(string? id)
    {
        SelectedCategoryId = string.IsNullOrEmpty(id) ? null : id;
    }
}

public sealed class CategoryFilterItem
{
    public string? Id { get; set; }
    public string Title { get; set; } = "";
}

public sealed class CurriculumGroup
{
    public string CategoryId { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public ObservableCollection<CurriculumLessonItem> Lessons { get; } = [];
}

public sealed class CurriculumLessonItem
{
    public string LessonId { get; set; } = "";
    public string Title { get; set; } = "";
    public string Subtitle { get; set; } = "";
    public string Meta { get; set; } = "";
    public int Stars { get; set; }
    public bool IsCompleted { get; set; }
    public int Score { get; set; }
}
