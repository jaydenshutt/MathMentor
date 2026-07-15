using System.Text.Json.Serialization;

namespace MathMentor.Models;

public sealed class UserProgress
{
    public Dictionary<string, LessonProgress> Lessons { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public DateTimeOffset LastOpened { get; set; } = DateTimeOffset.Now;
    public string? LastLessonId { get; set; }
    public bool HasCompletedWelcome { get; set; }
    public List<ActivityEntry> RecentActivity { get; set; } = [];
}

public sealed class LessonProgress
{
    public string LessonId { get; set; } = "";
    public bool ExplanationViewed { get; set; }
    public int BestScorePercent { get; set; }
    public int Attempts { get; set; }
    public int LastScorePercent { get; set; }
    public DateTimeOffset? LastReviewed { get; set; }
    public DateTimeOffset? LastSuccessfulReview { get; set; }
    public bool IsCompleted => BestScorePercent >= 70;

    [JsonIgnore]
    public int Stars => BestScorePercent switch
    {
        >= 95 => 3,
        >= 85 => 2,
        >= 70 => 1,
        _ => 0
    };
}

public sealed class ActivityEntry
{
    public DateTimeOffset Timestamp { get; set; }
    public string LessonId { get; set; } = "";
    public string LessonTitle { get; set; } = "";
    public string Action { get; set; } = "";
    public int? ScorePercent { get; set; }
}

public sealed class AppSettings
{
    public bool IsDarkTheme { get; set; } = true;
    public double FontScale { get; set; } = 1.0;
    public bool ShowTourOnStart { get; set; } = true;
}

public sealed class QuizAttemptResult
{
    public required string LessonId { get; init; }
    public required string LessonTitle { get; init; }
    public int CorrectCount { get; init; }
    public int TotalCount { get; init; }
    public int ScorePercent { get; init; }
    public bool IsNewBest { get; init; }
    public IReadOnlyList<QuestionResult> Results { get; init; } = [];
}

public sealed class QuestionResult
{
    public required PracticeQuestion Question { get; init; }
    public required string UserAnswer { get; init; }
    public required bool IsCorrect { get; init; }
}
