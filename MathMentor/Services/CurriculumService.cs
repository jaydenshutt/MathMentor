using MathMentor.Curriculum;
using MathMentor.Models;

namespace MathMentor.Services;

public sealed class CurriculumService : ICurriculumService
{
    public IReadOnlyList<Category> Categories { get; } = CurriculumCatalog.GetCategories();

    public IReadOnlyList<Lesson> AllLessons { get; } =
        CurriculumCatalog.GetAllLessons()
            .OrderBy(l => CurriculumCatalog.FindCategory(l.CategoryId)!.Order)
            .ThenBy(l => l.Order)
            .ToList();

    public Lesson? GetLesson(string lessonId) => CurriculumCatalog.FindLesson(lessonId);

    public Category? GetCategory(string categoryId) => CurriculumCatalog.FindCategory(categoryId);

    public Lesson? GetNext(string lessonId) => CurriculumCatalog.GetNextLesson(lessonId);

    public Lesson? GetPrevious(string lessonId) => CurriculumCatalog.GetPreviousLesson(lessonId);

    public IEnumerable<LessonSummary> Search(string? query, string? categoryId = null)
    {
        var q = query?.Trim() ?? "";
        foreach (var cat in Categories)
        {
            if (!string.IsNullOrEmpty(categoryId) &&
                !cat.Id.Equals(categoryId, StringComparison.OrdinalIgnoreCase))
                continue;

            foreach (var lesson in cat.Lessons)
            {
                if (q.Length == 0 ||
                    lesson.Title.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    lesson.Subtitle.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    cat.Title.Contains(q, StringComparison.OrdinalIgnoreCase))
                {
                    yield return new LessonSummary(
                        lesson.Id,
                        cat.Id,
                        cat.Title,
                        lesson.Title,
                        lesson.Subtitle,
                        lesson.Order,
                        lesson.Questions.Count);
                }
            }
        }
    }
}
