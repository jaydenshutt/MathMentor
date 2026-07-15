using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class Algebra2Lessons
{
    public const string CategoryId = "algebra2";

    public static Category Build()
    {
        var lessons = new[]
        {
            AbsoluteValueEquations(),
            RadicalExpressions(),
            ComplexNumbersIntro(),
            RationalEquations(),
            CompletingTheSquare()
        };
        return new Category(CategoryId, "Algebra II Essentials",
            "Absolute value, radicals, complex numbers, rational equations, and completing the square.",
            "\uE8A5", 6, lessons);
    }

    private static Lesson AbsoluteValueEquations() => new LessonBuilder("alg-abs-value", CategoryId, "Absolute Value Equations & Inequalities")
        .Subtitle("Distance from zero turns into cases, and inequalities become compound statements")
        .Order(1).Minutes("32 min")
        .Section("Why absolute value appears in equations",
            "Absolute value |A| means the distance from A to 0 on the number line. Distances are never negative, so |A| is always at least 0.\n\nWhen a problem says a quantity is a fixed distance from a target (tolerance, error bounds, distance on a line), absolute value is the natural model. Solving |expression| = k asks: which inputs make the expression land k units from zero?")
        .Section("The case rule for equations",
            "If k > 0, then |A| = k means A = k or A = -k. Geometrically, two points on the number line sit distance k from 0.\n\nIf k = 0, then |A| = 0 means A = 0 only (one solution).\n\nIf k < 0, then |A| = k has no solution, because a distance cannot equal a negative number.\n\nAlways isolate the absolute value first (get |something| alone on one side) before splitting into cases.",
            @"|A|=k\;(k>0)\Leftrightarrow A=k\text{ or }A=-k",
            simple: "Get the absolute value alone. If the other side is positive, write two equations: inside equals that number, or inside equals its opposite. If the other side is negative, no solution.",
            prior: "You should already solve linear equations and understand |a| as distance from zero (from integers and number line work).")
        .Section("Equations with absolute values on both sides",
            "For |A| = |B|, the distances match, so A = B or A = -B. You still get (at most) two linear cases. Check solutions in the original equation if isolation or algebra was messy, though pure |linear| = |linear| usually does not introduce extraneous roots the way radicals do.")
        .Section("Inequalities: less than means between",
            "For k > 0, |A| < k means -k < A < k (A is strictly inside the open interval from -k to k). |A| <= k means -k <= A <= k.\n\nWhy? Distance from 0 less than k is the open segment centered at 0. Graphically, shade between the boundary points.",
            @"|A|<k\Leftrightarrow -k<A<k\;(k>0)",
            simple: "Absolute value less than k: the inside sits between -k and k. Absolute value greater than k: the inside is left of -k or right of k.",
            prior: "Compound inequalities and graphing solution sets on a number line.")
        .Section("Inequalities: greater than means outside",
            "For k > 0, |A| > k means A < -k or A > k (union of two rays). |A| >= k means A <= -k or A >= k.\n\nIf k < 0, then |A| > k is true for all real A (every distance is at least 0, which is already greater than a negative). |A| < k with k <= 0 has no solution.")
        .Section("A reliable process checklist",
            "1) Isolate the absolute value expression.\n2) Compare the other side to 0 (negative means special cases).\n3) Split into the correct cases or compound inequality.\n4) Solve each piece.\n5) Write the solution as a union or interval, and check boundary points when the inequality is non-strict.")
        .Formula("Equation cases", @"|A|=k\Leftrightarrow A=k\text{ or }A=-k\;(k>0)", "Two points at distance k from zero.")
        .Formula("Less than", @"|A|<k\Leftrightarrow -k<A<k\;(k>0)", "Between the boundary values.")
        .Formula("Greater than", @"|A|>k\Leftrightarrow A<-k\text{ or }A>k\;(k>0)", "Outside the boundary values.")
        .Example("Simple absolute value equation",
            "Solve |x - 3| = 5.",
            [
                "The absolute value is already isolated. Right side 5 > 0, so two cases apply.",
                "Case 1: x - 3 = 5 → x = 8.",
                "Case 2: x - 3 = -5 → x = -2.",
                "Check: |8-3|=5 and |-2-3|=5. Both work. Solutions x = 8 or x = -2."
            ],
            "x = 8 or x = -2.",
            problemLatex: @"|x-3|=5",
            solutionLatex: @"x=8\text{ or }x=-2",
            stepLatex: [@"x-3=5\text{ or }x-3=-5", @"x=8", @"x=-2", null])
        .Example("Isolate first",
            "Solve 2|x + 1| - 4 = 6.",
            [
                "Add 4: 2|x + 1| = 10. Divide by 2: |x + 1| = 5.",
                "Split: x + 1 = 5 or x + 1 = -5.",
                "x = 4 or x = -6.",
                "Check: 2|4+1|-4=2·5-4=6; 2|-6+1|-4=2·5-4=6. Both valid."
            ],
            "x = 4 or x = -6.",
            problemLatex: @"2|x+1|-4=6",
            solutionLatex: @"x=4\text{ or }x=-6",
            stepLatex: [@"|x+1|=5", @"x+1=\pm 5", @"x=4,\;-6", null])
        .Example("Absolute value inequality (less than)",
            "Solve |2x - 1| < 7.",
            [
                "Right side positive: rewrite as a double inequality -7 < 2x - 1 < 7.",
                "Add 1 throughout: -6 < 2x < 8.",
                "Divide by 2: -3 < x < 4.",
                "In interval notation: (-3, 4). Boundary points x=-3 and x=4 give |2x-1|=7, not less than 7, so they stay out."
            ],
            "-3 < x < 4.",
            problemLatex: @"|2x-1|<7",
            solutionLatex: @"-3<x<4",
            stepLatex: [@"-7<2x-1<7", @"-6<2x<8", @"-3<x<4", null])
        .Example("Absolute value inequality (greater than)",
            "Solve |x + 2| >= 3.",
            [
                "Greater-or-equal splits into two rays: x + 2 <= -3 or x + 2 >= 3.",
                "First: x <= -5. Second: x >= 1.",
                "Solution: x <= -5 or x >= 1, written (-∞, -5] U [1, ∞).",
                "Check a test point in the middle, say x=0: |0+2|=2 < 3, not a solution, as expected for the gap between -5 and 1."
            ],
            "x <= -5 or x >= 1.",
            problemLatex: @"|x+2|\geq 3",
            solutionLatex: @"x\leq -5\text{ or }x\geq 1",
            stepLatex: [@"x+2\leq -3\text{ or }x+2\geq 3", @"x\leq -5\text{ or }x\geq 1", null, null])
        .Mistake("Writing only one case for |A| = k (forgetting A = -k).")
        .Mistake("Treating |A| = -3 as having solutions (distance cannot be negative).")
        .Mistake("Solving |A| < k as A < k only, instead of -k < A < k.")
        .Mistake("Using \"and\" when |A| > k requires \"or\" (two separate outer regions).")
        .Mistake("Splitting into cases before isolating the absolute value expression.")
        .Numeric("Solve |x|=4. What is the positive solution?", "4",
            ["|x|=4 → x=4 or x=-4."],
            "Positive solution is 4.", explanationLatex: @"4")
        .Numeric("Solve |x-2|=6. What is the larger solution?", "8",
            ["x-2=6 or x-2=-6 → x=8 or x=-4."],
            "Larger solution is 8.", explanationLatex: @"8")
        .Numeric("Solve |x+1|=0. What is x?", "-1",
            ["Only when the inside is 0: x+1=0."],
            "x = -1.", explanationLatex: @"x=-1")
        .Mcq("How many real solutions does |x| = -2 have?",
            ["0", "1", "2", "Infinitely many"], 0,
            ["Absolute value is never negative."],
            "Zero solutions; a distance cannot equal -2.")
        .Mcq("|x| < 3 is equivalent to:",
            ["x < 3 only", "-3 < x < 3", "x < -3 or x > 3", "x > 3"], 1,
            ["Distance from 0 less than 3 is the open interval between -3 and 3."],
            "-3 < x < 3.")
        .Mcq("|x| > 2 is equivalent to:",
            ["-2 < x < 2", "x > 2 only", "x < -2 or x > 2", "x >= 2"], 2,
            ["Greater than means outside the interval."],
            "x < -2 or x > 2.")
        .Numeric("Solve 3|x|=12. What is the positive x?", "4",
            ["|x|=4 → x=±4."],
            "Positive solution is 4.", explanationLatex: @"4")
        .Numeric("For |2x-4| < 6, the solution is a < x < b. What is b?", "5",
            ["-6 < 2x-4 < 6 → -2 < 2x < 10 → -1 < x < 5."],
            "Upper bound b = 5.", explanationLatex: @"5")
        .Mcq("Which equation has exactly one real solution?",
            ["|x|=5", "|x-1|=0", "|x|=-1", "|x+2|=3"], 1,
            ["Absolute value zero forces the inside to be zero."],
            "|x-1|=0 has the single solution x=1.")
        .Build();

    private static Lesson RadicalExpressions() => new LessonBuilder("alg-radicals", CategoryId, "Radical Expressions & Equations")
        .Subtitle("Simplify roots with product and quotient rules, then solve and check for extraneous answers")
        .Order(2).Minutes("34 min")
        .Section("Why radicals need careful domain",
            "In real numbers, √A is defined only when A >= 0, and √A itself is the principal (non-negative) square root. That is why √9 = 3, not ±3. The equation x² = 9 still has two solutions, but the radical symbol names only the principal root.\n\nCube roots are defined for negative inputs (∛(-8) = -2), but most Algebra II radical work focuses on square roots and their restrictions.")
        .Section("Product and quotient rules",
            "For non-negative a, b (and b > 0 in a denominator):\n√(a·b) = √a · √b, and √(a/b) = √a / √b.\n\nThese let you factor perfect squares out of a radical: √50 = √(25·2) = 5√2. The reverse (combining √a · √b into √(ab)) is useful when simplifying products.",
            @"\sqrt{ab}=\sqrt{a}\sqrt{b}\;(a,b\geq 0)",
            simple: "Factor the number under the root. Pull perfect squares out as ordinary factors. Leave what is left under the radical.",
            prior: "Prime factoring, perfect squares (4, 9, 16, 25, ...), and fraction arithmetic.")
        .Section("Simplifying radical expressions",
            "1) Factor the radicand completely (or into perfect-square factors).\n2) Apply √(m²·n) = m√n when m >= 0 (and track absolute value carefully if m could be negative for variable expressions: √(x²) = |x|).\n3) Reduce coefficients and combine like radical terms (same radicand), treating √k like a unit: 3√2 + 5√2 = 8√2.")
        .Section("Rationalizing denominators",
            "A classic style preference is no radical in the denominator. Multiply by a clever 1: 1/√2 · √2/√2 = √2/2. For two-term denominators, multiply by the conjugate: 1/(√3 - 1) · (√3 + 1)/(√3 + 1) uses difference of squares.")
        .Section("Solving radical equations",
            "Isolate one radical, then square both sides. Squaring can create extraneous solutions because if A = B then A² = B², but A² = B² does not force A = B (it allows A = -B too).\n\nAlways substitute candidate answers into the original equation, and reject any that make a radicand negative or fail to satisfy the isolated forms.",
            simple: "Isolate the root. Square both sides. Solve the new equation. Plug every answer back into the original and keep only the true ones.",
            prior: "Solving linear and quadratic equations; knowing that squaring is not always reversible.")
        .Section("Higher roots and short notes",
            "∛(a³) = a for real a. For even roots, the radicand must be non-negative in the reals. Fractional exponents connect roots and powers: a^{1/2} = √a, a^{m/n} = (a^{1/n})ᵐ when defined. Keep domains honest whenever an even root appears.")
        .Formula("Product rule", @"\sqrt{ab}=\sqrt{a}\sqrt{b}\;(a,b\geq 0)", "Factor perfect squares out of the radicand.")
        .Formula("Principal square root", @"\sqrt{a}\geq 0\;(a\geq 0)", "The radical symbol names the non-negative root.")
        .Formula("Square both sides carefully", @"A=B\Rightarrow A^2=B^2", "Converse is false: check for extraneous solutions.")
        .Example("Simplify a radical",
            "Simplify √72.",
            [
                "Factor 72 = 36 · 2, and 36 is a perfect square.",
                "√72 = √(36 · 2) = √36 · √2 = 6√2.",
                "Check: 6√2 ≈ 6·1.414 = 8.484, and √72 ≈ 8.485, matches.",
                "Could also write 72 = 4 · 18 → 2√18 = 2√(9·2) = 6√2, same result."
            ],
            "6√2.",
            problemLatex: @"\sqrt{72}",
            solutionLatex: @"6\sqrt{2}",
            stepLatex: [@"\sqrt{36\cdot 2}", @"6\sqrt{2}", null, null])
        .Example("Combine like radicals",
            "Simplify 5√12 + 3√3.",
            [
                "First simplify √12: √12 = √(4·3) = 2√3.",
                "Then 5√12 = 5 · 2√3 = 10√3.",
                "Add like terms: 10√3 + 3√3 = 13√3.",
                "Unlike radicands cannot combine (√2 + √3 is already simplest)."
            ],
            "13√3.",
            problemLatex: @"5\sqrt{12}+3\sqrt{3}",
            solutionLatex: @"13\sqrt{3}",
            stepLatex: [@"\sqrt{12}=2\sqrt{3}", @"5\sqrt{12}=10\sqrt{3}", @"13\sqrt{3}", null])
        .Example("Solve a radical equation",
            "Solve √(x + 3) = 5.",
            [
                "The radical is isolated. Square both sides: x + 3 = 25.",
                "x = 22.",
                "Check: √(22 + 3) = √25 = 5. Matches the right side.",
                "Domain of the original: x + 3 >= 0 → x >= -3; x = 22 is allowed."
            ],
            "x = 22.",
            problemLatex: @"\sqrt{x+3}=5",
            solutionLatex: @"x=22",
            stepLatex: [@"x+3=25", @"x=22", @"\sqrt{25}=5", null])
        .Example("Extraneous solution after squaring",
            "Solve √(2x + 3) = x.",
            [
                "Domain: 2x + 3 >= 0 → x >= -3/2. Also the principal root is >= 0, so the right side x must be >= 0 for equality to be possible.",
                "Square: 2x + 3 = x² → x² - 2x - 3 = 0 → (x - 3)(x + 1) = 0 → x = 3 or x = -1.",
                "Check x = 3: √(6+3) = √9 = 3. Good.",
                "Check x = -1: √(2(-1)+3) = √1 = 1, which is not equal to -1. Reject x = -1 (extraneous)."
            ],
            "Only x = 3.",
            problemLatex: @"\sqrt{2x+3}=x",
            solutionLatex: @"x=3",
            stepLatex: [@"2x+3=x^2", @"(x-3)(x+1)=0", @"x=3\text{ works};\;x=-1\text{ fails}", null])
        .Mistake("Writing √9 = ±3 (the radical symbol is the principal non-negative root).")
        .Mistake("Combining unlike radicals: √2 + √8 is not √10 without simplifying first carefully (√8=2√2, so √2+2√2=3√2).")
        .Mistake("Forgetting to check solutions after squaring both sides.")
        .Mistake("Canceling √ across addition: √(a+b) is not √a + √b in general.")
        .Mistake("Ignoring domain: accepting answers that make a radicand negative in the original equation.")
        .Numeric("Simplify √50 as k√2. What is k?", "5",
            ["√50 = √(25·2) = 5√2."],
            "k = 5.", explanationLatex: @"5")
        .Numeric("√36 equals?", "6",
            ["Principal square root of 36 is 6."],
            "6.", explanationLatex: @"6")
        .Numeric("Solve √x = 4. What is x?", "16",
            ["Square: x = 16. Check: √16 = 4."],
            "x = 16.", explanationLatex: @"16")
        .Numeric("Simplify 2√27 as k√3. What is k?", "6",
            ["√27 = 3√3, so 2·3√3 = 6√3."],
            "k = 6.", explanationLatex: @"6")
        .Mcq("Which is true for real numbers?",
            ["√(-4) = -2", "√4 = ±2", "√4 = 2", "√9 = -3"], 2,
            ["Principal square root is non-negative; √ of a negative is not real."],
            "√4 = 2.")
        .Mcq("After solving by squaring, you must:",
            ["Always accept both answers", "Check candidates in the original equation", "Discard the larger root", "Multiply by the conjugate"], 1,
            ["Squaring can introduce extraneous solutions."],
            "Check every candidate in the original equation.")
        .Numeric("√(x-1)=3. What is x?", "10",
            ["x-1=9 → x=10. Check: √9=3."],
            "x = 10.", explanationLatex: @"10")
        .Numeric("3√2 + 5√2 = k√2. What is k?", "8",
            ["Add coefficients: 3+5=8."],
            "k = 8.", explanationLatex: @"8")
        .Mcq("√(a+b) equals √a + √b:",
            ["Always", "Never", "Only for special values (not as an identity)", "When a=b only always"], 2,
            ["Counterexample: a=b=1 gives √2 ≠ 2. Equality fails as a general rule."],
            "Not an identity; only special cases if any.")
        .Build();

    private static Lesson ComplexNumbersIntro() => new LessonBuilder("alg-complex", CategoryId, "Complex Numbers Intro")
        .Subtitle("Define i, write a + bi form, and extend arithmetic past the reals")
        .Order(3).Minutes("32 min")
        .Section("Why invent complex numbers?",
            "Equations like x² + 1 = 0 have no real solution, because no real square is -1. Complex numbers extend the number system so that polynomial equations can have a full set of roots (the Fundamental Theorem of Algebra, stated later in full generality).\n\nIn this lesson, the practical goal is smaller: define the imaginary unit, write numbers as a + bi, and add, subtract, multiply, and divide with conjugates.")
        .Section("The imaginary unit i",
            "Define i by i² = -1 (equivalently i = √(-1) as a formal symbol in this course). Then i³ = i² · i = -i, and i⁴ = (i²)² = 1. Powers of i cycle every 4: i, -1, -i, 1, then repeat.\n\nFor positive real k, √(-k) is written i√k in standard form (principal branch conventions appear more carefully in advanced courses).",
            @"i^2=-1",
            simple: "i is a new number whose square is -1. Treat it like a variable, except replace i² with -1 whenever it appears.",
            prior: "Comfort with real arithmetic, radicals, and simplifying expressions with a placeholder letter.")
        .Section("Standard form a + bi",
            "A complex number is z = a + bi with real a (real part) and real b (imaginary part). Examples: 3 + 2i, -1 + 0i (a pure real), 0 + 5i (a pure imaginary).\n\nTwo complex numbers are equal when their real parts match and their imaginary parts match: a + bi = c + di means a = c and b = d.")
        .Section("Add, subtract, multiply",
            "Add/subtract componentwise: (a+bi) + (c+di) = (a+c) + (b+d)i.\n\nMultiply by distributing (FOIL) and replace i² with -1: (a+bi)(c+di) = ac + adi + bci + bdi² = (ac - bd) + (ad + bc)i.\n\nExample: (2+3i)(1-4i) = 2 - 8i + 3i - 12i² = 2 - 5i + 12 = 14 - 5i.")
        .Section("Conjugates and division",
            "The conjugate of a + bi is a - bi (flip the sign of the imaginary part). The product (a+bi)(a-bi) = a² + b² is a real number (never negative as a sum of squares).\n\nTo divide, multiply numerator and denominator by the conjugate of the denominator, then simplify to a + bi form.",
            @"\frac{a+bi}{c+di}\cdot\frac{c-di}{c-di}",
            simple: "For division, multiply top and bottom by the conjugate of the bottom. Simplify; use i² = -1. Write the answer as real part plus i times imaginary part.",
            prior: "Rationalizing denominators with conjugates (same pattern as √ expressions).")
        .Section("Complex solutions of quadratics (preview)",
            "When the discriminant D = b² - 4ac is negative, the quadratic formula still works and yields complex conjugates: if one root is p + qi with q ≠ 0, the other is p - qi for real-coefficient polynomials. Example: x² + 1 = 0 → x = ±i.")
        .Formula("Imaginary unit", @"i^2=-1", "Foundation of complex arithmetic.")
        .Formula("Standard form", @"z=a+bi", "a real part, b imaginary part (both real).")
        .Formula("Conjugate product", @"(a+bi)(a-bi)=a^2+b^2", "Used to divide complex numbers.")
        .Example("Powers of i",
            "Simplify i^7.",
            [
                "Reduce the exponent mod 4: powers cycle every 4.",
                "7 = 4·1 + 3, so i^7 = i^3.",
                "i^3 = i² · i = (-1)·i = -i.",
                "Check: i^4 = 1, so i^7 = i^4 · i^3 = 1 · (-i) = -i."
            ],
            "i^7 = -i.",
            problemLatex: @"i^7",
            solutionLatex: @"-i",
            stepLatex: [@"i^7=i^{4+3}=i^3", @"i^3=-i", null, null])
        .Example("Multiply complex numbers",
            "Compute (3 - 2i)(4 + i).",
            [
                "FOIL: 3·4 + 3·i + (-2i)·4 + (-2i)·i = 12 + 3i - 8i - 2i².",
                "Replace i² with -1: -2i² = -2(-1) = 2.",
                "Combine: (12 + 2) + (3 - 8)i = 14 - 5i.",
                "Real part 14, imaginary part -5."
            ],
            "14 - 5i.",
            problemLatex: @"(3-2i)(4+i)",
            solutionLatex: @"14-5i",
            stepLatex: [@"12+3i-8i-2i^2", @"12+2+(3-8)i", @"14-5i", null])
        .Example("Divide using the conjugate",
            "Write (1 + i)/(1 - i) in a + bi form.",
            [
                "Multiply numerator and denominator by the conjugate of the denominator, 1 + i.",
                "Numerator: (1+i)(1+i) = 1 + 2i + i² = 1 + 2i - 1 = 2i.",
                "Denominator: (1-i)(1+i) = 1 - i² = 1 - (-1) = 2.",
                "Result: 2i / 2 = i, which is 0 + 1i."
            ],
            "i (or 0 + i).",
            problemLatex: @"\frac{1+i}{1-i}",
            solutionLatex: @"i",
            stepLatex: [@"\frac{(1+i)^2}{1-i^2}", @"\frac{2i}{2}", @"i", null])
        .Example("Quadratic with complex roots",
            "Solve x² + 4x + 13 = 0.",
            [
                "a=1, b=4, c=13. Discriminant D = 16 - 52 = -36.",
                "x = (-4 ± √(-36)) / 2 = (-4 ± 6i) / 2.",
                "x = -2 ± 3i.",
                "The roots are complex conjugates: -2 + 3i and -2 - 3i."
            ],
            "x = -2 ± 3i.",
            problemLatex: @"x^2+4x+13=0",
            solutionLatex: @"x=-2\pm 3i",
            stepLatex: [@"D=-36", @"x=\frac{-4\pm 6i}{2}", @"x=-2\pm 3i", null])
        .Mistake("Writing i² = 1 or i² = i instead of i² = -1.")
        .Mistake("Adding real and imaginary parts into one number (3 + 2i is not 5).")
        .Mistake("Forgetting to distribute the conjugate to both numerator and denominator when dividing.")
        .Mistake("Treating √(-9) as -3 instead of 3i (in this course's standard form).")
        .Mistake("Stopping at (-4 ± √(-36))/2 without simplifying to a + bi form.")
        .Numeric("What is i² as an integer?", "-1",
            ["By definition i² = -1."],
            "i² = -1.", explanationLatex: @"-1")
        .Numeric("Real part of 5 - 3i?", "5",
            ["In a+bi, a is the real part."],
            "Real part is 5.", explanationLatex: @"5")
        .Numeric("Imaginary part of 2 + 7i? (the real coefficient of i)", "7",
            ["In a+bi, b is the imaginary part."],
            "Imaginary part is 7.", explanationLatex: @"7")
        .Mcq("i^4 equals:",
            ["i", "-1", "-i", "1"], 3,
            ["i^4 = (i²)² = (-1)² = 1."],
            "1.")
        .Mcq("(2+3i) + (1-5i) equals:",
            ["3 - 2i", "3 + 8i", "1 - 2i", "2 - 15i"], 0,
            ["Add reals 2+1=3; add imaginaries 3+(-5)=-2."],
            "3 - 2i.")
        .Numeric("(3+i)(3-i) equals what real number?", "10",
            ["Difference of squares: 9 - i² = 9 - (-1) = 10."],
            "10.", explanationLatex: @"10")
        .Numeric("Solve x² = -16. What is the positive imaginary solution as a real multiple of i? (enter the coefficient of i)", "4",
            ["x = ±4i; positive imaginary means 4i, coefficient 4."],
            "4i has coefficient 4.", explanationLatex: @"4")
        .Mcq("The conjugate of 4 - 5i is:",
            ["-4 + 5i", "4 + 5i", "-4 - 5i", "5 - 4i"], 1,
            ["Flip the sign of the imaginary part only."],
            "4 + 5i.")
        .Mcq("For x² + 1 = 0, the solutions are:",
            ["x = 1 only", "x = ±1", "x = ±i", "no solutions in any system"], 2,
            ["x² = -1 → x = ±i."],
            "x = i or x = -i.")
        .Build();

    private static Lesson RationalEquations() => new LessonBuilder("alg-rational-eq", CategoryId, "Rational Equations")
        .Subtitle("Clear denominators with an LCD, then reject values that make a denominator zero")
        .Order(4).Minutes("34 min")
        .Section("What a rational equation is",
            "A rational equation has at least one variable expression in a denominator (or is an equality of rational expressions). Examples: 1/x = 3, (x+1)/(x-2) = 4, 2/(x+1) + 3/x = 1.\n\nUnlike simplifying a single rational expression, here the goal is to find x-values that make the equation true, while never allowing a zero denominator.")
        .Section("Why LCD clearing works",
            "If two fractions are equal, multiplying both sides by the same nonzero quantity preserves equality. Multiplying every term by a common multiple of all denominators cancels each denominator and leaves a polynomial (often linear or quadratic) equation.\n\nThe catch: the multiplier is zero at excluded values, so those x cannot be solutions even if they satisfy the cleared equation. Always list excluded values first (or check at the end).",
            simple: "Find every x that makes any denominator zero and ban those values. Multiply through by the LCD. Solve what remains. Throw out banned values.",
            prior: "Simplifying rational expressions, factoring, and solving linear/quadratic equations.")
        .Section("Step-by-step method",
            "1) Factor denominators if helpful.\n2) State domain restrictions: any x that makes a denominator zero is excluded.\n3) Identify the LCD of all denominators.\n4) Multiply every term on both sides by the LCD.\n5) Solve the resulting equation.\n6) Discard any candidate that was excluded (extraneous). Verify remaining answers in the original equation.")
        .Section("Proportions and cross multiplying",
            "If the equation is a single proportion a/b = c/d (with b, d ≠ 0), then ad = bc provided you still respect exclusions. Cross multiplying is LCD clearing in disguise for two fractions. If more than two fractional terms appear, prefer the full LCD method so you do not drop terms.")
        .Section("Extraneous solutions",
            "Clearing denominators can manufacture solutions that make an original denominator zero. Those must be rejected. Example sketch: after clearing, you might get x = 2, but if x - 2 was a denominator, x = 2 is not allowed.\n\nAlso watch for equations that simplify to a contradiction (no solution) or an identity on the allowed domain.")
        .Section("Worked strategy tips",
            "Keep algebra tidy: distribute carefully after multiplying by the LCD. Combine like terms before moving everything to one side. For quadratics, factor or use the formula, then filter through the restricted domain.")
        .Formula("Clearing denominators", @"\frac{a}{b}=\frac{c}{d}\Rightarrow ad=bc\;(b,d\neq 0)", "Proportion form; still enforce domain.")
        .Formula("LCD multiply", @"\text{multiply every term by LCD}", "Cancels denominators; check excluded values after.")
        .Formula("Excluded values", @"\text{denominator}=0\Rightarrow x\text{ not allowed}", "Non-negotiable domain restriction.")
        .Example("Simple rational equation",
            "Solve 3/x = 6/(x + 1).",
            [
                "Exclusions: x ≠ 0 and x ≠ -1.",
                "Cross multiply (or LCD x(x+1)): 3(x+1) = 6x.",
                "3x + 3 = 6x → 3 = 3x → x = 1.",
                "x = 1 is allowed (not 0 or -1). Check: 3/1 = 3; 6/2 = 3. Equal."
            ],
            "x = 1.",
            problemLatex: @"\frac{3}{x}=\frac{6}{x+1}",
            solutionLatex: @"x=1",
            stepLatex: [@"3(x+1)=6x", @"3x+3=6x", @"x=1", null])
        .Example("LCD with three terms",
            "Solve 1/x + 1/2 = 1/3.",
            [
                "Exclusion: x ≠ 0. LCD of x, 2, 3 is 6x.",
                "Multiply every term by 6x: 6x·(1/x) + 6x·(1/2) = 6x·(1/3).",
                "6 + 3x = 2x.",
                "6 = 2x - 3x → 6 = -x → x = -6. Allowed. Check: 1/(-6) + 1/2 = -1/6 + 3/6 = 2/6 = 1/3."
            ],
            "x = -6.",
            problemLatex: @"\frac{1}{x}+\frac{1}{2}=\frac{1}{3}",
            solutionLatex: @"x=-6",
            stepLatex: [@"\times 6x", @"6+3x=2x", @"x=-6", null])
        .Example("Extraneous root rejected",
            "Solve (x + 2)/(x - 1) = 3/(x - 1).",
            [
                "Exclusion: x ≠ 1, because both sides have denominator x - 1.",
                "Multiply both sides by (x - 1): x + 2 = 3.",
                "Then x = 1.",
                "But x = 1 is excluded. It makes the original undefined, so it is extraneous. Solution set is empty."
            ],
            "No solution (empty set).",
            problemLatex: @"\frac{x+2}{x-1}=\frac{3}{x-1}",
            solutionLatex: @"\emptyset",
            stepLatex: [@"x+2=3", @"x=1", @"x=1\text{ excluded}", @"\emptyset"])
        .Example("Quadratic after clearing",
            "Solve (x + 1)/(x - 1) = 2/x (with x ≠ 0, x ≠ 1).",
            [
                "Exclusions: x ≠ 0, x ≠ 1. Cross multiply: x(x + 1) = 2(x - 1).",
                "Expand: x² + x = 2x - 2. Bring all terms left: x² + x - 2x + 2 = 0 → x² - x + 2 = 0.",
                "Discriminant 1 - 8 = -7 < 0, so no real roots of the cleared equation.",
                "Conclusion: no real x satisfies the original equation."
            ],
            "No real solution.",
            problemLatex: @"\frac{x+1}{x-1}=\frac{2}{x}",
            solutionLatex: @"\emptyset",
            stepLatex: [@"x(x+1)=2(x-1)", @"x^2-x+2=0", @"D=-7", @"\emptyset"])
        .Mistake("Forgetting to exclude values that make a denominator zero.")
        .Mistake("Multiplying only some terms by the LCD, not every term on both sides.")
        .Mistake("Canceling a variable factor before considering that it might be zero (losing or gaining roots incorrectly).")
        .Mistake("Cross multiplying when the equation is not a single pair of fractions.")
        .Mistake("Accepting an algebraic solution that makes an original denominator zero.")
        .Numeric("Solve 4/x = 2. What is x?", "2",
            ["4 = 2x → x = 2. Check x ≠ 0."],
            "x = 2.", explanationLatex: @"2")
        .Numeric("Solve 1/x = 1/5. What is x?", "5",
            ["Cross multiply: x = 5."],
            "x = 5.", explanationLatex: @"5")
        .Numeric("For 2/(x-3)=1, what is x?", "5",
            ["2 = x-3 → x=5. Check x≠3."],
            "x = 5.", explanationLatex: @"5")
        .Mcq("When solving a rational equation, values that make a denominator zero are:",
            ["Always solutions", "Never solutions", "Solutions only if numerator is also zero", "Ignored"], 1,
            ["The original expression is undefined there."],
            "Never solutions of the original equation.")
        .Mcq("Best first step for 1/x + 1/(x+1) = 1/2 is:",
            ["Cross multiply immediately as one proportion", "Multiply through by the LCD 2x(x+1)", "Set each numerator to zero", "Square both sides"], 1,
            ["Three denominators: use the full LCD."],
            "Multiply every term by 2x(x+1).")
        .Numeric("Solve 6/(x+1)=3. What is x?", "1",
            ["6 = 3(x+1) → 2 = x+1 → x=1."],
            "x = 1.", explanationLatex: @"1")
        .Numeric("Solve 5/x + 1 = 2. What is x?", "5",
            ["5/x = 1 → x = 5."],
            "x = 5.", explanationLatex: @"5")
        .Mcq("After clearing denominators you get x = 4, but x - 4 was a denominator. The solution set is:",
            ["{4}", "all reals", "empty set (for that candidate)", "{0, 4}"], 2,
            ["x=4 is excluded; if it was the only candidate, there is no solution."],
            "Reject x=4; empty if nothing else remains.")
        .Numeric("Solve 3/(x-1)=3/2. What is x?", "3",
            ["Cross: 3·2 = 3(x-1) → 2 = x-1 → x=3."],
            "x = 3.", explanationLatex: @"3")
        .Build();

    private static Lesson CompletingTheSquare() => new LessonBuilder("quad-complete-square", CategoryId, "Completing the Square")
        .Subtitle("A quadratic technique for solving, vertex form, and understanding the quadratic formula")
        .Order(5).Minutes("36 min")
        .Section("Why complete the square?",
            "Completing the square rewrites a quadratic so a perfect square trinomial appears. That serves three goals:\n1) Solve ax² + bx + c = 0 by reducing to a square equal to a constant.\n2) Convert y = ax² + bx + c into vertex form y = a(x - h)² + k for graphing and max/min.\n3) Derive the quadratic formula once and for all by completing the square on the general equation.\n\nIt is a core Algebra II / quadratic skill even when the formula is available, because vertex form is often what applications need.")
        .Section("The perfect square pattern",
            "Recall (x + p)² = x² + 2px + p². So a trinomial x² + bx is almost a square: half of b is p = b/2, and the missing piece is p² = (b/2)².\n\nIdentity: x² + bx = (x + b/2)² - (b/2)². Adding and subtracting (b/2)² rearranges the expression without changing its value.",
            @"x^2+bx=(x+\frac{b}{2})^2-(\frac{b}{2})^2",
            simple: "Take half of the middle coefficient, square it, and that number completes the square. Write the square of (x + half).",
            prior: "Expanding (x+p)², solving by square roots (x² = k → x = ±√k), and basic fraction arithmetic.")
        .Section("Solving equations by completing the square",
            "For x² + bx + c = 0:\n1) Move c: x² + bx = -c.\n2) Add (b/2)² to both sides.\n3) Left side becomes (x + b/2)².\n4) Take square roots: x + b/2 = ±√(right side).\n5) Solve for x.\n\nIf the leading coefficient is a ≠ 1, divide through by a first (or factor a out carefully when converting functions to vertex form).")
        .Section("Vertex form connection",
            "For f(x) = x² + bx + c, complete the square to get f(x) = (x - h)² + k with h = -b/2 and k = f(h). For f(x) = a(x² + (b/a)x) + c, factor a from the x terms, complete the square inside, then distribute a back.\n\nVertex is (h, k). This is the same h = -b/(2a) you use for axis of symmetry.",
            @"y=a(x-h)^2+k")
        .Section("Link to the quadratic formula",
            "Starting from ax² + bx + c = 0, divide by a, complete the square, and simplify. You arrive at x = (-b ± √(b² - 4ac))/(2a). Completing the square is not competing with the formula; it is the reason the formula is true.")
        .Section("Common pitfalls checklist",
            "• Forget to add (b/2)² to both sides (only adding to one side breaks equality).\n• Half of an odd b is a fraction; keep exact fractions, do not round mid-stream.\n• When a ≠ 1, divide first or track a when you factor it out.\n• After taking square roots, include ±.\n• For vertex form of a function, you add and subtract inside (or balance outside) carefully so the function values stay the same.")
        .Formula("Complete the square", @"x^2+bx+(\frac{b}{2})^2=(x+\frac{b}{2})^2", "Add the square of half the linear coefficient.")
        .Formula("Vertex form", @"y=a(x-h)^2+k", "Vertex (h,k); obtained by completing the square.")
        .Formula("Quadratic formula (result)", @"x=\frac{-b\pm\sqrt{b^2-4ac}}{2a}", "Completing the square on the general quadratic.")
        .Example("Solve by completing the square",
            "Solve x² + 6x + 5 = 0 by completing the square.",
            [
                "Move constant: x² + 6x = -5.",
                "Half of 6 is 3; 3² = 9. Add 9 to both sides: x² + 6x + 9 = 4.",
                "Left side (x + 3)² = 4. Square roots: x + 3 = ±2.",
                "x + 3 = 2 → x = -1. x + 3 = -2 → x = -5. Check: (-1)²+6(-1)+5=0; 25-30+5=0."
            ],
            "x = -1 or x = -5.",
            problemLatex: @"x^2+6x+5=0",
            solutionLatex: @"x=-1,\;-5",
            stepLatex: [@"x^2+6x=-5", @"x^2+6x+9=4", @"(x+3)^2=4", @"x=-1\text{ or }x=-5"])
        .Example("Half is a fraction",
            "Solve x² + 5x + 4 = 0 by completing the square.",
            [
                "x² + 5x = -4. Half of 5 is 5/2; (5/2)² = 25/4.",
                "Add 25/4: x² + 5x + 25/4 = -4 + 25/4 = (-16+25)/4 = 9/4.",
                "(x + 5/2)² = 9/4. Then x + 5/2 = ±3/2.",
                "x = -5/2 + 3/2 = -1, or x = -5/2 - 3/2 = -4. Roots -1 and -4."
            ],
            "x = -1 or x = -4.",
            problemLatex: @"x^2+5x+4=0",
            solutionLatex: @"x=-1,\;-4",
            stepLatex: [@"(\frac{5}{2})^2=\frac{25}{4}", @"(x+\frac{5}{2})^2=\frac{9}{4}", @"x=-\frac{5}{2}\pm\frac{3}{2}", @"x=-1,\;-4"])
        .Example("Vertex form of a function",
            "Rewrite y = x² - 4x + 1 in vertex form and name the vertex.",
            [
                "Group x terms: y = (x² - 4x) + 1. Half of -4 is -2; (-2)² = 4.",
                "Add and subtract 4 inside: y = (x² - 4x + 4 - 4) + 1 = (x - 2)² - 4 + 1.",
                "y = (x - 2)² - 3.",
                "Vertex is (2, -3). Opens upward. Axis x = 2."
            ],
            "y = (x - 2)² - 3; vertex (2, -3).",
            problemLatex: @"y=x^2-4x+1",
            solutionLatex: @"y=(x-2)^2-3",
            stepLatex: [@"y=(x^2-4x+4)+1-4", @"y=(x-2)^2-3", @"\text{vertex }(2,-3)", null])
        .Example("Leading coefficient not 1",
            "Solve 2x² + 8x - 10 = 0 by completing the square.",
            [
                "Divide by 2: x² + 4x - 5 = 0 → x² + 4x = 5.",
                "Half of 4 is 2; 2² = 4. Add 4: x² + 4x + 4 = 9 → (x + 2)² = 9.",
                "x + 2 = ±3 → x = -2 + 3 = 1, or x = -2 - 3 = -5.",
                "Check in original: 2(1)+8(1)-10=0; 2(25)+8(-5)-10=50-40-10=0."
            ],
            "x = 1 or x = -5.",
            problemLatex: @"2x^2+8x-10=0",
            solutionLatex: @"x=1,\;-5",
            stepLatex: [@"x^2+4x=5", @"(x+2)^2=9", @"x=-2\pm 3", @"x=1,\;-5"])
        .Mistake("Adding (b/2)² to only one side of the equation.")
        .Mistake("Using b² instead of (b/2)² as the completing term.")
        .Mistake("Dropping the ± after taking square roots.")
        .Mistake("Forgetting to divide by a when the leading coefficient is not 1.")
        .Mistake("When converting a function to vertex form, adding (b/2)² inside without balancing (subtracting the same amount or adjusting the constant).")
        .Numeric("To complete the square for x² + 8x, what number do you add?", "16",
            ["Half of 8 is 4; 4² = 16."],
            "Add 16: (x+4)².", explanationLatex: @"16")
        .Numeric("Half of the coefficient 10 (as in x²+10x) is?", "5",
            ["b/2 = 10/2 = 5."],
            "5.", explanationLatex: @"5")
        .Numeric("Solve (x-3)² = 16. What is the larger solution?", "7",
            ["x-3 = ±4 → x=7 or x=-1."],
            "Larger solution is 7.", explanationLatex: @"7")
        .Numeric("x² + 6x + 9 is (x+k)². What is k?", "3",
            ["(x+3)² = x²+6x+9."],
            "k = 3.", explanationLatex: @"3")
        .Mcq("Completing the square on x² + bx uses which added term?",
            ["b²", "(b/2)²", "2b", "b/2"], 1,
            ["Half the linear coefficient, then square."],
            "(b/2)².")
        .Mcq("Vertex form of a parabola is:",
            ["y = ax² + bx + c only", "y = a(x-h)² + k", "y = mx + b", "x = ay² + by + c only"], 1,
            ["Completing the square produces a(x-h)²+k."],
            "y = a(x-h)² + k.")
        .Numeric("For x² - 2x, what constant completes the square?", "1",
            ["Half of -2 is -1; (-1)² = 1."],
            "Add 1.", explanationLatex: @"1")
        .Numeric("After (x+1)² = 9, the solutions for x are -1±3. What is the smaller x?", "-4",
            ["-1-3=-4; -1+3=2."],
            "Smaller is -4.", explanationLatex: @"-4")
        .Mcq("Why complete the square when the quadratic formula exists?",
            ["It never helps", "It builds vertex form and explains the formula", "It avoids ± symbols", "It only works for b=0"], 1,
            ["Vertex form and derivation of the formula are major reasons."],
            "Vertex form and understanding the formula.")
        .Numeric("Vertex x-coordinate of y = x² - 6x + 2 is?", "3",
            ["h = -b/(2a) = 6/2 = 3, or complete the square."],
            "x = 3 at the vertex.", explanationLatex: @"3")
        .Build();
}
