using System.IO;
using System.Text.Json;
using MathMentor.Models;

namespace MathMentor.Services;

public sealed class ProgressService : IProgressService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly string _filePath;
    private readonly ICurriculumService _curriculum;

    public UserProgress Progress { get; private set; }

    public ProgressService(ICurriculumService curriculum)
    {
        _curriculum = curriculum;
        var dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MathMentor");
        Directory.CreateDirectory(dir);
        _filePath = Path.Combine(dir, "progress.json");
        Progress = Load();
        Progress.LastOpened = DateTimeOffset.Now;
        Save();
    }

    public LessonProgress GetLessonProgress(string lessonId)
    {
        if (!Progress.Lessons.TryGetValue(lessonId, out var p))
        {
            p = new LessonProgress { LessonId = lessonId };
            Progress.Lessons[lessonId] = p;
        }
        return p;
    }

    public void MarkExplanationViewed(string lessonId, string lessonTitle)
    {
        var p = GetLessonProgress(lessonId);
        p.ExplanationViewed = true;
        p.LastReviewed = DateTimeOffset.Now;
        Progress.LastLessonId = lessonId;
        AddActivity(lessonId, lessonTitle, "Reviewed explanation", null);
        Save();
    }

    public QuizAttemptResult RecordQuizAttempt(string lessonId, string lessonTitle, IReadOnlyList<QuestionResult> results)
    {
        var correct = results.Count(r => r.IsCorrect);
        var total = results.Count;
        var percent = total == 0 ? 0 : (int)Math.Round(100.0 * correct / total);

        var p = GetLessonProgress(lessonId);
        p.Attempts++;
        p.LastScorePercent = percent;
        p.LastReviewed = DateTimeOffset.Now;
        var isNewBest = percent >= p.BestScorePercent;
        if (percent > p.BestScorePercent)
            p.BestScorePercent = percent;
        if (percent >= 70)
            p.LastSuccessfulReview = DateTimeOffset.Now;

        Progress.LastLessonId = lessonId;
        AddActivity(lessonId, lessonTitle, "Completed practice", percent);
        Save();

        return new QuizAttemptResult
        {
            LessonId = lessonId,
            LessonTitle = lessonTitle,
            CorrectCount = correct,
            TotalCount = total,
            ScorePercent = percent,
            IsNewBest = isNewBest && p.Attempts > 0,
            Results = results
        };
    }

    public double GetOverallMasteryPercent()
    {
        var lessons = _curriculum.AllLessons;
        if (lessons.Count == 0) return 0;
        var sum = lessons.Sum(l => GetLessonProgress(l.Id).BestScorePercent);
        return sum / (double)lessons.Count;
    }

    public double GetCategoryMasteryPercent(string categoryId, int lessonCount)
    {
        if (lessonCount == 0) return 0;
        var cat = _curriculum.GetCategory(categoryId);
        if (cat is null) return 0;
        return cat.Lessons.Average(l => GetLessonProgress(l.Id).BestScorePercent);
    }

    public IReadOnlyList<LessonProgress> GetWeakLessons(int take = 8)
    {
        return _curriculum.AllLessons
            .Select(l => GetLessonProgress(l.Id))
            .Where(p => p.Attempts > 0 && p.BestScorePercent < 85)
            .OrderBy(p => p.BestScorePercent)
            .ThenByDescending(p => p.LastReviewed)
            .Take(take)
            .ToList();
    }

    public IReadOnlyList<LessonProgress> GetNeedsReview(int take = 12)
    {
        var now = DateTimeOffset.Now;
        return _curriculum.AllLessons
            .Select(l => GetLessonProgress(l.Id))
            .Select(p => new { Progress = p, Score = ScoreForReview(p, now) })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Select(x => x.Progress)
            .Take(take)
            .ToList();
    }

    private static double ScoreForReview(LessonProgress p, DateTimeOffset now)
    {
        if (p.Attempts == 0 && !p.ExplanationViewed) return 0;
        if (p.Attempts == 0) return 1;

        var days = p.LastSuccessfulReview.HasValue
            ? (now - p.LastSuccessfulReview.Value).TotalDays
            : (p.LastReviewed.HasValue ? (now - p.LastReviewed.Value).TotalDays + 3 : 10);

        var performanceGap = Math.Max(0, 100 - p.BestScorePercent) / 20.0;
        return days + performanceGap * 2;
    }

    public void ResetAll()
    {
        Progress = new UserProgress();
        Save();
    }

    public string ExportJson() => JsonSerializer.Serialize(Progress, JsonOptions);

    public void ImportJson(string json)
    {
        var loaded = JsonSerializer.Deserialize<UserProgress>(json, JsonOptions)
                     ?? new UserProgress();
        Progress = loaded;
        Save();
    }

    public void Save()
    {
        try
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(Progress, JsonOptions));
        }
        catch
        {
            // Local IO failure should not crash the tutor.
        }
    }

    private UserProgress Load()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<UserProgress>(json, JsonOptions) ?? new UserProgress();
            }
        }
        catch
        {
            // Corrupt file, start fresh.
        }
        return new UserProgress();
    }

    private void AddActivity(string lessonId, string title, string action, int? score)
    {
        Progress.RecentActivity.Insert(0, new ActivityEntry
        {
            Timestamp = DateTimeOffset.Now,
            LessonId = lessonId,
            LessonTitle = title,
            Action = action,
            ScorePercent = score
        });
        if (Progress.RecentActivity.Count > 30)
            Progress.RecentActivity = Progress.RecentActivity.Take(30).ToList();
    }
}
