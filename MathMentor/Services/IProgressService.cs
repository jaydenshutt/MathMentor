using MathMentor.Models;

namespace MathMentor.Services;

public interface IProgressService
{
    UserProgress Progress { get; }
    LessonProgress GetLessonProgress(string lessonId);
    void MarkExplanationViewed(string lessonId, string lessonTitle);
    QuizAttemptResult RecordQuizAttempt(string lessonId, string lessonTitle, IReadOnlyList<QuestionResult> results);
    double GetOverallMasteryPercent();
    double GetCategoryMasteryPercent(string categoryId, int lessonCount);
    IReadOnlyList<LessonProgress> GetWeakLessons(int take = 8);
    IReadOnlyList<LessonProgress> GetNeedsReview(int take = 12);
    void ResetAll();
    string ExportJson();
    void ImportJson(string json);
    void Save();
}
