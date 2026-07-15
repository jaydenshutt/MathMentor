using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class ReviewLessons
{
    public const string CategoryId = "reviews";

    public static Category Build()
    {
        var lessons = new[]
        {
            ArithmeticReview(),
            AlgebraReview(),
            GeometryReview(),
            PrecalcReview()
        };
        return new Category(CategoryId, "Cumulative Reviews",
            "Practice-focused cumulative reviews spanning arithmetic, algebra, geometry, and functions with trigonometry.",
            "\uE8EF", 18, lessons);
    }

    private static Lesson ArithmeticReview() => new LessonBuilder("rev-arithmetic", CategoryId, "Arithmetic Cumulative Review")
        .Subtitle("Operations, order of operations, fractions, decimals, and percent fluency")
        .Order(1).Minutes("28 min")
        .Section("What this review targets",
            "Arithmetic is the operating system for every later course. This lesson pulls together whole-number operations, order of operations, fraction and decimal arithmetic, and percent translations. Work slowly enough to show steps; speed without accuracy is not the goal.",
            simple: "Refresh the core skills you use constantly: compute carefully, simplify, and convert among fractions, decimals, and percents.",
            prior: "Lessons from Arithmetic Foundations and Fractions/Decimals/Percentages feed directly into these problems.")
        .Section("Order of operations",
            "Evaluate groupings first (parentheses), then exponents, then multiply/divide left to right, then add/subtract left to right. A common failure is doing all addition before multiplication, or reading left to right without priority rules.\n\nRewrite messy expressions with clear intermediate lines rather than doing everything in your head.",
            @"2+3\cdot 4=14\text{ (not }20\text{)}",
            simple: "Multiply and divide before add and subtract, unless parentheses say otherwise.")
        .Section("Fraction operations",
            "Add/subtract with a common denominator; multiply numerators and denominators; divide by multiplying by the reciprocal. Simplify at the end (or along the way) by canceling common factors.\n\nKeep improper fractions until the end if they make algebra cleaner, then convert to mixed numbers only if the context wants them.",
            @"\frac{a}{b}\div\frac{c}{d}=\frac{a}{b}\cdot\frac{d}{c}",
            prior: "Equivalent fractions and least common multiples are the tools behind common denominators.")
        .Section("Decimals and percents",
            "Percent means per hundred: p% = p/100. Convert percent → decimal by dividing by 100; decimal → percent by multiplying by 100. Part = percent × whole is the skeleton of most percent problems (discounts, tax, tips, increases).",
            @"p\%=\frac{p}{100}",
            simple: "Move the decimal two places for percent ↔ decimal when the numbers are base ten friendly.")
        .Section("Integer signs and absolute value",
            "Same-sign products/quotients are positive; different signs are negative. Absolute value is distance from zero. Subtraction means add the opposite. Sign slips create most “I know the steps but missed the answer” moments.",
            prior: "Number Foundations: integers and absolute value.")
        .Formula("Order reminder", @"a+b\cdot c=a+(b\cdot c)", "Multiplication before addition.")
        .Formula("Percent to decimal", @"p\%=\frac{p}{100}", "Divide by 100.")
        .Formula("Part-whole percent", @"\text{part}=\frac{p}{100}\cdot\text{whole}", "Core percent equation.")
        .Example("Order of operations",
            "Evaluate 8 + 12 ÷ 4 · 2 − 1.",
            [
                "Division and multiplication left to right: 12 ÷ 4 = 3, then 3 · 2 = 6.",
                "Expression becomes 8 + 6 − 1.",
                "Add/subtract left to right: 14 − 1 = 13.",
                "Wrong path: 12÷4·2 treated as 12÷8."
            ],
            "13.",
            solutionLatex: @"13")
        .Example("Fraction divide",
            "Compute (3/4) ÷ (9/8).",
            [
                "Multiply by reciprocal: (3/4)·(8/9).",
                "Cancel: 3 cancels with 9 → 1/3; 4 cancels with 8 → 2/1.",
                "(1/1)·(2/3) = 2/3.",
                "Check: (3/4) = 0.75, (9/8)=1.125, 0.75/1.125 = 0.666... = 2/3."
            ],
            "2/3.",
            problemLatex: @"\frac{3}{4}\div\frac{9}{8}",
            solutionLatex: @"\frac{2}{3}")
        .Example("Percent of a number",
            "What is 15% of 80?",
            [
                "15% = 0.15.",
                "0.15 · 80 = 12.",
                "Or (15/100)·80 = 1200/100 = 12.",
                "Sense: 10% of 80 is 8; 5% is 4; total 12."
            ],
            "12.",
            solutionLatex: @"12")
        .Example("Signed arithmetic",
            "Compute (−7) − (−3) + 2.",
            [
                "Subtracting −3 means adding 3: −7 + 3 + 2.",
                "−7 + 3 = −4.",
                "−4 + 2 = −2.",
                "Double-negative handling is the key step."
            ],
            "−2.",
            solutionLatex: @"-2")
        .Mistake("Doing addition before multiplication when no parentheses require it.")
        .Mistake("Forgetting to use a common denominator when adding fractions.")
        .Mistake("Treating 15% as 15 instead of 0.15 in multiplications.")
        .Mistake("Dropping a negative sign mid-problem.")
        .Numeric("Evaluate 5 + 2 · 3.", "11",
            ["2·3=6 first.", "5+6=11."],
            "11.")
        .Numeric("Compute 2/3 + 1/6. Enter as a decimal.", "0.833",
            ["Common denominator 6: 4/6 + 1/6 = 5/6.", "5/6 ≈ 0.833."],
            "5/6 ≈ 0.833.",
            tolerance: 0.01)
        .Numeric("What is 25% of 60?", "15",
            ["0.25·60."],
            "15.")
        .Numeric("Compute (−5)·(−4).", "20",
            ["Same signs → positive.", "20."],
            "20.")
        .Numeric("Compute 7 − 12.", "-5",
            ["7 + (−12)."],
            "−5.")
        .Mcq("Which equals 3/5?",
            ["0.3", "0.6", "1.5", "0.35"], 1,
            ["3÷5 = 0.6."],
            "3/5 = 0.6.")
        .Numeric("Simplify 18/24 to a decimal.", "0.75",
            ["Divide numerator and denominator by 6: 3/4.", "0.75."],
            "0.75.",
            tolerance: 0.001)
        .Numeric("10% of 45?", "4.5",
            ["0.10·45 = 4.5."],
            "4.5.",
            tolerance: 0.01)
        .Build();

    private static Lesson AlgebraReview() => new LessonBuilder("rev-algebra", CategoryId, "Algebra I Cumulative Review")
        .Subtitle("Equations, inequalities, linear graphs, systems, and factoring checkpoints")
        .Order(2).Minutes("30 min")
        .Section("Review map",
            "Algebra I turns arithmetic into general rules with variables. This cumulative set revisits solving linear equations and inequalities, slope-intercept thinking, systems, and basic factoring/polynomial structure. Show inverse operations clearly; that is the skill colleges and later courses assume.",
            simple: "Undo operations to solve; use slope and intercepts to read lines; factor to rewrite products.",
            prior: "Pre-Algebra equations and Algebra I linear/systems lessons are the foundation.")
        .Section("Linear equations",
            "Simplify each side, then use inverse operations to isolate the variable. What you do to one side, do to the other. Check by substitution. Equations with variables on both sides need collection first; identities and contradictions are possible special cases.",
            @"ax+b=c\;\Rightarrow\;x=\frac{c-b}{a}\;(a\neq 0)",
            simple: "Mirror moves on both sides until x stands alone.")
        .Section("Inequalities",
            "Solve like equations, but reverse the inequality direction when multiplying or dividing by a negative number. Graph solutions on a number line with open/closed circles as needed.",
            prior: "The flip rule is the main difference from equations.")
        .Section("Slope and forms of lines",
            "Slope m = (y2 − y1)/(x2 − x1) measures rise over run. Slope-intercept form y = mx + b makes slope and y-intercept visible. Parallel lines share slope; perpendicular lines have negative reciprocal slopes (when defined).",
            @"m=\frac{y_2-y_1}{x_2-x_1}",
            simple: "Slope is steepness; b is where the line hits the y-axis in y = mx + b.")
        .Section("Systems and factoring snapshot",
            "A 2×2 linear system can be solved by substitution or elimination. Solutions are intersection points of lines (one, none, or infinitely many).\n\nFactoring undoes distribution: pull out a GCF first, then use patterns like difference of squares x² − a² = (x − a)(x + a) when they fit.",
            @"x^2-a^2=(x-a)(x+a)")
        .Formula("Slope", @"m=\frac{y_2-y_1}{x_2-x_1}", "Rise over run between two points.")
        .Formula("Slope-intercept", @"y=mx+b", "Slope m, y-intercept b.")
        .Formula("Difference of squares", @"x^2-a^2=(x-a)(x+a)", "Classic factoring pattern.")
        .Example("Solve two-step equation",
            "Solve 3x − 7 = 11.",
            [
                "Add 7 to both sides: 3x = 18.",
                "Divide by 3: x = 6.",
                "Check: 3·6 − 7 = 18 − 7 = 11.",
                "True, so x = 6."
            ],
            "x = 6.",
            problemLatex: @"3x-7=11",
            solutionLatex: @"x=6")
        .Example("Inequality flip",
            "Solve −2x > 8.",
            [
                "Divide by −2 and reverse the inequality: x < −4.",
                "Check with x = −5: −2(−5) = 10 > 8, true.",
                "Check boundary style: x = −4 gives equality, not >.",
                "Forgetting the flip would incorrectly give x > −4."
            ],
            "x < −4.",
            solutionLatex: @"x<-4")
        .Example("Slope between points",
            "Find the slope through (1, 2) and (3, 8).",
            [
                "m = (8 − 2)/(3 − 1) = 6/2 = 3.",
                "Rise 6, run 2.",
                "Line rises steeply to the right.",
                "Order consistency: subtract y's and x's in the same point order."
            ],
            "m = 3.",
            solutionLatex: @"m=3")
        .Example("Factor difference of squares",
            "Factor x² − 25.",
            [
                "Recognize a² = 25 so a = 5.",
                "x² − 25 = (x − 5)(x + 5).",
                "Check: (x − 5)(x + 5) = x² − 25.",
                "Not (x − 5)², which is x² − 10x + 25."
            ],
            "(x − 5)(x + 5).",
            problemLatex: @"x^2-25",
            solutionLatex: @"(x-5)(x+5)")
        .Mistake("Forgetting to reverse an inequality when multiplying/dividing by a negative.")
        .Mistake("Subtracting slope coordinates in inconsistent order.")
        .Mistake("Stopping after undoing only one side of a two-sided equation.")
        .Mistake("Factoring x² − 25 as (x − 5)².")
        .Numeric("Solve 2x + 5 = 17. Find x.", "6",
            ["2x = 12.", "x = 6."],
            "x = 6.",
            explanationLatex: @"x=6")
        .Numeric("Solve x/4 = 3. Find x.", "12",
            ["Multiply both sides by 4."],
            "x = 12.")
        .Numeric("Slope through (0, 1) and (2, 5)?", "2",
            ["(5−1)/(2−0) = 4/2 = 2."],
            "m = 2.")
        .Numeric("If y = −3x + 7, what is the y-intercept?", "7",
            ["In y = mx + b, b is the intercept."],
            "b = 7.")
        .Mcq("Solve −x ≥ 4. The solution is:",
            ["x ≥ −4", "x ≤ −4", "x ≥ 4", "x ≤ 4"], 1,
            ["Multiply by −1 and flip: x ≤ −4."],
            "x ≤ −4.")
        .Numeric("Expand (x+3)(x+1). Coefficient of x?", "4",
            ["x² + 4x + 3.", "Coefficient of x is 4."],
            "4.")
        .Numeric("Solve the system: x + y = 10 and x − y = 2. Find x.", "6",
            ["Add equations: 2x = 12.", "x = 6."],
            "x = 6.")
        .Numeric("Factor out GCF of 6x² + 9x. Coefficient in GCF (positive)?", "3",
            ["GCF is 3x.", "3 is the numeric part."],
            "3.")
        .Build();

    private static Lesson GeometryReview() => new LessonBuilder("rev-geometry", CategoryId, "Geometry Cumulative Review")
        .Subtitle("Angles, triangles, Pythagorean theorem, area, and circle essentials")
        .Order(3).Minutes("30 min")
        .Section("Why geometry review matters",
            "Geometry mixes visual reasoning with precise formulas. This set revisits angle relationships, triangle sum, right-triangle tools, and area/circumference. Sketch every problem; labels prevent most errors.",
            simple: "Draw it, mark known measures, then apply the matching relationship or formula.",
            prior: "Geometry category lessons on angles, triangles, and measurement.")
        .Section("Angles and lines",
            "Vertical angles are equal. Adjacent angles on a straight line sum to 180° (linear pair). When a transversal crosses parallel lines, corresponding and alternate interior angles are equal; consecutive interior angles sum to 180°.",
            @"\text{linear pair: }a+b=180^\circ",
            simple: "Straight line → 180°. Opposite (vertical) angles match.")
        .Section("Triangles",
            "Interior angles of a triangle sum to 180°. An isosceles triangle has two equal sides and base angles equal. Exterior angle equals the sum of the two remote interior angles.",
            @"\angle A+\angle B+\angle C=180^\circ",
            prior: "Angle sum is the gateway to solving for missing triangle angles.")
        .Section("Right triangles and Pythagoras",
            "In a right triangle with legs a, b and hypotenuse c, a² + b² = c². Only the side opposite the right angle is the hypotenuse. Pythagorean triples like 3-4-5 and 5-12-13 save time when they appear.",
            @"a^2+b^2=c^2",
            simple: "Legs square and add; square root for hypotenuse (when finding c).")
        .Section("Area and circles",
            "Rectangle area = length × width; triangle area = (1/2)bh; circle area = πr²; circumference = 2πr. Keep radius and diameter distinct: diameter = 2r. Units for area are squares; circumference is length.",
            @"A=\pi r^2,\quad C=2\pi r")
        .Formula("Triangle angle sum", @"A+B+C=180^\circ", "Interior angles of any triangle.")
        .Formula("Pythagorean theorem", @"a^2+b^2=c^2", "Right triangle with hypotenuse c.")
        .Formula("Circle area", @"A=\pi r^2", "Disk area from radius.")
        .Example("Linear pair",
            "Two adjacent angles on a straight line measure (3x)° and (2x + 20)°. Find x.",
            [
                "Linear pair: 3x + (2x + 20) = 180.",
                "5x + 20 = 180.",
                "5x = 160, x = 32.",
                "Angles: 96° and 84°, sum 180°."
            ],
            "x = 32.",
            solutionLatex: @"x=32")
        .Example("Triangle missing angle",
            "A triangle has angles 50° and 60°. Find the third angle.",
            [
                "Sum is 180°.",
                "Third = 180 − 50 − 60 = 70.",
                "So the third angle is 70°.",
                "Check: 50+60+70 = 180."
            ],
            "70°.",
            solutionLatex: @"70^\circ")
        .Example("Pythagorean theorem",
            "Legs 6 and 8. Find the hypotenuse.",
            [
                "c² = 6² + 8² = 36 + 64 = 100.",
                "c = √100 = 10 (length positive).",
                "Recognizable 6-8-10 is a scaled 3-4-5 triple.",
                "Do not stop at c² = 100 without taking the root if length is asked."
            ],
            "10.",
            problemLatex: @"c^2=6^2+8^2",
            solutionLatex: @"c=10")
        .Example("Circle area",
            "Radius 5. Find the area in terms of π.",
            [
                "A = πr² = π·25 = 25π.",
                "If a decimal is required, use π ≈ 3.14 → about 78.5.",
                "Diameter would be 10; using 10 as radius is a common slip.",
                "Area units would be square units."
            ],
            "25π.",
            solutionLatex: @"25\pi")
        .Mistake("Using a leg as the hypotenuse in Pythagoras.")
        .Mistake("Confusing radius with diameter in circle formulas.")
        .Mistake("Assuming every triangle with a 90° mention is isosceles without evidence.")
        .Mistake("Adding angles of a triangle to 360° instead of 180°.")
        .Numeric("Angles 40° and 70° in a triangle. Third angle?", "70",
            ["180 − 40 − 70 = 70."],
            "70°.")
        .Numeric("Right triangle legs 5 and 12. Hypotenuse?", "13",
            ["25+144=169.", "√169=13."],
            "13.")
        .Numeric("Rectangle 9 by 4. Area?", "36",
            ["9·4."],
            "36.")
        .Numeric("Triangle base 10, height 6. Area?", "30",
            ["(1/2)·10·6 = 30."],
            "30.")
        .Numeric("Circumference of circle radius 3, in terms of π: coefficient of π?", "6",
            ["C = 2πr = 6π.", "Coefficient 6."],
            "6.")
        .Mcq("Vertical angles are:",
            ["Always complementary", "Always equal", "Always 180°", "Always 90°"], 1,
            ["Opposite equal angles formed by intersecting lines."],
            "Vertical angles are congruent (equal measure).")
        .Numeric("If one linear-pair angle is 110°, the other is?", "70",
            ["180 − 110."],
            "70°.")
        .Numeric("Area of circle radius 2 as multiple of π (the coefficient)?", "4",
            ["A = π·4 = 4π."],
            "4.")
        .Build();

    private static Lesson PrecalcReview() => new LessonBuilder("rev-precalc", CategoryId, "Functions & Trig Cumulative Review")
        .Subtitle("Function basics, key graphs, exponential ideas, and core trig values")
        .Order(4).Minutes("32 min")
        .Section("Scope of this review",
            "Functions and trigonometry power precalculus and calculus readiness. This cumulative practice hits function notation, domain thinking, linear/quadratic/exponential patterns, and unit-circle values for sine and cosine. Keep definitions and graphs connected: every formula should mean something on a picture.",
            simple: "f(x) is an output machine; trig values are coordinates on the unit circle for special angles.",
            prior: "Functions & Advanced Algebra and Trigonometry lessons.")
        .Section("Function notation and evaluation",
            "f(x) is the output when the input is x. Evaluating f(3) means substitute 3 for x. Domain is the set of allowed inputs (watch denominators and even roots). Range is the set of outputs that actually occur.",
            @"f(a)=\text{output at input }a",
            simple: "Replace x with the given number and simplify carefully.")
        .Section("Linear, quadratic, exponential snapshots",
            "Linear: constant rate of change, graph a line. Quadratic: y = ax² + bx + c, parabola, vertex and roots matter. Exponential: y = ab^x (b > 0, b ≠ 1) multiplies by a constant factor over equal x-steps; growth if b > 1, decay if 0 < b < 1.",
            @"y=ab^x",
            prior: "Slope for linear; vertex/factoring for quadratic; percent growth links to exponential bases.")
        .Section("Transformations",
            "Compared with a parent function y = f(x): y = f(x − h) + k shifts right h and up k; y = −f(x) reflects over the x-axis; y = af(x) stretches vertically by |a|. Knowing parent shapes (line, parabola, absolute value, sine wave) makes transformed sketches fast.",
            simple: "Inside changes affect x (horizontal); outside changes affect y (vertical).")
        .Section("Trig essentials",
            "On the unit circle, cos θ is x and sin θ is y. Memorize QI specials: 0°, 30°, 45°, 60°, 90° and use ASTC signs in other quadrants. Identity: sin²θ + cos²θ = 1. Tangent is sin/cos when defined.",
            @"\sin^2\theta+\cos^2\theta=1",
            prior: "Unit circle lesson: coordinates and reference angles.")
        .Formula("Pythagorean identity", @"\sin^2\theta+\cos^2\theta=1", "Unit circle equation in trig form.")
        .Formula("Exponential model", @"y=ab^x", "Multiplicative change across equal steps.")
        .Formula("Sine and cosine on unit circle", @"(\cos\theta,\sin\theta)", "Terminal point on x² + y² = 1.")
        .Example("Evaluate a function",
            "If f(x) = 2x² − 3, find f(4).",
            [
                "Substitute: 2(4)² − 3.",
                "16 · 2 = 32, then 32 − 3 = 29.",
                "f(4) = 29.",
                "Do not compute 2x first then square incorrectly as (2·4)²."
            ],
            "29.",
            problemLatex: @"f(x)=2x^2-3",
            solutionLatex: @"f(4)=29")
        .Example("Exponential growth step",
            "A value starts at 50 and multiplies by 1.1 each year. Find the value after 2 years.",
            [
                "Model: y = 50(1.1)^t.",
                "After 2 years: 50(1.1)^2 = 50·1.21 = 60.5.",
                "Year-by-year: 50 → 55 → 60.5.",
                "Adding 10% of the original twice (50+5+5) wrongly ignores compounding on the new amount."
            ],
            "60.5.",
            solutionLatex: @"60.5")
        .Example("Special trig value",
            "Find sin 30° and cos 30°.",
            [
                "30° is a QI special angle.",
                "sin 30° = 1/2, cos 30° = √3/2.",
                "Check: (1/2)² + (√3/2)² = 1/4 + 3/4 = 1.",
                "Swapping sin and cos with 60° is a common mix-up."
            ],
            "sin = 1/2, cos = √3/2.",
            solutionLatex: @"\sin 30^\circ=\frac{1}{2},\;\cos 30^\circ=\frac{\sqrt{3}}{2}")
        .Example("Quadrant sign",
            "What is cos 180°?",
            [
                "180° points to (−1, 0) on the unit circle.",
                "Cosine is the x-coordinate: −1.",
                "Sine is 0 at 180°.",
                "Reference angle 0° with QII/negative x-axis thinking yields the same."
            ],
            "−1.",
            solutionLatex: @"\cos 180^\circ=-1")
        .Mistake("Evaluating 2x² as (2x)² without parentheses justifying it.")
        .Mistake("Treating exponential growth like repeated addition of the original percent only.")
        .Mistake("Mixing up sin and cos of 30° and 60°.")
        .Mistake("Ignoring quadrant signs for cosine/sine outside QI.")
        .Numeric("If f(x)=3x+1, what is f(5)?", "16",
            ["3·5+1=16."],
            "16.")
        .Numeric("If g(x)=x², what is g(−3)?", "9",
            ["(−3)² = 9."],
            "9.")
        .Numeric("sin 90°?", "1",
            ["Unit circle point (0,1).", "y-coordinate 1."],
            "1.")
        .Numeric("cos 0°?", "1",
            ["Point (1,0)."],
            "1.")
        .Numeric("sin 30° as a decimal?", "0.5",
            ["1/2 = 0.5."],
            "0.5.",
            tolerance: 0.001)
        .Mcq("For y = 2^x, when x increases by 1, y is:",
            ["Increased by 2", "Multiplied by 2", "Squared", "Divided by 2"], 1,
            ["Exponential base 2 multiplies outputs by 2 each integer step."],
            "Multiplied by 2.")
        .Numeric("cos 60° as a decimal?", "0.5",
            ["cos 60° = 1/2."],
            "0.5.",
            tolerance: 0.001)
        .Numeric("If f(x)=10−x, f(2)=?", "8",
            ["10−2=8."],
            "8.")
        .Build();
}
