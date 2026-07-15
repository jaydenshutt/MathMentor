using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class CalculusExtraLessons
{
    public const string CategoryId = "calc-advanced";

    public static Category Build()
    {
        var lessons = new[]
        {
            ImplicitDiff(),
            RelatedRatesDeep(),
            PartialFractions(),
            DiffEqIntro()
        };
        return new Category(CategoryId, "Calculus Extensions",
            "Implicit differentiation, related rates depth, partial fractions, and differential equations intro.",
            "\uE9F9", 17, lessons);
    }

    private static Lesson ImplicitDiff() => new LessonBuilder("calc-implicit", CategoryId, "Implicit Differentiation")
        .Subtitle("Differentiate equations that do not solve for y, treating y as a function of x")
        .Order(1).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "Circles and other implicit curves still have tangent slopes dy/dx.")
        .Section("Explicit versus implicit",
            "An explicit formula y = f(x) already isolates y. Many curves are given implicitly by an equation F(x, y) = 0, such as x² + y² = 25. You could solve for y = ±√(25 − x²) in pieces, but differentiating the original equation is often cleaner.\n\nImplicit differentiation assumes y is a differentiable function of x near the point of interest, then differentiates both sides with respect to x using the chain rule on every y term.",
            simple: "Do not solve for y first if it is messy. Differentiate the whole equation and solve for dy/dx at the end.",
            prior: "Power rule, product rule, and chain rule for compositions.")
        .Section("The chain rule on y terms",
            "Whenever you differentiate a function of y with respect to x, multiply by dy/dx. Examples:\n• d/dx [y²] = 2y dy/dx\n• d/dx [sin y] = cos(y) · dy/dx\n• d/dx [x y] = x dy/dx + y (product rule)\n\nAfter differentiating both sides, collect every term that has dy/dx on one side and factor dy/dx out. Divide to isolate dy/dx.",
            @"\frac{d}{dx}[y^2]=2y\frac{dy}{dx}",
            simple: "y is not a constant. Every y-power or y-function needs a dy/dx factor from the chain rule.",
            prior: "Chain rule practice on (something)ⁿ and products.")
        .Section("Tangent lines on implicit curves",
            "At a point (x₀, y₀) on the curve, plug x₀ and y₀ into the formula for dy/dx to get the slope, then use point-slope form. If the denominator of dy/dx is zero while the numerator is not, the tangent is vertical. If both are zero, the derivative may fail (singular point); the problem may need a different analysis.")
        .Section("Second derivatives (preview)",
            "To find d²y/dx², differentiate the expression for dy/dx again implicitly, then substitute dy/dx where it appears so the second derivative is in terms of x and y only. This lesson’s core drills focus on first derivatives.")
        .Section("Related idea: logarithmic differentiation",
            "For complicated products/quotients/powers, taking ln of both sides and differentiating implicitly can be efficient. That is a cousin of the same chain-rule mindset.")
        .Section("Check by solving when easy",
            "On x² + y² = r², implicit differentiation gives dy/dx = −x/y (y ≠ 0). Solving the upper semicircle y = √(r² − x²) and differentiating with the chain rule matches that formula. Checks build confidence.")
        .Formula("Circle slope", @"x^2+y^2=r^2\Rightarrow\frac{dy}{dx}=-\frac{x}{y}", "y ≠ 0.")
        .Formula("Product with y", @"\frac{d}{dx}[xy]=x\frac{dy}{dx}+y", "Product rule plus chain rule.")
        .Example("Differentiate a circle",
            "Given x² + y² = 25, find dy/dx.",
            [
                "Differentiate both sides in x: 2x + 2y dy/dx = 0.",
                "2y dy/dx = −2x.",
                "dy/dx = −x/y (if y ≠ 0).",
                "At (3, 4) on the circle, slope = −3/4."
            ],
            "dy/dx = −x/y.",
            problemLatex: @"x^2+y^2=25",
            solutionLatex: @"\frac{dy}{dx}=-\frac{x}{y}",
            stepLatex: [@"2x+2y y'=0", @"2y y'=-2x", @"y'=-x/y", @"y'(3,4)=-3/4"])
        .Example("Product term",
            "Differentiate x y + y³ = 7 with respect to x and solve for dy/dx.",
            [
                "Product on x y: y + x dy/dx.",
                "Plus 3y² dy/dx = 0 (right side constant).",
                "x dy/dx + 3y² dy/dx = −y.",
                "dy/dx = −y / (x + 3y²)."
            ],
            "dy/dx = −y/(x + 3y²).",
            solutionLatex: @"\frac{dy}{dx}=-\frac{y}{x+3y^2}")
        .Example("Tangent line",
            "For x² + y² = 25 at (3, −4), write the tangent line.",
            [
                "Slope dy/dx = −x/y = −3/(−4) = 3/4.",
                "Point-slope: y + 4 = (3/4)(x − 3).",
                "Optional standard form: 3x − 4y = 25 (check with the point).",
                "Note (3, −4) is on the lower half; slope positive there."
            ],
            "y + 4 = (3/4)(x − 3).",
            solutionLatex: @"y+4=\frac{3}{4}(x-3)")
        .Example("Where is the tangent horizontal?",
            "On x² + y² = 25, where is dy/dx = 0?",
            [
                "dy/dx = −x/y = 0 when numerator is 0 and denominator ≠ 0.",
                "−x = 0 ⇒ x = 0, with y ≠ 0.",
                "On the circle, (0, 5) and (0, −5).",
                "Those are the top and bottom points; tangent is horizontal."
            ],
            "At (0, 5) and (0, −5).",
            solutionLatex: @"(0,5),\;(0,-5)")
        .Mistake("Treating y as a constant so d/dx[y²] becomes 0.")
        .Mistake("Forgetting the product rule on terms like x y or x² y.")
        .Mistake("Stopping after differentiating and never solving for dy/dx.")
        .Mistake("Plugging a point that is not on the curve into the slope formula.")
        .Numeric("From 2x + 2y y' = 0 with x = 1, y = 2, y' = ?", "-0.5",
            ["2(1) + 2(2)y' = 0 ⇒ 2 + 4y' = 0 ⇒ y' = −1/2."],
            "−0.5.", tolerance: 0.01, explanationLatex: @"-\frac{1}{2}")
        .Numeric("On x² + y² = 25 at (0, 5), dy/dx = ?", "0",
            ["−x/y = 0."],
            "0.", explanationLatex: @"0")
        .Numeric("On x² + y² = 25 at (5, 0), the tangent is vertical. Enter 1 if true, 0 if false.", "1",
            ["y = 0 makes −x/y undefined; vertical tangent."],
            "True (1).", explanationLatex: @"1")
        .Mcq("d/dx [y³] equals:",
            ["3y²", "3y² dy/dx", "3y", "0"], 1,
            ["Chain rule in x."],
            "3y² dy/dx.")
        .Numeric("If y + x y' = 0 and y = 4, x = 2, then y' = ?", "-2",
            ["4 + 2 y' = 0 ⇒ y' = −2."],
            "−2.", explanationLatex: @"-2")
        .Mcq("Implicit differentiation is most helpful when:",
            ["y is already isolated simply", "the relation mixes x and y in a hard-to-solve way", "you only need limits", "integrals only"], 1,
            ["Avoid solving for y explicitly."],
            "Hard-to-solve relations.")
        .Numeric("d/dx [x²] in the equation x² + y² = 1 contributes what coefficient of x after dividing by 2? (the term before y')", "1",
            ["2x becomes x after dividing the whole differentiated equation by 2."],
            "Think of x + y y' = 0; coefficient of bare x is 1.", explanationLatex: @"1")
        .Numeric("At (3, 4) on x² + y² = 25, slope −x/y = ?", "-0.75",
            ["−3/4 = −0.75."],
            "−0.75.", tolerance: 0.01, explanationLatex: @"-\frac{3}{4}")
        .Build();

    private static Lesson RelatedRatesDeep() => new LessonBuilder("calc-related-rates", CategoryId, "Related Rates Deep Dive")
        .Subtitle("Link changing quantities with geometry, differentiate in time, then plug the snapshot")
        .Order(2).Minutes("34 min")
        .Visual(VisualKind.LineGraph, "One equation can relate two rates when both quantities depend on time.")
        .Section("The related rates script",
            "Related rates problems share a reliable workflow:\n1) Draw and label a diagram with variables for changing quantities.\n2) Write a geometric or algebraic relation that is always true (not only at one instant).\n3) Differentiate both sides with respect to time t, using the chain rule.\n4) Only then substitute the specific values at the instant of interest.\n5) Solve for the unknown rate; include units and sign (increasing/decreasing).\n\nThe deadly habit is inserting a changing length as a constant before differentiating, which destroys the relationship.",
            simple: "Relate, differentiate, then plug in. Never plug the snapshot numbers in too early.",
            prior: "Implicit differentiation and basic geometric formulas (area, Pythagoras, similar triangles).")
        .Section("Similar triangles and sliding ladders",
            "A ladder of fixed length L leaning on a wall satisfies x² + y² = L². Differentiate: 2x dx/dt + 2y dy/dt = 0. If the foot slides away (dx/dt > 0), the top slides down (dy/dt < 0).\n\nShadow problems and cone-filling problems often use similar triangles: ratios of sides stay equal as the figure grows, giving a relation among variables before any derivatives.")
        .Section("Expanding shapes",
            "Circle: A = π r² ⇒ dA/dt = 2π r dr/dt.\nSphere surface/volume and cube edges follow the same idea: differentiate the geometric formula in t.\n\nAsk what is given (a rate) and what is asked (another rate) at a stated size.")
        .Section("Multiple variables and constraints",
            "Sometimes three variables appear. Use the constraint to eliminate one variable before or after differentiating. Similar triangles often reduce two lengths to one free variable.")
        .Section("Units and interpretation",
            "If length is meters and time seconds, dx/dt is m/s and dA/dt is m²/s. Negative rates mean decrease. Word answers should say “the top is sliding down at … m/s.”")
        .Section("Sanity checks",
            "Does the sign match the story? Is the magnitude plausible? If the ladder foot is far out and barely moving, the top can move quickly near the ground: related rates can surprise intuition, but algebra does not lie.")
        .Formula("Ladder relation", @"x^2+y^2=L^2", "Differentiate in t afterward.")
        .Formula("Circle area rate", @"\frac{dA}{dt}=2\pi r\frac{dr}{dt}", "From A = π r².")
        .Example("Expanding circle",
            "Oil spreads in a circle. When r = 10 m, dr/dt = 0.5 m/s. Find dA/dt.",
            [
                "A = π r² always.",
                "dA/dt = 2π r dr/dt.",
                "Plug in: 2π · 10 · 0.5 = 10π m²/s.",
                "Area increases at 10π square meters per second."
            ],
            "dA/dt = 10π m²/s.",
            problemLatex: @"A=\pi r^2",
            solutionLatex: @"\frac{dA}{dt}=10\pi",
            stepLatex: [null, @"2\pi r r'", @"2\pi\cdot 10\cdot 0.5", @"10\pi"])
        .Example("Sliding ladder",
            "A 13 ft ladder leans on a wall. Foot is 5 ft from the wall and sliding away at 2 ft/s. How fast is the top sliding down?",
            [
                "x² + y² = 169. When x = 5, y = 12 (5-12-13 triangle).",
                "2x dx/dt + 2y dy/dt = 0 ⇒ x dx/dt + y dy/dt = 0.",
                "5·2 + 12 dy/dt = 0 ⇒ dy/dt = −10/12 = −5/6 ft/s.",
                "Top descends at 5/6 ft/s."
            ],
            "dy/dt = −5/6 ft/s.",
            solutionLatex: @"\frac{dy}{dt}=-\frac{5}{6}")
        .Example("Similar triangles shadow",
            "A 6 ft person walks away from a 15 ft lamppost at 4 ft/s. Let s be the tip of the shadow from the post base and x the person’s distance from the post. Using similarity carefully is required; here practice the structure: 15/s = 6/(s − x) leads after algebra to a linear relation between s and x, then differentiate.",
            [
                "From 15/s = 6/(s − x), cross-multiply: 15(s − x) = 6s.",
                "15s − 15x = 6s ⇒ 9s = 15x ⇒ s = (15/9)x = (5/3)x.",
                "ds/dt = (5/3) dx/dt = (5/3)·4 = 20/3 ft/s.",
                "The shadow tip moves away from the post at 20/3 ft/s when the person walks at 4 ft/s."
            ],
            "ds/dt = 20/3 ft/s.",
            solutionLatex: @"\frac{ds}{dt}=\frac{20}{3}")
        .Example("Cone volume rate",
            "Water drains from a conical tank. V = (1/3)π r² h. Suppose similarity gives r = h/2 always. Express V in one variable and relate dV/dt to dh/dt.",
            [
                "r = h/2 ⇒ V = (1/3)π (h/2)² h = (1/3)π h³/4 = π h³/12.",
                "dV/dt = (π/12)·3 h² dh/dt = (π/4) h² dh/dt.",
                "Given a numeric dV/dt and h, solve for dh/dt.",
                "The key was eliminating r with the similarity constraint before differentiating."
            ],
            "dV/dt = (π/4) h² dh/dt.",
            solutionLatex: @"\frac{dV}{dt}=\frac{\pi}{4}h^2\frac{dh}{dt}")
        .Mistake("Substituting a specific x or r before differentiating the general relation.")
        .Mistake("Forgetting units or the sign of a decreasing quantity.")
        .Mistake("Using the wrong geometric formula for the figure.")
        .Mistake("Differentiating constants that are truly fixed (like ladder length) incorrectly as if they vary.")
        .Numeric("A = π r², r = 2, dr/dt = 3. (dA/dt)/π = ?", "12",
            ["dA/dt = 2π r dr/dt = 12π."],
            "12.", explanationLatex: @"12")
        .Numeric("x² + y² = 25, x = 3, y = 4, dx/dt = 2. Then 3·2 + 4 dy/dt = 0. dy/dt = ?", "-1.5",
            ["6 + 4 y' = 0 ⇒ y' = −1.5."],
            "−1.5.", tolerance: 0.01, explanationLatex: @"-1.5")
        .Numeric("Sphere V = (4/3)π r³. If r = 3 and dr/dt = 1, (dV/dt)/π = ?", "36",
            ["dV/dt = 4π r² dr/dt = 4π·9·1 = 36π."],
            "36.", explanationLatex: @"36")
        .Mcq("Best order of steps:",
            ["Plug numbers, then differentiate", "Relate, differentiate, then plug numbers", "Guess the rate", "Only draw, never algebra"], 1,
            ["Standard related rates workflow."],
            "Relate, differentiate, plug.")
        .Numeric("Ladder x² + y² = 100. x = 6, y = 8, dx/dt = 1. dy/dt = ?", "-0.75",
            ["6·1 + 8 y' = 0 ⇒ y' = −6/8 = −0.75."],
            "−0.75.", tolerance: 0.01, explanationLatex: @"-0.75")
        .Numeric("If s = (5/3)x and dx/dt = 6, ds/dt = ?", "10",
            ["(5/3)·6 = 10."],
            "10.", explanationLatex: @"10")
        .Mcq("In x² + y² = L² with L fixed, dL/dt is:",
            ["Usually nonzero", "0", "Equal to dx/dt", "Equal to dy/dt"], 1,
            ["Fixed ladder length."],
            "0.")
        .Numeric("A = 4π r² (sphere surface). r = 1, dr/dt = 2. (dA/dt)/π = ?", "16",
            ["dA/dt = 8π r dr/dt = 16π."],
            "16.", explanationLatex: @"16")
        .Build();

    private static Lesson PartialFractions() => new LessonBuilder("calc-partial-fractions", CategoryId, "Partial Fractions Intro")
        .Subtitle("Split rational integrands into simpler pieces that integrate with logs and powers")
        .Order(3).Minutes("32 min")
        .Visual(VisualKind.IntegralArea, "Partial fractions turn a hard rational integral into a sum of easy ones.")
        .Section("Why partial fractions?",
            "Many rational functions are hard to integrate in combined form but easy after splitting into a sum of simpler fractions. For example,\n\n(5x + 1)/((x + 1)(x − 2)) = A/(x + 1) + B/(x − 2)\n\nEach term integrates to a logarithm (or a power if the denominator is a power). Partial fractions is an algebra technique in service of integration (and sometimes inverse Laplace transforms later).",
            simple: "Break a complicated fraction into a sum of simple fractions you already know how to integrate.",
            prior: "Factoring polynomials, solving linear systems, and ∫ 1/(x − a) dx = ln|x − a| + C.")
        .Section("Setup: proper rational functions",
            "First ensure the fraction is proper: degree of numerator less than degree of denominator. If not, polynomial-divide first, then decompose the proper remainder.\n\nFactor the denominator completely over the reals into linear and irreducible quadratic factors.")
        .Section("Linear factors",
            "Distinct linear factors (x − a)(x − b)… lead to terms A/(x − a) + B/(x − b) + …\n\nClear the denominator and solve for constants by plugging convenient x-values (cover-up method) or equating coefficients.",
            @"\frac{px+q}{(x-a)(x-b)}=\frac{A}{x-a}+\frac{B}{x-b}",
            simple: "One unknown constant for each distinct linear factor.",
            prior: "Clearing denominators and solving two equations in two unknowns.")
        .Section("Repeated linear factors (preview)",
            "For (x − a)² in the denominator, include both A/(x − a) and B/(x − a)². Higher powers need every power down to 1. Irreducible quadratics use (Cx + D)/(quadratic). This intro lesson drills the distinct linear case thoroughly.")
        .Section("Integrating after the split",
            "∫ A/(x − a) dx = A ln|x − a| + C.\n∫ B/(x − a)² dx = B ∫ (x − a)⁻² dx = −B/(x − a) + C.\n\nAlways differentiate your answer to check.")
        .Section("Common algebra checks",
            "After finding A and B, recombine over a common denominator and confirm you recover the original numerator. A one-minute check prevents long integral mistakes.")
        .Formula("Two linear factors", @"\frac{1}{(x-a)(x-b)}=\frac{1}{a-b}\left(\frac{1}{x-a}-\frac{1}{x-b}\right)", "Template when numerator is 1 (a ≠ b).")
        .Formula("Log integral", @"\int\frac{1}{x-a}\,dx=\ln|x-a|+C", "After constants factor out.")
        .Example("Find A and B",
            "Decompose (5x + 1)/((x + 1)(x − 2)).",
            [
                "Write (5x + 1)/((x + 1)(x − 2)) = A/(x + 1) + B/(x − 2).",
                "Clear: 5x + 1 = A(x − 2) + B(x + 1).",
                "x = 2: 10 + 1 = B(3) ⇒ 11 = 3B ⇒ B = 11/3.",
                "x = −1: −5 + 1 = A(−3) ⇒ −4 = −3A ⇒ A = 4/3.",
                "So (4/3)/(x + 1) + (11/3)/(x − 2)."
            ],
            "A = 4/3, B = 11/3.",
            problemLatex: @"\frac{5x+1}{(x+1)(x-2)}",
            solutionLatex: @"\frac{4}{3(x+1)}+\frac{11}{3(x-2)}",
            stepLatex: [null, @"5x+1=A(x-2)+B(x+1)", @"B=11/3", @"A=4/3", null])
        .Example("Integrate the decomposition",
            "Using A = 4/3, B = 11/3 from the previous style split of a related problem, integrate (4/3)/(x + 1) + (11/3)/(x − 2).",
            [
                "∫ = (4/3) ln|x + 1| + (11/3) ln|x − 2| + C.",
                "Can combine as ln of a power: ln(|x + 1|^{4/3} |x − 2|^{11/3}) + C.",
                "Differentiate to verify the sum of the original simple fractions.",
                "Domain excludes x = −1 and x = 2."
            ],
            "(4/3) ln|x + 1| + (11/3) ln|x − 2| + C.",
            solutionLatex: @"\frac{4}{3}\ln|x+1|+\frac{11}{3}\ln|x-2|+C")
        .Example("Cover-up for 1/((x−1)(x−4))",
            "Decompose 1/((x − 1)(x − 4)).",
            [
                "1/((x − 1)(x − 4)) = A/(x − 1) + B/(x − 4).",
                "1 = A(x − 4) + B(x − 1).",
                "x = 1: 1 = A(−3) ⇒ A = −1/3.",
                "x = 4: 1 = B(3) ⇒ B = 1/3.",
                "Result: (−1/3)/(x − 1) + (1/3)/(x − 4)."
            ],
            "−1/(3(x − 1)) + 1/(3(x − 4)).",
            solutionLatex: @"-\frac{1}{3(x-1)}+\frac{1}{3(x-4)}")
        .Example("Improper fraction first step",
            "Explain the first step for ∫ (x² + 1)/(x − 1) dx.",
            [
                "Degree numerator 2 ≥ degree denominator 1: improper.",
                "Divide: (x² + 1)/(x − 1) = x + 1 + 2/(x − 1) after polynomial division.",
                "Integrate termwise: x²/2 + x + 2 ln|x − 1| + C.",
                "Partial fractions apply to the proper remainder only; division came first."
            ],
            "Divide first; then integrate the polynomial plus proper remainder.",
            solutionLatex: @"x+1+\frac{2}{x-1}")
        .Mistake("Decomposing an improper fraction without dividing first.")
        .Mistake("Using only A/(x − a) when a repeated factor (x − a)² requires two terms.")
        .Mistake("Algebra errors when clearing denominators (lost factors).")
        .Mistake("Forgetting absolute values in ln|x − a|.")
        .Numeric("1/((x−1)(x−2)) = A/(x−1) + B/(x−2). A = ?", "-1",
            ["Cover-up x = 1: 1/(1−2) = −1."],
            "A = −1.", explanationLatex: @"-1")
        .Numeric("Same decomposition: B = ?", "1",
            ["Cover-up x = 2: 1/(2−1) = 1."],
            "B = 1.", explanationLatex: @"1")
        .Numeric("∫ 1/(x − 3) dx has coefficient of ln|x − 3| equal to?", "1",
            ["Standard log integral."],
            "1.", explanationLatex: @"1")
        .Mcq("Partial fractions require the rational function to be:",
            ["Improper only", "Proper (or made proper by division)", "Trigonometric", "Exponential"], 1,
            ["Divide first if improper."],
            "Proper after any needed division.")
        .Numeric("If 3/(x−1) + 2/(x+1) is recombined, numerator at x = 0 is?", "1",
            ["Common denom x² − 1: [3(x+1) + 2(x−1)]/(x²−1); at 0: (3 − 2)=1."],
            "1.", explanationLatex: @"1")
        .Numeric("∫ 2/(x + 4) dx = 2 ln|x + 4| + C. Coefficient 2 is correct? Enter 1 for yes.", "1",
            ["Constant factors out of the integral."],
            "Yes.", explanationLatex: @"1")
        .Mcq("∫ 1/(x − 5)² dx equals:",
            ["ln|x − 5| + C", "−1/(x − 5) + C", "1/(x − 5) + C", "2(x − 5) + C"], 1,
            ["Power rule: ∫ u⁻² du = −1/u."],
            "−1/(x − 5) + C.")
        .Numeric("Degrees: num degree 3, den degree 2. After one division, remainder degree at most?", "1",
            ["Remainder degree < divisor degree."],
            "1.", explanationLatex: @"1")
        .Build();

    private static Lesson DiffEqIntro() => new LessonBuilder("calc-diff-eq", CategoryId, "Differential Equations Intro")
        .Subtitle("Equations that involve a function and its derivative; solve separable models")
        .Order(4).Minutes("34 min")
        .Visual(VisualKind.LineGraph, "Slope fields and solution curves describe families of functions, not single numbers.")
        .Section("What is a differential equation?",
            "A differential equation (DE) relates an unknown function to its derivatives. Example: dy/dx = 2x says “the slope of y at each x is 2x.” Solutions are functions, not single numbers. The general solution often includes +C; an initial condition y(x₀) = y₀ picks one particular solution.\n\nMany natural laws are DEs: population growth, cooling, radioactive decay, and simple motion.",
            @"\frac{dy}{dx}=f(x,y)",
            simple: "A DE is a puzzle whose answer is a whole function. Derivatives describe how that function changes.",
            prior: "Antiderivatives and the meaning of dy/dx as slope.")
        .Section("Checking a proposed solution",
            "To verify y = y(x) solves a DE, compute the needed derivatives and substitute into both sides. If the equation holds for all x in an interval, it is a solution. This check is often easier than finding the solution from scratch.")
        .Section("Separable equations",
            "A first-order DE is separable if it can be written dy/dx = g(x) h(y), or equivalently dy/h(y) = g(x) dx (when h(y) ≠ 0). Integrate both sides:\n\n∫ dy/h(y) = ∫ g(x) dx\n\nThen solve for y if possible, and apply initial conditions.\n\nExample: dy/dx = k y (exponential growth/decay) separates as dy/y = k dx ⇒ ln|y| = k x + C ⇒ y = A e^{k x}.",
            @"\frac{dy}{y}=k\,dx",
            simple: "Get all y stuff on one side and x stuff on the other, then integrate both sides.",
            prior: "∫ 1/y dy = ln|y| and basic exponential algebra.")
        .Section("Exponential growth and decay",
            "The model dy/dt = k y with y(0) = y₀ gives y = y₀ e^{k t}. If k > 0, growth; if k < 0, decay. Half-life and doubling time are special t-values you can solve from the exponential equation.\n\nNewton’s law of cooling and continuously compounded interest are close relatives of this DE.")
        .Section("Slope fields (picture of the DE)",
            "A slope field draws short segments with slope f(x, y) at grid points. Solution curves must follow those little slopes. Even without a formula, you can sketch behavior. Autonomous equations dy/dx = f(y) have the same slopes on horizontal lines.")
        .Section("What this lesson does not cover yet",
            "Linear first-order integrating factors, second-order constant-coefficient equations, and systems appear in a full DE course. Here the goal is fluency with separation and exponential models, plus the habit of checking solutions.")
        .Formula("Exponential model", @"\frac{dy}{dt}=ky\Rightarrow y=y_0 e^{kt}", "Growth or decay.")
        .Formula("Separation idea", @"\int\frac{dy}{h(y)}=\int g(x)\,dx", "When dy/dx = g(x) h(y).")
        .Example("Verify a solution",
            "Show that y = x² + 3 solves dy/dx = 2x.",
            [
                "Compute dy/dx = 2x.",
                "Right-hand side of the DE is 2x.",
                "They match for all x.",
                "Note: y = x² + C solves the same DE for any constant C."
            ],
            "Yes; derivative matches 2x.",
            problemLatex: @"y=x^2+3",
            solutionLatex: @"\frac{dy}{dx}=2x")
        .Example("Separate and integrate",
            "Solve dy/dx = 3 y with y(0) = 5.",
            [
                "Separate: dy/y = 3 dx (y ≠ 0).",
                "Integrate: ln|y| = 3x + C.",
                "y = A e^{3x} with A = ±e^C (and A = 0 is the equilibrium solution).",
                "y(0) = 5 ⇒ A = 5. So y = 5 e^{3x}."
            ],
            "y = 5 e^{3x}.",
            solutionLatex: @"y=5e^{3x}",
            stepLatex: [@"\frac{dy}{y}=3\,dx", @"\ln|y|=3x+C", @"y=Ae^{3x}", @"A=5"])
        .Example("Decay half-life structure",
            "y = y₀ e^{k t} with k < 0. If half-life is the time T when y(T) = y₀/2, find the relation for k.",
            [
                "y₀/2 = y₀ e^{k T}.",
                "1/2 = e^{k T}.",
                "ln(1/2) = k T ⇒ k = −(ln 2)/T.",
                "So y = y₀ e^{−(ln 2) t / T} = y₀ (1/2)^{t/T}."
            ],
            "k = −(ln 2)/T.",
            solutionLatex: @"k=-\frac{\ln 2}{T}")
        .Example("Separable non-exponential",
            "Solve dy/dx = x / y with y > 0 and y(0) = 2.",
            [
                "y dy = x dx.",
                "Integrate: y²/2 = x²/2 + C.",
                "y² = x² + 2C. Let K = 2C: y² = x² + K.",
                "y(0) = 2 ⇒ 4 = K. Since y > 0, y = √(x² + 4)."
            ],
            "y = √(x² + 4).",
            solutionLatex: @"y=\sqrt{x^2+4}")
        .Mistake("Treating a DE solution as a single number instead of a function.")
        .Mistake("Losing +C or mishandling the absolute value when integrating 1/y.")
        .Mistake("Dividing by y without considering the equilibrium solution y = 0 when it applies.")
        .Mistake("Applying an initial condition before integrating (usually too early).")
        .Numeric("If dy/dx = 4 and y(0) = 1, then y(2) = ?", "9",
            ["y = 4x + 1; at 2 is 9."],
            "9.", explanationLatex: @"9")
        .Numeric("y = 3 e^{2t}. y(0) = ?", "3",
            ["e^0 = 1."],
            "3.", explanationLatex: @"3")
        .Numeric("dy/dt = 5y. Growth constant k = ?", "5",
            ["Standard form dy/dt = k y."],
            "5.", explanationLatex: @"5")
        .Mcq("General solution of dy/dx = 2x is:",
            ["y = 2", "y = x² + C", "y = 2x", "y = e^{2x} only"], 1,
            ["Antiderivative of 2x."],
            "y = x² + C.")
        .Numeric("y = 7 e^{-t}. y(0) = ?", "7",
            ["e^0 = 1."],
            "7.", explanationLatex: @"7")
        .Numeric("If y = e^{kt} and y(1) = e^3, then k = ?", "3",
            ["e^k = e^3 ⇒ k = 3."],
            "3.", explanationLatex: @"3")
        .Mcq("Separable DEs can be written so that:",
            ["Only x appears", "y terms and x terms move to opposite sides for integration", "No derivatives appear", "Solutions are always linear"], 1,
            ["Separation of variables."],
            "Separate variables and integrate.")
        .Numeric("y² = x² + 9, y > 0. y(0) = ?", "3",
            ["√9 = 3."],
            "3.", explanationLatex: @"3")
        .Build();
}
