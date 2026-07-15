namespace MathMentor.Models;

public enum QuestionType
{
    MultipleChoice,
    Numeric
}

public enum VisualKind
{
    None,
    LineGraph,
    UnitCircle,
    Parabola,
    IntegralArea,
    FunctionTransform,
    GeometryCanvas,
    ExponentialGrowth,
    LogGraph
}

/// <summary>Inline educational diagrams shown inside lesson explanation sections.</summary>
public enum SectionDiagramKind
{
    None,
    /// <summary>Horizontal place-value chart; DiagramData = example whole number (e.g. "3472").</summary>
    PlaceValueChart
}

/// <summary>Top-level curriculum category (e.g. Algebra I).</summary>
public sealed record Category(
    string Id,
    string Title,
    string Description,
    string IconGlyph,
    int Order,
    IReadOnlyList<Lesson> Lessons);

/// <summary>A single focused lesson with explanation, examples, and practice.</summary>
public sealed record Lesson(
    string Id,
    string CategoryId,
    string Title,
    string Subtitle,
    int Order,
    string EstimatedMinutes,
    IReadOnlyList<ContentSection> Sections,
    IReadOnlyList<WorkedExample> Examples,
    IReadOnlyList<KeyFormula> Formulas,
    IReadOnlyList<string> CommonMistakes,
    IReadOnlyList<PracticeQuestion> Questions,
    VisualKind Visual = VisualKind.None,
    string? VisualCaption = null,
    IReadOnlyList<string>? KeyTakeaways = null);

public sealed record ContentSection(
    string Heading,
    string Body,
    string? FormulaLatex = null,
    SectionDiagramKind Diagram = SectionDiagramKind.None,
    string? DiagramData = null,
    /// <summary>Optional plain-language re-explain for struggling students.</summary>
    string? SimpleRestate = null,
    /// <summary>Optional bridge to earlier topics the student should recall.</summary>
    string? PriorLink = null);

public sealed record ExampleStep(string Text, string? Latex = null);

public sealed record WorkedExample(
    string Title,
    string Problem,
    string? ProblemLatex,
    IReadOnlyList<ExampleStep> Steps,
    string? SolutionLatex,
    string Closing,
    string? ClosingLatex = null);

public sealed record KeyFormula(
    string Name,
    string Latex,
    string Description);

public sealed record PracticeQuestion(
    string Id,
    string Prompt,
    string? PromptLatex,
    QuestionType Type,
    IReadOnlyList<string>? Choices,
    string CorrectAnswer,
    double Tolerance,
    IReadOnlyList<string> Hints,
    string Explanation,
    string? ExplanationLatex);

/// <summary>Lightweight summary for lists and navigation.</summary>
public sealed record LessonSummary(
    string Id,
    string CategoryId,
    string CategoryTitle,
    string Title,
    string Subtitle,
    int Order,
    int QuestionCount);
