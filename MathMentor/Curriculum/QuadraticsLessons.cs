using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class QuadraticsLessons
{
    public const string CategoryId = "quadratics";

    public static Category Build()
    {
        var lessons = new[]
        {
            SolvingQuadratics(),
            Discriminant(),
            GraphingParabolas(),
            QuadraticApps()
        };
        return new Category(CategoryId, "Quadratics",
            "Solve and graph quadratic functions; connect factoring, vertices, and real max/min applications.",
            "\uE9D9", 7, lessons);
    }

    private static Lesson SolvingQuadratics() => new LessonBuilder("quad-solve", CategoryId, "Solving Quadratic Equations")
        .Subtitle("Factoring, square roots, completing the square, and the quadratic formula, all aimed at finding zeros")
        .Order(1).Minutes("34 min")
        .Section("What makes an equation quadratic?",
            "A quadratic equation can be written in standard form ax^2 + bx + c = 0 with a ≠ 0. The highest power of the variable is 2. Solutions are called roots or zeros: values of x that make the equation true.\n\nWhy \"quadratic\"? From Latin for square: the degree-2 term is a square power. Graphically, y = ax^2 + bx + c is a parabola. Every real root is an x-intercept of that graph. That link is not optional decoration. Factoring finds zeros; zeros mark x-intercepts; later the discriminant tells you how many intercepts to expect before you finish solving.\n\nIf a = 0, the equation is no longer quadratic (it collapses to linear or constant). Always confirm you truly have a nonzero leading coefficient before choosing a quadratic method.",
            simple: "Quadratic means degree 2 after you set everything equal to zero. Roots = zeros = x-values that make the left side zero = x-intercepts on the graph.",
            prior: "You need linear solving, factoring of simple trinomials, and the idea that graphs cross the x-axis where y = 0.")
        .Section("Strategy map: which method when?",
            "1) Factoring and the zero product property: fastest when the trinomial factors cleanly over the integers.\n2) Square root method: when the equation is (linear expression)^2 = constant, or a pure square equals a constant after isolating.\n3) Completing the square: rewrites the quadratic so a square is isolated; it also builds vertex form y = a(x - h)^2 + k and is the algebra behind the quadratic formula.\n4) Quadratic formula: always works for any a, b, c with a ≠ 0 (over the reals when the discriminant is non-negative).\n\nGood solvers try the cheapest correct method first, but keep the formula as a safety net. Completing the square is not only a backup: it is the bridge from standard form to vertex form and to the formula itself.",
            simple: "Set equal to zero. Try factoring. If not, use square roots when you only see a square and a constant. Otherwise use the formula (or complete the square on purpose).",
            prior: "You need factoring of trinomials, fraction and radical arithmetic, and the zero product property from algebra.")
        .Section("Factoring, zeros, and x-intercepts (the core chain)",
            "If ax^2 + bx + c factors as a(x - r)(x - s) = 0, then by the zero product property either x - r = 0 or x - s = 0, so x = r or x = s. Those roots are the zeros of the quadratic polynomial. On the graph of y = ax^2 + bx + c, the points (r, 0) and (s, 0) are the x-intercepts (when they are real).\n\nThis is the first critical connection in the unit:\nfactoring → zeros → x-intercepts.\n\nWhen a quadratic does not factor nicely over the integers, the zeros still exist or not for the same geometric reason; you simply need square roots, completing the square, or the formula to find them. Factoring is a discovery tool, not a different definition of \"root.\"",
            @"a(x-r)(x-s)=0",
            simple: "If a product is zero, a factor is zero. Each factor zero is a root. Each real root is where the parabola hits the x-axis.",
            prior: "Zero product property: if AB = 0, then A = 0 or B = 0 (for real numbers).")
        .Section("Square root method and the ±",
            "From x^2 = k with k > 0 you get two real solutions x = ±√k. From x^2 = 0, one solution x = 0. From x^2 = k with k < 0, no real solutions.\n\nThe ± is not decoration. Squaring destroys sign information, so both the positive and negative roots restore candidates. For (x - 3)^2 = 16, first x - 3 = ±4, then x = 3 + 4 or x = 3 - 4.\n\nThis method is completing the square's younger sibling: once a perfect square stands alone equal to a constant, square roots finish the solve.",
            simple: "If a square equals a positive constant, take ± square root. If the square is of (x - h), add h after the ± step.",
            prior: "You should know perfect squares and how to simplify simple radicals like √12 = 2√3.")
        .Section("Completing the square: vertex form and the formula idea",
            "Rewrite x^2 + bx as (x + b/2)^2 - (b/2)^2, then move constants and take square roots when solving. Completing the square converts standard form into vertex form y = a(x - h)^2 + k. That is the second critical connection:\ncompleting the square ↔ vertex form y = a(x - h)^2 + k ↔ the idea behind the quadratic formula.\n\nThe quadratic formula is completing the square done once for general a, b, c. You do not need to re-derive it every time, but knowing it is algebra (not magic) builds confidence and ties solving to graphing. When a ≠ 1, factor a out of the x terms first, complete the square inside, then distribute a back if you want vertex form.",
            @"x^2+bx=\left(x+\frac{b}{2}\right)^2-\left(\frac{b}{2}\right)^2",
            simple: "Half the middle coefficient, square it, add and subtract that perfect square so you can write a binomial squared. That is completing the square.",
            prior: "Expanding (x + m)^2 = x^2 + 2mx + m^2 is the reverse skill you need.")
        .Section("Quadratic formula, and reading a, b, c carefully",
            "For ax^2 + bx + c = 0,\n\nx = (-b ± √(b^2 - 4ac)) / (2a).\n\nIdentify a, b, c including signs. The expression under the root is the discriminant D = b^2 - 4ac (next lesson). It decides how many real roots you get. Always divide the entire numerator by 2a, not only part of it.\n\nStrategy reminder: if factoring is obvious, use it and name the zeros as intercepts. If not, formula or completing the square. Both should agree when you check.",
            @"x=\frac{-b\pm\sqrt{b^2-4ac}}{2a}",
            simple: "Plug a, b, c into the formula. Compute the discriminant first. Then build both roots with ±. Simplify radicals when you can.",
            prior: "Order of operations, signed arithmetic, and simplifying √(perfect square factors).")
        .Section("Checks that catch most errors",
            "After solving, substitute each root into the original equation. Both sides should match. Graph sense helps too: if a > 0 and the constant term c is positive with D > 0, you expect two real intercepts; a double root should land at the vertex on the axis.\n\nAlso check that you did not lose the ±, flip the sign of b, or divide only -b by 2a while leaving the square root undivided.")
        .Formula("Quadratic formula", @"x=\frac{-b\pm\sqrt{b^2-4ac}}{2a}", "Works for all quadratics with a ≠ 0; real roots when D ≥ 0.")
        .Formula("Square root principle", @"x^2=k\Rightarrow x=\pm\sqrt{k}\;(k>0)", "Two real roots when k is positive; none real when k is negative.")
        .Formula("Zero product", @"AB=0\Rightarrow A=0\;\mathrm{or}\;B=0", "Use after factoring a product equal to zero; each factor zero is a root.")
        .Formula("Complete the square idea", @"x^2+bx=\left(x+\frac{b}{2}\right)^2-\left(\frac{b}{2}\right)^2", "Bridge to vertex form and to the quadratic formula derivation.")
        .Example("Solve by factoring (zeros as intercepts)",
            "Solve x^2 - 5x + 6 = 0, and name what the roots mean on the graph of y = x^2 - 5x + 6.",
            [
                "Thinking: look for integers that multiply to 6 and add to -5: -2 and -3.",
                "Factor: (x - 2)(x - 3) = 0.",
                "Zero product: x - 2 = 0 or x - 3 = 0, so x = 2 or x = 3.",
                "Check: 4 - 10 + 6 = 0; 9 - 15 + 6 = 0. Both roots work.",
                "Graph link: the parabola crosses the x-axis at (2, 0) and (3, 0). Factoring found the zeros, and zeros are the x-intercepts."
            ],
            "Roots are 2 and 3; the graph has x-intercepts at x = 2 and x = 3.",
            problemLatex: @"x^2-5x+6=0",
            solutionLatex: @"x=2,\;3",
            stepLatex: [null, @"(x-2)(x-3)=0", @"x=2\;\mathrm{or}\;x=3", null, null],
            closingLatex: @"x=2,\;3")
        .Example("Square root method with a shift",
            "Solve (x - 3)^2 = 16.",
            [
                "Thinking: a square equals a positive constant, so take ± square root of both sides.",
                "x - 3 = ±√16 = ±4.",
                "First branch: x - 3 = 4 → x = 7. Second: x - 3 = -4 → x = -1.",
                "Check: (7 - 3)^2 = 16 and (-1 - 3)^2 = 16. Both work.",
                "Common mistake callout: writing only x = 7 and dropping the minus branch."
            ],
            "x = 7 or x = -1.",
            problemLatex: @"(x-3)^2=16",
            solutionLatex: @"x=7,\;-1",
            stepLatex: [null, @"x-3=\pm 4", @"x=7\;\mathrm{or}\;x=-1", null, null],
            closingLatex: @"x=7,\;-1")
        .Example("Quadratic formula with simplified radical",
            "Solve x^2 + 2x - 2 = 0.",
            [
                "Identify a = 1, b = 2, c = -2.",
                "Discriminant: b^2 - 4ac = 4 - 4(1)(-2) = 4 + 8 = 12.",
                "x = (-2 ± √12) / 2. Simplify √12 = 2√3: x = (-2 ± 2√3)/2 = -1 ± √3.",
                "Two irrational real roots: -1 + √3 and -1 - √3. Approximate check: √3 ≈ 1.73 so roots near 0.73 and -2.73.",
                "Connection: D = 12 > 0 matches two real zeros and two x-intercepts on y = x^2 + 2x - 2."
            ],
            "x = -1 ± √3.",
            problemLatex: @"x^2+2x-2=0",
            solutionLatex: @"x=-1\pm\sqrt{3}",
            stepLatex: [@"a=1,\;b=2,\;c=-2", @"b^2-4ac=12", @"x=\frac{-2\pm\sqrt{12}}{2}", @"x=-1\pm\sqrt{3}", null],
            closingLatex: @"x=-1\pm\sqrt{3}")
        .Example("Formula when factoring is less obvious",
            "Solve 2x^2 - 3x - 2 = 0.",
            [
                "a = 2, b = -3, c = -2. Discriminant: (-3)^2 - 4(2)(-2) = 9 + 16 = 25.",
                "x = (3 ± √25) / (2 · 2) = (3 ± 5)/4. Careful: -b = -(-3) = 3.",
                "First root: (3 + 5)/4 = 8/4 = 2. Second: (3 - 5)/4 = -2/4 = -1/2.",
                "Factoring check: 2x^2 - 3x - 2 = (2x + 1)(x - 2). Same roots x = 2 and x = -1/2.",
                "Zeros again mean intercepts: y = 2x^2 - 3x - 2 crosses the x-axis at x = 2 and x = -1/2."
            ],
            "x = 2 or x = -1/2.",
            problemLatex: @"2x^2-3x-2=0",
            solutionLatex: @"x=2,\;-\frac{1}{2}",
            stepLatex: [@"D=25", @"x=\frac{3\pm 5}{4}", @"x=2,\;-\frac{1}{2}", null, null],
            closingLatex: @"x=2,\;-\frac{1}{2}")
        .Mistake("Dropping the ± when taking square roots of both sides of a squared equation.")
        .Mistake("Using b^2 + 4ac instead of b^2 - 4ac in the quadratic formula.")
        .Mistake("Forgetting that -b means the opposite of b (sign errors when b is already negative).")
        .Mistake("Dividing only part of the numerator by 2a instead of the whole (-b ± square root).")
        .Mistake("Treating factoring failures as \"no roots\" instead of switching to the formula or completing the square.")
        .Numeric("Solve x^2 - 9 = 0. What is the positive root?", "3",
            ["Rewrite as x^2 = 9.", "x = ±3; the positive root is 3."],
            "Positive root is 3.",
            explanationLatex: @"3")
        .Numeric("x^2 - 5x + 6 = 0. What is the smaller root?", "2",
            ["Factor as (x - 2)(x - 3) = 0.", "Roots 2 and 3; smaller is 2."],
            "Smaller root is 2.",
            explanationLatex: @"2")
        .Numeric("x^2 = 16. What is the positive solution?", "4",
            ["Take square roots: x = ±4.", "Positive solution is 4."],
            "Positive solution is 4.",
            explanationLatex: @"4")
        .Mcq("In the quadratic formula, the denominator is:",
            ["b", "2a", "a", "c"], 1,
            ["The formula has the entire (-b ± square root) over one denominator.", "That denominator is 2a."],
            "2a.",
            explanationLatex: @"2a")
        .Numeric("For x^2 + 4x + 1 = 0, what is b^2 - 4ac?", "12",
            ["a = 1, b = 4, c = 1.", "16 - 4(1)(1) = 12."],
            "Discriminant is 12.",
            explanationLatex: @"12")
        .Numeric("Solve (x - 3)^2 = 0. What is x?", "3",
            ["Double root: x - 3 = 0.", "x = 3 only."],
            "x = 3 (repeated root).",
            explanationLatex: @"x=3")
        .Numeric("2x^2 = 50. What is the positive x?", "5",
            ["Divide by 2: x^2 = 25.", "x = ±5; positive is 5."],
            "Positive solution is 5.",
            explanationLatex: @"5")
        .Mcq("Which equation is quadratic?",
            ["2x + 1 = 0", "x^3 - x = 0", "x^2 - 4x = 5", "√x = 3"], 2,
            ["Quadratic means degree 2 after arranging as a polynomial equation.", "Moving 5 gives x^2 - 4x - 5 = 0."],
            "x^2 - 4x = 5 is quadratic (degree 2).")
        .Takeaways(
            "A quadratic equation has form ax^2 + bx + c = 0 with a ≠ 0; roots are zeros of the polynomial.",
            "Factoring plus zero product finds zeros, and real zeros are x-intercepts of y = ax^2 + bx + c.",
            "Completing the square links standard form to vertex form and is the idea behind the quadratic formula.",
            "Use square roots when a pure square equals a constant; always keep the ± for two real branches when the constant is positive.",
            "The quadratic formula always works; compute D = b^2 - 4ac carefully and divide the whole numerator by 2a.")
        .Build();

    private static Lesson Discriminant() => new LessonBuilder("quad-disc", CategoryId, "The Discriminant & Nature of Roots")
        .Subtitle("How many real solutions, without fully solving every time, and how that matches x-intercepts")
        .Order(2).Minutes("28 min")
        .Section("Where the discriminant lives",
            "In the quadratic formula, the expression under the square root is D = b^2 - 4ac. That quantity is the discriminant. It decides whether the square root is real and positive, zero, or not real, and therefore how many real solutions ax^2 + bx + c = 0 has.\n\nYou can compute D without finishing the entire formula. That is useful for \"how many roots?\" questions and for understanding graphs before you solve.\n\nThis lesson's critical connection: the discriminant links the quadratic formula to the number of x-intercepts of y = ax^2 + bx + c.",
            @"D=b^2-4ac",
            simple: "D is the stuff under the square root in the quadratic formula. Its sign tells you how many real roots (and how many x-intercepts) you get.",
            prior: "You should know the quadratic formula structure and that square roots of negative numbers are not real.")
        .Section("The three cases, with geometric meaning",
            "• D > 0: two distinct real roots. The parabola crosses the x-axis twice.\n• D = 0: exactly one real root (a repeated or double root). The parabola is tangent to the x-axis and touches at the vertex.\n• D < 0: no real roots (two complex conjugate roots if you work over complex numbers). The parabola never meets the x-axis.\n\nThe sign of a still controls opening direction (up or down). D controls how many x-intercepts. Solving lesson found zeros; this lesson predicts how many zeros exist before (or instead of) listing them.",
            @"D=b^2-4ac",
            simple: "Compute b^2 - 4ac. Positive → two real roots. Zero → one (double). Negative → none real. Same counts for x-intercepts.",
            prior: "Graphs of parabolas: opening up or down, and intercepts as solutions of y = 0.")
        .Section("Why D = 0 is a double root",
            "When D = 0, the formula collapses to the single value x = -b/(2a). Factoring often shows a square: x^2 - 6x + 9 = (x - 3)^2 = 0, so x = 3 with multiplicity two. Graphically that single intercept is also the vertex sitting on the x-axis.\n\nMultiplicity two does not mean two different x-values. It means the root is repeated in the factorization and the graph touches and turns back instead of crossing through.",
            simple: "D = 0 means the ± part adds nothing new: one repeated root, vertex on the x-axis.",
            prior: "Vertex x-coordinate x = -b/(2a) from standard form (graphing lesson).")
        .Section("Formula, factoring, and intercepts stay consistent",
            "If you can factor, you already know the roots and can count them. The discriminant must agree: two distinct linear factors over the reals means D > 0; a perfect square factor means D = 0; no real factorization into reals means D < 0.\n\nExample chain: (x - 1)(x - 4) = x^2 - 5x + 4 has D = 25 - 16 = 9 > 0, two intercepts. (x - 2)^2 = x^2 - 4x + 4 has D = 0, one intercept. x^2 + 1 has D = -4 < 0, no real intercepts.\n\nNever treat D as a separate universe from solving. It is a forecast from the same coefficients the formula uses.",
            simple: "Same a, b, c drive factoring, formula, D, and the graph. They cannot disagree about how many real zeros exist.",
            prior: "Factoring and formula from the solving lesson.")
        .Section("Parameters and conditions",
            "Sometimes a, b, or c contains a parameter (like an unknown c). Setting D > 0, D = 0, or D < 0 turns into an inequality or equation for that parameter.\n\nExample: x^2 + 4x + c = 0 has exactly one real solution when 16 - 4c = 0, so c = 4. If c < 4 then D > 0 (two real roots); if c > 4 then D < 0 (none real). Word problems about \"for what values does the model hit the ground twice?\" are often discriminant conditions in disguise.")
        .Section("Complex roots (brief honesty)",
            "D < 0 does not mean mathematics gives up. Over complex numbers there are still two roots. In most Algebra I / II real-number courses, we say \"no real solutions\" and note the graph misses the x-axis.\n\nFor this course, focus on the real picture: intercepts you can plot, and D as the classifier. Complex roots appear more fully in later algebra.")
        .Section("Quick checklist before you compute",
            "1) Write the equation as ax^2 + bx + c = 0 (move all terms to one side).\n2) Identify a, b, c with signs.\n3) Compute D = b^2 - 4ac carefully (negatives multiply).\n4) Classify: two, one, or zero real roots.\n5) If needed, finish the formula or factor to list the roots and mark intercepts.")
        .Formula("Discriminant", @"D=b^2-4ac", "Sign of D classifies the number of real roots and x-intercepts.")
        .Formula("Two distinct real roots", @"D>0", "Two different zeros; parabola crosses the x-axis twice.")
        .Formula("Repeated real root", @"D=0\Rightarrow x=-\frac{b}{2a}", "Double root; vertex lies on the x-axis.")
        .Formula("No real roots", @"D<0", "No real zeros; parabola misses the x-axis (complex roots exist later).")
        .Example("Two distinct real roots",
            "Without solving fully, describe the roots of x^2 - 4x + 1 = 0 and what the graph does.",
            [
                "a = 1, b = -4, c = 1. D = (-4)^2 - 4(1)(1) = 16 - 4 = 12.",
                "D = 12 > 0 → two distinct real roots.",
                "Explicitly they are (4 ± √12)/2 = 2 ± √3 if you want them, but nature only needed D.",
                "Graph: upward parabola crossing the x-axis at two points (two intercepts).",
                "Link: formula's square root is real and nonzero, so two zeros and two intercepts."
            ],
            "Two distinct real solutions (D = 12 > 0); two x-intercepts.",
            problemLatex: @"x^2-4x+1=0",
            solutionLatex: @"D=12>0",
            stepLatex: [@"D=16-4=12", @"D>0", null, null, null],
            closingLatex: @"D=12>0")
        .Example("Exactly one real root",
            "Analyze x^2 - 6x + 9 = 0.",
            [
                "D = 36 - 4(1)(9) = 36 - 36 = 0.",
                "One real root (repeated). Formula: x = 6/(2) = 3.",
                "Factoring: (x - 3)^2 = 0 confirms double root x = 3.",
                "Graph touches the x-axis at the vertex (3, 0), does not cross through.",
                "Connection: D = 0, factoring shows a square, and the vertex is the only intercept."
            ],
            "Repeated root at x = 3; one x-intercept at the vertex.",
            problemLatex: @"x^2-6x+9=0",
            solutionLatex: @"D=0,\;x=3",
            stepLatex: [@"D=0", @"x=3", @"(x-3)^2=0", null, null],
            closingLatex: @"x=3")
        .Example("No real roots",
            "Analyze x^2 + 2x + 5 = 0.",
            [
                "D = 4 - 4(1)(5) = 4 - 20 = -16.",
                "D < 0 → no real solutions.",
                "Completing the square view: (x + 1)^2 + 4 = 0 → (x + 1)^2 = -4, impossible for real x.",
                "Graph of y = x^2 + 2x + 5 opens upward with vertex y-value 4 > 0, entirely above the x-axis.",
                "Link: negative discriminant means the formula's square root is not real, so zero real intercepts."
            ],
            "No real roots; parabola never crosses the x-axis.",
            problemLatex: @"x^2+2x+5=0",
            solutionLatex: @"D=-16<0",
            stepLatex: [@"D=-16", @"D<0", null, null, null],
            closingLatex: @"D=-16")
        .Example("Solve for a parameter",
            "For what value of c does x^2 + 4x + c = 0 have exactly one real solution?",
            [
                "Need D = 0 for exactly one real root.",
                "D = 16 - 4(1)(c) = 16 - 4c.",
                "Set 16 - 4c = 0 → 4c = 16 → c = 4.",
                "Check: x^2 + 4x + 4 = (x + 2)^2 = 0, root x = -2 only.",
                "If c < 4, D > 0 (two roots / two intercepts); if c > 4, D < 0 (none real)."
            ],
            "c = 4.",
            problemLatex: @"x^2+4x+c=0",
            solutionLatex: @"c=4",
            stepLatex: [@"D=16-4c", @"16-4c=0", @"c=4", null, null],
            closingLatex: @"c=4")
        .Mistake("Thinking D < 0 means no solutions in any number system (complex solutions still exist).")
        .Mistake("Sign errors when computing b^2 - 4ac, especially with negative b or c.")
        .Mistake("Confusing D = 0 (one real root, vertex on the axis) with \"no solution.\"")
        .Mistake("Using the discriminant on an equation that is not yet in ax^2 + bx + c = 0 form.")
        .Mistake("Forgetting that the count of real roots is also the count of x-intercepts of y = ax^2 + bx + c.")
        .Numeric("Discriminant of x^2 + 3x + 2?", "1",
            ["b^2 - 4ac = 9 - 8.", "D = 1."],
            "D = 1.",
            explanationLatex: @"D=1")
        .Numeric("Discriminant of x^2 + 2x + 1?", "0",
            ["4 - 4(1)(1) = 0.", "Perfect square trinomial."],
            "D = 0.",
            explanationLatex: @"D=0")
        .Mcq("If D > 0, the number of distinct real roots is:",
            ["0", "1", "2", "3"], 2,
            ["Positive discriminant means two different real solutions.", "That is two distinct real roots."],
            "Two.")
        .Mcq("If D = 0, the graph of y = ax^2 + bx + c:",
            ["Misses the x-axis", "Touches the x-axis once", "Crosses twice", "Is a line"], 1,
            ["Double root means the vertex lies on the x-axis.", "The parabola touches once, does not cross twice."],
            "Touches the x-axis once.")
        .Numeric("Discriminant of 2x^2 - 3x + 4?", "-23",
            ["b^2 - 4ac = 9 - 4(2)(4).", "9 - 32 = -23."],
            "D = -23.",
            explanationLatex: @"D=-23")
        .Numeric("For x^2 - 5x + c to have exactly one root, c = ?", "6.25",
            ["Set D = 25 - 4c = 0.", "c = 25/4 = 6.25."],
            "c = 25/4 = 6.25.",
            explanationLatex: @"c=\frac{25}{4}",
            tolerance: 0.01)
        .Numeric("Number of real roots if D = -1?", "0",
            ["Negative discriminant means no real roots.", "Answer 0."],
            "0 real roots.",
            explanationLatex: @"0")
        .Mcq("For x^2 + 1 = 0, the discriminant is:",
            ["1", "0", "-4", "-1"], 2,
            ["a = 1, b = 0, c = 1.", "D = 0 - 4(1)(1) = -4."],
            "D = -4.",
            explanationLatex: @"D=-4")
        .Takeaways(
            "D = b^2 - 4ac is the expression under the square root in the quadratic formula.",
            "D > 0 two distinct real roots; D = 0 one repeated real root; D < 0 no real roots.",
            "The discriminant also counts x-intercepts of y = ax^2 + bx + c: two, one (vertex touch), or zero.",
            "When D = 0 the root is x = -b/(2a) and the vertex sits on the x-axis.",
            "Parameter problems often reduce to solving D = 0, D > 0, or D < 0 for the unknown coefficient.")
        .Build();

    private static Lesson GraphingParabolas() => new LessonBuilder("quad-graph", CategoryId, "Graphing Parabolas, Vertex Form & Transformations")
        .Subtitle("Vertex, axis of symmetry, intercepts, and moving the parent parabola with purpose")
        .Order(3).Minutes("34 min")
        .Visual(VisualKind.Parabola, "y = ax^2 + bx + c opens up (a > 0) or down (a < 0); the vertex is the turning point.")
        .Section("The parent parabola y = x^2",
            "The graph of y = x^2 is a U-shaped curve called a parabola, with vertex (turning point) at (0, 0) and axis of symmetry x = 0. Points are symmetric: if (2, 4) is on the graph, so is (-2, 4).\n\nEvery quadratic graph is a stretch, flip, and/or shift of this parent. Solving lessons found zeros; discriminant lessons counted intercepts; this lesson places the whole curve: vertex, axis, intercepts, and shape.",
            simple: "Start from y = x^2: U shape, vertex at the origin, mirror symmetry across the y-axis. Other quadratics move and stretch that picture.",
            prior: "Plotting points and reading (x, y) pairs; knowing that y = 0 marks x-intercepts.")
        .Section("Role of a: open, stretch, flip",
            "For y = ax^2 + bx + c (or vertex form y = a(x - h)^2 + k):\n• a > 0 → opens upward (vertex is a minimum).\n• a < 0 → opens downward (vertex is a maximum).\n• |a| > 1 → steeper / stretched away from the x-axis.\n• 0 < |a| < 1 → wider / compressed toward the x-axis.\n\nThe sign of a is the first thing to read when sketching. Applications later use this same fact: vertex is max when a < 0 and min when a > 0.",
            simple: "Positive a: smile (minimum at vertex). Negative a: frown (maximum at vertex). Large |a|: skinny. Small |a|: wide.",
            prior: "Comparing steepness of graphs and reading positive vs negative leading coefficients.")
        .Section("Vertex form and transformations",
            "y = a(x - h)^2 + k has vertex (h, k). Notice the sign inside: (x - 3)^2 shifts right 3; (x + 3)^2 = (x - (-3))^2 shifts left 3. The +k shifts up; subtracting k shifts down.\n\nThis form makes graphing easy: plot the vertex, use a for shape, plot a few symmetric points, draw a smooth curve.\n\nCritical connection from solving: completing the square rewrites standard form into this vertex form. Solving, formula derivation, and graphing share one algebraic move.",
            @"y=a(x-h)^2+k",
            simple: "Vertex form shows the turn point (h, k) immediately. Remember: (x - h) moves right when h is positive; (x + h) moves left.",
            prior: "Completing the square from the solving lesson turns ax^2 + bx + c into a(x - h)^2 + k.")
        .Section("Standard form tools",
            "From y = ax^2 + bx + c:\n• Axis of symmetry / vertex x-coordinate: x = -b/(2a).\n• Vertex y-coordinate: plug that x into the function.\n• Y-intercept: c (value at x = 0).\n• X-intercepts: solve ax^2 + bx + c = 0 (factor or formula); none if D < 0.\n\nChain recall: factoring finds zeros; zeros are x-intercepts; D predicts how many intercepts; the vertex sits midway between two distinct intercepts on the axis of symmetry.",
            @"x=-\frac{b}{2a}",
            simple: "From standard form, vertex x is -b/(2a). Plug in for y. Intercepts: y-intercept is c; x-intercepts are the real roots.",
            prior: "Quadratic formula and discriminant from earlier lessons in this category.")
        .Section("From standard form to vertex form (completing the square)",
            "Example idea: y = x^2 - 4x + 1. Half of -4 is -2; (-2)^2 = 4. Rewrite y = (x^2 - 4x + 4) + 1 - 4 = (x - 2)^2 - 3. Vertex (2, -3), matching x = -b/(2a) = 2.\n\nWhen a ≠ 1, factor a from the x terms first, complete the square inside the parentheses, then distribute a and simplify the constant. Same algebra that builds the quadratic formula, now used for graphing.",
            simple: "Complete the square to reveal (h, k). Check against x = -b/(2a) so standard form and vertex form agree.",
            prior: "Expanding and reversing (x - h)^2 = x^2 - 2hx + h^2.")
        .Section("A sketch checklist",
            "1) Opening direction from a.\n2) Vertex (and axis of symmetry).\n3) Y-intercept.\n4) X-intercepts if they exist and are easy (factor or D and formula).\n5) One extra point for shape, then reflect across the axis.\n\nIf D < 0, skip real x-intercepts and emphasize that the curve stays above or below the axis depending on a and the vertex height.")
        .Section("Why symmetry saves work",
            "The axis x = h is a mirror. If you know a point h + d units to the right of the vertex, the point h - d units to the left has the same y-value. That is why tables often only need a few points once the vertex is known.\n\nApplications will reuse the vertex as max/min without redrawing the whole parabola. Graph skill is optimization skill.")
        .Formula("Vertex x-coordinate", @"x=-\frac{b}{2a}", "Axis of symmetry for y = ax^2 + bx + c.")
        .Formula("Vertex form", @"y=a(x-h)^2+k", "Vertex (h, k); a controls open/stretch; max if a < 0, min if a > 0.")
        .Formula("Y-intercept", @"y(0)=c", "In standard form ax^2 + bx + c.")
        .Formula("Intercept link", @"ax^2+bx+c=0", "Real roots are x-intercepts; D tells how many.")
        .Example("Vertex from standard form",
            "Find the vertex of y = x^2 - 4x + 1.",
            [
                "a = 1, b = -4. Vertex x = -b/(2a) = 4/2 = 2.",
                "y = (2)^2 - 4(2) + 1 = 4 - 8 + 1 = -3.",
                "Vertex is (2, -3). Axis of symmetry x = 2.",
                "Opens up (a > 0), so (2, -3) is a minimum point.",
                "Completing-the-square check: y = (x - 2)^2 - 3, same vertex."
            ],
            "Vertex (2, -3).",
            problemLatex: @"y=x^2-4x+1",
            solutionLatex: @"(2,-3)",
            stepLatex: [@"x=\frac{4}{2}=2", @"y=4-8+1=-3", @"(2,-3)", null, @"(x-2)^2-3"],
            closingLatex: @"(2,-3)")
        .Example("Read transformations from vertex form",
            "Describe key features of y = (x - 3)^2 + 2.",
            [
                "Compared to y = x^2: shift right 3, up 2. Here a = 1 (same width as parent).",
                "Vertex (h, k) = (3, 2).",
                "Opens upward; axis x = 3.",
                "Y-intercept: (0 - 3)^2 + 2 = 9 + 2 = 11 → (0, 11).",
                "X-intercepts: set (x - 3)^2 + 2 = 0 → (x - 3)^2 = -2, impossible real, so D would be negative in standard form; no x-intercepts."
            ],
            "Vertex (3, 2), opens up, shifted right 3 and up 2; no real x-intercepts.",
            problemLatex: @"y=(x-3)^2+2",
            solutionLatex: @"(3,2)",
            stepLatex: [null, @"(h,k)=(3,2)", @"x=3", @"y(0)=11", null],
            closingLatex: @"(3,2)")
        .Example("Opens down with stretch",
            "Analyze y = -2(x + 1)^2 + 5.",
            [
                "Rewrite (x + 1) as (x - (-1)): h = -1, k = 5. Vertex (-1, 5).",
                "a = -2 < 0 → opens downward, so the vertex is a maximum.",
                "|a| = 2 > 1 → vertically stretched (steeper than y = -x^2).",
                "Maximum value of the function is 5, achieved at x = -1.",
                "Application preview: same vertex-as-max idea used for projectiles and profit models."
            ],
            "Maximum at (-1, 5); opens down, stretch factor 2.",
            problemLatex: @"y=-2(x+1)^2+5",
            solutionLatex: @"(-1,5)",
            stepLatex: [@"(h,k)=(-1,5)", @"a=-2", null, @"\mathrm{max}=5", null],
            closingLatex: @"(-1,5)")
        .Example("Intercepts of a simple parabola",
            "For y = x^2 - 1, find intercepts and vertex.",
            [
                "Y-intercept: y(0) = -1 → (0, -1).",
                "X-intercepts: x^2 - 1 = 0 → (x - 1)(x + 1) = 0 → x = ±1. Factoring → zeros → intercepts.",
                "Vertex: a = 1, b = 0, c = -1 → x = 0, y = -1 → (0, -1).",
                "D = 0 - 4(1)(-1) = 4 > 0 agrees with two intercepts.",
                "Classic upward parabola through ±1 on the x-axis, parent shifted down 1."
            ],
            "Vertex (0, -1); x-intercepts ±1; y-intercept -1.",
            problemLatex: @"y=x^2-1",
            solutionLatex: @"(0,-1)",
            stepLatex: [@"y(0)=-1", @"x=\pm 1", @"(0,-1)", @"D=4", null],
            closingLatex: @"(0,-1)")
        .Mistake("Writing the vertex as (k, h) instead of (h, k).")
        .Mistake("Sign error: treating y = (x + 3)^2 as a shift right 3 (it is left 3).")
        .Mistake("Forgetting that a < 0 makes the vertex a maximum, not a minimum.")
        .Mistake("Using x = b/(2a) instead of x = -b/(2a).")
        .Mistake("Finding roots for intercepts but forgetting that D < 0 means no real x-intercepts.")
        .Numeric("For y = x^2 - 6x + 5, what is the vertex x-coordinate?", "3",
            ["x = -b/(2a) = 6/2.", "Vertex x = 3."],
            "Vertex x = 3.",
            explanationLatex: @"x=3")
        .Numeric("For y = x^2 - 6x + 5, vertex y at x = 3?", "-4",
            ["y = 9 - 18 + 5.", "y = -4."],
            "Vertex y = -4.",
            explanationLatex: @"y=-4")
        .Mcq("y = -x^2 + 4 has vertex:",
            ["(0, 4)", "(0, -4)", "(4, 0)", "(2, 0)"], 0,
            ["No x term: vertex on the y-axis.", "y = 4 at x = 0; a < 0 so max at (0, 4)."],
            "(0, 4).")
        .Numeric("In y = 2(x - 5)^2 + 7, what is h?", "5",
            ["Vertex form a(x - h)^2 + k.", "h = 5."],
            "h = 5.",
            explanationLatex: @"h=5")
        .Numeric("In y = 2(x - 5)^2 + 7, what is k?", "7",
            ["k is the vertical shift.", "Vertex y-coordinate is 7."],
            "k = 7.",
            explanationLatex: @"k=7")
        .Mcq("If a < 0, the parabola:",
            ["Opens up", "Opens down", "Is linear", "Has no vertex"], 1,
            ["Negative leading coefficient means opens downward.", "Vertex is a maximum."],
            "Opens down.")
        .Numeric("Y-intercept of y = 3x^2 - 2x + 8?", "8",
            ["f(0) = c.", "c = 8."],
            "Y-intercept is 8.",
            explanationLatex: @"8")
        .Mcq("The axis of symmetry of y = (x + 4)^2 - 1 is:",
            ["x = 4", "x = -4", "y = -1", "x = 1"], 1,
            ["Vertex at (-4, -1).", "Axis is the vertical line x = h = -4."],
            "x = -4.")
        .Takeaways(
            "Every quadratic graph is a transformed parabola with a vertex and a vertical axis of symmetry.",
            "Vertex form y = a(x - h)^2 + k shows vertex (h, k); a sets open direction and stretch.",
            "From standard form, vertex x is -b/(2a); y-intercept is c; x-intercepts are real roots of ax^2 + bx + c = 0.",
            "Completing the square converts standard form to vertex form, the same move that explains the quadratic formula.",
            "a > 0 means minimum at the vertex; a < 0 means maximum at the vertex (key for applications).")
        .Build();

    private static Lesson QuadraticApps() => new LessonBuilder("quad-apps", CategoryId, "Quadratic Applications")
        .Subtitle("Projectile motion, area models, and optimization: the vertex is the max or min that matters")
        .Order(4).Minutes("32 min")
        .Section("Why quadratics show up in the real world",
            "Whenever a quantity depends on a square term, area (length times width when both involve x), gravity (height vs time under constant acceleration), or revenue (price times quantity when demand is linear), a quadratic model appears.\n\nTwo features drive applications:\n• Roots often mark start/stop events (launch and landing, break-even points).\n• The vertex marks an extreme value (max height, max area, max profit).\n\nCritical connection for this lesson: applications use the vertex as max/min. That is the same (h, k) or x = -b/(2a) skill from graphing, not a new formula family.",
            simple: "Quadratics model curves that turn. The turn point (vertex) is usually the answer to \"highest,\" \"lowest,\" or \"maximum.\" Roots answer \"when is it zero?\"",
            prior: "Vertex formula x = -b/(2a), vertex form, and solving quadratics by factoring or the formula.")
        .Section("Projectile height model",
            "In feet and seconds, a common model is h(t) = -16t^2 + v0 t + h0, where -16 comes from gravity (half of about 32 ft/s^2), v0 is initial upward velocity, and h0 is initial height. In meters: about -4.9t^2 + v0 t + h0.\n\n• Time of max height: t = -b/(2a) on h(t) = at^2 + bt + c.\n• Max height: h at that time (vertex y-value).\n• Landing: solve h(t) = 0 for t ≥ 0 (discard negative time).\n\nDomain discipline: time starts at 0; height must make sense for the story. Factoring a height equation uses the same zeros → \"when height is zero\" chain from solving.",
            @"t=-\frac{b}{2a}",
            simple: "Vertex → highest point when a < 0. Roots → when height is zero. Domain: time ≥ 0 and height that fits the story.",
            prior: "Graphing: a < 0 opens down so the vertex is a maximum; solving: h(t) = 0 finds landing times.")
        .Section("Optimization with a quadratic",
            "If profit, revenue, or area is a quadratic function of x with a < 0, the maximum is at the vertex. If a > 0, the vertex is a minimum (for example, cost models that open upward).\n\nYou do not need to test dozens of values. Compute x = -b/(2a), then evaluate the function there. Completing the square also reveals the max/min as the k in y = a(x - h)^2 + k, same vertex form as graphing.\n\nAlways check that the optimal x lies in the problem's domain (positive lengths, allowed production counts, and so on).",
            simple: "For max/min questions, find the vertex input, then plug in to get the extreme value. Sign of a tells you max vs min.",
            prior: "Vertex form and x = -b/(2a) from the graphing lesson.")
        .Section("Area problems and domain",
            "Classic setup: a rectangle with width x and length linear in x (for example 20 - x when a perimeter constraint fixes the sum of length and width). Area A(x) = x(20 - x) = 20x - x^2 is quadratic. Only x in an open interval where both sides are positive is meaningful (0 < x < 20).\n\nMax area occurs at the vertex x = 10, which makes a square in this symmetric case. Factoring A(x) = 0 gives the endpoints of the domain story (zero area when a side is zero), another zeros application.")
        .Section("Reading the question carefully",
            "\"When does it hit the ground?\" → root of h(t) = 0 (often the positive one).\n\"What is the maximum height?\" → vertex y-value, not the time alone.\n\"At what time is height maximum?\" → vertex x-value (here t).\n\"What width maximizes area?\" → vertex x-value, then maybe plug in for max area.\n\nMixing time with height, or input with output, is the most common application error. Label units: seconds vs feet, meters vs square meters.")
        .Section("Connecting the whole quadratics unit",
            "1) Factoring finds zeros; zeros are intercepts and \"when is it zero?\" times in stories.\n2) Completing the square / vertex form finds (h, k); applications read k as max or min value.\n3) Discriminant predicts whether a projectile model hits a given height line twice, once, or never (set h(t) = target and inspect D).\n4) Graphs unify everything: intercepts, vertex, open direction.\n\nIf a word problem feels new, translate it into one of those four tools instead of inventing a fifth method.")
        .Section("Reasonable answers and checks",
            "After computing, ask: is time positive? Is area positive? Is max height above the launch height when the object is thrown upward? Substitute the vertex time back into h(t). For area, check that length and width are both positive at your answer.\n\nA perfect algebraic vertex outside the domain is not the application's answer; restrict to the interval that the story allows.")
        .Formula("Vertex time or input", @"t=-\frac{b}{2a}", "For q(t) = at^2 + bt + c, input of max/min when a ≠ 0.")
        .Formula("Projectile (feet)", @"h(t)=-16t^2+v_0 t+h_0", "a = -16 < 0 so vertex is maximum height.")
        .Formula("Area with fixed sum of sides", @"A=x(L-x)=Lx-x^2", "Quadratic in x; max at x = L/2 when a = -1.")
        .Formula("Max or min value", @"q\left(-\frac{b}{2a}\right)", "Evaluate the quadratic at the vertex input to get the extreme output.")
        .Example("Maximum height of a projectile",
            "A ball's height is h(t) = -16t^2 + 64t (feet, seconds). Find the maximum height.",
            [
                "a = -16, b = 64. Time of max: t = -64 / (2 · (-16)) = -64 / -32 = 2 seconds.",
                "h(2) = -16(4) + 64(2) = -64 + 128 = 64 feet.",
                "Because a < 0, the parabola opens down; the vertex is truly a maximum.",
                "Wrong answer to avoid: saying \"max height is 2\" (that is the time, not the height).",
                "Unit link: applications use the vertex as max/min; graphing already named that point (h, k)."
            ],
            "Maximum height is 64 ft at t = 2 s.",
            problemLatex: @"h(t)=-16t^2+64t",
            solutionLatex: @"64",
            stepLatex: [@"t=2", @"h(2)=64", null, null, null],
            closingLatex: @"64")
        .Example("When does it land?",
            "Using h(t) = -16t^2 + 64t, when does the ball return to height 0?",
            [
                "Solve -16t^2 + 64t = 0 (zeros of the height model).",
                "Factor: -16t(t - 4) = 0 → t = 0 or t = 4.",
                "t = 0 is launch; t = 4 s is landing. Time in the air: 4 seconds.",
                "Check midpoint t = 2 is the max (previous example), symmetric flight under this simple model.",
                "Chain: factoring → zeros → \"when height is zero,\" same as x-intercepts of the height graph."
            ],
            "Lands at t = 4 s.",
            problemLatex: @"-16t^2+64t=0",
            solutionLatex: @"t=4",
            stepLatex: [@"-16t(t-4)=0", @"t=0,\;4", null, null, null],
            closingLatex: @"t=4")
        .Example("Maximum rectangular area",
            "A rectangle has width x and length 20 - x (same units). What width maximizes area, and what is that max area?",
            [
                "Area A(x) = x(20 - x) = 20x - x^2. Here a = -1, b = 20.",
                "Vertex at x = -20 / (2 · (-1)) = 10.",
                "A(10) = 10 · 10 = 100.",
                "Domain: 0 < x < 20. x = 10 is inside the domain; a square gives max area for this fixed perimeter-style constraint.",
                "A(x) = 0 at x = 0 and x = 20 (endpoints, zero area), another zeros story at the domain edges."
            ],
            "Max area 100 when x = 10 (a square).",
            problemLatex: @"A=x(20-x)",
            solutionLatex: @"100",
            stepLatex: [@"A=20x-x^2", @"x=10", @"A=100", null, null],
            closingLatex: @"100")
        .Example("Maximum revenue",
            "Revenue is modeled by R(x) = -2x^2 + 40x. Find the x that maximizes revenue and the max revenue.",
            [
                "a = -2, b = 40. Optimal x = -40 / (2 · (-2)) = -40 / -4 = 10.",
                "R(10) = -2(100) + 40(10) = -200 + 400 = 200.",
                "Since a < 0, this critical point is a maximum.",
                "Interpretation: if x is number of items (or a price tier index), operate at x = 10 for revenue 200 in the model's units.",
                "Same vertex tool as projectiles and area: only the story labels change."
            ],
            "Max revenue 200 at x = 10.",
            problemLatex: @"R(x)=-2x^2+40x",
            solutionLatex: @"200",
            stepLatex: [@"x=10", @"R(10)=200", null, null, null],
            closingLatex: @"200")
        .Mistake("Reporting the time of the vertex when the question asked for maximum height (or the reverse).")
        .Mistake("Ignoring domain: negative time, or lengths that make a side negative.")
        .Mistake("Using a root as if it were the maximum point.")
        .Mistake("Forgetting that a > 0 means the vertex is a minimum in optimization contexts.")
        .Mistake("Solving h(t) = 0 and keeping a negative time as a physical landing time.")
        .Numeric("h = -16t^2 + 48t. Time of max height?", "1.5",
            ["t = -48 / (2 · (-16)) = 48/32.", "t = 1.5 s."],
            "t = 1.5 s.",
            explanationLatex: @"t=1.5",
            tolerance: 0.01)
        .Numeric("h = -16t^2 + 64t. Maximum h?", "64",
            ["t = 2; h = -16(4) + 128.", "Max height 64."],
            "Max height 64.",
            explanationLatex: @"64")
        .Numeric("A = x(12 - x). What x maximizes A?", "6",
            ["A = -x^2 + 12x; vertex x = 12/2.", "x = 6."],
            "x = 6.",
            explanationLatex: @"6")
        .Numeric("A = x(12 - x). Maximum area value?", "36",
            ["A(6) = 6 · 6.", "Max area 36."],
            "Max area 36.",
            explanationLatex: @"36")
        .Mcq("For h = -5t^2 + 20t + 2, the parabola opens:",
            ["Up", "Down", "Left", "Right"], 1,
            ["Leading coefficient a = -5.", "a < 0 means opens down (typical projectile)."],
            "Down (typical projectile).")
        .Numeric("Ball lands: -16t^2 + 32t = 0. Positive t?", "2",
            ["Factor: -16t(t - 2) = 0.", "t = 0 or 2; positive landing time is 2."],
            "Positive landing time t = 2.",
            explanationLatex: @"t=2")
        .Numeric("R = -x^2 + 10x. Maximum R?", "25",
            ["Vertex at x = 5; R = -25 + 50.", "Max R = 25."],
            "Max R = 25.",
            explanationLatex: @"25")
        .Mcq("A ball's height is h(t) = -16t^2 + 32t + 48. The value h(0) = 48 represents:",
            ["Max height", "Time in air", "Initial height", "Landing time"], 2,
            ["At t = 0, height is the starting height h0.", "48 is initial height, not max height."],
            "Initial height 48.")
        .Takeaways(
            "Application questions usually ask either for a root (when a quantity is zero) or for a vertex (max/min value or when it occurs).",
            "For h(t) = at^2 + bt + c with a < 0, max height is the vertex y-value at t = -b/(2a).",
            "Landing and break-even times come from solving the quadratic equal to zero; keep domain t ≥ 0 when time is physical.",
            "Area and revenue models are often downward-opening quadratics; maximize at the vertex inside the allowed interval.",
            "The whole unit connects: factoring → zeros → intercepts; completing the square ↔ vertex form; D counts intercepts; apps use the vertex as max/min.")
        .Build();
}
