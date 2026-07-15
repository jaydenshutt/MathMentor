using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class CalculusLessons
{
    public const string CategoryId = "calculus";

    public static Category Build()
    {
        var lessons = new[]
        {
            Limits(),
            DerivativeBasics(),
            ProductQuotientChain(),
            DerivativeApps(),
            Antiderivatives(),
            DefiniteIntegrals(),
            IntegrationTechniques()
        };
        return new Category(CategoryId, "Calculus",
            "Limits, derivatives, integrals, and the fundamental theorem, single-variable core.",
            "\uE9F9", 16, lessons);
    }

    private static Lesson Limits() => new LessonBuilder("calc-limits", CategoryId, "Limits & Continuity")
        .Subtitle("What a function approaches, the foundation under every derivative and integral")
        .Order(1).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "A limit describes the intended height of the graph even if there is a hole or the point is redefined.")
        .Section("Intuition first: the “approaching” idea",
            "Before any formal ε-δ language, hold this picture: as the input x gets closer and closer to a number a (from values near a, not necessarily equal to a), the outputs f(x) get closer and closer to a number L. We write\nlim_{x→a} f(x) = L\nand say “the limit of f as x approaches a is L.”\n\n Crucially, the limit does not care what happens exactly at x = a. The function can have a hole there, a different value plugged in, or even be undefined at a. Limits ask about the neighborhood, not the single point. That is why limits can “see through” removable discontinuities after algebraic simplification.",
            @"\lim_{x\to a}f(x)=L",
            simple: "Ignore the exact point for a moment. What y-value is the graph heading toward as you slide x toward a from nearby?",
            prior: "You need function notation f(x), graphs, and basic algebra (factoring, canceling common factors).")
        .Section("One-sided limits and when two-sided limits fail",
            "Sometimes left and right disagree. The left-hand limit lim_{x→a−} f(x) only uses x < a; the right-hand limit lim_{x→a+} f(x) only uses x > a. For the two-sided limit to exist as a finite number, both one-sided limits must exist and be equal.\n\nClassic example: f(x) = |x|/x. As x→0+, f(x) = 1; as x→0−, f(x) = −1. The two-sided limit does not exist (DNE), even though one-sided limits do.\n\nLimits can also “equal” infinity as a description of unbounded growth: lim_{x→0+} 1/x = +∞ means values grow without bound, not that infinity is a real number output.")
        .Section("Computing limits: direct substitution, algebra, and infinity",
            "For polynomials and rational functions at points in the domain, direct substitution works: plug in a. If you get a nonzero over zero, expect a vertical asymptote / infinite behavior. If you get 0/0, that is indeterminate, factor, conjugate, or simplify, then try again. Canceling a factor (x − a) often reveals a hole: the simplified function matches nearby, so the limit exists even though the original formula was undefined at a.\n\nEnd behavior uses x → ±∞. For rational functions, compare degrees of numerator and denominator to find horizontal asymptotes.",
            simple: "Try plugging in. If you get a normal number, you are done. If you get 0/0, simplify and try again. If you get nonzero/0, think infinite blow-up.")
        .Section("Continuity: limit meets value",
            "A function is continuous at a if three things hold:\n1) f(a) is defined,\n2) lim_{x→a} f(x) exists (finite),\n3) lim_{x→a} f(x) = f(a).\n\nInformally: you can draw the graph through x = a without lifting your pencil. Polynomials are continuous everywhere. Rational functions are continuous wherever the denominator is not zero. Jump discontinuities (one-sided limits differ) and asymptotes break continuity. Removable discontinuities are holes you could “fill in” with a single point to restore continuity.",
            @"\lim_{x\to a}f(x)=f(a)",
            prior: "Limits must already make sense before continuity can be checked, continuity is “limit equals value.”")
        .Formula("Limit notation", @"\lim_{x\to a}f(x)=L", "Outputs approach L as inputs approach a.")
        .Formula("Continuity at a point", @"\lim_{x\to a}f(x)=f(a)", "Limit exists, value exists, and they match.")
        .Example("Direct substitution",
            "Evaluate lim_{x→2} (3x + 1).",
            [
                "f(x) = 3x + 1 is a polynomial, continuous everywhere.",
                "Substitute x = 2: 3(2) + 1 = 7.",
                "No algebra tricks needed, substitution is valid.",
                "Graphically, the line passes through height 7 at x = 2."
            ],
            "The limit is 7.",
            problemLatex: @"\lim_{x\to 2}(3x+1)",
            solutionLatex: @"7",
            stepLatex: [null, @"3(2)+1=7", null, null])
        .Example("Removable hole after factoring",
            "Evaluate lim_{x→1} (x² − 1)/(x − 1).",
            [
                "Direct sub gives (1 − 1)/(1 − 1) = 0/0, indeterminate, not “undefined forever.”",
                "Factor numerator: (x − 1)(x + 1)/(x − 1).",
                "For x ≠ 1, cancel: expression equals x + 1.",
                "Now lim_{x→1} (x + 1) = 2. The original function has a hole at x = 1, but the limit is 2."
            ],
            "Limit is 2 (hole at x = 1).",
            problemLatex: @"\lim_{x\to 1}\frac{x^2-1}{x-1}",
            solutionLatex: @"2",
            stepLatex: [@"\frac{0}{0}", @"\frac{(x-1)(x+1)}{x-1}", @"x+1", @"1+1=2"])
        .Example("Two-sided limit does not exist",
            "Explain lim_{x→0} |x|/x.",
            [
                "For x > 0, |x| = x, so |x|/x = 1. Right-hand limit is 1.",
                "For x < 0, |x| = −x, so |x|/x = −1. Left-hand limit is −1.",
                "Left ≠ right → two-sided limit DNE.",
                "Note: the function is still defined for all x ≠ 0; existence of f(x) nearby does not force the limit to exist."
            ],
            "Does not exist (left 1 vs right −1).",
            problemLatex: @"\lim_{x\to 0}\frac{|x|}{x}",
            solutionLatex: @"\text{DNE}")
        .Example("Infinite one-sided behavior",
            "Describe lim_{x→0+} 1/x.",
            [
                "As x approaches 0 through positive values, 1/x grows without bound: 1/0.1 = 10, 1/0.01 = 100, …",
                "We write lim_{x→0+} 1/x = +∞ as a statement of unbounded increase.",
                "This is not a finite limit; the two-sided limit also fails because the left side goes to −∞.",
                "Graphically: vertical asymptote at x = 0."
            ],
            "Diverges to +∞ (vertical asymptote).",
            solutionLatex: @"+\infty")
        .Mistake("Assuming lim_{x→a} f(x) always equals f(a) (false at discontinuities).")
        .Mistake("Canceling a factor and then claiming the original function is defined at the canceled root.")
        .Mistake("Declaring 0/0 = 0 or 0/0 = 1 instead of simplifying.")
        .Mistake("Saying a two-sided limit exists when left and right disagree.")
        .Numeric("lim_{x→3} (2x + 5) = ?", "11",
            ["Substitute x = 3.", "6 + 5 = 11."],
            "Limit is 11.")
        .Numeric("lim_{x→2} (x² − 4)/(x − 2) = ?", "4",
            ["Factor: (x − 2)(x + 2)/(x − 2) → x + 2.", "At 2: 4."],
            "Limit is 4.")
        .Numeric("lim_{x→0} x/x = ?", "1",
            ["For x ≠ 0 the quotient is 1.", "Limit is 1 even though 0/0 is indeterminate as a form."],
            "Limit is 1.")
        .Mcq("If the left-hand limit ≠ right-hand limit, then:",
            ["The limit is their average", "The two-sided limit DNE", "The limit is always 0", "The limit is always ∞"], 1,
            ["Two-sided limits require matching one-sided limits."],
            "The two-sided limit does not exist.")
        .Numeric("If f is continuous at 1 and f(1) = 4, then lim_{x→1} f(x) = ?", "4",
            ["Continuity means limit equals value."],
            "Limit must be 4.")
        .Numeric("lim_{x→∞} (1/x) = ?", "0",
            ["Values get arbitrarily small."],
            "Limit is 0.")
        .Mcq("Polynomials are continuous:",
            ["Nowhere", "Only at 0", "Everywhere", "Only at integers"], 2,
            ["Standard theorem of calculus / algebra of continuous functions."],
            "Everywhere on the real line.")
        .Numeric("lim_{x→1} (x² + 2x − 3)/(x − 1) = ?", "4",
            ["Factor numerator (x + 3)(x − 1).", "Cancel → x + 3 → 4."],
            "Limit is 4.")
        .Build();

    private static Lesson DerivativeBasics() => new LessonBuilder("calc-deriv", CategoryId, "Derivative Definition, Power Rule & Basic Rules")
        .Subtitle("Instantaneous rate of change, from secant slopes to the tangent line")
        .Order(2).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "The derivative at a point is the slope of the tangent line to y = f(x) there.")
        .Section("From average rate to instantaneous rate",
            "The average rate of change of y = f(x) on [a, a + h] is the secant slope\n[f(a + h) − f(a)] / h.\n\nIf you shrink the gap h toward 0, that secant becomes a better model of the curve’s local steepness. When the limit exists, we call it the derivative of f at a:\nf'(a) = lim_{h→0} [f(a + h) − f(a)] / h.\n\nGeometrically: slope of the tangent line. Physically: if s(t) is position, s'(t) is instantaneous velocity. Economically: marginal cost is a derivative. One idea, many stories.",
            @"f'(x)=\lim_{h\to 0}\frac{f(x+h)-f(x)}{h}",
            simple: "Average speed uses a time interval. Instantaneous speed is what you get when that interval shrinks toward zero, the derivative.",
            prior: "You need limits and the slope formula between two points.")
        .Section("Differentiability vs continuity",
            "If f is differentiable at a (f'(a) exists as a finite number), then f is continuous at a. The converse is false: corners (like |x| at 0) and cusps are continuous but not differentiable. Vertical tangent lines also break differentiability in the finite-slope sense. So “smooth enough for a unique tangent slope” is stricter than “no jump.”")
        .Section("Power rule and the first toolkit",
            "Computing the limit definition every time is educational but slow. Pattern recognition gives rules:\n• Constant rule: d/dx [c] = 0 (horizontal line).\n• Power rule: d/dx [x^n] = n x^{n−1} for any real n (with domain care for non-integer n).\n• Constant multiple: d/dx [c f(x)] = c f'(x).\n• Sum/difference: derivative of a sum is the sum of derivatives.\n\nTogether these differentiate any polynomial in seconds. Always drop the power by one and multiply by the old power, forgetting the “subtract 1” is the #1 power-rule error.",
            @"\frac{d}{dx}x^n=n x^{n-1}",
            simple: "Bring the exponent down in front, then reduce the exponent by one. Constants vanish; coefficients hitch a ride.")
        .Section("Reading f' and writing tangent lines",
            "f'(a) is a number, the slope at x = a. The tangent line is\ny − f(a) = f'(a)(x − a).\n\nThe derivative function f'(x) is a new function giving the slope at every x where it exists. Graphically, where f' > 0 the original function is increasing; where f' < 0 it is decreasing. That bridge leads to the applications lesson.")
        .Formula("Definition of derivative", @"f'(x)=\lim_{h\to 0}\frac{f(x+h)-f(x)}{h}", "Difference quotient limit.")
        .Formula("Power rule", @"\frac{d}{dx}x^n=n x^{n-1}", "Core shortcut for powers.")
        .Formula("Tangent line", @"y-f(a)=f'(a)(x-a)", "Point-slope form at x = a.")
        .Example("Power rule single term",
            "Differentiate x^5.",
            [
                "Identify n = 5.",
                "Power rule: n x^{n−1} = 5x^4.",
                "No other terms to process.",
                "Check mentally: at large positive x, x^5 is steeply rising, and 5x^4 > 0, consistent."
            ],
            "d/dx [x^5] = 5x^4.",
            problemLatex: @"\frac{d}{dx}x^5",
            solutionLatex: @"5x^4",
            stepLatex: [@"n=5", @"5x^{4}", null, null])
        .Example("Polynomial term by term",
            "If f(x) = 3x² − 4x + 7, find f'(x).",
            [
                "Differentiate term by term using constant multiple and power rules.",
                "d/dx [3x²] = 3 · 2x = 6x.",
                "d/dx [−4x] = −4; d/dx [7] = 0.",
                "f'(x) = 6x − 4."
            ],
            "f'(x) = 6x − 4.",
            problemLatex: @"f(x)=3x^2-4x+7",
            solutionLatex: @"f'(x)=6x-4",
            stepLatex: [null, @"6x", @"-4", @"6x-4"])
        .Example("Tangent slope at a point",
            "For f(x) = x², what is the slope of the tangent at x = 3?",
            [
                "First find f'(x). By power rule, f'(x) = 2x.",
                "Evaluate at the point: f'(3) = 6.",
                "So the tangent line through (3, 9) has slope 6: y − 9 = 6(x − 3).",
                "Definition check: [(3+h)² − 9]/h = (6h + h²)/h = 6 + h → 6 as h → 0."
            ],
            "Slope is 6.",
            solutionLatex: @"f'(3)=6")
        .Example("Derivative from the definition",
            "Use the definition to show that if f(x) = x², then f'(x) = 2x.",
            [
                "Form the difference quotient: [f(x+h) − f(x)]/h = [(x+h)² − x²]/h.",
                "Expand: (x² + 2xh + h² − x²)/h = (2xh + h²)/h.",
                "Simplify for h ≠ 0: 2x + h.",
                "Take lim_{h→0}: f'(x) = 2x. This is the power rule’s special case n = 2, proved from scratch."
            ],
            "f'(x) = 2x.",
            problemLatex: @"f(x)=x^2",
            solutionLatex: @"f'(x)=2x",
            stepLatex: [@"\frac{(x+h)^2-x^2}{h}", @"\frac{2xh+h^2}{h}", @"2x+h", @"2x"])
        .Mistake("Writing d/dx [x^n] = n x^n (forgot to subtract 1 from the exponent).")
        .Mistake("Claiming the derivative of a constant is the constant itself instead of 0.")
        .Mistake("Confusing f'(a) (a number) with f'(x) (a function).")
        .Mistake("Thinking continuity automatically implies differentiability.")
        .Numeric("In n x^{n−1} for d/dx [x^3], what is n?", "3",
            ["Power rule coefficient is the old exponent."],
            "n = 3; derivative 3x².")
        .Numeric("If f(x) = x^4, what is f'(2)?", "32",
            ["f' = 4x³.", "4 · 8 = 32."],
            "f'(2) = 32.")
        .Numeric("d/dx [7] = ?", "0",
            ["Constant rule."],
            "0.")
        .Numeric("d/dx [5x] = ?", "5",
            ["Linear function with slope 5."],
            "5.")
        .Numeric("f(x) = x² + 3x. What is f'(1)?", "5",
            ["f' = 2x + 3.", "At 1: 5."],
            "f'(1) = 5.")
        .Mcq("f'(a) represents:",
            ["Only average rate on a big interval", "Tangent slope at x = a", "Area under the curve", "Y-intercept of f"], 1,
            ["Geometric meaning of the derivative."],
            "The slope of the tangent line at a.")
        .Numeric("If f(x) = √x = x^{1/2}, what is f'(4)?", "0.25",
            ["f' = (1/2) x^{-1/2} = 1/(2√x).", "At 4: 1/(2·2) = 1/4."],
            "f'(4) = 0.25.", tolerance: 0.01)
        .Numeric("d/dx [x^7] at x = 1 equals?", "7",
            ["7x^6 at 1 is 7."],
            "7.")
        .Build();

    private static Lesson ProductQuotientChain() => new LessonBuilder("calc-rules", CategoryId, "Product, Quotient & Chain Rules")
        .Subtitle("Products, quotients, and compositions, when simple power rules are not enough")
        .Order(3).Minutes("32 min")
        .Section("Why we need more rules",
            "The sum rule is friendly: derivative of a sum is the sum of derivatives. Products and compositions are not so simple. The derivative of a product is not the product of derivatives, and the derivative of a composition is not merely the outer derivative. Each structure gets its own carefully justified rule from the definition of the derivative.\n\nMemorize them with meaning, not as empty slogans.",
            simple: "Different algebraic shapes need different derivative recipes: product, quotient, and nested functions.")
        .Section("Product rule",
            "If u(x) and v(x) are differentiable, then\n(uv)' = u'v + uv'.\n\nStory: when both factors change, the total change has a part from u changing (with v as is) plus a part from v changing (with u as is). Forgetting either term undercounts the rate.\n\nCheck on x · x = x²: u = v = x, u' = v' = 1 → 1·x + x·1 = 2x, which matches the power rule. That sanity check builds trust.",
            @"(uv)'=u'v+uv'",
            prior: "You need basic derivatives (power rule, constants) before multiplying functions together.")
        .Section("Quotient rule",
            "For v ≠ 0,\n(u/v)' = (u'v − uv') / v².\n\nMemory phrase often taught: “low d-high minus high d-low over low squared.” The minus sign is ordered, swapping it flips the answer’s sign.\n\nAlternative approach: rewrite u/v as u · v^{−1} and use product + chain. Same result, sometimes fewer slips.",
            @"\left(\frac{u}{v}\right)'=\frac{u'v-uv'}{v^2}")
        .Section("Chain rule: the workhorse",
            "If y = f(g(x)), then y' = f'(g(x)) · g'(x).\n\nIn words: derivative of the outside, evaluated at the inside, times derivative of the inside. Every nested structure needs this: (3x + 1)^5, sin(x²), e^{2x}, √(x³ + 1), and combinations thereof.\n\nA practical habit: name the outside and inside explicitly. Outside: (something)^5; inside: 3x + 1. Outside derivative 5(something)^4; multiply by inside derivative 3.\n\nMissing the inner derivative is the most common chain-rule error in the world.",
            @"\frac{d}{dx}f(g(x))=f'(g(x))g'(x)",
            simple: "Peel the onion: differentiate the outer layer, then multiply by how fast the inner layer is changing.")
        .Formula("Product rule", @"(uv)'=u'v+uv'", "Two terms; do not multiply u' by v' alone.")
        .Formula("Quotient rule", @"\left(\frac{u}{v}\right)'=\frac{u'v-uv'}{v^2}", "Order of the subtraction matters.")
        .Formula("Chain rule", @"\frac{d}{dx}f(g(x))=f'(g(x))g'(x)", "Outer times inner.")
        .Example("Product rule that matches a known answer",
            "Differentiate x · x² using the product rule (as practice), and compare to d/dx [x³].",
            [
                "Set u = x, v = x², so u' = 1, v' = 2x.",
                "u'v + uv' = 1 · x² + x · 2x = x² + 2x² = 3x².",
                "Direct power rule on x³ also gives 3x².",
                "Agreement confirms the product rule on a case you already trust."
            ],
            "Result 3x².",
            problemLatex: @"\frac{d}{dx}(x\cdot x^2)",
            solutionLatex: @"3x^2",
            stepLatex: [@"u=x,\;v=x^2", @"1\cdot x^2+x\cdot 2x", @"3x^2", null])
        .Example("Chain rule with a linear inside",
            "Differentiate (5x + 2)^4.",
            [
                "Outside: ( )^4; inside: 5x + 2.",
                "Outer derivative: 4(5x + 2)^3.",
                "Multiply by inner derivative 5: 4(5x + 2)^3 · 5 = 20(5x + 2)^3.",
                "If you forget the ·5, you get an incomplete answer that fails a numerical check."
            ],
            "20(5x + 2)^3.",
            problemLatex: @"\frac{d}{dx}(5x+2)^4",
            solutionLatex: @"20(5x+2)^3",
            stepLatex: [null, @"4(5x+2)^3", @"4(5x+2)^3\cdot 5", @"20(5x+2)^3"])
        .Example("Chain rule with a polynomial inside",
            "Differentiate (x² + 1)^3.",
            [
                "Outer power 3, inner x² + 1.",
                "3(x² + 1)^2 times derivative of inside 2x.",
                "Result: 6x(x² + 1)^2.",
                "Expanded form is optional; factored form is usually better."
            ],
            "6x(x² + 1)^2.",
            solutionLatex: @"6x(x^2+1)^2")
        .Example("Quotient rule",
            "Differentiate x/(x + 1).",
            [
                "u = x, v = x + 1; u' = 1, v' = 1.",
                "Numerator of the derivative: u'v − uv' = 1·(x + 1) − x·1 = x + 1 − x = 1.",
                "Denominator: v² = (x + 1)².",
                "Derivative = 1/(x + 1)²."
            ],
            "1/(x + 1)².",
            problemLatex: @"\frac{d}{dx}\frac{x}{x+1}",
            solutionLatex: @"\frac{1}{(x+1)^2}",
            stepLatex: [@"u=x,\;v=x+1", @"u'v-uv'=1", @"v^2=(x+1)^2", @"\frac{1}{(x+1)^2}"])
        .Mistake("Product rule as u'v' only (missing the cross terms’ correct form).")
        .Mistake("Forgetting the inner derivative in the chain rule.")
        .Mistake("Reversing the order in the quotient rule numerator (sign error).")
        .Mistake("Using chain rule on a non-composition like 3x + 1 (no need, derivative is just 3).")
        .Numeric("d/dx (x · x) at x = 2 equals?", "4",
            ["Derivative is 2x; at 2 is 4."],
            "4.")
        .Numeric("d/dx (3x)^2 at x = 1?", "18",
            ["2(3x)·3 = 18x; at 1 is 18."],
            "18.")
        .Numeric("d/dx (x² + 1)^2 at x = 1?", "8",
            ["2(x² + 1)·2x = 4x(x² + 1); at 1 is 8."],
            "8.")
        .Numeric("For x ≠ 0, x²/x simplifies to x. What is its derivative?", "1",
            ["Simplified function has derivative 1."],
            "1.")
        .Mcq("Which requires the chain rule?",
            ["3x + 1", "(3x + 1)^5", "5", "x + x"], 1,
            ["Composition of a power with a linear function."],
            "(3x + 1)^5.")
        .Numeric("f(x) = √x = x^{1/2}. f'(4) = ?", "0.25",
            ["(1/2)/√x at 4 is 1/4."],
            "0.25.", tolerance: 0.01)
        .Numeric("Product (x + 1)(x + 2) = x² + 3x + 2. Derivative at x = 0?", "3",
            ["2x + 3 at 0 is 3."],
            "3.")
        .Numeric("d/dx [x/(x + 1)] at x = 0?", "1",
            ["Derivative 1/(x + 1)²; at 0 is 1."],
            "1.")
        .Build();

    private static Lesson DerivativeApps() => new LessonBuilder("calc-deriv-apps", CategoryId, "Applications of Derivatives")
        .Subtitle("Optimization, related rates, motion, and reading a graph from f' and f''")
        .Order(4).Minutes("34 min")
        .Visual(VisualKind.LineGraph, "Critical points and the sign of f' reveal where a function rises, falls, and turns.")
        .Section("What the first derivative tells you",
            "On an interval where f' > 0, f is increasing. Where f' < 0, f is decreasing. Critical points in the domain occur where f' = 0 or f' is undefined. They are candidates for local maxima and minima, but not automatic extrema (f' can touch zero without changing sign).\n\nThe first derivative test: if f' changes from + to − at a critical point, local max; from − to +, local min; no sign change means neither (plateau or flat inflection-type critical point).",
            simple: "Positive slope → climbing. Negative slope → descending. Zero slope → pause to check if it is a peak, valley, or flat step.",
            prior: "You need to compute derivatives and solve f'(x) = 0.")
        .Section("Concavity and the second derivative",
            "f'' is the derivative of f'. If f'' > 0, slopes are increasing and the graph is concave up (like a cup). If f'' < 0, concave down (like a frown). An inflection point is where concavity changes.\n\nSecond derivative test: at a critical point with f'(c) = 0, if f''(c) > 0 you have a local min; if f''(c) < 0 a local max; if f''(c) = 0 the test is inconclusive.")
        .Section("Optimization workflow",
            "Applied max/min problems follow a script:\n1) Read carefully; define variables and the quantity Q to optimize.\n2) Write a constraint linking variables (perimeter fixed, sum of sides, similar triangles, etc.).\n3) Reduce Q to a function of one variable.\n4) Find critical points on the realistic domain; check endpoints if the domain is closed.\n5) Interpret the answer with units and common sense.\n\nDiagrams prevent algebra about the wrong quantity.",
            prior: "Algebraic modeling (area, perimeter, product) from earlier courses is the setup; calculus finds the optimal value.")
        .Section("Related rates",
            "When two quantities are linked by an equation and both change with time, differentiate both sides with respect to t (using the chain rule) to relate their rates. Classic settings: expanding circle A = πr², ladder sliding down a wall, conical tank filling.\n\nOrder matters: write the geometric relation first, differentiate second, then plug in the specific numbers at the instant of interest. Plugging numbers before differentiating often destroys the relationship.",
            simple: "Write how the quantities are tied together. Differentiate with respect to time. Only then insert the snapshot values.")
        .Formula("First derivative test idea", @"f'=0\text{ with sign change}\Rightarrow\text{local ext}", "Sign chart classifies critical points.")
        .Formula("Related rates sample", @"\frac{dA}{dt}=2\pi r\frac{dr}{dt}", "From A = πr², differentiate in t.")
        .Example("Fence problem style max area",
            "Maximize A = x(10 − x) for x between 0 and 10.",
            [
                "Expand or differentiate directly: A' = 10 − 2x.",
                "Set A' = 0: x = 5.",
                "A(5) = 5 · 5 = 25. Endpoints A(0) = A(10) = 0.",
                "Second derivative A'' = −2 < 0 confirms a maximum. Max area is 25."
            ],
            "Maximum area 25 at x = 5.",
            problemLatex: @"A=x(10-x)",
            solutionLatex: @"A_{\max}=25",
            stepLatex: [@"A'=10-2x", @"x=5", @"A(5)=25", @"A''=-2"])
        .Example("Particle motion",
            "Position s(t) = t³ − 6t². When is the particle at rest?",
            [
                "Velocity v = s' = 3t² − 12t.",
                "At rest means v = 0: 3t(t − 4) = 0 → t = 0 or t = 4.",
                "You can further study sign of v to see direction of motion on intervals.",
                "Acceleration a = v' = 6t − 12 for finer analysis."
            ],
            "At rest at t = 0 and t = 4.",
            solutionLatex: @"t=0,\;4")
        .Example("Related rates: expanding circle",
            "Area A = πr². If r = 5 and dr/dt = 2, find dA/dt.",
            [
                "Differentiate with respect to t: dA/dt = 2πr dr/dt.",
                "Substitute the instant: r = 5, dr/dt = 2.",
                "dA/dt = 2π·5·2 = 20π.",
                "Units: if r is in meters and t in seconds, dA/dt is m²/s."
            ],
            "dA/dt = 20π.",
            problemLatex: @"A=\pi r^2",
            solutionLatex: @"\frac{dA}{dt}=20\pi",
            stepLatex: [@"\frac{dA}{dt}=2\pi r\frac{dr}{dt}", @"2\pi\cdot 5\cdot 2", @"20\pi", null])
        .Example("Concavity language",
            "What does f''(x) > 0 tell you about the graph of f?",
            [
                "f'' > 0 means f' is increasing, slopes become less negative or more positive.",
                "The graph bends upward: concave up, like a smile or a cup holding water.",
                "This does not by itself say whether f is increasing or decreasing; that is f''s job via f'.",
                "Example: f(x) = x² has f'' = 2 > 0 everywhere and is a classic concave-up parabola."
            ],
            "The graph is concave up on that interval.")
        .Mistake("Reporting a critical x-value without classifying max/min/neither or checking endpoints.")
        .Mistake("Plugging related-rates numbers before differentiating.")
        .Mistake("Confusing “f' = 0” with “global maximum” on an unbounded domain.")
        .Mistake("Mixing up concave up (f'' > 0) with increasing (f' > 0).")
        .Numeric("f' = 2x − 8 = 0. Critical x?", "4",
            ["2x = 8."],
            "x = 4.")
        .Numeric("A = x(20 − x). x that maximizes A?", "10",
            ["A' = 20 − 2x = 0."],
            "x = 10.")
        .Numeric("Max value of A = x(20 − x)?", "100",
            ["At x = 10: 10·10 = 100."],
            "100.")
        .Numeric("A = πr², r = 3, dr/dt = 1. What is (dA/dt)/π ?", "6",
            ["dA/dt = 2πr dr/dt = 6π.", "Divide by π: 6."],
            "6.")
        .Mcq("If f' > 0 on an interval, then f is:",
            ["Constant", "Increasing", "Decreasing", "Concave down only"], 1,
            ["First derivative sign chart."],
            "Increasing.")
        .Numeric("s = t². Velocity v = s' at t = 5?", "10",
            ["v = 2t."],
            "10.")
        .Numeric("f(x) = x³. What is f''(1)?", "6",
            ["f' = 3x², f'' = 6x, at 1 is 6."],
            "6.")
        .Numeric("For A = x(10 − x), A''(x) = ?", "-2",
            ["A' = 10 − 2x, A'' = −2."],
            "−2.")
        .Build();

    private static Lesson Antiderivatives() => new LessonBuilder("calc-antideriv", CategoryId, "Antiderivatives & Indefinite Integrals")
        .Subtitle("Undo differentiation, and never forget +C")
        .Order(5).Minutes("28 min")
        .Section("Running differentiation in reverse",
            "A function F is an antiderivative of f on an interval if F'(x) = f(x) for every x in that interval. Example: both x² and x² + 7 have derivative 2x, so both are antiderivatives of 2x.\n\nIn general, if F is one antiderivative, the complete family is F(x) + C for constant C, because the derivative of a constant is zero. The indefinite integral notation\n∫ f(x) dx = F(x) + C\nnames that entire family. The +C is not optional decoration; different initial conditions pick different members of the family.",
            @"\int f(x)\,dx=F(x)+C",
            simple: "Ask: what function, when differentiated, gives me this? Then remember a whole vertical family differs by a constant.",
            prior: "You need to be fluent with basic derivative rules so you can reverse them.")
        .Section("Power rule for integrals",
            "Reverse of d/dx [x^{n+1}/(n+1)] = x^n gives, for n ≠ −1,\n∫ x^n dx = x^{n+1}/(n+1) + C.\n\nAlso:\n• ∫ k f(x) dx = k ∫ f(x) dx\n• ∫ (f + g) = ∫ f + ∫ g\n\nThe case n = −1 is special: ∫ x^{−1} dx = ∫ (1/x) dx = ln|x| + C, which appears later when logs are in view. For this lesson’s core drills, focus on n ≠ −1 and polynomials.",
            @"\int x^n\,dx=\frac{x^{n+1}}{n+1}+C\;(n\neq -1)")
        .Section("Always check by differentiating",
            "The cheapest insurance in integral calculus: differentiate your answer. You should recover the integrand exactly. If you get something else, fix the antiderivative before moving on. This habit catches off-by-one exponent errors and missing coefficients.")
        .Section("Initial conditions pick C",
            "If F'(x) = f(x) and F(x0) = y0, first find the general antiderivative F(x) = G(x) + C, then solve G(x0) + C = y0 for C. That is how motion problems turn acceleration into velocity into position when you know starting data.")
        .Formula("Power integral", @"\int x^n\,dx=\frac{x^{n+1}}{n+1}+C\;(n\neq -1)", "Reverse power rule.")
        .Formula("Family of antiderivatives", @"\int f=F+C", "Constants disappear under differentiation.")
        .Example("Undo a simple power",
            "Find ∫ 3x² dx.",
            [
                "Guess: something like x³ should differentiate to 3x².",
                "Indeed d/dx [x³] = 3x².",
                "Include the constant: x³ + C.",
                "Check: derivative of x³ + C is 3x²."
            ],
            "x³ + C.",
            problemLatex: @"\int 3x^2\,dx",
            solutionLatex: @"x^3+C",
            stepLatex: [null, @"\frac{d}{dx}x^3=3x^2", @"x^3+C", null])
        .Example("Power rule with fractional coefficient",
            "Find ∫ x³ dx.",
            [
                "Raise exponent: x^4.",
                "Divide by new exponent 4: x^4/4.",
                "Add C: x^4/4 + C.",
                "Check: d/dx [x^4/4] = 4x³/4 = x³."
            ],
            "x⁴/4 + C.",
            solutionLatex: @"\frac{x^4}{4}+C")
        .Example("Sum of terms",
            "Find ∫ (2x + 5) dx.",
            [
                "Integrate termwise: ∫ 2x dx + ∫ 5 dx.",
                "∫ 2x dx = x²; ∫ 5 dx = 5x.",
                "Result x² + 5x + C (one constant is enough for the sum).",
                "Check: 2x + 5."
            ],
            "x² + 5x + C.",
            problemLatex: @"\int(2x+5)\,dx",
            solutionLatex: @"x^2+5x+C",
            stepLatex: [null, @"x^2+5x", @"x^2+5x+C", null])
        .Example("Initial condition",
            "Find F if F'(x) = 2x and F(0) = 3.",
            [
                "General antiderivative: F(x) = x² + C.",
                "Use F(0) = 3: 0 + C = 3 → C = 3.",
                "Particular solution F(x) = x² + 3.",
                "Check: F' = 2x and F(0) = 3."
            ],
            "F(x) = x² + 3.",
            solutionLatex: @"x^2+3")
        .Mistake("Dropping +C on indefinite integrals.")
        .Mistake("Using the derivative power rule n x^{n−1} when you meant to integrate.")
        .Mistake("Writing ∫ x^n dx = x^{n+1} without dividing by n + 1.")
        .Mistake("Adding a new +C for every term instead of one family constant (harmless but cluttered), or worse, assigning different meanings to multiple C’s inconsistently.")
        .Numeric("∫ 6x dx. Coefficient of x² in the antiderivative (before C)?", "3",
            ["6 · x²/2 = 3x²."],
            "3.")
        .Numeric("∫ x dx. Coefficient of x²?", "0.5",
            ["x²/2."],
            "0.5.", tolerance: 0.01)
        .Numeric("∫ 4 dx. Coefficient of x?", "4",
            ["4x + C."],
            "4.")
        .Numeric("If F(x) = x³ + C and F(1) = 2, what is C?", "1",
            ["1 + C = 2."],
            "C = 1.")
        .Mcq("An indefinite integral represents:",
            ["Exactly one function", "A +C family of antiderivatives", "Only a definite number", "No functions"], 1,
            ["Definition of indefinite integral."],
            "The family F(x) + C.")
        .Numeric("∫ 0 dx is a constant C. What is d/dx of that constant?", "0",
            ["Derivative of constant is 0, checks out."],
            "0.")
        .Numeric("∫ 5x^4 dx produces a multiple of x^k. What is k?", "5",
            ["Raise 4 by 1."],
            "Power 5: x^5 + C after coefficient adjust.")
        .Numeric("∫ (3x² + 2) dx has linear coefficient (for x term) equal to?", "2",
            ["∫ 2 dx = 2x."],
            "2.")
        .Build();

    private static Lesson DefiniteIntegrals() => new LessonBuilder("calc-definite", CategoryId, "Definite Integrals & Fundamental Theorem")
        .Subtitle("Signed area under a curve, and why derivatives and integrals are inverses")
        .Order(6).Minutes("32 min")
        .Visual(VisualKind.IntegralArea, "A definite integral measures net signed area between y = f(x) and the x-axis from x = a to x = b.")
        .Section("Area as a limit of sums",
            "To estimate area under y = f(x) from a to b, slice [a, b] into thin rectangles, add f(x_i*) Δx, and refine the partition. The limiting sum (when it exists) is the definite integral ∫_a^b f(x) dx.\n\nImportant: the integral records signed area. Above the x-axis contributes positively; below contributes negatively. Net area can be zero even when geometric area is not (equal lobes cancel).",
            @"\int_a^b f(x)\,dx",
            simple: "Add up lots of thin “height times width” pieces. The integral is the perfect limiting total, with signs.",
            prior: "You need the idea of area and the antiderivative skill from the previous lesson.")
        .Section("The Fundamental Theorem of Calculus (FTC)",
            "Two linked statements make calculus a superpower.\n\nFTC evaluation form: if F' = f and f is continuous on [a, b], then\n∫_a^b f(x) dx = F(b) − F(a).\nYou compute area by undoing a derivative and evaluating at endpoints, no infinite rectangle sum by hand.\n\nFTC derivative form: d/dx ∫_a^x f(t) dt = f(x). Accumulated area from a fixed lower limit up to x has rate of growth equal to the integrand’s height at x.",
            @"\int_a^b f(x)\,dx=F(b)-F(a)",
            simple: "Find any antiderivative, plug in the top, subtract what you get at the bottom.")
        .Section("Properties you will use constantly",
            "• ∫_a^b f = −∫_b^a f (swapping bounds flips sign)\n• ∫_a^a f = 0 (zero width)\n• ∫_a^b f + ∫_b^c f = ∫_a^c f (additivity on adjacent intervals)\n• ∫ (kf + g) = k∫ f + ∫ g (linearity)\n\nThese let you split integrals at roots, factor constants, and reverse limits cleanly.")
        .Section("Net area vs total area",
            "If a problem asks for total geometric area between the curve and the axis, split where f changes sign and add absolute contributions. The plain definite integral without absolute values only gives net signed area. Word problems usually say which they want, read carefully.")
        .Formula("FTC (evaluation)", @"\int_a^b f(x)\,dx=F(b)-F(a)", "Antiderivative at bounds.")
        .Formula("FTC (derivative of accumulation)", @"\frac{d}{dx}\int_a^x f(t)\,dt=f(x)", "Rate of accumulated area.")
        .Example("Evaluate with FTC",
            "Compute ∫_0^2 3x² dx.",
            [
                "Antiderivative of 3x² is x³ (because d/dx x³ = 3x²).",
                "Evaluate F(2) − F(0) = 8 − 0 = 8.",
                "Notation: [x³]_0^2 = 8.",
                "Check roughly: average height of 3x² on [0, 2] is positive and area 8 is plausible."
            ],
            "Value 8.",
            problemLatex: @"\int_0^2 3x^2\,dx",
            solutionLatex: @"8",
            stepLatex: [@"F=x^3", @"F(2)-F(0)=8", null, null])
        .Example("Another polynomial area",
            "Compute ∫_1^3 2x dx.",
            [
                "Antiderivative x².",
                "[x²]_1^3 = 9 − 1 = 8.",
                "Graphically: under the line y = 2x from 1 to 3 is a trapezoid of area 8.",
                "Matches FTC."
            ],
            "8.",
            solutionLatex: @"8")
        .Example("Canceling signed areas",
            "Compute ∫_{−1}^{1} x dx.",
            [
                "Antiderivative x²/2.",
                "[x²/2]_{−1}^{1} = 1/2 − 1/2 = 0.",
                "The triangle above the axis on [0, 1] cancels the triangle below on [−1, 0].",
                "Net signed area is 0; total geometric area would be 1."
            ],
            "0 (net area).",
            problemLatex: @"\int_{-1}^{1}x\,dx",
            solutionLatex: @"0",
            stepLatex: [@"F=\frac{x^2}{2}", @"\frac{1}{2}-\frac{1}{2}=0", null, null])
        .Example("Derivative under an integral sign",
            "Evaluate d/dx ∫_0^x cos t dt.",
            [
                "By FTC, the derivative of the integral from a constant to x is the integrand evaluated at x.",
                "Here the integrand is cos t, so the result is cos x.",
                "Optional check: ∫_0^x cos t dt = sin x − sin 0 = sin x, and d/dx sin x = cos x.",
                "Both paths agree."
            ],
            "cos x.",
            problemLatex: @"\frac{d}{dx}\int_0^x\cos t\,dt",
            solutionLatex: @"\cos x")
        .Mistake("Reversing F(b) − F(a) or dropping a minus sign at a negative lower limit.")
        .Mistake("Confusing net signed area with total geometric area.")
        .Mistake("Differentiating the antiderivative but forgetting to evaluate at bounds for a definite integral.")
        .Mistake("Using an antiderivative that is invalid on the whole interval (watch absolute values / domain).")
        .Numeric("∫_0^1 2x dx = ?", "1",
            ["[x²]_0^1 = 1."],
            "1.")
        .Numeric("∫_0^3 1 dx = ?", "3",
            ["Height 1 times width 3."],
            "3.")
        .Numeric("∫_2^2 f(x) dx = ?", "0",
            ["Zero width interval."],
            "0.")
        .Numeric("∫_0^2 x dx = ?", "2",
            ["[x²/2]_0^2 = 2."],
            "2.")
        .Mcq("The Fundamental Theorem connects:",
            ["Limits only to infinite series", "Derivatives and integrals", "Only algebra to geometry", "Trig to logarithms only"], 1,
            ["Core theorem of calculus."],
            "Derivatives and integrals.")
        .Numeric("∫_1^4 3 dx = ?", "9",
            ["3 · (4 − 1) = 9."],
            "9.")
        .Numeric("∫_0^1 x² dx = 1/k. What is k?", "3",
            ["[x³/3]_0^1 = 1/3."],
            "k = 3.")
        .Numeric("∫_0^2 4x dx = ?", "8",
            ["[2x²]_0^2 = 8."],
            "8.")
        .Build();

    private static Lesson IntegrationTechniques() => new LessonBuilder("calc-techniques", CategoryId, "Integration Techniques & Area/Volume Apps")
        .Subtitle("u-substitution, integration by parts, and geometric applications of integrals")
        .Order(7).Minutes("34 min")
        .Visual(VisualKind.IntegralArea, "Substitution rewrites a complicated integral into a form you already know how to finish.")
        .Section("u-substitution: reverse the chain rule",
            "The chain rule says d/dx F(g(x)) = F'(g(x)) g'(x). Running that backward: if you see an integrand that looks like f(g(x)) g'(x), set u = g(x) so du = g'(x) dx, and convert to ∫ f(u) du.\n\nAfter integrating in u, either substitute back to x (indefinite) or change the limits to u-values (definite), do not mix x-limits with a u-integrand.\n\nPattern recognition tip: the “inside” function’s derivative should be sitting next to it, up to a constant factor you can adjust.",
            @"\int f(g(x))g'(x)\,dx=\int f(u)\,du",
            simple: "Name the inside chunk u. Rewrite everything, including dx, in terms of u. Integrate the simpler problem.",
            prior: "You need the chain rule and basic antiderivatives (powers, etc.).")
        .Section("Integration by parts: reverse the product rule",
            "The product rule (uv)' = u'v + uv' rearranges to u dv = d(uv) − v du. Integrating yields\n∫ u dv = uv − ∫ v du.\n\nChoose u as something that simplifies when differentiated (often polynomials), and dv as something easy to integrate. The LIATE heuristic (Log, Inverse trig, Algebraic, Trig, Exponential) is a starting suggestion for picking u, not a law of nature. After one parts step, you should have a simpler integral.",
            @"\int u\,dv=uv-\int v\,du")
        .Section("Area between curves and solid volumes",
            "Area between y = f(x) and y = g(x) from a to b (with f ≥ g) is ∫_a^b [f(x) − g(x)] dx, top minus bottom.\n\nDisk method: rotate a region about an axis; cross-sections are disks of radius R(x), volume ∫ π [R(x)]² dx. Washers subtract an inner hole: π(R_outer² − R_inner²). Shells use circumference × height × thickness. These applications show that integrals are not only “area under a curve” but accumulated cross-sectional measure in general.")
        .Section("Strategy when stuck",
            "Ask: Is there an inside function whose derivative is present? → substitution. Is the integrand a product of two very different types? → parts. Can algebra simplify first (expand, long divide, trig identity)? Do that before heavy machinery. And always differentiate your indefinite answer to check.")
        .Formula("Substitution", @"\int f(g(x))g'(x)\,dx=\int f(u)\,du", "Chain rule in reverse.")
        .Formula("Integration by parts", @"\int u\,dv=uv-\int v\,du", "Product rule in reverse.")
        .Formula("Disk volume", @"V=\int_a^b \pi [R(x)]^2\,dx", "Solid of revolution with solid disks.")
        .Example("Classic u-substitution",
            "Find ∫ 2x (x² + 1)^3 dx.",
            [
                "Inside: u = x² + 1. Then du = 2x dx, exactly the factor present.",
                "Integral becomes ∫ u³ du.",
                "Integrate: u^4/4 + C.",
                "Back-substitute: (x² + 1)^4 / 4 + C. Check by chain rule differentiation."
            ],
            "(x² + 1)^4 / 4 + C.",
            problemLatex: @"\int 2x(x^2+1)^3\,dx",
            solutionLatex: @"\frac{(x^2+1)^4}{4}+C",
            stepLatex: [@"u=x^2+1,\;du=2x\,dx", @"\int u^3\,du", @"\frac{u^4}{4}+C", @"\frac{(x^2+1)^4}{4}+C"])
        .Example("Definite integral with substitution",
            "Evaluate ∫_0^1 2x(x² + 1) dx using u-sub and changing limits.",
            [
                "u = x² + 1, du = 2x dx.",
                "When x = 0, u = 1; when x = 1, u = 2.",
                "∫_1^2 u du = [u²/2]_1^2 = 2 − 1/2 = 3/2.",
                "If you forget to change limits and plug x-bounds into a u-antiderivative, you get nonsense, a common error."
            ],
            "3/2.",
            problemLatex: @"\int_0^1 2x(x^2+1)\,dx",
            solutionLatex: @"\frac{3}{2}",
            stepLatex: [@"u=x^2+1", @"x:0\to 1\Rightarrow u:1\to 2", @"\int_1^2 u\,du=\frac{3}{2}", null])
        .Example("Integration by parts setup",
            "Find ∫ x e^x dx.",
            [
                "Choose u = x (algebraic; derivative simplifies), dv = e^x dx.",
                "Then du = dx, v = e^x.",
                "∫ u dv = uv − ∫ v du = x e^x − ∫ e^x dx = x e^x − e^x + C.",
                "Factor: e^x (x − 1) + C. Differentiate to verify: product rule recovers x e^x."
            ],
            "e^x (x − 1) + C.",
            problemLatex: @"\int x e^x\,dx",
            solutionLatex: @"e^x(x-1)+C",
            stepLatex: [@"u=x,\;dv=e^x\,dx", @"du=dx,\;v=e^x", @"xe^x-\int e^x\,dx", @"e^x(x-1)+C"])
        .Example("Area as a definite integral",
            "Find the area under y = x from 0 to 2.",
            [
                "Area = ∫_0^2 x dx.",
                "Antiderivative x²/2; evaluate: 2 − 0 = 2.",
                "Geometry check: triangle with base 2 and height 2 has area (1/2)·2·2 = 2.",
                "Integral and geometry agree."
            ],
            "Area is 2.",
            solutionLatex: @"2")
        .Mistake("Forgetting to convert the entire dx factor into du (partial substitution).")
        .Mistake("Keeping x-limits while the integrand is written in u.")
        .Mistake("Choosing u and dv in parts so that ∫ v du is harder than the original integral.")
        .Mistake("Using top − bottom area formula without checking which curve is actually on top.")
        .Numeric("d/dx [sin(x²)] at x = 0? (chain rule check often paired with sub)", "0",
            ["cos(x²)·2x; at 0 is 0."],
            "0.")
        .Numeric("∫_0^2 π x² dx divided by π equals?", "2.667",
            ["[x³/3]_0^2 = 8/3 ≈ 2.667."],
            "8/3 ≈ 2.667.", tolerance: 0.02)
        .Numeric("Area under y = 3 from x = 1 to x = 4?", "9",
            ["3 · 3 = 9."],
            "9.")
        .Numeric("If u = x³ + 1, du = k x² dx. What is k?", "3",
            ["du = 3x² dx."],
            "3.")
        .Mcq("Integration by parts reverses which rule?",
            ["Chain rule", "Product rule", "Quotient rule only", "Intermediate value theorem"], 1,
            ["Product rule rearranged and integrated."],
            "Product rule.")
        .Numeric("∫_0^1 1 dx (area of unit square) = ?", "1",
            ["Rectangle height 1 width 1."],
            "1.")
        .Numeric("V = ∫_0^1 π (1)² dx, then V/π = ?", "1",
            ["Cylinder radius 1 height 1; volume π, so V/π = 1."],
            "1.")
        .Numeric("∫ 3x² (x³ + 5)^4 dx after u = x³ + 5 becomes ∫ u^4 du. True antiderivative coefficient of u^5 is 1/k. k=?", "5",
            ["∫ u^4 = u^5/5."],
            "k = 5.")
        .Build();
}
