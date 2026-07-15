using MathMentor.Models;

namespace MathMentor.Services;

public interface ICurriculumService
{
    IReadOnlyList<Category> Categories { get; }
    IReadOnlyList<Lesson> AllLessons { get; }
    Lesson? GetLesson(string lessonId);
    Category? GetCategory(string categoryId);
    Lesson? GetNext(string lessonId);
    Lesson? GetPrevious(string lessonId);
    IEnumerable<LessonSummary> Search(string? query, string? categoryId = null);
}
