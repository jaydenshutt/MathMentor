using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class AlgebraLessons
{
    public const string CategoryId = "algebra1";

    public static Category Build()
    {
        var lessons = new[]
        {
            LinearEquations(),
            SlopeGraphing(),
            Systems(),
            SystemsApps(),
            Polynomials(),
            PolyDivision(),
            Factoring(),
            RationalExpressions()
        };
        return new Category(CategoryId, "Algebra I",
            "Linear equations, graphing, systems, polynomials, factoring, and rational expressions.",
            "\uE8A5", 5, lessons);
    }

    private static Lesson LinearEquations() => new LessonBuilder("alg-linear", CategoryId, "Linear Equations in One Variable")
        .Subtitle("Isolate the unknown, and understand why each move is fair")
        .Order(1).Minutes("28 min")
        .Section("What an equation really says",
            "An equation is a balance scale. The left side and the right side claim to be equal. Solving means finding every value of the variable that makes that claim true.\n\nA linear equation in one variable can be rearranged into the form ax + b = 0 (or ax + b = cx + d before simplifying) with a != 0 after combining like terms. The graph of y = ax + b is a straight line, which is why these are called linear, but in this lesson we focus on solving for x, not graphing yet.")
        .Section("Why inverse operations work",
            "Whatever you do to one side, you must do to the other so the two sides stay equal. Addition undoes subtraction; multiplication undoes division; distributing undoes factoring out a common factor in reverse.\n\nThink of a locked box: if someone added 5, you subtract 5. If they multiplied by 3, you divide by 3. The order of undoing usually goes outward-in: undo addition/subtraction first, then multiplication/division, unless grouping symbols force you to distribute first.",
            simple: "Keep both sides balanced. Undo the last thing that happened to the variable, one careful step at a time.",
            prior: "You should already be comfortable with one- and two-step equations (x + 3 = 7, 2x = 10). Multi-step work is the same idea with more layers.")
        .Section("A reliable multi-step process",
            "1) Simplify each side separately: distribute parentheses, combine like terms.\n2) Collect variable terms on one side (add/subtract to move them).\n3) Collect constant terms on the other side.\n4) Divide (or multiply) to isolate the variable.\n5) Check by substituting back into the original equation.\n\nChecking is not optional busywork; it catches sign errors and distribution mistakes before they become habits.")
        .Section("Variables on both sides",
            "When x appears on both sides, subtract one of the x-terms from both sides so only one side still has x. Example sketch: 5x - 3 = 2x + 9, subtract 2x, get 3x - 3 = 9, add 3, get 3x = 12, so x = 4.\n\nWhy not just \"move\" terms casually? Because \"move\" is slang for \"add the opposite to both sides.\" Writing the balanced step keeps signs honest.")
        .Section("Special cases: identity and contradiction",
            "Sometimes the variable cancels completely.\n• If you get a true statement with no variable left (like 3 = 3), every real number works, an identity. The original equation was always true.\n• If you get a false statement (like 0 = 5), no real number works, a contradiction. The empty set is the solution.\n\nThese are not failures of algebra; they are honest answers about when the balance can never tip or always balances.")
        .Formula("Balance principle", @"A=B\Rightarrow A+c=B+c", "Adding the same quantity to both sides preserves equality.")
        .Formula("Collecting variables", @"ax+b=cx+d\Rightarrow (a-c)x=d-b", "Subtract cx and b from both sides (in some order).")
        .Formula("Clearing fractions", @"\frac{x}{2}+3=\frac{x}{4}+5", "Multiply every term by a common multiple of the denominators.")
        .Example("Distribute, then isolate",
            "Solve 3(x - 2) = 15.",
            [
                "Distribute the 3 to every term inside: 3x - 6 = 15. Forgetting the -6 is the classic error.",
                "Add 6 to both sides to undo the -6: 3x = 21.",
                "Divide both sides by 3: x = 7.",
                "Check: 3(7 - 2) = 3(5) = 15. Matches the right side, done."
            ],
            "x = 7 is the unique solution.",
            problemLatex: @"3(x-2)=15",
            solutionLatex: @"x=7",
            stepLatex: [@"3x-6=15", @"3x=21", @"x=7", @"3(7-2)=15"])
        .Example("Variables on both sides",
            "Solve 4x + 5 = 2x + 17.",
            [
                "Subtract 2x from both sides so x lives only on the left: 2x + 5 = 17.",
                "Subtract 5 from both sides: 2x = 12.",
                "Divide by 2: x = 6.",
                "Check: left 4(6)+5=29; right 2(6)+17=29. Equal, so x = 6 is correct."
            ],
            "Collect like terms carefully; then isolate.",
            problemLatex: @"4x+5=2x+17",
            solutionLatex: @"x=6",
            stepLatex: [@"2x+5=17", @"2x=12", @"x=6", null])
        .Example("Clear fractions first",
            "Solve (x/2) + 3 = (x/4) + 5.",
            [
                "Denominators are 2 and 4. Multiply every term by 4 (the LCD) to eliminate fractions.",
                "4·(x/2) + 4·3 = 4·(x/4) + 4·5 gives 2x + 12 = x + 20.",
                "Subtract x: x + 12 = 20. Subtract 12: x = 8.",
                "Check: 8/2 + 3 = 7; 8/4 + 5 = 7. Both sides match."
            ],
            "Clearing denominators early reduces messy fraction arithmetic.",
            problemLatex: @"\frac{x}{2}+3=\frac{x}{4}+5",
            solutionLatex: @"x=8",
            stepLatex: [@"\times 4", @"2x+12=x+20", @"x=8", null])
        .Example("No solution (contradiction)",
            "Solve 2x + 1 = 2x + 5.",
            [
                "Subtract 2x from both sides: 1 = 5.",
                "1 = 5 is never true, no matter what x is.",
                "Conclusion: the equation has no solution (empty set).",
                "Graphically, y = 2x + 1 and y = 2x + 5 are parallel lines that never meet if you thought of both sides as lines; here the contradiction shows the claimed equality never holds."
            ],
            "A false numerical statement after simplifying means no solution.",
            problemLatex: @"2x+1=2x+5",
            solutionLatex: @"\emptyset",
            stepLatex: [@"1=5", null, null, null])
        .Mistake("Forgetting to distribute to every term inside parentheses.")
        .Mistake("Adding or subtracting a term on only one side of the equation.")
        .Mistake("Dividing only one term when clearing a coefficient (e.g. turning 3x + 6 = 15 into x + 6 = 5).")
        .Mistake("Treating an identity (all reals) as \"no solution\" or vice versa.")
        .Numeric("Solve 2(x+3)=14. What is x?", "4",
            ["Distribute or divide both sides by 2 first.", "x+3=7, so x=4."],
            "2(x+3)=14 leads to x+3=7, so x=4.", explanationLatex: @"x=4")
        .Numeric("Solve 5x-2=3x+10. What is x?", "6",
            ["Subtract 3x: 2x-2=10.", "Add 2: 2x=12, so x=6."],
            "Collect terms: 2x=12, so x=6.", explanationLatex: @"x=6")
        .Numeric("Solve 7x+3=3x+19. What is x?", "4",
            ["Subtract 3x: 4x+3=19.", "Subtract 3: 4x=16, so x=4."],
            "4x=16, so x=4.", explanationLatex: @"x=4")
        .Mcq("After simplifying, 3x+4=3x+4 becomes a true statement with no x left. The equation has:",
            ["No solution", "One solution", "All real numbers", "Two solutions"], 2,
            ["Variables canceled and the remaining statement is true.", "That is an identity."],
            "It is true for every real x, all real numbers.")
        .Numeric("Solve 6-2x=10. What is x?", "-2",
            ["Subtract 6: -2x=4.", "Divide by -2: x=-2."],
            "-2x=4, so x=-2.", explanationLatex: @"x=-2")
        .Numeric("Solve 0.5x+1=4. What is x?", "6",
            ["Subtract 1: 0.5x=3.", "Divide by 0.5 (or multiply by 2): x=6."],
            "0.5x=3, so x=6.", explanationLatex: @"x=6")
        .Numeric("Solve 4(x-1)=2(x+5). What is x?", "7",
            ["4x-4=2x+10.", "2x=14, so x=7."],
            "After distributing and collecting: x=7.", explanationLatex: @"x=7")
        .Mcq("Which equation has no solution?",
            ["2x+1=5", "x+3=x+3", "x+1=x+4", "3x=0"], 2,
            ["Subtract x: left with 1=4.", "A contradiction means empty set."],
            "x+1=x+4 simplifies to 1=4, impossible.")
        .Takeaways(
            "Keep both sides balanced: every operation must hit both sides.",
            "Simplify, collect variables, collect constants, then divide to isolate x.",
            "Always check by substituting back into the original equation.",
            "True statement with no x means all reals; false statement means no solution.",
            "Distribute to every term and clear fractions with the LCD when helpful.")
        .Build();

    private static Lesson SlopeGraphing() => new LessonBuilder("alg-slope", CategoryId, "Slope, Graphing Lines & Writing Equations")
        .Subtitle("Rate of change, intercepts, and the language of straight lines")
        .Order(2).Minutes("30 min")
        .Visual(VisualKind.LineGraph, "Linear functions appear as straight lines; slope is steepness and direction.")
        .Section("Why slope matters",
            "Slope measures how fast y changes as x changes, the rate of change. In a wage problem, slope can be dollars per hour. On a graph, it is steepness. In science, it is often a constant speed or growth rate.\n\nIf a line rises 3 units for every 1 unit of run, the slope is 3. That single number captures the entire tilt of a nonvertical line.")
        .Section("Slope formula: rise over run",
            "Given two distinct points (x1, y1) and (x2, y2) on a nonvertical line,\n\nm = (y2 - y1)/(x2 - x1).\n\nThe numerator is the change in y (rise); the denominator is the change in x (run). Order must be consistent: if you start with y2 - y1 on top, use x2 - x1 on the bottom, not a mix.\n\nSigns: positive slope goes uphill left to right; negative goes downhill; zero is horizontal; undefined means vertical (run = 0, division by zero).",
            @"m=\frac{y_2-y_1}{x_2-x_1}",
            simple: "Pick two points. Subtract the y's. Subtract the x's in the same order. Divide. That quotient is the slope.",
            prior: "You need ordered pairs and the idea that a graph is a set of (x, y) points. Fraction arithmetic helps when rise and run are not integers.")
        .Section("Forms of a line equation",
            "• Slope-intercept: y = mx + b. Here m is slope and b is the y-intercept (where the line hits the y-axis, at (0, b)). This form is perfect for graphing from a starting height and a tilt.\n• Point-slope: y - y1 = m(x - x1). Use when you know one point and the slope; write the equation immediately, then expand if you need slope-intercept.\n• Standard form: Ax + By = C (often A, B, C integers). Useful for some systems and intercept reading (set x=0 or y=0).")
        .Section("Graphing from y = mx + b",
            "Plot the y-intercept (0, b). From there, use slope as rise/run: for m = 2/3, go up 2 and right 3 (or down 2 and left 3). Draw the line through the points. For integer m, think of m as m/1.")
        .Section("Parallel and perpendicular lines",
            "Parallel nonvertical lines never meet and share the same slope. Perpendicular lines meet at right angles; for nonvertical lines their slopes are negative reciprocals: if one slope is m, the other is -1/m (when m != 0). Check: m · (-1/m) = -1.\n\nVertical and horizontal lines are perpendicular (undefined slope meets slope 0). Two vertical lines are parallel to each other.")
        .Formula("Slope", @"m=\frac{y_2-y_1}{x_2-x_1}", "Average rate of change of y with respect to x along the line.")
        .Formula("Slope-intercept form", @"y=mx+b", "m = slope, b = y-intercept.")
        .Formula("Point-slope form", @"y-y_1=m(x-x_1)", "Uses any known point on the line.")
        .Formula("Perpendicular slopes", @"m_{\perp}=-\frac{1}{m}\;(m\neq 0)", "Product of slopes is -1 for nonvertical perpendicular lines.")
        .Example("Slope from two points",
            "Find the slope of the line through (1, 2) and (3, 8).",
            [
                "Use m = (y2 - y1)/(x2 - x1). Take (x1,y1)=(1,2) and (x2,y2)=(3,8).",
                "Rise: 8 - 2 = 6. Run: 3 - 1 = 2.",
                "m = 6/2 = 3.",
                "Interpretation: for each 1 unit right, y increases by 3. Check with swapped order: (2-8)/(1-3)= (-6)/(-2)=3, same slope."
            ],
            "The slope is 3.",
            problemLatex: @"(1,2),\;(3,8)",
            solutionLatex: @"m=3",
            stepLatex: [null, @"8-2=6,\;3-1=2", @"m=\frac{6}{2}=3", null])
        .Example("Equation from slope and y-intercept",
            "Write the equation of the line with slope 2 through (0, -1).",
            [
                "Point (0, -1) is the y-intercept, so b = -1.",
                "Slope-intercept form needs m and b: y = 2x + (-1).",
                "Write y = 2x - 1.",
                "Check: when x=0, y=-1. Slope of 2 means another point is (1, 1)."
            ],
            "y = 2x - 1.",
            problemLatex: @"m=2,\;(0,-1)",
            solutionLatex: @"y=2x-1")
        .Example("Equation from two points",
            "Find the equation of the line through (2, 3) and (4, 7).",
            [
                "First find slope: m = (7 - 3)/(4 - 2) = 4/2 = 2.",
                "Use point-slope with (2, 3): y - 3 = 2(x - 2).",
                "Expand: y - 3 = 2x - 4, so y = 2x - 1.",
                "Verify the other point: at x=4, y=8-1=7. Both points lie on y=2x-1."
            ],
            "y = 2x - 1.",
            problemLatex: @"(2,3),\;(4,7)",
            solutionLatex: @"y=2x-1",
            stepLatex: [@"m=2", @"y-3=2(x-2)", @"y=2x-1", null])
        .Example("Perpendicular line through a point",
            "Find the line perpendicular to y = 3x + 1 that passes through the origin (0, 0).",
            [
                "The given line has slope 3. Perpendicular slope is the negative reciprocal: -1/3.",
                "Through (0, 0) with slope -1/3: y - 0 = (-1/3)(x - 0).",
                "So y = (-1/3)x.",
                "Check: 3 · (-1/3) = -1, so the slopes are perpendicular. Both pass rules for nonvertical lines."
            ],
            "y = -x/3.",
            problemLatex: @"y=3x+1,\;(0,0)",
            solutionLatex: @"y=-\frac{1}{3}x",
            stepLatex: [@"m_{\perp}=-\frac{1}{3}", @"y=-\frac{1}{3}x", null, null])
        .Mistake("Subtracting coordinates inconsistently (mixing the order of points between numerator and denominator).")
        .Mistake("Confusing b (y-intercept) with the x-intercept.")
        .Mistake("Saying perpendicular slopes are reciprocals without the negative (for nonvertical lines).")
        .Mistake("Calling a vertical line's slope 0 instead of undefined.")
        .Numeric("Slope through (0,0) and (4,8)?", "2",
            ["m = (8-0)/(4-0) = 8/4."],
            "m = 2.", explanationLatex: @"m=2")
        .Numeric("In y=-3x+5, what is the slope?", "-3",
            ["In y=mx+b, m is the coefficient of x."],
            "m = -3.", explanationLatex: @"m=-3")
        .Numeric("In y=2x+7, what is the y-intercept b?", "7",
            ["b is the constant term when the equation is y=mx+b."],
            "b = 7; the line crosses the y-axis at (0, 7).", explanationLatex: @"b=7")
        .Numeric("Slope through (1,5) and (1,9)? Enter 999 if undefined.", "999",
            ["x-coordinates are equal, so run = 0.", "Vertical line means undefined slope."],
            "Undefined (vertical). Use 999 as the sentinel value.", explanationLatex: @"m\;\mathrm{undefined}")
        .Mcq("Which line is parallel to y=4x-1?",
            ["y=-4x", "y=4x+9", "y=(1/4)x", "x=4"], 1,
            ["Parallel nonvertical lines share the same slope.", "Only y=4x+9 has slope 4."],
            "y=4x+9 has m=4, same as y=4x-1.")
        .Numeric("A line has slope 2. What is the slope of a perpendicular line?", "-0.5",
            ["Negative reciprocal of 2 is -1/2."],
            "Perpendicular slope is -1/2 = -0.5.", explanationLatex: @"m=-\frac{1}{2}", tolerance: 0.001)
        .Numeric("Line with m=1 through (2,5): write y=x+b. What is b?", "3",
            ["Plug in: 5 = 1·2 + b, so b = 3."],
            "y = x + 3.", explanationLatex: @"b=3")
        .Mcq("A horizontal line has slope:",
            ["Undefined", "1", "0", "-1"], 2,
            ["No rise as x changes.", "Rise = 0 means m = 0."],
            "Horizontal lines have slope 0.")
        .Takeaways(
            "Slope m = rise/run = (y2 - y1)/(x2 - x1) with consistent order.",
            "y = mx + b packages slope and y-intercept for quick graphing.",
            "Point-slope form is ideal when you know one point and m.",
            "Parallel lines share slope; perpendicular nonvertical slopes are negative reciprocals.",
            "Vertical lines have undefined slope; horizontal lines have slope 0.")
        .Build();

    private static Lesson Systems() => new LessonBuilder("alg-systems", CategoryId, "Systems of Linear Equations")
        .Subtitle("Find the pair (x, y) that satisfies every equation at once")
        .Order(3).Minutes("30 min")
        .Section("What a system is asking",
            "A system of linear equations is two (or more) linear equations that share the same variables. A solution is an ordered pair (x, y) that makes every equation true at the same time, not just one of them.\n\nGraphically, each equation is a line. The solution is the intersection point(s). That picture explains the three possible outcomes before you compute.")
        .Section("Three outcomes (and why they happen)",
            "• One solution: lines intersect at exactly one point (different slopes).\n• No solution: lines are parallel and distinct (same slope, different intercepts); they never meet.\n• Infinitely many solutions: the equations describe the same line (multiples of each other); every point on the line works.\n\nAlgebra must match geometry: if you get a contradiction like 0 = 1, the lines never meet; if you get 0 = 0, the equations are dependent.")
        .Section("Substitution",
            "Solve one equation for one variable, then replace that variable in the other equation. You reduce the system to a single equation in one unknown.\n\nBest when a variable already has coefficient 1 or -1 (easy to isolate). After finding one value, substitute back to find the other; never stop halfway.",
            simple: "Solve for the easy variable. Plug that expression into the other equation. Solve, then go back for the partner variable.",
            prior: "You need solid one-variable equation solving, including distributing and combining like terms.")
        .Section("Elimination (addition method)",
            "Line up like terms and add (or subtract) the equations so one variable cancels. Often you multiply one or both equations first so coefficients of x (or y) become opposites.\n\nExample idea: if you have 2x + y = 10 and x - y = 2, adding cancels y immediately. If coefficients do not match, scale: multiply the second by 2 before adding.")
        .Section("Graphing as a check",
            "Sketching both lines (or graphing on a tool) estimates the intersection. Exact fractional answers are safer with substitution/elimination, but a graph catches wild algebra errors.")
        .Formula("Substitution pattern", @"y=mx+b\;\rightarrow\;\text{replace }y\text{ in the other equation}", "Reduce to one variable.")
        .Formula("Elimination idea", @"E_1+E_2\text{ when coefficients of one variable are opposites}", "Scale equations first when needed.")
        .Example("Substitution",
            "Solve the system: y = 2x + 1 and x + y = 7.",
            [
                "The first equation already solves for y. Substitute into the second: x + (2x + 1) = 7.",
                "Combine: 3x + 1 = 7, so 3x = 6, so x = 2.",
                "Back-substitute: y = 2(2) + 1 = 5.",
                "Check in both: y=2x+1 gives 5=4+1; x+y=2+5=7. Solution (2, 5)."
            ],
            "The unique solution is (2, 5).",
            problemLatex: @"y=2x+1,\;x+y=7",
            solutionLatex: @"(2,5)",
            stepLatex: [@"x+(2x+1)=7", @"3x=6,\;x=2", @"y=5", null])
        .Example("Elimination",
            "Solve: 2x + y = 10 and x - y = 2.",
            [
                "Notice +y and -y. Add the equations: (2x + y) + (x - y) = 10 + 2 gives 3x = 12, so x = 4.",
                "Substitute into x - y = 2: 4 - y = 2, so -y = -2, so y = 2.",
                "Check in 2x + y: 8 + 2 = 10.",
                "Solution (4, 2)."
            ],
            "Adding canceled y; then back-solve for y.",
            problemLatex: @"2x+y=10,\;x-y=2",
            solutionLatex: @"(4,2)",
            stepLatex: [@"3x=12,\;x=4", @"y=2", null, null])
        .Example("No solution (parallel lines)",
            "Solve: y = 3x and y = 3x + 1.",
            [
                "Substitute: 3x = 3x + 1.",
                "Subtract 3x: 0 = 1, a contradiction.",
                "No ordered pair can satisfy both; the lines are parallel (same slope 3, different intercepts 0 and 1).",
                "Solution set is empty."
            ],
            "Empty set, no solution.",
            problemLatex: @"y=3x,\;y=3x+1",
            solutionLatex: @"\emptyset")
        .Example("Word problem to system",
            "Two apples and one banana cost $5. One apple and one banana cost $3. Find each price.",
            [
                "Let a = apple price, b = banana price. Equations: 2a + b = 5 and a + b = 3.",
                "Subtract the second from the first: (2a + b) - (a + b) = 5 - 3, so a = 2.",
                "From a + b = 3: 2 + b = 3, so b = 1.",
                "Check: 2(2)+1=5; 2+1=3. Apple $2, banana $1."
            ],
            "Define variables clearly, write equations, then eliminate or substitute.",
            solutionLatex: @"a=2,\;b=1")
        .Mistake("Finding x and forgetting to substitute back for y (or vice versa).")
        .Mistake("Adding equations that do not cancel anything useful without scaling coefficients first.")
        .Mistake("Mixing up which equation you used after scaling (forgetting to multiply the constant side too).")
        .Mistake("Reporting \"no solution\" when you actually got 0 = 0 (infinitely many).")
        .Numeric("System: y=x+1 and x+y=5. Find x.", "2",
            ["x + (x+1) = 5 gives 2x+1=5, so 2x=4."],
            "x = 2 (then y = 3).", explanationLatex: @"x=2")
        .Numeric("Same system y=x+1, x+y=5. Find y.", "3",
            ["From x=2: y=2+1=3."],
            "y = 3.", explanationLatex: @"y=3")
        .Numeric("x+y=10 and x-y=2. Find x.", "6",
            ["Add the equations: 2x=12, so x=6."],
            "x = 6.", explanationLatex: @"x=6")
        .Numeric("x+y=10 and x-y=2. Find y.", "4",
            ["From x=6: 6+y=10, so y=4.", "Or subtract equations."],
            "y = 4.", explanationLatex: @"y=4")
        .Mcq("The system y=2x and y=2x+3 has:",
            ["One solution", "No solution", "Infinitely many solutions", "Two solutions"], 1,
            ["Same slope, different intercepts means parallel distinct lines."],
            "No solution.")
        .Numeric("2x+y=7 and x=2. Find y.", "3",
            ["Plug x=2: 4+y=7, so y=3."],
            "y = 3.", explanationLatex: @"y=3")
        .Numeric("3x+2y=12 and x=2. Find y.", "3",
            ["6+2y=12, so 2y=6, so y=3."],
            "y = 3.", explanationLatex: @"y=3")
        .Mcq("If solving a system leads to 0 = 0, the system has:",
            ["No solution", "Exactly one solution", "Infinitely many solutions", "Only x = 0"], 2,
            ["The equations are dependent (same line)."],
            "Infinitely many solutions.")
        .Takeaways(
            "A solution of a system makes every equation true at once (an intersection point).",
            "Three outcomes: one solution, none (parallel), or infinitely many (same line).",
            "Substitution: solve for one variable and plug into the other equation.",
            "Elimination: scale so coefficients cancel, then add or subtract.",
            "Always find both x and y, and check in the original equations.")
        .Build();

    private static Lesson SystemsApps() => new LessonBuilder("alg-systems-apps", CategoryId, "Systems Applications & Linear Inequalities")
        .Subtitle("Word problems, mixture models, and graphing solution regions for systems of inequalities")
        .Order(4).Minutes("34 min")
        .Visual(VisualKind.LineGraph, "Intersection points solve equation systems; shaded regions solve inequality systems.")
        .Section("Why applications need systems",
            "Many real situations have two unknown quantities linked by two independent facts: ticket prices and counts, mixture concentrations, boat speed and current, or break-even between cost and revenue. One equation is not enough; two independent linear relationships pin down a unique pair (when the model is consistent).\n\nThe skill is translation: define variables clearly, write equations that match the story units, solve with substitution or elimination, then interpret the answer in context (including units and whether the solution is realistic).",
            simple: "Two unknowns need two independent facts. Name the unknowns, write equations, solve, then explain the answer in words.",
            prior: "You should already solve systems by substitution and elimination (previous lesson).")
        .Section("A word-problem playbook",
            "1) Read once for the story, again for quantities.\n2) Define variables with units (let x = number of adult tickets, y = number of child tickets).\n3) Write one equation per independent fact (total tickets, total money, total mass, and so on).\n4) Solve algebraically.\n5) Check in the original story sentences, not only in the algebra.\n6) Reject nonsense answers if the model requires non-negative counts or similar constraints (or report them carefully if the question is pure math).\n\nCommon structures: sum and difference, total cost, mixture of two concentrations, distance = rate · time with two rates.",
            simple: "Variables first, equations second, solve third, check fourth. Never skip the story check.",
            prior: "Translating phrases like \"total is 40\" and \"costs $3 more\" into algebra.")
        .Section("Mixture and value problems",
            "Mixture problems combine two pure or two blended ingredients into a new blend. Typical form: amount of substance from part A plus amount from part B equals amount in the mix. If x liters of 10% solution and y liters of 30% solution make 20 liters of 18% solution, then x + y = 20 and 0.10x + 0.30y = 0.18·20.\n\nValue problems are similar with money: price · quantity for each type sums to total revenue. Keep decimals or clear them by multiplying through by 100 when percents appear.",
            simple: "Write a total-quantity equation and a \"stuff or money\" equation. Solve the system.",
            prior: "Percent as a decimal and distributing products like 0.10x.")
        .Section("Linear inequalities in two variables",
            "A linear inequality such as y < 2x + 1 or x + y >= 4 describes a half-plane, not just a line. Graph the boundary line (solid for <= or >=, dashed for < or >), then test a point (often (0,0) if it is not on the line) to decide which side to shade.\n\nEvery point in the shaded region is a solution. The boundary is included only for non-strict inequalities.",
            @"y<mx+b",
            simple: "Draw the line, solid or dashed. Pick a test point. Shade the side that makes the inequality true.",
            prior: "Graphing lines from slope-intercept or intercepts, and comparing numbers with <, >, <=, >=.")
        .Section("Systems of linear inequalities",
            "A system of inequalities asks for the overlap of several half-planes: the intersection of the shaded regions. That overlap can be a polygon (bounded feasible region), an unbounded region, or empty if the inequalities fight each other.\n\nIn context (often called linear programming later), corner points of a bounded region matter because max/min of linear goals often occur at corners. For Algebra I, focus on accurately graphing and describing the solution set.",
            simple: "Shade each inequality carefully; the answer is where all shadings overlap.",
            prior: "Systems of equations (boundaries may intersect) plus single-inequality shading.")
        .Section("Connecting equations and inequalities",
            "The solution of a system of equations is usually a point (or none, or a whole line). The solution of a system of inequalities is usually a region. If a story says \"at least 10\" or \"no more than 50,\" you need inequalities. If it says \"exactly 10,\" you need equations.\n\nYou can mix: equality constraints are lines; inequality constraints cut half-planes. Always re-read the problem language for exactly versus at least/at most.",
            simple: "Exactly means equation. At least / at most / no more than means inequality.",
            prior: "English-to-math for comparisons: at least 5 means x >= 5.")
        .Section("Checking and communicating answers",
            "For equation systems from words: state the ordered pair with labels (adults = 12, children = 8). For inequality systems: describe the region or list clear conditions. For multiple-choice shading questions, verify a test point from the claimed region in every inequality.\n\nUnits and realism matter: negative ticket sales usually mean a modeling or algebra error, not a deep mystery.")
        .Formula("Mixture skeleton", @"x+y=T,\;c_1 x+c_2 y=c_T T", "Totals of amount and of \"active ingredient\" or value.")
        .Formula("Half-plane idea", @"y>mx+b\ \text{shades one side of the line}", "Test a point to choose the side.")
        .Formula("Feasible region", @"\text{overlap of all half-planes}", "Solution set of a system of inequalities.")
        .Example("Ticket word problem",
            "Adult tickets cost $8 and child tickets cost $5. A group buys 12 tickets for $81. How many of each?",
            [
                "Let a = number of adult tickets, c = number of child tickets.",
                "Equations: a + c = 12 and 8a + 5c = 81.",
                "From the first, c = 12 - a. Substitute: 8a + 5(12 - a) = 81, so 8a + 60 - 5a = 81, so 3a = 21, so a = 7.",
                "Then c = 5. Check: 7+5=12; 8·7 + 5·5 = 56 + 25 = 81.",
                "Common mistake callout: writing 8a + 5a = 81 and forgetting the counts differ."
            ],
            "7 adult and 5 child tickets.",
            problemLatex: @"a+c=12,\;8a+5c=81",
            solutionLatex: @"a=7,\;c=5",
            stepLatex: [null, @"c=12-a", @"3a=21", @"a=7,\;c=5", null])
        .Example("Percent mixture",
            "How many liters of 10% acid and 30% acid should be mixed to make 20 liters of 18% acid?",
            [
                "Let x = liters of 10% solution, y = liters of 30% solution.",
                "x + y = 20 and 0.10x + 0.30y = 0.18·20 = 3.6.",
                "From x = 20 - y: 0.10(20 - y) + 0.30y = 3.6, so 2 - 0.10y + 0.30y = 3.6, so 0.20y = 1.6, so y = 8.",
                "Then x = 12. Check: 0.10·12 + 0.30·8 = 1.2 + 2.4 = 3.6.",
                "Common mistake callout: averaging 10% and 30% to get 20% and ignoring the target 18%, or forgetting the total is 20."
            ],
            "12 L of 10% and 8 L of 30%.",
            problemLatex: @"x+y=20,\;0.10x+0.30y=3.6",
            solutionLatex: @"x=12,\;y=8",
            stepLatex: [null, @"0.18\cdot 20=3.6", @"y=8", @"x=12", null])
        .Example("Graph one linear inequality",
            "Graph the solution of y <= -x + 2. Is (0, 0) a solution? Is (3, 0)?",
            [
                "Boundary: y = -x + 2, solid line because of <=.",
                "Test (0, 0): 0 <= -0 + 2 is true, so shade the side containing (0, 0).",
                "Test (3, 0): 0 <= -3 + 2 means 0 <= -1, false, so (3, 0) is not a solution.",
                "Every point on or below the line (in the shaded half-plane) works.",
                "Common mistake callout: using a dashed line for <=, or shading the wrong side without a test point."
            ],
            "(0, 0) yes; (3, 0) no. Shade the half-plane containing the origin.",
            problemLatex: @"y\leq -x+2",
            solutionLatex: @"(0,0)\text{ yes},\;(3,0)\text{ no}")
        .Example("System of inequalities (overlap)",
            "Describe the solution of: y >= 0, x >= 0, and x + y <= 4.",
            [
                "x >= 0 is the half-plane to the right of the y-axis (including the axis).",
                "y >= 0 is above the x-axis (including the axis).",
                "x + y <= 4 is on or below the line x + y = 4 (intercepts (4, 0) and (0, 4)).",
                "Overlap: the triangle with vertices (0,0), (4,0), and (0,4), including interior and boundaries.",
                "Common mistake callout: shading only the line x + y = 4, or excluding the axes when >= allows them."
            ],
            "First-quadrant triangle under x + y = 4, including boundaries.",
            problemLatex: @"x\geq 0,\;y\geq 0,\;x+y\leq 4",
            solutionLatex: @"\text{triangle }(0,0),(4,0),(0,4)")
        .Mistake("Defining variables vaguely (\"let x = tickets\") without saying which kind.")
        .Mistake("Writing only a money equation and forgetting the count (or total amount) equation.")
        .Mistake("Shading the wrong side of an inequality without testing a point.")
        .Mistake("Using a dashed boundary for <= or >= (the boundary should be solid).")
        .Mistake("Treating a system of inequalities as if the answer were a single point only.")
        .Numeric("Adults $10, children $4. 10 tickets cost $64. How many adult tickets?", "4",
            ["a + c = 10 and 10a + 4c = 64.", "c = 10 - a; 10a + 4(10 - a) = 64 leads to 6a = 24, so a = 4."],
            "4 adult tickets (and 6 child).", explanationLatex: @"a=4")
        .Numeric("x + y = 30 and 0.2x + 0.5y = 12. Find x.", "10",
            ["From y = 30 - x: 0.2x + 0.5(30 - x) = 12.", "0.2x + 15 - 0.5x = 12, so -0.3x = -3, so x = 10."],
            "x = 10.", explanationLatex: @"x=10")
        .Mcq("For y > 2x - 1, the boundary line should be:",
            ["Solid", "Dashed", "Not drawn", "Only the y-intercept"], 1,
            ["Strict inequality excludes the boundary.", "Use a dashed line."],
            "Dashed boundary for >.")
        .Mcq("Is (1, 1) a solution of x + y < 3 and y > 0?",
            ["Yes", "No", "Only the first inequality", "Only the second"], 0,
            ["1+1=2 < 3 true; y=1 > 0 true.", "Both true means yes."],
            "Yes, both inequalities hold.")
        .Numeric("x >= 0, y >= 0, x + y <= 6. What is the maximum possible x on the boundary?", "6",
            ["On x + y = 6 with y = 0, x = 6.", "Non-negative constraints allow the intercept."],
            "Maximum x is 6 at (6, 0).", explanationLatex: @"6")
        .Numeric("Two numbers sum to 40 and differ by 8. What is the larger number?", "24",
            ["x + y = 40 and x - y = 8.", "Add: 2x = 48, so x = 24."],
            "Larger number is 24.", explanationLatex: @"24")
        .Mcq("A system of inequalities typically has a solution that is:",
            ["Always exactly one point", "A region (possibly empty)", "Always the entire plane", "Only vertical lines"], 1,
            ["Overlap of half-planes forms a region."],
            "A region (or empty if inconsistent).")
        .Numeric("Test (0,0) in 2x + y >= 4. Enter 1 if true, 0 if false.", "0",
            ["2(0)+0 = 0, and 0 >= 4 is false."],
            "False; (0,0) is not in that half-plane.", explanationLatex: @"0")
        .Takeaways(
            "Define variables with units, write one equation or inequality per independent fact, then solve.",
            "Mixture and value problems need a total-amount equation and a content/money equation.",
            "Linear inequalities shade half-planes; solid vs dashed depends on inclusive vs strict.",
            "Systems of inequalities: the answer is the overlap of all shaded regions.",
            "Check solutions in the original story; reject or flag unrealistic results when context requires it.")
        .Build();

    private static Lesson Polynomials() => new LessonBuilder("alg-poly", CategoryId, "Polynomials: Operations & Classification")
        .Subtitle("Name them, write them in standard form, and combine with care")
        .Order(5).Minutes("26 min")
        .Section("What counts as a polynomial?",
            "A polynomial in x is a sum of terms of the form a_n x^n where each exponent n is a non-negative integer (0, 1, 2, …) and coefficients a_n are real numbers. Examples: 3x^2 - 5x + 1, 7, x. Non-examples: 1/x (negative power), sqrt(x) (fractional power), 2^x (variable in the exponent).\n\nWhy the restriction? Polynomials are the nicest algebraic expressions: defined everywhere, smooth graphs, and closed under add/subtract/multiply; the result is still a polynomial.")
        .Section("Vocabulary that saves time",
            "• Degree: highest exponent of the variable in the polynomial (after combining like terms). Degree of 5x^3 - 2x + 7 is 3.\n• Leading coefficient: coefficient of the highest-degree term.\n• Standard form: terms written from highest degree to lowest (descending powers).\n• By number of terms: monomial (1), binomial (2), trinomial (3).\n• By degree (common names): linear (1), quadratic (2), cubic (3), constant (0).",
            simple: "Degree = biggest power. Standard form = big powers on the left. Count terms to say mono/bi/tri.",
            prior: "Exponents like x^2 mean x·x. Like terms share the same variable powers (3x^2 and -5x^2 combine; 3x^2 and 3x do not).")
        .Section("Adding and subtracting",
            "Add/subtract by combining like terms only. Think of stacking matching powers: (2x^2 + 3x) + (x^2 - 5x + 4) = 3x^2 - 2x + 4.\n\nSubtraction means distribute a minus sign to every term of the second polynomial: (f) - (g) = f + (-g). Sign errors on the second polynomial are the main hazard.")
        .Section("Multiplying",
            "Use the distributive property: every term in the first factor multiplies every term in the second. For two binomials, FOIL (First, Outer, Inner, Last) is a mnemonic for the four products, but distribution is the real idea, and it works for longer polynomials too.\n\nPattern: (x + a)(x + b) = x^2 + (a+b)x + ab. Keep the result in standard form.")
        .Formula("Binomial product", @"(x+a)(x+b)=x^2+(a+b)x+ab", "Middle term is the sum of a and b; constant is the product.")
        .Formula("Distributive multiply", @"c(ax^n+bx^m)=cax^n+cbx^m", "Multiply coefficients; add exponents only when multiplying same bases.")
        .Example("Classify carefully",
            "Classify 3x^2 - 5x + 1 by degree and by number of terms.",
            [
                "Three terms means trinomial.",
                "Highest power is 2 means degree 2 means quadratic.",
                "Standard form already: leading term 3x^2, leading coefficient 3.",
                "So: quadratic trinomial."
            ],
            "Quadratic trinomial.",
            problemLatex: @"3x^2-5x+1",
            solutionLatex: @"\mathrm{quadratic\;trinomial}")
        .Example("Add polynomials",
            "Simplify (2x^2 + 3x) + (x^2 - 5x + 4).",
            [
                "Group like terms: (2x^2 + x^2) + (3x - 5x) + 4.",
                "2 + 1 = 3 for x^2; 3 - 5 = -2 for x; constant 4.",
                "Result: 3x^2 - 2x + 4.",
                "Wrong path to avoid: adding exponents (turning x^2 + x^2 into x^4); that is for multiplication of powers, not addition of like terms."
            ],
            "3x^2 - 2x + 4.",
            problemLatex: @"(2x^2+3x)+(x^2-5x+4)",
            solutionLatex: @"3x^2-2x+4",
            stepLatex: [@"3x^2+(3x-5x)+4", @"3x^2-2x+4", null, null])
        .Example("Multiply binomials (FOIL with meaning)",
            "Expand (x + 4)(x - 1).",
            [
                "First: x·x = x^2. Outer: x·(-1) = -x. Inner: 4·x = 4x. Last: 4·(-1) = -4.",
                "Combine middle terms: -x + 4x = 3x.",
                "Result: x^2 + 3x - 4.",
                "Check with a number: x=2 gives (6)(1)=6; 4+6-4=6."
            ],
            "x^2 + 3x - 4.",
            problemLatex: @"(x+4)(x-1)",
            solutionLatex: @"x^2+3x-4",
            stepLatex: [@"x^2-x+4x-4", @"x^2+3x-4", null, null])
        .Example("Monomial times polynomial",
            "Simplify 2x(3x^2 - 5).",
            [
                "Distribute 2x to each term: 2x·3x^2 - 2x·5.",
                "2·3 = 6 and x·x^2 = x^3, so 6x^3.",
                "2x·5 = 10x, so subtract: 6x^3 - 10x.",
                "Standard form is already highest degree first. No constant term."
            ],
            "6x^3 - 10x.",
            problemLatex: @"2x(3x^2-5)",
            solutionLatex: @"6x^3-10x")
        .Mistake("Adding exponents when combining like terms (2x^2 + 3x^2 is 5x^2, not 5x^4).")
        .Mistake("Forgetting the outer/inner products when multiplying binomials (missing the middle term).")
        .Mistake("Distributing a minus only to the first term of a subtracted polynomial.")
        .Mistake("Calling 1/x or sqrt(x) a polynomial.")
        .Numeric("What is the degree of 5x^3 - 2x + 7?", "3",
            ["Degree is the highest power of x."],
            "Degree 3.", explanationLatex: @"3")
        .Numeric("In (2x+3)+(x-1), what is the coefficient of x after simplifying?", "3",
            ["2x + x = 3x."],
            "The x term is 3x; coefficient 3.", explanationLatex: @"3")
        .Mcq("(x+2)+(x+5) simplifies to:",
            ["2x+7", "x^2+7", "2x+10", "x+7"], 0,
            ["Combine like terms: x+x and 2+5."],
            "2x+7.")
        .Numeric("Constant term of (x+3)(x+4)?", "12",
            ["Last parts: 3·4=12."],
            "Constant term is 12.", explanationLatex: @"12")
        .Numeric("Coefficient of x in (x+3)(x+4)?", "7",
            ["Middle: 3+4=7 from (x+3)(x+4)=x^2+(3+4)x+12."],
            "Coefficient of x is 7.", explanationLatex: @"7")
        .Numeric("2x^2 · 3x: what is the coefficient of x^3?", "6",
            ["2·3=6; x^2·x=x^3 gives 6x^3."],
            "Coefficient 6.", explanationLatex: @"6")
        .Mcq("Which is not a polynomial?",
            ["x^2+1", "1/x", "3", "x"], 1,
            ["Polynomials cannot have the variable in a denominator (negative exponents)."],
            "1/x is not a polynomial.")
        .Numeric("Degree of the product (x^2+1)(x^3-x) after expanding?", "5",
            ["Degrees add under multiplication of polynomials: 2+3=5."],
            "Degree 5 (leading terms x^2·x^3=x^5).", explanationLatex: @"5")
        .Takeaways(
            "Polynomials use non-negative integer powers only; no 1/x, sqrt(x), or 2^x as terms.",
            "Degree is the highest power; standard form lists descending powers.",
            "Add and subtract by combining like terms; distribute a minus to every term.",
            "Multiply by distributing every term by every term (FOIL is a special case).",
            "Classify by degree (linear, quadratic, …) and by number of terms (mono/bi/tri).")
        .Build();

    private static Lesson PolyDivision() => new LessonBuilder("alg-poly-division", CategoryId, "Polynomial Long Division & Synthetic Division")
        .Subtitle("Divide polynomials like multi-digit numbers, and use synthetic division for linear divisors")
        .Order(6).Minutes("34 min")
        .Section("Why divide polynomials?",
            "Multiplication builds products; division undoes that packaging. Dividing polynomials appears when you simplify rational expressions, factor higher-degree polynomials, find quotient and remainder forms, or prepare for the factor and remainder theorems.\n\nIf f(x) = d(x) · q(x) + r(x) with the degree of r smaller than the degree of d, then f(x)/d(x) = q(x) + r(x)/d(x) when d(x) != 0. That is the same structure as 17 = 5 · 3 + 2, so 17/5 = 3 + 2/5.",
            simple: "Polynomial division finds quotient and remainder so dividend = divisor · quotient + remainder.",
            prior: "Polynomial add/subtract/multiply and comparing degrees. Long division of whole numbers is the template.")
        .Section("Long division process",
            "Write the dividend and divisor in standard form. Include 0 placeholders for missing powers (divide x^3 + 1 by x - 1 using x^3 + 0x^2 + 0x + 1).\n\n1) Divide leading term of current dividend by leading term of divisor; that is the next quotient term.\n2) Multiply the entire divisor by that term.\n3) Subtract (distribute a minus carefully).\n4) Bring down the next term and repeat until the remainder's degree is less than the divisor's degree.\n\nKeep columns aligned by powers of x so like terms stay in the same place.",
            simple: "Divide leading terms, multiply, subtract, bring down, repeat. Stop when remainder degree is smaller than divisor degree.",
            prior: "Distributing and subtracting polynomials without sign errors.")
        .Section("Synthetic division: the shortcut for monic linear divisors",
            "When the divisor is x - c (leading coefficient 1), synthetic division compresses the arithmetic into a coefficient table.\n\nWrite c on the left. List coefficients of the dividend in order (include zeros for missing powers). Bring down the first coefficient. Multiply by c, add to the next coefficient, multiply by c, add, and so on. The last number is the remainder; the others are coefficients of the quotient (one degree lower than the dividend).\n\nFor divisor x + 3, use c = -3 because x + 3 = x - (-3).",
            @"x-c",
            simple: "Only for divisors like x - c. Bring down, multiply by c, add across. Last number is remainder.",
            prior: "Standard form coefficients and careful signed arithmetic.")
        .Section("Remainder theorem (the big idea)",
            "Remainder theorem: when a polynomial f(x) is divided by x - c, the remainder is the constant f(c).\n\nWhy that helps: evaluating f(c) can be faster than full division if you only need the remainder. Conversely, synthetic division that ends with remainder 0 means x - c is a factor and f(c) = 0 (factor theorem connection).\n\nExample: f(x) = x^2 - 3x + 2 divided by x - 1 has remainder f(1) = 1 - 3 + 2 = 0, so (x - 1) divides evenly.",
            @"f(x)=(x-c)q(x)+f(c)",
            simple: "Divide by x - c: remainder equals plug-in f(c). Remainder 0 means (x - c) is a factor.",
            prior: "Evaluating polynomials by substitution.")
        .Section("Writing the result correctly",
            "Always state: dividend = divisor · quotient + remainder, or dividend/divisor = quotient + remainder/divisor.\n\nIf remainder is 0, the divisor is a factor and the quotient is an exact polynomial factor. Degrees should check: deg(dividend) = deg(divisor) + deg(quotient) when remainder is 0 (or with remainder, the main term degrees still match that pattern for the quotient part).",
            simple: "Report quotient and remainder. Prefer the identity form to check multiplication.",
            prior: "Multiplying polynomials to verify: divisor · quotient + remainder should recover the dividend.")
        .Section("Common traps and missing terms",
            "• Forgetting zero placeholders shifts every coefficient and ruins synthetic division.\n• Subtracting means changing all signs of the product line; only changing the first sign is a classic error.\n• Synthetic division does not apply unchanged to quadratic divisors; use long division when the divisor is not linear of the form x - c (or carefully adapt for ax - c by factoring a out).\n• Interpreting the synthetic root: the boxed number is c for x - c, not the constant of x + c without a sign flip.")
        .Section("Connecting forward",
            "Factoring lessons use these tools to pull out linear factors. Rational expressions use division when degrees are high. Calculus and higher algebra reuse remainder and factor ideas constantly. Clean division skill is infrastructure.")
        .Formula("Division algorithm", @"f(x)=d(x)q(x)+r(x)", "deg(r) < deg(d), or r = 0.")
        .Formula("Remainder theorem", @"f(c)=\text{remainder when }f\text{ is divided by }x-c", "Evaluate to get the remainder.")
        .Formula("Synthetic setup", @"x-c\ \text{with coefficients of }f", "Last output entry is remainder.")
        .Example("Long division",
            "Divide x^2 + 5x + 6 by x + 2.",
            [
                "Leading terms: x^2 / x = x. Multiply x + 2 by x: x^2 + 2x.",
                "Subtract from x^2 + 5x + 6: (x^2 + 5x + 6) - (x^2 + 2x) = 3x + 6.",
                "3x / x = 3. Multiply x + 2 by 3: 3x + 6. Subtract: 0.",
                "Quotient x + 3, remainder 0. Check: (x + 2)(x + 3) = x^2 + 5x + 6.",
                "Common mistake callout: subtracting x^2 + 2x as if adding, getting 7x instead of 3x."
            ],
            "Quotient x + 3, remainder 0.",
            problemLatex: @"(x^2+5x+6)\div(x+2)",
            solutionLatex: @"x+3",
            stepLatex: [@"x", @"3x+6", @"3", @"r=0", null])
        .Example("Long division with remainder",
            "Divide x^2 + 3x + 1 by x + 1.",
            [
                "x^2 / x = x. Multiply x + 1 by x: x^2 + x.",
                "Subtract: (x^2 + 3x + 1) - (x^2 + x) = 2x + 1.",
                "2x / x = 2. Multiply x + 1 by 2: 2x + 2.",
                "Subtract: (2x + 1) - (2x + 2) = -1. Remainder -1, degree 0 < 1.",
                "So x^2 + 3x + 1 = (x + 1)(x + 2) + (-1). Check with remainder theorem: f(-1) = 1 - 3 + 1 = -1."
            ],
            "Quotient x + 2, remainder -1.",
            problemLatex: @"(x^2+3x+1)\div(x+1)",
            solutionLatex: @"x+2-\frac{1}{x+1}",
            stepLatex: [@"x", @"2x+1", @"2", @"r=-1", null])
        .Example("Synthetic division",
            "Use synthetic division to divide 2x^3 - 3x^2 + x - 5 by x - 2.",
            [
                "Root c = 2. Coefficients: 2, -3, 1, -5.",
                "Bring down 2. Multiply by 2: 4. Add to -3: 1. Multiply by 2: 2. Add to 1: 3. Multiply by 2: 6. Add to -5: 1.",
                "Bottom row: 2, 1, 3, remainder 1. Quotient 2x^2 + x + 3, remainder 1.",
                "Check: f(2) = 2·8 - 3·4 + 2 - 5 = 16 - 12 + 2 - 5 = 1, matches remainder theorem.",
                "Common mistake callout: using c = -2 because of the minus sign in x - 2."
            ],
            "Quotient 2x^2 + x + 3, remainder 1.",
            problemLatex: @"(2x^3-3x^2+x-5)\div(x-2)",
            solutionLatex: @"2x^2+x+3+\frac{1}{x-2}",
            stepLatex: [@"c=2", @"2,\;1,\;3,\;r=1", null, @"f(2)=1", null])
        .Example("Missing powers and remainder theorem",
            "Divide x^3 - 8 by x - 2 using synthetic division, and verify the remainder with f(2).",
            [
                "Write x^3 + 0x^2 + 0x - 8. Coefficients: 1, 0, 0, -8. c = 2.",
                "Bring down 1. ·2 add: 2. ·2 add: 4. ·2 add: 8. Remainder 0.",
                "Quotient x^2 + 2x + 4, remainder 0. So x^3 - 8 = (x - 2)(x^2 + 2x + 4).",
                "f(2) = 8 - 8 = 0, matches. This is difference of cubes structure.",
                "Common mistake callout: using coefficients 1, -8 only and skipping zero placeholders."
            ],
            "Quotient x^2 + 2x + 4, remainder 0.",
            problemLatex: @"(x^3-8)\div(x-2)",
            solutionLatex: @"x^2+2x+4",
            stepLatex: [@"1,0,0,-8", @"1,2,4,r=0", null, @"f(2)=0", null])
        .Mistake("Forgetting zero coefficients for missing powers of x.")
        .Mistake("Adding the multiply line instead of subtracting in long division.")
        .Mistake("Using c = -2 for divisor x - 2 in synthetic division (should be c = 2).")
        .Mistake("Reporting only the quotient and ignoring a nonzero remainder.")
        .Mistake("Trying plain synthetic division with a quadratic divisor without adjusting the method.")
        .Numeric("Divide x^2 + 5x + 6 by x + 2. What is the remainder?", "0",
            ["Factors as (x+2)(x+3).", "Remainder 0."],
            "Remainder is 0.", explanationLatex: @"0")
        .Numeric("f(x)=x^2-3x+2. What is f(1)? (remainder when dividing by x-1)", "0",
            ["1 - 3 + 2 = 0."],
            "f(1)=0.", explanationLatex: @"0")
        .Numeric("Synthetic division of x^2 + 3x + 1 by x + 1 uses c = ?", "-1",
            ["x + 1 = x - (-1), so c = -1."],
            "c = -1.", explanationLatex: @"-1")
        .Mcq("When dividing by x - c, the remainder equals:",
            ["f(0)", "f(c)", "The leading coefficient", "Always 0"], 1,
            ["Remainder theorem: remainder is f(c)."],
            "f(c).")
        .Numeric("Coefficients of x^3 + 1 for synthetic division (four numbers). What is the second coefficient?", "0",
            ["x^3 + 0x^2 + 0x + 1.", "Second is 0."],
            "0 (placeholder for x^2).", explanationLatex: @"0")
        .Numeric("(x^2 + 4x + 3) divided by (x + 1). Quotient is x + k. What is k?", "3",
            ["(x+1)(x+3)=x^2+4x+3.", "k = 3."],
            "Quotient x + 3, so k = 3.", explanationLatex: @"3")
        .Mcq("Synthetic division is designed primarily for divisors of the form:",
            ["x^2 + 1", "x - c", "2x^2 - x", "Any cubic"], 1,
            ["Monic linear divisors x - c."],
            "x - c.")
        .Numeric("f(x)=2x^2 - 5. f(3) = ?", "13",
            ["2·9 - 5 = 18 - 5 = 13."],
            "13 (also the remainder when dividing by x - 3).", explanationLatex: @"13")
        .Takeaways(
            "Dividend = divisor · quotient + remainder, with deg(remainder) < deg(divisor).",
            "Long division: divide leading terms, multiply, subtract, bring down, repeat.",
            "Synthetic division speeds up division by x - c; include zero placeholders.",
            "Remainder theorem: remainder when dividing by x - c is f(c).",
            "Remainder 0 means x - c is a factor; always verify with multiplication or evaluation.")
        .Build();

    private static Lesson Factoring() => new LessonBuilder("alg-factor", CategoryId, "Factoring Polynomials")
        .Subtitle("Undo multiplication so equations can split into simpler pieces")
        .Order(7).Minutes("30 min")
        .Section("Why factor at all?",
            "Factoring rewrites a sum as a product. That matters because of the zero product property: if A·B = 0, then A = 0 or B = 0 (or both). So a hard polynomial equation can become two (or more) simple linear equations.\n\nFactoring is also reverse multiplication: if you expand (x+2)(x+3) you get x^2+5x+6; factoring goes the other way. Fluency with expanding makes factoring patterns recognizable.")
        .Section("Always start with the GCF",
            "Greatest common factor first, of coefficients and of variable powers. Factor 6x^2 + 9x as 3x(2x + 3). Pulling out the GCF simplifies everything that follows and often reveals a difference of squares or a nicer trinomial.\n\nIf you skip GCF, you may still factor further later, but numbers get messier and solutions may miss a root like x=0.",
            simple: "Ask: what divides every term? Pull that out first. Then look at what remains.",
            prior: "You should know multiplication of binomials and how to find a GCF of whole numbers.")
        .Section("Trinomials x^2 + bx + c",
            "Search for two numbers that multiply to c and add to b. Those numbers become the constants in (x + p)(x + q).\n\nSigns matter: if c > 0 and b > 0, both factors positive; if c > 0 and b < 0, both negative; if c < 0, the factors have opposite signs. Trial with small factor pairs of |c| is systematic, not guessing.")
        .Section("Special patterns",
            "• Difference of squares: a^2 - b^2 = (a - b)(a + b). No middle term.\n• Perfect square trinomials: a^2 + 2ab + b^2 = (a + b)^2 and a^2 - 2ab + b^2 = (a - b)^2.\n• Sum of squares a^2 + b^2 does not factor over the reals into real linear factors (it is not (a+b)^2).")
        .Section("Solving with zero product",
            "Bring all terms to one side (= 0), factor completely, set each factor equal to zero, solve. Discarding a factor or dividing both sides by a variable expression can lose solutions (especially x=0).")
        .Formula("Difference of squares", @"a^2-b^2=(a-b)(a+b)", "Memorize and recognize perfect squares.")
        .Formula("Zero product property", @"AB=0\Rightarrow A=0\text{ or }B=0", "Requires a product equal to zero, not 5, not x.")
        .Formula("Perfect square", @"a^2+2ab+b^2=(a+b)^2", "Middle term must match 2ab.")
        .Example("GCF first",
            "Factor 6x^2 + 9x completely.",
            [
                "Coefficients 6 and 9 share GCF 3. Variables: both terms have at least x^1, so factor x.",
                "GCF is 3x. Factor: 3x(2x + 3).",
                "Check by distributing: 3x·2x + 3x·3 = 6x^2 + 9x.",
                "2x+3 has no common factor other than 1, done."
            ],
            "3x(2x + 3).",
            problemLatex: @"6x^2+9x",
            solutionLatex: @"3x(2x+3)")
        .Example("Trinomial factors",
            "Factor x^2 + 5x + 6.",
            [
                "Need two numbers that multiply to 6 and add to 5.",
                "Pairs of 6: (1,6), (2,3). 2+3=5, yes.",
                "Write (x + 2)(x + 3).",
                "Expand to verify: x^2 + 3x + 2x + 6 = x^2 + 5x + 6."
            ],
            "(x + 2)(x + 3).",
            problemLatex: @"x^2+5x+6",
            solutionLatex: @"(x+2)(x+3)",
            stepLatex: [@"2\cdot 3=6,\;2+3=5", @"(x+2)(x+3)", null, null])
        .Example("Difference of squares",
            "Factor x^2 - 16.",
            [
                "Recognize x^2 - 4^2, a difference of squares.",
                "Apply a^2 - b^2 = (a - b)(a + b) with a=x, b=4.",
                "(x - 4)(x + 4).",
                "Not (x - 4)^2; that would be x^2 - 8x + 16, which has a middle term."
            ],
            "(x - 4)(x + 4).",
            problemLatex: @"x^2-16",
            solutionLatex: @"(x-4)(x+4)")
        .Example("Solve by factoring",
            "Solve x^2 - 5x + 6 = 0.",
            [
                "Factor: find numbers multiplying to 6 and adding to -5: -2 and -3.",
                "(x - 2)(x - 3) = 0.",
                "Zero product: x - 2 = 0 or x - 3 = 0, so x = 2 or x = 3.",
                "Check: 4 - 10 + 6 = 0; 9 - 15 + 6 = 0."
            ],
            "x = 2 or x = 3.",
            problemLatex: @"x^2-5x+6=0",
            solutionLatex: @"x=2,\;3",
            stepLatex: [@"(x-2)(x-3)=0", @"x=2\text{ or }x=3", null, null])
        .Mistake("Sign errors when choosing factor pairs of c that should sum to b.")
        .Mistake("Stopping after a GCF when the remaining polynomial still factors.")
        .Mistake("Writing a^2 - b^2 as (a - b)^2.")
        .Mistake("Dividing both sides of an equation by x and losing the solution x = 0.")
        .Mcq("x^2 - 9 factors as:",
            ["(x-3)(x-3)", "(x-3)(x+3)", "(x+9)(x-1)", "x(x-9)"], 1,
            ["Difference of squares: 9 = 3^2."],
            "(x-3)(x+3).")
        .Numeric("x^2 + 7x + 12 = (x+3)(x+?). What is the missing number?", "4",
            ["Need 3 + ? = 7 and 3·? = 12, so ? = 4."],
            "Missing number is 4: (x+3)(x+4).", explanationLatex: @"4")
        .Numeric("Solve (x-5)(x+2)=0. What is the smaller solution?", "-2",
            ["x=5 or x=-2.", "Smaller is -2."],
            "Smaller solution is -2.", explanationLatex: @"-2")
        .Numeric("GCF of 8x^3 and 12x^2: what is the coefficient part of the GCF?", "4",
            ["GCF of 8 and 12 is 4; variables give x^2, so 4x^2."],
            "Coefficient 4.", explanationLatex: @"4")
        .Mcq("x^2 + 6x + 9 equals:",
            ["(x+3)^2", "(x+9)(x+1)", "(x-3)^2", "(x+6)(x+3)"], 0,
            ["Perfect square: 3^2=9 and 2·x·3=6x."],
            "(x+3)^2.")
        .Numeric("Solve x^2 = 4. What is the positive solution?", "2",
            ["x^2 - 4 = 0 gives (x-2)(x+2)=0, so x=+/-2."],
            "Positive solution is 2.", explanationLatex: @"2")
        .Numeric("Factor x^2 - x - 6 as (x-3)(x+?). What is the second constant?", "2",
            ["-3 and +2 multiply to -6 and add to -1."],
            "(x-3)(x+2); the constant is 2.", explanationLatex: @"2")
        .Mcq("If (x-4)(x+1)=0, the solutions are:",
            ["Only x=4", "x=4 and x=-1", "x=4 and x=1", "x=-4 and x=-1"], 1,
            ["Set each factor to zero."],
            "x=4 or x=-1.")
        .Takeaways(
            "Factoring rewrites a sum as a product; use it with the zero product property to solve equations.",
            "Always pull out the GCF first.",
            "For x^2 + bx + c, find two numbers that multiply to c and add to b.",
            "Memorize difference of squares and perfect-square trinomials.",
            "Set the equation to zero, factor completely, solve each factor; do not lose roots by dividing by x.")
        .Build();

    private static Lesson RationalExpressions() => new LessonBuilder("alg-rational", CategoryId, "Rational Expressions")
        .Subtitle("Algebraic fractions: simplify, multiply, divide, add, with domain in mind")
        .Order(8).Minutes("28 min")
        .Section("What a rational expression is",
            "A rational expression is a ratio of two polynomials, P(x)/Q(x), with Q not the zero polynomial. Examples: (x^2 - 1)/(x + 2), 3/x, (2x)/(x - 5).\n\nJust like numerical fractions are undefined when the denominator is 0, rational expressions are undefined at roots of the denominator. Those excluded values are part of a complete answer even after simplifying.")
        .Section("Why canceling works (and when it fails)",
            "You may cancel common factors, pieces multiplied together, not terms that are added. (x^2 - 9)/(x - 3) = (x-3)(x+3)/(x-3) = x+3 provided x != 3. The factor (x-3) cancels because for x != 3 it is a nonzero common multiplier.\n\nIllegal: (x + 2)/x is not 2 by \"canceling x.\" Addition is not multiplication. This single mistake causes years of algebra pain.",
            simple: "Factor completely. Cancel matching factors top and bottom. Never cancel across a + or - unless it is part of a full factor.",
            prior: "Factoring polynomials (GCF, difference of squares, trinomials) is the engine of simplifying rationals.")
        .Section("Multiply and divide",
            "Multiply: multiply numerators, multiply denominators, but cancel common factors first to keep numbers small. Divide: multiply by the reciprocal of the divisor (same as numerical fractions).\n\nAlways state or remember values that make any original denominator zero.")
        .Section("Add and subtract",
            "Same denominator: add/subtract numerators, keep the denominator, then simplify. Unlike denominators: build a common denominator (often the LCD of the polynomial denominators), rewrite each fraction, then combine numerators.\n\nExample: 1/x + 2/x = 3/x. For 1/x + 1/(x+1), LCD is x(x+1).")
        .Section("Domain after simplifying",
            "Simplifying can hide holes. (x^2 - 1)/(x - 1) simplifies to x + 1 for x != 1, but x = 1 is still excluded from the original expression. Graphs show a hole at x=1 on the line y=x+1.")
        .Formula("Defined when", @"\frac{P(x)}{Q(x)}\text{ requires }Q(x)\neq 0", "Excluded values matter even after canceling.")
        .Formula("Multiply", @"\frac{a}{b}\cdot\frac{c}{d}=\frac{ac}{bd}", "Cancel common factors first when possible.")
        .Formula("Divide", @"\frac{a}{b}\div\frac{c}{d}=\frac{a}{b}\cdot\frac{d}{c}", "Multiply by the reciprocal.")
        .Example("Simplify with a hole",
            "Simplify (x^2 - 9)/(x - 3).",
            [
                "Factor numerator: x^2 - 9 = (x - 3)(x + 3).",
                "Write (x-3)(x+3)/(x-3). For x != 3, cancel (x-3).",
                "Simplified form: x + 3, with restriction x != 3.",
                "Why x != 3 remains: original denominator was zero at x=3, so that input was never allowed."
            ],
            "x + 3 for x != 3.",
            problemLatex: @"\frac{x^2-9}{x-3}",
            solutionLatex: @"x+3\;(x\neq 3)",
            stepLatex: [@"\frac{(x-3)(x+3)}{x-3}", @"x+3\;(x\neq 3)", null, null])
        .Example("Multiply and cancel",
            "Simplify (x/2) · (4/(x + 1)).",
            [
                "Multiply: (x · 4) / (2 · (x + 1)) = 4x / (2(x + 1)).",
                "Cancel factor 2: 2x / (x + 1), with x != -1 (and original factors already fine for x).",
                "Could cancel before multiplying: 4/2 = 2, same result.",
                "Final: 2x/(x+1), x != -1."
            ],
            "2x/(x+1), x != -1.",
            problemLatex: @"\frac{x}{2}\cdot\frac{4}{x+1}",
            solutionLatex: @"\frac{2x}{x+1}",
            stepLatex: [@"\frac{4x}{2(x+1)}", @"\frac{2x}{x+1}", null, null])
        .Example("Divide by a fraction",
            "Simplify (x/3) ÷ (x/6).",
            [
                "Division means multiply by reciprocal: (x/3) · (6/x).",
                "Cancel x (for x != 0) and simplify 6/3: 1 · 2 = 2.",
                "Result 2, with x != 0 (and denominators 3 and 6 never zero anyway).",
                "Check with x=6: (6/3)÷(6/6)=2÷1=2."
            ],
            "2 for x != 0.",
            problemLatex: @"\frac{x}{3}\div\frac{x}{6}",
            solutionLatex: @"2\;(x\neq 0)")
        .Example("Add like denominators",
            "Simplify 1/x + 2/x.",
            [
                "Same denominator x: add numerators 1 + 2 = 3.",
                "Result 3/x, with x != 0.",
                "Not 3/(2x); denominators do not add.",
                "Think of units: 1 apple-box + 2 apple-boxes = 3 apple-boxes, same box size 1/x."
            ],
            "3/x, x != 0.",
            problemLatex: @"\frac{1}{x}+\frac{2}{x}",
            solutionLatex: @"\frac{3}{x}")
        .Mistake("Canceling terms instead of factors: (x+2)/x is not 2.")
        .Mistake("Forgetting excluded values after simplifying.")
        .Mistake("Adding denominators when adding fractions.")
        .Mistake("Forgetting to multiply by the reciprocal when dividing.")
        .Numeric("Simplify (2x)/4 at x=6. What value do you get?", "3",
            ["(2x)/4 = x/2; at x=6 gives 3."],
            "Value is 3.", explanationLatex: @"3")
        .Mcq("(x^2-1)/(x-1) simplifies to (for x!=1):",
            ["x-1", "x+1", "x", "1"], 1,
            ["x^2-1=(x-1)(x+1); cancel (x-1)."],
            "x+1.")
        .Numeric("1/2 + 1/3 as a fraction a/b in lowest terms?", "5/6",
            ["LCD 6: 3/6 + 2/6 = 5/6."],
            "5/6.", explanationLatex: @"\frac{5}{6}", tolerance: 0)
        .Numeric("For (x-2)/(x+5), what x is excluded?", "-5",
            ["Denominator zero when x+5=0, so x=-5."],
            "x != -5.", explanationLatex: @"x\neq -5")
        .Mcq("(3/x) ÷ (6/x) equals:",
            ["1/2", "2", "18/x^2", "3/6"], 0,
            ["(3/x)·(x/6)=3/6=1/2 for x!=0."],
            "1/2.")
        .Numeric("Value of (x+1)/(x+1) when x=4?", "1",
            ["For x!=-1 the expression is 1; x=4 is fine."],
            "1.", explanationLatex: @"1")
        .Numeric("2/x + 3/x = a/x. What is a?", "5",
            ["Add numerators: 2+3=5."],
            "a = 5, so 5/x.", explanationLatex: @"5")
        .Mcq("Which step is invalid?",
            ["Cancel (x-2) in (x-2)/(x-2)", "Rewrite (x^2-1)/(x-1) as x+1 for x!=1", "Cancel x in (x+5)/x to get 5", "Multiply by reciprocal to divide fractions"], 2,
            ["x is a factor of the denominator but not a factor of the whole numerator x+5."],
            "You cannot cancel the x in (x+5)/x to leave 5.")
        .Takeaways(
            "A rational expression is a ratio of polynomials; exclude zeros of the denominator.",
            "Cancel common factors only, never terms across + or -.",
            "Multiply tops and bottoms; divide by multiplying by the reciprocal.",
            "Add/subtract with a common denominator, then simplify.",
            "Simplified form can hide holes; keep original domain restrictions.")
        .Build();
}
