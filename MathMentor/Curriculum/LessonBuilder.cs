using MathMentor.Models;

namespace MathMentor.Curriculum;

/// <summary>Fluent helper for assembling pedagogically complete lessons.</summary>
public sealed class LessonBuilder
{
    private readonly string _id;
    private readonly string _categoryId;
    private readonly string _title;
    private string _subtitle = "";
    private int _order;
    private string _minutes = "20 min";
    private readonly List<ContentSection> _sections = [];
    private readonly List<WorkedExample> _examples = [];
    private readonly List<KeyFormula> _formulas = [];
    private readonly List<string> _mistakes = [];
    private readonly List<PracticeQuestion> _questions = [];
    private readonly List<string> _takeaways = [];
    private VisualKind _visual = VisualKind.None;
    private string? _visualCaption;
    private int _qCounter;

    public LessonBuilder(string id, string categoryId, string title)
    {
        _id = id;
        _categoryId = categoryId;
        _title = title;
    }

    public LessonBuilder Subtitle(string s) { _subtitle = s; return this; }
    public LessonBuilder Order(int o) { _order = o; return this; }
    public LessonBuilder Minutes(string m) { _minutes = m; return this; }
    public LessonBuilder Visual(VisualKind kind, string? caption = null)
    {
        _visual = kind;
        _visualCaption = caption;
        return this;
    }

    public LessonBuilder Section(
        string heading,
        string body,
        string? latex = null,
        SectionDiagramKind diagram = SectionDiagramKind.None,
        string? diagramData = null,
        string? simple = null,
        string? prior = null)
    {
        _sections.Add(new ContentSection(heading, body, latex, diagram, diagramData, simple, prior));
        return this;
    }

    public LessonBuilder Formula(string name, string latex, string description)
    {
        _formulas.Add(new KeyFormula(name, latex, description));
        return this;
    }

    public LessonBuilder Mistake(string text)
    {
        _mistakes.Add(text);
        return this;
    }

    /// <summary>End-of-lesson key takeaways (3-5 bullets recommended).</summary>
    public LessonBuilder Takeaways(params string[] items)
    {
        _takeaways.AddRange(items.Where(s => !string.IsNullOrWhiteSpace(s)));
        return this;
    }

    public LessonBuilder Example(
        string title,
        string problem,
        string[] steps,
        string closing,
        string? problemLatex = null,
        string? solutionLatex = null,
        string?[]? stepLatex = null,
        string? closingLatex = null)
    {
        var exampleSteps = new List<ExampleStep>(steps.Length);
        for (var i = 0; i < steps.Length; i++)
        {
            string? latex = null;
            if (stepLatex is not null && i < stepLatex.Length)
                latex = stepLatex[i];
            exampleSteps.Add(new ExampleStep(steps[i], latex));
        }

        _examples.Add(new WorkedExample(title, problem, problemLatex, exampleSteps, solutionLatex, closing, closingLatex));
        return this;
    }

    public LessonBuilder Mcq(
        string prompt,
        string[] choices,
        int correctIndex,
        string[] hints,
        string explanation,
        string? promptLatex = null,
        string? explanationLatex = null)
    {
        _qCounter++;
        _questions.Add(new PracticeQuestion(
            $"{_id}-q{_qCounter}",
            prompt,
            promptLatex,
            QuestionType.MultipleChoice,
            choices,
            choices[correctIndex],
            0,
            hints,
            explanation,
            explanationLatex));
        return this;
    }

    public LessonBuilder Numeric(
        string prompt,
        string correctAnswer,
        string[] hints,
        string explanation,
        double tolerance = 0.01,
        string? promptLatex = null,
        string? explanationLatex = null)
    {
        _qCounter++;
        _questions.Add(new PracticeQuestion(
            $"{_id}-q{_qCounter}",
            prompt,
            promptLatex,
            QuestionType.Numeric,
            null,
            correctAnswer,
            tolerance,
            hints,
            explanation,
            explanationLatex));
        return this;
    }

    public Lesson Build()
    {
        // Ensure every lesson has clear takeaways (explicit preferred; sensible fallback if omitted).
        var takeaways = _takeaways.Count > 0
            ? _takeaways.ToList()
            : BuildDefaultTakeaways();

        return new Lesson(
            _id,
            _categoryId,
            _title,
            _subtitle,
            _order,
            _minutes,
            _sections,
            _examples,
            _formulas,
            _mistakes,
            _questions,
            _visual,
            _visualCaption,
            takeaways);
    }

    private List<string> BuildDefaultTakeaways()
    {
        var list = new List<string>();
        foreach (var f in _formulas.Take(3))
            list.Add($"{f.Name}: {f.Description}");
        if (list.Count == 0 && _sections.Count > 0)
            list.Add($"Be able to explain the main idea of \"{_title}\" in your own words.");
        list.Add("Redo at least one worked example from scratch without looking at the steps.");
        list.Add("Scan the common mistakes list before you start the practice set.");
        if (_questions.Count > 0)
            list.Add("Use practice feedback: after each miss, reread the matching explanation section.");
        return list.Take(5).ToList();
    }
}
