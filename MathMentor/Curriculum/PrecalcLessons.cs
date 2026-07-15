using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class PrecalcLessons
{
    public const string CategoryId = "precalc";

    public static Category Build()
    {
        var lessons = new[]
        {
            Composition(),
            Inverses(),
            Sequences(),
            RationalGraph()
        };
        return new Category(CategoryId, "Precalculus Extensions",
            "Composition, inverses, sequences, and rational graphs that bridge algebra to calculus.",
            "\uE9D2", 11, lessons);
    }

    private static Lesson Composition() => new LessonBuilder("fn-composition", CategoryId, "Composition of Functions")
        .Subtitle("Chain functions so the output of one becomes the input of the next")
        .Order(1).Minutes("30 min")
        .Visual(VisualKind.FunctionTransform, "Composition stacks rules: (f ∘ g)(x) means apply g first, then f.")
        .Section("What composition means",
            "Function composition builds a new rule by piping one function into another. The notation (f ∘ g)(x) means f(g(x)): evaluate the inner function g at x, then feed that result into the outer function f.\n\nOrder matters. In general f(g(x)) is not the same as g(f(x)). Think of a factory line: painting then packaging is different from packaging then painting. Composition is the algebra of sequential processes.",
            @" (f\circ g)(x)=f(g(x)) ",
            simple: "Do the inside function first. Take its answer and plug it into the outside function.",
            prior: "You need function notation f(x) and the skill of substituting a number or expression into a rule.")
        .Section("Evaluating compositions",
            "To compute (f ∘ g)(a), first find g(a), then f of that value. To find a formula for (f ∘ g)(x), replace every input slot of f with the entire expression for g(x), then simplify carefully with parentheses.\n\nExample pattern: if f(x) = 2x + 1 and g(x) = x², then f(g(x)) = 2(x²) + 1 = 2x² + 1, while g(f(x)) = (2x + 1)² = 4x² + 4x + 1. Same building blocks, different chain order, different results.",
            simple: "Number path: g first, then f. Formula path: paste g’s formula into every x in f, then clean up.",
            prior: "Distributing, FOIL, and powers of binomials from algebra.")
        .Section("Domain of a composition",
            "For (f ∘ g)(x) to make sense, two conditions must hold:\n1) x must be in the domain of g.\n2) g(x) must land in the domain of f.\n\nSo the domain of f ∘ g is not automatically the domain of f. If g(x) = √x and f(x) = 1/(x − 3), then g requires x ≥ 0, and f requires g(x) ≠ 3, so √x ≠ 3, hence x ≠ 9. Domain of f ∘ g: [0, 9) ∪ (9, ∞).",
            simple: "Inner function must accept x. Outer function must accept whatever the inner function outputs.",
            prior: "Domain rules: no zero denominators, no negative inputs under even roots in real numbers.")
        .Section("Decomposing a formula",
            "Working backward is useful: given h(x) = (2x + 5)³, one natural split is g(x) = 2x + 5 and f(u) = u³ so that h = f ∘ g. Many formulas admit more than one decomposition. Calculus later uses this idea constantly for the chain rule: see an outside shape and an inside expression.",
            simple: "Ask: what is the last operation applied? That is the outer function. Everything underneath is the inner function.",
            prior: "Reading expression structure: powers, roots, and linear pieces.")
        .Section("Notation warnings",
            "• f ∘ g is not multiplication of f and g. The product is usually written f(x)·g(x) or (fg)(x).\n• f(g(x)) is the same as (f ∘ g)(x).\n• Writing f ∘ g(x) without parentheses can be ambiguous in some texts; prefer (f ∘ g)(x) or f(g(x)).\n• Composition is associative: (f ∘ g) ∘ h = f ∘ (g ∘ h), but still not commutative.")
        .Section("Why precalculus cares",
            "Composition is the language of linked models: convert °C to °F, then °F to a cost formula; scale a measurement, then apply a tax. It is also the conceptual core of the chain rule in calculus. Fluency here pays off immediately.")
        .Formula("Composition definition", @"(f\circ g)(x)=f(g(x))", "Apply g first, then f.")
        .Formula("Domain idea", @"x\in D_g,\;g(x)\in D_f", "Both stages must be legal.")
        .Example("Evaluate a composition at a number",
            "Let f(x) = 3x − 1 and g(x) = x². Find (f ∘ g)(2).",
            [
                "Compute the inner value: g(2) = 2² = 4.",
                "Feed into f: f(4) = 3(4) − 1 = 11.",
                "So (f ∘ g)(2) = 11.",
                "Check the other order if curious: (g ∘ f)(2) = g(5) = 25, different answer."
            ],
            "(f ∘ g)(2) = 11.",
            problemLatex: @"f(x)=3x-1,\;g(x)=x^2",
            solutionLatex: @"(f\circ g)(2)=11",
            stepLatex: [@"g(2)=4", @"f(4)=11", null, @"(g\circ f)(2)=25"])
        .Example("Build the composed formula",
            "With f(x) = √x and g(x) = x + 4, find (f ∘ g)(x).",
            [
                "Replace the input of f with g(x): f(g(x)) = √(g(x)).",
                "g(x) = x + 4, so (f ∘ g)(x) = √(x + 4).",
                "Domain requires x + 4 ≥ 0, so x ≥ −4.",
                "Do not write √x + 4 unless you mean (√x) + 4; parentheses matter."
            ],
            "(f ∘ g)(x) = √(x + 4), domain x ≥ −4.",
            solutionLatex: @"\sqrt{x+4}")
        .Example("Opposite order",
            "Same f and g as the previous example. Find (g ∘ f)(x) and its domain.",
            [
                "g(f(x)) = f(x) + 4 = √x + 4.",
                "Domain comes from f: x ≥ 0 (then adding 4 is always fine).",
                "Compare to √(x + 4): different formula and different domain.",
                "Composition order is not commutative."
            ],
            "(g ∘ f)(x) = √x + 4, domain x ≥ 0.",
            solutionLatex: @"\sqrt{x}+4")
        .Example("Domain of f(g(x)) with a restriction",
            "Let g(x) = x − 1 and f(x) = 1/x. Find the domain of (f ∘ g)(x).",
            [
                "g is defined for all real x.",
                "f requires its input ≠ 0, so g(x) ≠ 0.",
                "x − 1 ≠ 0 ⇒ x ≠ 1.",
                "Domain of f ∘ g: all reals except 1. Formula: 1/(x − 1)."
            ],
            "All real x except 1.",
            solutionLatex: @"x\neq 1")
        .Mistake("Evaluating f first when the notation is f(g(x)).")
        .Mistake("Treating f ∘ g as the product f·g.")
        .Mistake("Forgetting domain restrictions from both the inner and outer functions.")
        .Mistake("Dropping parentheses so √(x + 4) becomes √x + 4.")
        .Numeric("f(x) = 2x + 3, g(x) = x − 1. (f ∘ g)(4) = ?", "9",
            ["g(4) = 3.", "f(3) = 2·3 + 3 = 9."],
            "(f ∘ g)(4) = 9.", explanationLatex: @"9")
        .Numeric("f(x) = x², g(x) = x + 2. (f ∘ g)(3) = ?", "25",
            ["g(3) = 5.", "f(5) = 25."],
            "25.", explanationLatex: @"25")
        .Numeric("f(x) = x², g(x) = x + 2. (g ∘ f)(3) = ?", "11",
            ["f(3) = 9.", "g(9) = 11."],
            "11.", explanationLatex: @"11")
        .Mcq("Which expression equals (f ∘ g)(x)?",
            ["f(x)·g(x)", "f(g(x))", "g(f(x)) always", "f(x) + g(x)"], 1,
            ["Definition of composition."],
            "f(g(x)).")
        .Numeric("f(x) = 5 − x, g(x) = 2x. (f ∘ g)(1) = ?", "3",
            ["g(1) = 2.", "f(2) = 3."],
            "3.", explanationLatex: @"3")
        .Mcq("For (f ∘ g)(x) to be defined, which must be true?",
            ["Only x in domain of f", "x in domain of g and g(x) in domain of f", "Only g(x) = 0", "f and g must be linear"], 1,
            ["Both stages of the pipeline must be legal."],
            "Inner domain and outer domain of the image.")
        .Numeric("If g(x) = 3x and f(x) = x + 7, (f ∘ g)(2) = ?", "13",
            ["g(2) = 6.", "f(6) = 13."],
            "13.", explanationLatex: @"13")
        .Numeric("h(x) = (x − 1)² can be f(g(x)) with g(x) = x − 1 and f(u) = u². f(g(5)) = ?", "16",
            ["g(5) = 4.", "4² = 16."],
            "16.", explanationLatex: @"16")
        .Build();

    private static Lesson Inverses() => new LessonBuilder("fn-inverses", CategoryId, "Inverse Functions")
        .Subtitle("Undo a function, swap inputs and outputs, and know when an inverse exists")
        .Order(2).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "Inverse graphs reflect across y = x when both are plotted in the same plane.")
        .Section("What an inverse does",
            "An inverse function undoes another function. If f maps a to b, then f⁻¹ maps b back to a. In notation, f⁻¹(f(x)) = x for x in the domain of f, and f(f⁻¹(y)) = y for y in the domain of f⁻¹.\n\nThe superscript −1 is not an exponent here. f⁻¹(x) does not mean 1/f(x). The reciprocal function is 1/f(x) or [f(x)]⁻¹ in ordinary algebra; inverse function notation reuses the same looking mark with a different meaning.",
            @"f^{-1}(f(x))=x",
            simple: "An inverse rewinds the machine: put in an output, get back the original input.",
            prior: "Function evaluation and the idea that each input gives one output.")
        .Section("One-to-one: when inverses exist",
            "Not every function has an inverse function. For f⁻¹ to be a function, each output of f must come from exactly one input. Equivalently, f must be one-to-one (injective): f(a) = f(b) implies a = b.\n\nGraph test: the horizontal line test. If some horizontal line hits the graph more than once, two different inputs share an output, so you cannot uniquely reverse the process. Example: y = x² on all reals fails; y = x² on [0, ∞) passes and has inverse √x.",
            simple: "If two different x-values give the same y, you cannot define a single inverse value for that y.",
            prior: "Vertical line test for functions; now horizontal lines police invertibility.")
        .Section("Finding an inverse algebraically",
            "Standard steps for y = f(x) when an inverse exists:\n1) Replace f(x) with y.\n2) Swap x and y (this encodes “inputs and outputs trade places”).\n3) Solve for the new y.\n4) Rename that y as f⁻¹(x).\n5) State the domain of f⁻¹ (range of f) and range of f⁻¹ (domain of f).\n\nExample: y = 2x + 3 → x = 2y + 3 → x − 3 = 2y → y = (x − 3)/2. So f⁻¹(x) = (x − 3)/2.",
            @"y=f(x)\;\Rightarrow\;x=f(y)\;\Rightarrow\;y=f^{-1}(x)",
            simple: "Swap the letters, then solve for y again. That new formula is the inverse.",
            prior: "Solving linear and simple radical equations for a variable.")
        .Section("Graphs and the line y = x",
            "If you graph y = f(x) and y = f⁻¹(x) on the same axes, each is the reflection of the other across the diagonal line y = x. A point (a, b) on f becomes (b, a) on f⁻¹. That geometric fact is the same as swapping coordinates algebraically.")
        .Section("Restricting domain to create inverses",
            "Many useful functions are not one-to-one on their natural domain, but become invertible on a restricted piece. Trigonometry does this with inverse sine on [−π/2, π/2]. Quadratics use a half-parabola. Always read whether the problem already restricted the domain.")
        .Section("Checking your answer",
            "Compose both ways: f(f⁻¹(x)) and f⁻¹(f(x)) should simplify to x on the appropriate domains. If not, you made an algebra error or the original was not one-to-one on the set you used.")
        .Formula("Inverse undo", @"f(f^{-1}(x))=x", "Composition recovers the input.")
        .Formula("Linear inverse sample", @"f(x)=mx+b\;(m\neq 0)\Rightarrow f^{-1}(x)=\frac{x-b}{m}", "Swap and solve.")
        .Example("Inverse of a linear function",
            "Find the inverse of f(x) = 4x − 1.",
            [
                "Set y = 4x − 1.",
                "Swap: x = 4y − 1.",
                "Solve: x + 1 = 4y ⇒ y = (x + 1)/4.",
                "So f⁻¹(x) = (x + 1)/4. Check: f(f⁻¹(x)) = 4·((x+1)/4) − 1 = x."
            ],
            "f⁻¹(x) = (x + 1)/4.",
            problemLatex: @"f(x)=4x-1",
            solutionLatex: @"f^{-1}(x)=\frac{x+1}{4}",
            stepLatex: [@"y=4x-1", @"x=4y-1", @"y=\frac{x+1}{4}", null])
        .Example("Horizontal line test",
            "Does f(x) = x³ have an inverse on all real numbers? Why?",
            [
                "Cubes are strictly increasing: if a < b then a³ < b³.",
                "Each real output is hit exactly once (cube root undoes cube).",
                "Horizontal lines hit the graph once.",
                "Yes: f⁻¹(x) = ∛x exists on all reals."
            ],
            "Yes; inverse is the cube root.",
            solutionLatex: @"f^{-1}(x)=x^{1/3}")
        .Example("Why x² needs a restriction",
            "Explain why f(x) = x² on (−∞, ∞) has no inverse function, and fix it.",
            [
                "f(2) = f(−2) = 4: one output, two inputs.",
                "Horizontal line y = 4 hits twice; not one-to-one.",
                "Restrict to [0, ∞). Then f is one-to-one and f⁻¹(x) = √x for x ≥ 0.",
                "Restricting to (−∞, 0] instead gives inverse −√x on [0, ∞)."
            ],
            "Not one-to-one on all reals; restrict domain (e.g. x ≥ 0).",
            solutionLatex: @"f^{-1}(x)=\sqrt{x}\;(x\ge 0)")
        .Example("Inverse of a simple rational",
            "Find the inverse of f(x) = 1/(x − 2), x ≠ 2.",
            [
                "y = 1/(x − 2).",
                "Swap: x = 1/(y − 2).",
                "Solve: x(y − 2) = 1 ⇒ y − 2 = 1/x ⇒ y = 2 + 1/x.",
                "f⁻¹(x) = 2 + 1/x, with x ≠ 0. Note domain/range swapped carefully."
            ],
            "f⁻¹(x) = 2 + 1/x (x ≠ 0).",
            solutionLatex: @"f^{-1}(x)=2+\frac{1}{x}")
        .Mistake("Reading f⁻¹(x) as 1/f(x).")
        .Mistake("Claiming every function has an inverse without checking one-to-one.")
        .Mistake("Swapping x and y but forgetting to solve for the new y.")
        .Mistake("Ignoring domain restrictions after finding an inverse formula.")
        .Numeric("f(x) = 2x + 5. f⁻¹(9) = ?", "2",
            ["2x + 5 = 9 ⇒ 2x = 4 ⇒ x = 2."],
            "2.", explanationLatex: @"2")
        .Numeric("f(x) = 3x − 6. Slope of f⁻¹ is 1/m. What is that slope?", "0.333",
            ["m = 3, so inverse slope is 1/3."],
            "1/3 ≈ 0.333.", tolerance: 0.01, explanationLatex: @"\frac{1}{3}")
        .Mcq("Which test checks that a function is one-to-one (for invertibility)?",
            ["Vertical line test", "Horizontal line test", "Pythagorean theorem", "Intermediate value theorem only"], 1,
            ["Horizontal lines detect repeated outputs."],
            "Horizontal line test.")
        .Numeric("f(x) = x + 7. f⁻¹(10) = ?", "3",
            ["x + 7 = 10 ⇒ x = 3."],
            "3.", explanationLatex: @"3")
        .Numeric("If f(2) = 5 and f is invertible, f⁻¹(5) = ?", "2",
            ["Inverse swaps the pair (2, 5) to (5, 2)."],
            "2.", explanationLatex: @"2")
        .Mcq("f(x) = x² on all reals has an inverse function?",
            ["Yes, √x", "Yes, x² again", "No, not one-to-one", "Only if we ban x = 0"], 2,
            ["Two x-values share most positive outputs."],
            "No on the full real line.")
        .Numeric("f(x) = 5x. f⁻¹(20) = ?", "4",
            ["5x = 20 ⇒ x = 4."],
            "4.", explanationLatex: @"4")
        .Numeric("f(x) = (x − 1)/2. f⁻¹(3) = ?", "7",
            ["(x − 1)/2 = 3 ⇒ x − 1 = 6 ⇒ x = 7."],
            "7.", explanationLatex: @"7")
        .Build();

    private static Lesson Sequences() => new LessonBuilder("fn-sequences", CategoryId, "Sequences: Arithmetic & Geometric")
        .Subtitle("Lists of numbers with a clear pattern: add a constant or multiply by a constant")
        .Order(3).Minutes("32 min")
        .Section("Sequences as functions of n",
            "A sequence is an ordered list of numbers a₁, a₂, a₃, … (sometimes indexed from n = 0). You can think of it as a function whose domain is the positive integers: a(n) = a_n.\n\nTwo families dominate precalculus: arithmetic sequences (constant difference) and geometric sequences (constant ratio). Both appear in finance, population models, and as discrete versions of linear and exponential functions.",
            simple: "A sequence is a numbered list. Watch whether you add the same amount each step or multiply by the same factor.",
            prior: "Linear growth (add) versus exponential growth (multiply) from functions.")
        .Section("Arithmetic sequences",
            "An arithmetic sequence has a constant common difference d: each term is the previous term plus d.\n\na_n = a₁ + (n − 1)d\n\nExample: 3, 7, 11, 15, … has d = 4. The 10th term is 3 + 9·4 = 39.\n\nIf d > 0 the sequence increases; if d < 0 it decreases. The graph of points (n, a_n) lies on a straight line.",
            @"a_n=a_1+(n-1)d",
            simple: "Start at a₁, then add d again and again. To jump to term n, add d exactly (n − 1) times.",
            prior: "Solving linear equations; integer counting.")
        .Section("Geometric sequences",
            "A geometric sequence has a constant common ratio r: each term is the previous term times r.\n\na_n = a₁ · r^{n−1}\n\nExample: 2, 6, 18, 54, … has r = 3. The 5th term is 2 · 3⁴ = 162.\n\nIf |r| > 1, magnitudes grow; if 0 < |r| < 1, terms shrink toward 0; if r < 0, signs alternate.",
            @"a_n=a_1 r^{n-1}",
            simple: "Multiply by r each step. Term n multiplies the start by r, (n − 1) times.",
            prior: "Integer exponents and absolute value for growth versus decay.")
        .Section("Partial sums (series snapshots)",
            "The sum of the first n terms is often needed.\n• Arithmetic: S_n = n/2 · (a₁ + a_n) = n/2 · (2a₁ + (n − 1)d).\n• Geometric (r ≠ 1): S_n = a₁ (1 − r^n)/(1 − r).\n\nThese formulas are finite sums. Infinite geometric series converge only when |r| < 1; that deeper topic is a short step beyond this lesson’s core.",
            @"S_n=\frac{n}{2}(a_1+a_n)",
            simple: "Arithmetic sum: average of first and last, times how many terms. Geometric sum: use the closed formula with r^n.",
            prior: "Factoring and simplifying rational expressions helps with geometric sums.")
        .Section("Which type is it?",
            "Compute differences of consecutive terms: constant ⇒ arithmetic. Compute ratios of consecutive terms (when terms ≠ 0): constant ⇒ geometric. Some sequences are neither (example: 1, 4, 9, 16, … squares). Word problems: fixed raise each year is arithmetic; fixed percent growth is geometric.")
        .Section("Recursive versus explicit",
            "A recursive rule gives a term from previous terms (a_{n+1} = a_n + d). An explicit rule gives a_n directly from n. Explicit forms are faster for large n; recursive forms match how patterns are discovered.")
        .Formula("Arithmetic nth term", @"a_n=a_1+(n-1)d", "Common difference d.")
        .Formula("Geometric nth term", @"a_n=a_1 r^{n-1}", "Common ratio r.")
        .Formula("Arithmetic sum", @"S_n=\frac{n}{2}(a_1+a_n)", "n terms, first plus last.")
        .Example("Find an arithmetic term",
            "Arithmetic sequence with a₁ = 5 and d = 3. Find a₈.",
            [
                "Use a_n = a₁ + (n − 1)d.",
                "a₈ = 5 + 7·3 = 5 + 21 = 26.",
                "List check: 5, 8, 11, 14, 17, 20, 23, 26.",
                "Eight terms, seven steps of +3 from the first."
            ],
            "a₈ = 26.",
            problemLatex: @"a_1=5,\;d=3",
            solutionLatex: @"a_8=26",
            stepLatex: [@"a_n=a_1+(n-1)d", @"a_8=5+7\cdot 3", @"26", null])
        .Example("Find a geometric term",
            "Geometric sequence with a₁ = 3 and r = 2. Find a₆.",
            [
                "a_n = a₁ r^{n−1}.",
                "a₆ = 3 · 2⁵ = 3 · 32 = 96.",
                "List: 3, 6, 12, 24, 48, 96.",
                "Five doublings from the first term to the sixth."
            ],
            "a₆ = 96.",
            solutionLatex: @"a_6=96")
        .Example("Arithmetic sum",
            "Sum the first 10 terms of 2, 5, 8, 11, …",
            [
                "a₁ = 2, d = 3, n = 10.",
                "a₁₀ = 2 + 9·3 = 29.",
                "S₁₀ = 10/2 · (2 + 29) = 5 · 31 = 155.",
                "Or S_n = n/2 · (2a₁ + (n − 1)d) = 5 · (4 + 27) = 155."
            ],
            "Sum is 155.",
            solutionLatex: @"S_{10}=155")
        .Example("Geometric sum",
            "Find S₄ for a₁ = 5, r = 3.",
            [
                "Terms: 5, 15, 45, 135.",
                "Formula: S_n = a₁(1 − r^n)/(1 − r).",
                "S₄ = 5(1 − 3⁴)/(1 − 3) = 5(1 − 81)/(−2) = 5(−80)/(−2) = 5·40 = 200.",
                "Direct add: 5 + 15 + 45 + 135 = 200."
            ],
            "S₄ = 200.",
            solutionLatex: @"S_4=200")
        .Mistake("Using a_n = a₁ + n d instead of (n − 1)d (off-by-one).")
        .Mistake("Using a_n = a₁ r^n instead of r^{n−1} for standard indexing from n = 1.")
        .Mistake("Calling a sequence geometric when differences (not ratios) are constant.")
        .Mistake("Dividing by (1 − r) with r = 1 in the geometric sum formula.")
        .Numeric("Arithmetic: a₁ = 4, d = 5. a₃ = ?", "14",
            ["4 + 2·5 = 14."],
            "14.", explanationLatex: @"14")
        .Numeric("Geometric: a₁ = 2, r = 3. a₄ = ?", "54",
            ["2 · 3³ = 54."],
            "54.", explanationLatex: @"54")
        .Numeric("Arithmetic: 10, 7, 4, … What is d?", "-3",
            ["7 − 10 = −3."],
            "d = −3.", explanationLatex: @"-3")
        .Numeric("Geometric: 5, 10, 20, … What is r?", "2",
            ["10/5 = 2."],
            "r = 2.", explanationLatex: @"2")
        .Mcq("Which sequence is geometric?",
            ["2, 4, 6, 8", "3, 6, 12, 24", "1, 4, 9, 16", "5, 5, 5, 6"], 1,
            ["Constant ratio 2."],
            "3, 6, 12, 24.")
        .Numeric("Arithmetic sum: a₁ = 1, a_n = 9, n = 5. S₅ = ?", "25",
            ["S = 5/2 · (1 + 9) = 25."],
            "25.", explanationLatex: @"25")
        .Numeric("Geometric: a₁ = 4, r = 1/2. a₃ = ?", "1",
            ["4 · (1/2)² = 1."],
            "1.", explanationLatex: @"1")
        .Mcq("a_n = 7 + (n − 1)·2 describes:",
            ["A geometric sequence with r = 2", "An arithmetic sequence with d = 2", "Neither", "Only a constant sequence"], 1,
            ["Form a₁ + (n − 1)d."],
            "Arithmetic with d = 2.")
        .Build();

    private static Lesson RationalGraph() => new LessonBuilder("fn-rational-graph", CategoryId, "Rational Functions & Asymptotes Intro")
        .Subtitle("How numerator and denominator degrees shape holes, vertical walls, and end behavior")
        .Order(4).Minutes("34 min")
        .Visual(VisualKind.LineGraph, "Rational graphs can jump at vertical asymptotes and flatten toward horizontal lines.")
        .Section("What is a rational function?",
            "A rational function is a ratio of polynomials: f(x) = p(x)/q(x) with q not the zero polynomial. They generalize linear and polynomial graphs with new features: values where the denominator is zero, and end behavior controlled by degrees of p and q.\n\nBefore graphing, factor if possible. Common factors in numerator and denominator create holes (removable discontinuities), not vertical asymptotes.",
            @"f(x)=\frac{p(x)}{q(x)}",
            simple: "Polynomial divided by polynomial. Factor first; cancel matches for holes; leftover denominator zeros are vertical asymptotes.",
            prior: "Factoring polynomials and simplifying rational expressions from algebra.")
        .Section("Vertical asymptotes and holes",
            "After canceling common factors, any remaining x = a with denominator zero produces a vertical asymptote x = a: the graph shoots to ±∞ as x approaches a from each side.\n\nIf a factor cancels completely, x = a is a hole: the simplified function is defined there if you fill it in, but the original formula is not. Limit exists; function value in the original formula does not.",
            simple: "Canceled zero → hole. Uncanceled zero in the denominator → vertical asymptote.",
            prior: "Limits and continuity ideas: 0/0 after canceling versus nonzero/0.")
        .Section("Horizontal asymptotes by degree",
            "Compare deg(p) and deg(q) for end behavior as x → ±∞:\n• If deg(p) < deg(q): horizontal asymptote y = 0.\n• If deg(p) = deg(q): horizontal asymptote y = (leading coeff of p)/(leading coeff of q).\n• If deg(p) = deg(q) + 1: oblique (slant) asymptote; divide polynomials.\n• If deg(p) > deg(q) + 1: no horizontal or slant asymptote of the basic types (end behavior is polynomial-like of higher degree).\n\nHorizontal asymptotes describe ends, not barriers the graph can never cross in the middle.",
            @"\deg p=\deg q\Rightarrow y=\frac{a}{b}",
            simple: "Bottom-heavy → height 0 at infinity. Same degree → ratio of lead coefficients. Top one degree higher → slant line.",
            prior: "Leading terms of polynomials dominate for large |x|.")
        .Section("Intercepts and a sketch plan",
            "• y-intercept: f(0) if defined.\n• x-intercepts: zeros of the numerator that are not also zeros of the denominator.\n• Plot a few test points in each interval split by vertical asymptotes and holes.\n• Draw dashed asymptote lines, then the branches approaching them.\n\nA clean sketch beats random plotting.")
        .Section("Sign charts near asymptotes",
            "On each side of a vertical asymptote, the function is either large positive or large negative. A sign chart using factored form tells you which. That prevents drawing both branches on the wrong side of the x-axis.")
        .Section("Simple template: (ax+b)/(cx+d)",
            "Linear over linear is the workhorse example. Vertical asymptote where denominator is zero; horizontal asymptote y = a/c; intercepts easy to compute. Master this family before more complicated degrees.")
        .Formula("Vertical asymptote idea", @"q(a)=0,\;p(a)\neq 0\Rightarrow x=a", "After simplifying, denominator zero.")
        .Formula("Equal degree HA", @"y=\frac{a}{b}", "Lead coefficients when degrees match.")
        .Example("Hole versus asymptote",
            "f(x) = (x² − 1)/(x − 1). Identify the discontinuity type at x = 1.",
            [
                "Factor: (x − 1)(x + 1)/(x − 1) for x ≠ 1.",
                "Cancel: simplified form x + 1, x ≠ 1.",
                "The factor canceled, so x = 1 is a hole, not a vertical asymptote.",
                "Hole at (1, 2) because the simplified value is 1 + 1 = 2."
            ],
            "Hole at (1, 2).",
            problemLatex: @"f(x)=\frac{x^2-1}{x-1}",
            solutionLatex: @"(1,2)",
            stepLatex: [@"\frac{(x-1)(x+1)}{x-1}", @"x+1\;(x\neq 1)", null, @"(1,2)"])
        .Example("Vertical and horizontal asymptotes",
            "f(x) = (2x + 1)/(x − 3). Find asymptotes.",
            [
                "Denominator zero at x = 3; numerator 2·3 + 1 = 7 ≠ 0, so vertical asymptote x = 3.",
                "Degrees both 1: horizontal asymptote y = 2/1 = 2.",
                "y-intercept f(0) = 1/(−3) = −1/3.",
                "x-intercept: 2x + 1 = 0 ⇒ x = −1/2."
            ],
            "VA: x = 3; HA: y = 2.",
            solutionLatex: @"x=3,\;y=2")
        .Example("Horizontal asymptote y = 0",
            "g(x) = 5/(x² + 1). What is the horizontal asymptote?",
            [
                "deg numerator 0 < deg denominator 2.",
                "End behavior: g(x) → 0 as |x| → ∞.",
                "Horizontal asymptote y = 0.",
                "No real vertical asymptote because x² + 1 ≥ 1 > 0 always."
            ],
            "y = 0.",
            solutionLatex: @"y=0")
        .Example("Equal degree lead coefficients",
            "h(x) = (6x² + 1)/(3x² − 5). Find the horizontal asymptote.",
            [
                "Degrees both 2.",
                "Ratio of leading coefficients: 6/3 = 2.",
                "Horizontal asymptote y = 2.",
                "Vertical asymptotes where 3x² − 5 = 0, x = ±√(5/3), separate analysis."
            ],
            "y = 2.",
            solutionLatex: @"y=2")
        .Mistake("Calling a canceled factor a vertical asymptote instead of a hole.")
        .Mistake("Using y-intercept rules for horizontal asymptotes (different ideas).")
        .Mistake("Thinking a graph can never cross a horizontal asymptote (it can in the middle).")
        .Mistake("Forgetting to check that the numerator is nonzero before declaring a VA.")
        .Numeric("f(x) = 1/(x − 4). Vertical asymptote at x = ?", "4",
            ["Denominator zero at 4."],
            "x = 4.", explanationLatex: @"x=4")
        .Numeric("f(x) = (3x + 1)/(x + 5). HA is y = ?", "3",
            ["Equal degree; lead ratio 3/1 = 3."],
            "y = 3.", explanationLatex: @"y=3")
        .Numeric("f(x) = 7/(x² + 2). HA is y = ?", "0",
            ["Lower degree on top ⇒ y = 0."],
            "y = 0.", explanationLatex: @"y=0")
        .Mcq("After canceling (x − 2) fully, x = 2 is usually a:",
            ["Vertical asymptote", "Hole", "Horizontal asymptote", "x-intercept always"], 1,
            ["Removable discontinuity."],
            "Hole.")
        .Numeric("f(x) = (x − 1)/(x − 1) for x ≠ 1 simplifies to what constant?", "1",
            ["Cancels to 1."],
            "1.", explanationLatex: @"1")
        .Numeric("f(x) = (2x)/(4x + 8). HA y = ?", "0.5",
            ["Lead ratio 2/4 = 1/2."],
            "y = 1/2.", tolerance: 0.01, explanationLatex: @"y=\frac{1}{2}")
        .Mcq("deg(numerator) < deg(denominator) implies horizontal asymptote:",
            ["y = 1", "y = 0", "None ever", "y = x"], 1,
            ["Bottom-heavy rational functions die out to 0."],
            "y = 0.")
        .Numeric("f(x) = (x + 2)/(x − 5). f(0) = ?", "-0.4",
            ["2/(−5) = −0.4."],
            "−2/5 = −0.4.", tolerance: 0.01, explanationLatex: @"-\frac{2}{5}")
        .Build();
}
