using MathMentor.Models;

namespace MathMentor.Curriculum;

/// <summary>Assembles the full type-safe curriculum embedded in the application.</summary>
public static class CurriculumCatalog
{
    private static IReadOnlyList<Category>? _categories;

    public static IReadOnlyList<Category> GetCategories()
    {
        return _categories ??= BuildAll();
    }

    public static IReadOnlyList<Lesson> GetAllLessons() =>
        GetCategories()
            .OrderBy(c => c.Order)
            .SelectMany(c => c.Lessons.OrderBy(l => l.Order))
            .ToList();

    public static Lesson? FindLesson(string lessonId) =>
        GetAllLessons().FirstOrDefault(l => l.Id.Equals(lessonId, StringComparison.OrdinalIgnoreCase));

    public static Category? FindCategory(string categoryId) =>
        GetCategories().FirstOrDefault(c => c.Id.Equals(categoryId, StringComparison.OrdinalIgnoreCase));

    public static Lesson? GetNextLesson(string lessonId)
    {
        var all = GetAllLessons();
        var idx = all.ToList().FindIndex(l => l.Id.Equals(lessonId, StringComparison.OrdinalIgnoreCase));
        return idx >= 0 && idx < all.Count - 1 ? all[idx + 1] : null;
    }

    public static Lesson? GetPreviousLesson(string lessonId)
    {
        var all = GetAllLessons();
        var idx = all.ToList().FindIndex(l => l.Id.Equals(lessonId, StringComparison.OrdinalIgnoreCase));
        return idx > 0 ? all[idx - 1] : null;
    }

    /// <summary>
    /// Progressive order: arithmetic through calculus, then cumulative reviews.
    /// Category.Order values should match this sequence.
    /// </summary>
    private static IReadOnlyList<Category> BuildAll() =>
    [
        ArithmeticLessons.Build(),           // 1
        NumberFoundationsLessons.Build(),    // 2
        FractionsLessons.Build(),            // 3
        PreAlgebraLessons.Build(),           // 4
        AlgebraLessons.Build(),              // 5
        Algebra2Lessons.Build(),             // 6
        QuadraticsLessons.Build(),           // 7
        GeometryLessons.Build(),             // 8
        AdvancedGeometryLessons.Build(),     // 9
        FunctionsLessons.Build(),            // 10
        PrecalcLessons.Build(),              // 11
        TrigLessons.Build(),                 // 12
        TrigExtraLessons.Build(),            // 13
        StatsLessons.Build(),                // 14
        AppliedLessons.Build(),              // 15
        CalculusLessons.Build(),             // 16
        CalculusExtraLessons.Build(),        // 17
        ReviewLessons.Build()                // 18
    ];
}
