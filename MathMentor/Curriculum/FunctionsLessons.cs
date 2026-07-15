using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class FunctionsLessons
{
    public const string CategoryId = "functions";

    public static Category Build()
    {
        var lessons = new[]
        {
            FunctionBasics(),
            Transformations(),
            Exponential(),
            Logarithms()
        };
        return new Category(CategoryId, "Functions & Advanced Algebra",
            "Function thinking, transformations, exponential growth, and logarithms.",
            "\uE9D2", 10, lessons);
    }

    private static Lesson FunctionBasics() => new LessonBuilder("fn-basics", CategoryId, "Functions: Definition, Notation, Domain/Range")
        .Subtitle("Why exactly one output is the rule, and how domain and range describe a function's world")
        .Order(1).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "A function assigns each valid input exactly one output.")
        .Section("Why functions exist (and why the definition is strict)",
            "A function is a reliable input-output rule: each allowed input produces exactly one output. That single-output promise is what lets science, engineering, and algebra treat a process as predictable.\n\nIf a vending machine sometimes drops tea and sometimes coffee for the same button, it is not acting as a function of the button press. If a temperature sensor sometimes reports two different readings for the same moment, you cannot trust the model.\n\nA relation can pair inputs and outputs more loosely, including multiple outputs for one input. Every function is a relation, but not every relation is a function. The strict definition is not pedantry; it is the difference between a machine you can rely on and a coin flip.",
            simple: "Think of a function as a reliable machine: put in one allowed x, get exactly one y out. Never two different answers for the same x.",
            prior: "You already evaluate expressions like 2x + 1. Function notation just names the rule and makes inputs and outputs easy to talk about.")
        .Section("The vertical line test: the graph version of the definition",
            "On a graph of y versus x, each vertical line is one fixed input x. If that line hits the graph more than once, that x has two (or more) y-values, so y is not a function of x.\n\nClassic non-functions: a full circle x^2 + y^2 = 1, a sideways parabola x = y^2, and a vertical line x = 3 (which is not y as a function of x at all in the usual sense).\n\nClassic functions: y = x^2, y = 2x + 1, y = |x|, y = 1/x (for x != 0). Two different inputs may share the same output (both 2 and -2 square to 4). That is allowed. The ban is two outputs for one input, not two inputs for one output.",
            simple: "Slide a vertical line left to right. If it ever hits twice, the graph fails the function test for y in terms of x.",
            prior: "You need to read ordered pairs and recognize that a graph is a set of (x, y) points.")
        .Section("Notation f(x): naming the rule, not multiplying",
            "The symbol f(x) is read \"f of x.\" It does not mean f times x. The letter f is the name of the rule; the expression inside the parentheses is the input.\n\nExamples of rules:\n• f(x) = 2x + 1 means \"double the input, then add one.\"\n• g(t) = t^2 - 4 uses t as the input variable; the letter is a dummy name, the rule matters.\n• h(n) = 3n for integer n emphasizes that domain context can change the letter and the story.\n\nEvaluating means substituting carefully: f(3) replaces every input slot with 3. If f(x) = 3x - 2, then f(4) = 3·4 - 2 = 10. Parentheses matter when inputs are negative or binomials: f(-2), f(a + 1), f(x^2).",
            simple: "f(x) means \"the output of rule f when the input is x.\" To evaluate, replace x with the given number or expression and simplify.",
            prior: "Substitution into expressions, the same skill as plugging into formulas in algebra.")
        .Section("Domain: what you are allowed to put in",
            "The domain is the set of inputs for which the rule makes sense in the context (usually real numbers unless stated otherwise).\n\nCommon real-number restrictions:\n• Denominator != 0 (cannot divide by zero).\n• Even root of a negative is not real (sqrt(x - 1) needs x >= 1).\n• Logarithm arguments must be positive (covered in the logarithms lesson).\n\nSometimes domain is restricted by a story (\"time t >= 0\") even if the pure algebra would allow more. Always read whether the problem is pure algebra or applied. When several restrictions apply, the domain is the intersection of all of them.",
            simple: "Domain = legal inputs. Cross out values that break the expression (zeros in denominators, negatives under even roots in real math).",
            prior: "You need to solve simple equations and inequalities like x - 5 = 0 or x >= 0.")
        .Section("Range: what can come out",
            "The range is the set of all actual outputs the function produces as x runs through the domain. Finding range can be harder than domain: you may need graph intuition, completing the square, or inverse thinking.\n\nExamples:\n• f(x) = x^2 on all reals has range [0, infinity) because squares are never negative.\n• f(x) = 2x + 1 on all reals has range all reals (lines with nonzero slope cover every height).\n• A horizontal line y = 3 has range {3} only.\n• f(x) = 1/x on nonzero reals has range all nonzero reals (never hits 0).\n\nDomain and range together describe the function's input-output world, essential before graphing, transforming, or inverting.",
            simple: "Range = all heights the graph actually reaches. Ask: what y-values can this rule produce?",
            prior: "Basic graphs of lines and parabolas help you see range even before formal analysis.")
        .Section("Tables, mappings, and equations as the same idea",
            "A function can be presented as a table of pairs, a mapping diagram with arrows, a graph, or an equation. The definition does not care about the packaging; it cares that each allowed input maps to one output.\n\nWhen you build a table from f(x) = 2x + 1, each x appears once with its unique y. When you read a mapping, no input should have two arrows out. When you solve for y in a relation, check whether the solved form is single-valued in x.",
            simple: "Table, arrows, graph, or formula: if every input has one output, it is a function.",
            prior: "Reading tables and solving simple equations for y.")
        .Section("Putting it together: a checklist before you compute",
            "Before evaluating or graphing, ask:\n1) What is the rule (formula, piece, or description)?\n2) What inputs are allowed (domain)?\n3) Am I being asked for an output (evaluate), a set of outputs (range), or a yes/no (is it a function)?\n4) If I substitute, did I use parentheses for negatives and multi-term inputs?\n\nThat short checklist prevents the most common function-notation mistakes.")
        .Formula("Evaluation", @"f(a)=\text{output when }x=a", "Substitute carefully; simplify.")
        .Formula("Vertical line test", @"\text{each }x\text{ meets the graph at most once}", "Graphical form of one output per input.")
        .Formula("Domain idea", @"x\in D_f", "Only inputs for which the rule is defined in context.")
        .Example("Evaluate with function notation",
            "Given f(x) = 3x - 2, find f(4) and explain each step.",
            [
                "The rule says: multiply the input by 3, then subtract 2.",
                "Replace x with 4: f(4) = 3(4) - 2.",
                "Compute 12 - 2 = 10.",
                "So the machine outputs 10 when the input is 4. Writing f(4) = 10 is complete function language.",
                "Common mistake callout: reading f(4) as \"f times 4\" or writing 3x - 2 with x still in it."
            ],
            "f(4) = 10.",
            problemLatex: @"f(x)=3x-2",
            solutionLatex: @"f(4)=10",
            stepLatex: [null, @"f(4)=3(4)-2", @"12-2=10", null, null])
        .Example("Domain by excluding illegal inputs",
            "Find the domain of g(x) = 1/(x - 5) over the real numbers.",
            [
                "The expression divides by x - 5, so the denominator cannot be zero.",
                "Solve x - 5 = 0: x = 5 is forbidden.",
                "Every other real number is fine.",
                "Domain: all real x except 5, often written (-infinity, 5) U (5, infinity) or {x real : x != 5}.",
                "Common mistake callout: excluding 0 instead of 5, or saying the domain is only x = 5."
            ],
            "Domain is all reals except 5.",
            problemLatex: @"g(x)=\frac{1}{x-5}",
            solutionLatex: @"x\neq 5",
            stepLatex: [null, @"x-5=0", @"x\neq 5", null, null])
        .Example("Range of a simple square",
            "Let f(x) = x^2 for real x. What is the range? Why?",
            [
                "For any real input, x^2 >= 0. The output never goes negative.",
                "Can we hit 0? Yes, f(0) = 0.",
                "Can we hit any positive number M? Yes, f(sqrt(M)) = M (and also f(-sqrt(M)) = M).",
                "Range is [0, infinity). Note two different inputs can share an output; that is allowed.",
                "Common mistake callout: saying the range is all reals, or excluding 0."
            ],
            "Range is [0, infinity).",
            problemLatex: @"f(x)=x^2",
            solutionLatex: @"[0,\infty)",
            stepLatex: [@"x^2\geq 0", @"f(0)=0", @"f(\sqrt{M})=M", null, null])
        .Example("Spotting a non-function",
            "Is y a function of x for the relation x = y^2? Explain using outputs and the vertical line test idea.",
            [
                "Solve for y: y = +/- sqrt(x) when x >= 0. For example x = 4 gives y = 2 and y = -2.",
                "One input x = 4 is paired with two outputs, which violates the function definition for y = f(x).",
                "The graph is a sideways parabola; vertical lines x = constant (for x > 0) hit twice.",
                "By contrast, y = x^2 is a function: each x has exactly one square.",
                "Common mistake callout: thinking \"it is a parabola so it must be a function\" without checking which variable is the input."
            ],
            "y is not a function of x for x = y^2.",
            problemLatex: @"x=y^2",
            solutionLatex: @"\text{not }y=f(x)",
            stepLatex: [@"y=\pm\sqrt{x}", null, null, null, null])
        .Mistake("Reading f(x) as \"f times x\" instead of \"f of x.\"")
        .Mistake("Including values that make a denominator zero in the domain.")
        .Mistake("Thinking a function cannot send two different inputs to the same output (that is allowed).")
        .Mistake("Confusing domain (inputs) with range (outputs).")
        .Mistake("Assuming every equation in x and y defines y as a function of x.")
        .Numeric("f(x) = 2x + 5. f(3) = ?", "11",
            ["Substitute x = 3.", "2·3 + 5 = 11."],
            "f(3) = 11.", explanationLatex: @"f(3)=11")
        .Numeric("f(x) = x^2 - 1. f(4) = ?", "15",
            ["4^2 - 1 = 16 - 1.", "15."],
            "f(4) = 15.", explanationLatex: @"f(4)=15")
        .Numeric("For 1/(x + 2), the domain excludes x = ?", "-2",
            ["Denominator zero when x + 2 = 0.", "x = -2."],
            "Exclude x = -2.", explanationLatex: @"x\neq -2")
        .Mcq("Which defines y as a function of x?",
            ["x = y^2", "y = x^2", "x^2 + y^2 = 1 (full circle)", "Vertical line x = 2 as many y"], 1,
            ["y = x^2 assigns one y to each x.", "The circle and x = y^2 give two y-values for some x."],
            "y = x^2 is a function of x.")
        .Numeric("f(x) = 5 - x. f(0) = ?", "5",
            ["5 - 0 = 5."],
            "f(0) = 5.", explanationLatex: @"f(0)=5")
        .Numeric("f is linear: f(x) = mx + 1 and f(2) = 7. Find m.", "3",
            ["2m + 1 = 7.", "2m = 6, so m = 3."],
            "m = 3.", explanationLatex: @"m=3")
        .Mcq("The vertical line test checks that:",
            ["Each y has at most one x", "Each x has at most one y", "The slope is positive", "The area is finite"], 1,
            ["Functions allow only one output per input x."],
            "Each x meets the graph at most once.")
        .Mcq("The range of f(x) = x^2 for real x is:",
            ["All real numbers", "Only positive numbers (excluding 0)", "[0, infinity)", "Only integers"], 2,
            ["Squares are >= 0 and every value >= 0 is hit."],
            "Range is [0, infinity).")
        .Takeaways(
            "A function assigns each allowed input exactly one output; relations may be more loose.",
            "f(x) means \"f of x,\" evaluate by substituting, not by multiplying f by x.",
            "Domain = legal inputs; range = outputs actually produced.",
            "The vertical line test is the graph form of \"one y per x.\"",
            "Two inputs may share one output; that still counts as a function.")
        .Build();

    private static Lesson Transformations() => new LessonBuilder("fn-transform", CategoryId, "Function Transformations & Piecewise Functions")
        .Subtitle("How inside vs outside changes move a graph, and how piecewise rules switch midstream")
        .Order(2).Minutes("34 min")
        .Visual(VisualKind.FunctionTransform, "See how g(x)=a f(x-h)+k moves and scales the graph.")
        .Section("Why transformations matter",
            "If you know the parent graph of y = f(x), for example y = x^2, y = sqrt(x), y = |x|, y = 1/x, you can build a whole family of related graphs without plotting dozens of points. Transformations describe shifts, stretches, compressions, and reflections in a consistent language.\n\nThe payoff: vertex form of a parabola, modeling with shifted absolute values, and reading parameters off a graph become mechanical once inside versus outside is clear. You stop reinventing the graph and start editing it.",
            simple: "Learn one parent shape well. Then slide it, stretch it, or flip it using a few parameters instead of starting from scratch.",
            prior: "Function evaluation and basic parent graphs (line, parabola, absolute value, square root).")
        .Section("Outside changes move outputs (vertical)",
            "Operations outside f affect y-values after the function runs:\n• y = f(x) + k shifts the graph up k units if k > 0 (down if k < 0).\n• y = a f(x) multiplies every output by a: vertical stretch if |a| > 1, vertical compression if 0 < |a| < 1.\n• If a < 0, also reflect over the x-axis (outputs flip sign).\n\nIntuition: you compute f(x) first, then adjust the result. The input x is not moved sideways by these operations. Landmark heights (vertices, intercepts as y-values) are scaled and shifted after the parent rule runs.",
            simple: "Stuff outside the function changes heights: +k slides up/down; multiply by a stretches or flips vertically.",
            prior: "Multiplying and adding numbers, applied to outputs.")
        .Section("Inside changes move inputs (horizontal), with a twist",
            "Operations inside f alter which input is fed into the rule:\n• y = f(x - h) shifts the graph right by h if h > 0. Why \"minus means right\"? Because the input that used to produce a landmark at x = 0 now happens when x - h = 0, that is at x = h.\n• y = f(x + h) = f(x - (-h)) shifts left by h.\n• y = f(bx) compresses horizontally if |b| > 1 (the graph happens faster), stretches horizontally if 0 < |b| < 1.\n• y = f(-x) reflects over the y-axis.\n\nStudents often reverse horizontal shifts. Always ask: \"What x makes the inside match the parent's special input?\"",
            @"y=a\,f(b(x-h))+k",
            simple: "Inside is sneaky: f(x - 2) moves right 2, not left. Ask where the inside equals the old landmark input.",
            prior: "Solving simple equations like x - h = 0 to locate shifted landmarks (vertices, intercepts).")
        .Section("Order of transformations: a practical sequence",
            "When several changes appear at once, a reliable order for thinking is:\n1) Horizontal shifts and horizontal stretches/reflections (inside work).\n2) Vertical stretches/reflections (multiply by a).\n3) Vertical shifts (+k).\n\nDifferent textbooks phrase order slightly differently when stretches and shifts mix; what never changes is the inside/outside logic and the \"opposite direction\" horizontal shift rule. When in doubt, track a few key points from the parent through each change.",
            simple: "Track a parent point: apply inside changes to x, then scale y, then slide y. Check with a second point.",
            prior: "Evaluating a parent at simple points like x = 0, 1, 2, -1.")
        .Section("Piecewise functions: different rules on different domains",
            "A piecewise function uses different formulas on different parts of the domain. Absolute value is the classic example:\n|x| = x when x >= 0, and -x when x < 0.\n\nTo evaluate, first decide which piece contains the input; then use only that piece. Graphs may have corners or jumps depending on whether pieces meet smoothly. Continuity is a calculus topic; algebraically, check the left and right values at the boundary if asked whether the graph connects.",
            simple: "Piecewise = choose the rule whose condition matches your x, then evaluate that rule only.",
            prior: "Inequalities like x < 1 and function evaluation on each piece.")
        .Section("Absolute value and other parents as transformation practice",
            "y = |x - h| + k is a V shape with vertex (h, k). y = a|x - h| + k stretches or flips that V. Square root parents move the endpoint (0, 0) of y = sqrt(x) to (h, k) under y = a sqrt(x - h) + k, with domain x >= h when a is real and the inside stays non-negative.\n\nPractice naming: shift, stretch, reflect, then write the equation from a graph description. Both directions (equation to story, story to equation) build fluency.",
            simple: "Vertex or endpoint of the parent moves with (h, k); a controls steepness and flip.",
            prior: "Parent shapes for |x| and sqrt(x), and the meaning of vertex.")
        .Section("Connecting forward: why algebra and calculus care",
            "Vertex form of a quadratic is a transformation story about y = x^2. Piecewise rules appear in tax brackets, shipping rates, and absolute-value equations. Later, derivatives of transformed functions reuse these same shift and scale ideas. Mastering transformations early pays rent for years.")
        .Formula("General transform", @"a\,f(b(x-h))+k", "a vertical scale/flip; b horizontal scale/flip; h right; k up.")
        .Formula("Horizontal shift reminder", @"f(x-h)\ \text{shifts right }h", "Opposite of the sign inside.")
        .Formula("Vertical shift", @"f(x)+k\ \text{shifts up }k", "Outside addition moves heights.")
        .Example("Shift a parabola to a new vertex",
            "Describe how y = (x - 2)^2 + 3 comes from y = x^2, and name the vertex.",
            [
                "Parent y = x^2 has vertex (0, 0).",
                "Replace x with (x - 2): horizontal shift right 2.",
                "Then +3 outside: vertical shift up 3.",
                "Vertex moves to (2, 3). The shape (width) is unchanged because there is no extra stretch factor a != 1.",
                "Common mistake callout: saying (x - 2) shifts left 2."
            ],
            "Right 2, up 3; vertex (2, 3).",
            problemLatex: @"y=(x-2)^2+3",
            solutionLatex: @"(2,3)",
            stepLatex: [null, @"x-2=0\Rightarrow x=2", @"+3", @"(2,3)", null])
        .Example("Reflection of a square root",
            "Describe y = -sqrt(x) compared to y = sqrt(x). What is the range of y = -sqrt(x) for real x?",
            [
                "Parent sqrt(x) is defined for x >= 0 and produces outputs >= 0.",
                "The leading minus multiplies outputs by -1: reflection across the x-axis.",
                "Domain stays x >= 0 (inside unchanged).",
                "Range becomes (-infinity, 0], all non-positive outputs.",
                "Common mistake callout: reflecting over the y-axis instead, or claiming domain shrinks."
            ],
            "Reflect sqrt(x) over the x-axis; range (-infinity, 0].",
            problemLatex: @"y=-\sqrt{x}",
            solutionLatex: @"y=-\sqrt{x}",
            stepLatex: [null, @"y\mapsto -y", @"x\geq 0", @"(-\infty,0]", null])
        .Example("Evaluate a piecewise rule carefully",
            "Let f(x) = 2x when x < 1, and f(x) = 5 when x >= 1. Find f(1) and f(0).",
            [
                "For f(1): check the condition. 1 >= 1, so use the second piece: f(1) = 5.",
                "For f(0): 0 < 1, so use the first piece: f(0) = 2·0 = 0.",
                "Common error: using 2x at x = 1 because it \"looks continuous\"; the definition says x >= 1 uses 5.",
                "Graph: a line of slope 2 for x < 1, and a horizontal ray y = 5 for x >= 1. As x approaches 1 from the left, 2x approaches 2, which is not 5, so there is a jump.",
                "Common mistake callout: evaluating both pieces and averaging, or ignoring the inequality direction."
            ],
            "f(1) = 5 and f(0) = 0.",
            problemLatex: @"f(x)=2x\ (x<1),\;f(x)=5\ (x\geq 1)",
            solutionLatex: @"f(1)=5,\;f(0)=0")
        .Example("Absolute value as a shift",
            "Graph story for y = |x - 1|: relate to y = |x| and name the vertex.",
            [
                "Parent y = |x| is a V with vertex (0, 0).",
                "Inside (x - 1) shifts the graph right by 1.",
                "Vertex moves to (1, 0); still opens upward with slopes -1 and +1 on the two sides.",
                "Check: at x = 1, y = 0; at x = 3, y = 2; at x = -1, y = 2.",
                "Common mistake callout: shifting left to x = -1 because of the minus sign."
            ],
            "V shape shifted right 1; vertex (1, 0).",
            problemLatex: @"y=|x-1|",
            solutionLatex: @"y=|x-1|",
            stepLatex: [null, @"h=1", @"(1,0)", null, null])
        .Mistake("Shifting f(x + 2) to the right; it actually shifts left 2.")
        .Mistake("Using the wrong piece of a piecewise function for the given x.")
        .Mistake("Thinking y = f(2x) moves the graph right by 2 (it is a horizontal compression, not a shift).")
        .Mistake("Reflecting over the wrong axis: -f(x) is x-axis; f(-x) is y-axis.")
        .Mistake("Applying vertical stretch to x-coordinates instead of y-coordinates.")
        .Numeric("Vertex of y = (x + 4)^2 is at x = ?", "-4",
            ["(x + 4) = (x - (-4)).", "Shift left 4, so vertex x = -4."],
            "Vertex at x = -4.", explanationLatex: @"x=-4")
        .Numeric("y = f(x) + 7 shifts the parent up by?", "7",
            ["Outside +7 raises all outputs by 7."],
            "Up 7 units.", explanationLatex: @"7")
        .Mcq("y = f(x - 3) shifts the graph:",
            ["Left 3", "Right 3", "Up 3", "Down 3"], 1,
            ["Inside minus is a shift right.", "Landmark when x - 3 = 0 means x = 3."],
            "Right 3.")
        .Numeric("f(x) = x^2 if x <= 0, else f(x) = x. f(-3) = ?", "9",
            ["-3 <= 0, so use x^2.", "(-3)^2 = 9."],
            "f(-3) = 9.", explanationLatex: @"9")
        .Numeric("Same f as previous. f(2) = ?", "2",
            ["2 > 0, so use f(x) = x.", "f(2) = 2."],
            "f(2) = 2.", explanationLatex: @"2")
        .Numeric("Vertical stretch y = 3x^2: value at x = 2?", "12",
            ["3 times (2)^2 = 3 times 4 = 12."],
            "12.", explanationLatex: @"12")
        .Mcq("y = -f(x) is a reflection over the:",
            ["Y-axis", "X-axis", "Origin only (always)", "Line y = x"], 1,
            ["Negating outputs flips over the x-axis."],
            "X-axis.")
        .Numeric("For y = f(x) - 5, the graph shifts down by?", "5",
            ["Outside -5 lowers outputs by 5."],
            "Down 5.", explanationLatex: @"5")
        .Takeaways(
            "Outside changes affect outputs (vertical shift, stretch, x-axis reflection).",
            "Inside changes affect inputs; f(x - h) shifts right h (opposite of the inside sign).",
            "General form a f(b(x - h)) + k packages scale, flip, and shift.",
            "Piecewise: pick the piece whose condition contains x, then evaluate only that rule.",
            "Track parent landmarks (vertex, intercepts) through each transformation to check your story.")
        .Build();

    private static Lesson Exponential() => new LessonBuilder("fn-exponential", CategoryId, "Exponential Functions, Graphs, Growth & Decay")
        .Subtitle("Why multiplying repeatedly beats adding, and how (1 +/- r)^t models percent change")
        .Order(3).Minutes("34 min")
        .Visual(VisualKind.ExponentialGrowth, "Exponential curves grow (or decay) by a constant factor each step.")
        .Section("Linear vs exponential: the deep distinction",
            "A linear function changes by adding a constant amount per step (slope). An exponential function changes by multiplying by a constant factor per step.\n\nIf a population gains 100 people every year, that is linear. If it grows by 5% of its current size every year, that is exponential: each year the gain itself gets larger as the base grows. That is why exponential models explode (or collapse) so dramatically over long times.\n\nForm: f(x) = a · b^x with a != 0, base b > 0, and b != 1. Here a = f(0) is the initial value, and b is the growth factor per 1-unit increase in x.",
            simple: "Linear: add the same amount each step. Exponential: multiply by the same factor each step.",
            prior: "Integer exponents and percent-to-decimal conversion (5% = 0.05). Function evaluation basics.")
        .Section("Growth factor b: growth vs decay",
            "• If b > 1, the function grows as x increases (exponential growth).\n• If 0 < b < 1, the function decays toward 0 (exponential decay).\n• b = 1 is a horizontal line (degenerate); b <= 0 is not used for real exponential modeling in standard courses.\n\nPercent models rewrite the factor:\n• Growth of r (as a decimal): b = 1 + r, so y = a(1 + r)^t.\n• Decay of r: b = 1 - r, so y = a(1 - r)^t.\n\nExample: 4% annual growth means multiply by 1.04 each year. 15% decay means multiply by 0.85 each period.",
            @"y=a(1\pm r)^t",
            simple: "Growth factor > 1 grows; between 0 and 1 shrinks. Percent growth uses 1 + r; percent decay uses 1 - r.",
            prior: "You must convert percents to decimals before adding to or subtracting from 1.")
        .Section("Graph features you should expect",
            "For a > 0 and b > 1: the graph passes through (0, a), increases, is always positive, and has a horizontal asymptote y = 0 as x goes to -infinity. For 0 < b < 1: decreases toward the same asymptote y = 0 as x goes to +infinity.\n\nUnlike polynomials, exponential graphs do not turn around; growth stays growth. That one-way behavior is why half-life and compound interest formulas stay multiplicative. If a < 0, the graph is reflected over the x-axis (below the axis), still approaching y = 0, but standard growth/decay stories use a > 0.",
            simple: "Starts at (0, a), never hits y = 0 for finite x, and either climbs faster and faster or slides toward zero.",
            prior: "Coordinate graphing and the idea of an asymptote as a line the graph approaches but does not cross (for a > 0).")
        .Section("Tables and equal ratios: recognizing exponential data",
            "In a table with equally spaced x-values, linear data show a constant first difference in y. Exponential data show a roughly constant ratio y_{next}/y_{current} equal to the growth factor b.\n\nExample: y-values 5, 10, 20, 40 with x stepping by 1 have ratio 2 each time, so a model y = 5 · 2^x fits if x starts at 0. Real data are noisy; look for approximately constant ratios after cleaning units and timing.",
            simple: "Equal x-steps: constant add means linear; constant multiply means exponential.",
            prior: "Reading tables and dividing consecutive terms carefully.")
        .Section("Compound interest and repeated percent change",
            "Compound interest is exponential growth of money: each period you earn interest on a new, larger balance. Simple interest, by contrast, is linear in time. Always match the exponent to the number of compounding periods, and use the period rate (APR adjusted for compounding when required by the formula you are given).\n\nPopulation growth, depreciation of a car, and radioactive half-life are the same multiplicative idea with different stories and bases.",
            simple: "Interest-on-interest means multiply by (1 + rate) over and over; that is exponential, not add a fixed dollar amount each year.",
            prior: "Percent of a number and converting 4% to 0.04.")
        .Section("Comparing growth: when exponential overtakes linear",
            "A line can start steeper than an exponential curve for a while, especially if the exponential starts small. Over a long enough horizon, exponential growth with b > 1 outruns any linear model. That is not a slogan; it is why compounding and population models matter for planning.\n\nWhen reading word problems, ask: does each period add a fixed amount, or multiply by a fixed factor (including percent of current amount)? That single question chooses the family.",
            simple: "Add fixed amount each time: linear. Multiply by fixed factor each time: exponential.",
            prior: "Comparing values by substitution at larger and larger t.")
        .Section("Connecting forward: logs undo exponentials",
            "Solving b^x = a for x is the inverse problem of evaluating powers. Logarithms (next lesson) name that inverse. Fluency with exponential graphs, factors, and (1 +/- r)^t makes log equations feel like undoing a process you already understand.")
        .Formula("Exponential model", @"y=a b^x", "Initial a; multiply by b each step.")
        .Formula("Percent growth/decay", @"y=a(1\pm r)^t", "r as a decimal; t number of periods.")
        .Formula("Initial value", @"f(0)=a", "Any nonzero number to the power 0 is 1, so f(0) = a.")
        .Example("Evaluate an exponential expression",
            "Given f(x) = 3 · 2^x, find f(4).",
            [
                "Compute the power first: 2^4 = 16.",
                "Then multiply by the initial coefficient: 3 · 16 = 48.",
                "Meaning: start at 3 when x = 0; double four times: 3, 6, 12, 24, 48.",
                "Order matters: 3 · 2^4 is not (3 · 2)^4.",
                "Common mistake callout: computing 6^4 or doing 3 · 2 · 4 as if it were linear."
            ],
            "f(4) = 48.",
            problemLatex: @"f(x)=3\cdot 2^x",
            solutionLatex: @"48",
            stepLatex: [@"2^4=16", @"3\cdot 16=48", null, null, null])
        .Example("Compound growth with percent",
            "Invest $500 at 4% annual interest compounded yearly for 3 years. Write the exact expression and approximate the balance.",
            [
                "Model: y = a(1 + r)^t with a = 500, r = 0.04, t = 3.",
                "Exact: 500(1.04)^3.",
                "1.04^2 = 1.0816; 1.0816 times 1.04 = 1.124864.",
                "500 times 1.124864 = 562.432, about $562.43.",
                "Common mistake callout: using 500 + 0.04 · 3 (simple interest thinking) or r = 4 instead of 0.04."
            ],
            "About $562.43.",
            problemLatex: @"500(1.04)^3",
            solutionLatex: @"500(1.04)^3",
            stepLatex: [@"r=0.04", @"1.04^3", @"562.43", null, null])
        .Example("Half-life style decay",
            "A quantity starts at 200 and is multiplied by 1/2 each step: y = 200 · (1/2)^x. What remains after 3 steps?",
            [
                "Each step halves the amount.",
                "After 3 steps: 200 · (1/2)^3 = 200 · (1/8) = 25.",
                "Path: 200, 100, 50, 25.",
                "Factor 1/2 is between 0 and 1, so this is exponential decay.",
                "Common mistake callout: subtracting 1/2 three times, or writing 200 · 3 · (1/2)."
            ],
            "25 remain.",
            problemLatex: @"y=200\cdot\left(\frac{1}{2}\right)^x",
            solutionLatex: @"25",
            stepLatex: [null, @"200\cdot\frac{1}{8}=25", null, null, null])
        .Example("Identify growth or decay from the formula",
            "Classify y = 5(0.9)^x. State the initial value and the percent change per step.",
            [
                "Initial value a = 5 = y when x = 0.",
                "Base b = 0.9 is between 0 and 1, so decay.",
                "0.9 = 1 - 0.1, so each step multiplies by 90% of the previous value: 10% decay per step.",
                "The graph decreases toward the asymptote y = 0 but stays positive.",
                "Common mistake callout: calling it growth because 0.9 looks \"close to 1,\" or treating a = 0.9 as the initial value."
            ],
            "Exponential decay from 5 at 10% per step.",
            problemLatex: @"y=5(0.9)^x",
            solutionLatex: @"y=5(0.9)^x",
            stepLatex: [@"a=5", @"0<0.9<1", @"r=0.1", null, null])
        .Mistake("Writing (1 + r)t instead of (1 + r)^t; missing the exponent turns growth linear.")
        .Mistake("Treating b^x as b · x (confusing exponential with linear).")
        .Mistake("Using r = 4 instead of r = 0.04 for 4% growth.")
        .Mistake("Calling y = a · b^x decay whenever a is small; decay is about 0 < b < 1, not about a.")
        .Mistake("Forgetting that f(0) = a when the model is y = a b^x.")
        .Numeric("2^5 = ?", "32",
            ["2·2·2·2·2 = 32."],
            "32.", explanationLatex: @"32")
        .Numeric("5 · 3^2 = ?", "45",
            ["3^2 = 9; 5 times 9 = 45."],
            "45.", explanationLatex: @"45")
        .Numeric("100(1.1)^2 = ?", "121",
            ["1.1^2 = 1.21.", "100 times 1.21 = 121."],
            "121.", explanationLatex: @"121")
        .Numeric("80(0.5)^3 = ?", "10",
            ["(0.5)^3 = 0.125 = 1/8.", "80 / 8 = 10."],
            "10.", explanationLatex: @"10")
        .Mcq("y = 2 · (1/3)^x is:",
            ["Growth", "Decay", "Linear", "Quadratic"], 1,
            ["Base 1/3 is between 0 and 1."],
            "Exponential decay.")
        .Numeric("f(0) for f(x) = 7 · 5^x ?", "7",
            ["5^0 = 1, so f(0) = 7 · 1 = 7."],
            "f(0) = 7 (initial value).", explanationLatex: @"7")
        .Numeric("Population 1000 grows 5% in one year. New population?", "1050",
            ["Multiply by 1.05.", "1000 times 1.05 = 1050."],
            "1050.", explanationLatex: @"1050")
        .Numeric("2000 decays 10% once. Amount left?", "1800",
            ["Multiply by 0.9.", "2000 times 0.9 = 1800."],
            "1800.", explanationLatex: @"1800")
        .Takeaways(
            "Exponential: multiply by a constant factor each step; linear: add a constant amount.",
            "y = a b^x with a initial, b > 1 growth, 0 < b < 1 decay.",
            "Percent models use y = a(1 +/- r)^t with r as a decimal.",
            "Graphs pass through (0, a), stay positive when a > 0, and approach y = 0 as an asymptote.",
            "Match the story: fixed add vs fixed percent of current amount chooses the model family.")
        .Build();

    private static Lesson Logarithms() => new LessonBuilder("fn-logarithms", CategoryId, "Logarithms, Properties, Solving Exp/Log Equations")
        .Subtitle("Logs ask the exponent question, and log rules turn products into sums")
        .Order(4).Minutes("36 min")
        .Visual(VisualKind.LogGraph, "The log curve is the exponential reflected across y = x; argument must stay positive.")
        .Section("What a logarithm is really asking",
            "The equation log_b(a) = c means \"b raised to what power equals a?\" In symbols:\n\nlog_b(a) = c  if and only if  b^c = a,\n\nwith a > 0, b > 0, and b != 1.\n\nSo logarithms undo exponentials the way subtraction undoes addition. If 2^5 = 32, then log_2(32) = 5. Common log is log_10 (often written log). Natural log is ln = log_e with e about 2.71828.\n\nWhy invent a new symbol? Because solving b^x = a for x is the inverse problem of computing powers, and inverse functions deserve their own name and graph (log is the reflection of the exponential across y = x).",
            @"\log_b a=c \Leftrightarrow b^c=a",
            simple: "log_b(a) means: what exponent on b gives a? Logs answer the \"what power?\" question.",
            prior: "Integer and simple rational exponents; exponential equations like 2^x = 8. Function inverse idea is helpful but can be learned side by side.")
        .Section("Domain of a log: why the argument must be positive",
            "For real logs, the input (argument) must be positive: you cannot write log_b(0) or log_b(of a negative). Why? b^c is always positive for allowed bases, so it can never equal 0 or a negative number. The range of log_b is all real numbers; exponents can be any real.\n\nGraph: vertical asymptote at x = 0 for y = log_b(x), slow growth through (1, 0) because b^0 = 1 so log_b(1) = 0, and through (b, 1) because b^1 = b. As x approaches 0 from the right, the log goes to -infinity; as x grows, the log grows without bound, but slowly.",
            simple: "Only positive numbers have real logs. log of 1 is always 0; log_b(b) = 1.",
            prior: "Exponential outputs are positive for standard bases; that forces log domain (0, infinity).")
        .Section("Log properties: structure, not magic",
            "The big three (same base throughout):\n• Product: log_b(mn) = log_b(m) + log_b(n)\n• Quotient: log_b(m/n) = log_b(m) - log_b(n)\n• Power: log_b(m^k) = k log_b(m)\n\nWhy they work: they mirror exponent laws. If m = b^p and n = b^q, then mn = b^{p+q}, so the log of a product is the sum of exponents p + q.\n\nChange of base: log_b(a) = log_k(a) / log_k(b) for any valid k (often k = 10 or e). That is how calculators compute odd bases.\n\nCritical false belief: log(m + n) is not log m + log n.",
            @"\log_b(mn)=\log_b m+\log_b n",
            simple: "Products become sum of logs. Quotients become subtract logs. Exponents on the inside come out front as multipliers.",
            prior: "Exponent rules: b^p · b^q = b^{p+q}, (b^p)^k = b^{pk}. Logs translate those rules into addition and multiplication.")
        .Section("Solving log equations",
            "Core strategy: rewrite a log equation as exponential. log_b(x) = c means x = b^c. If you have log_b(expression) = c, set expression = b^c, then solve, and check that every argument stays positive.\n\nIf log_b(A) = log_b(B) with valid base, then A = B (one-to-one property), still check domain. Combining logs with product/quotient rules can reduce multiple logs to one before converting to exponential form.",
            simple: "Log equation to exponential form. Check that every log argument is positive.",
            prior: "Definition of log and solving basic polynomial or linear equations after the rewrite.")
        .Section("Solving exponential equations with logs",
            "When b^x = a and a is not an obvious power of b, take logs: x = log_b(a), or x = ln(a)/ln(b) by change of base. If both sides share the same base already, equate exponents: b^u = b^v implies u = v.\n\nAlso use inverse cancellation: log_b(b^x) = x and b^{log_b(x)} = x (for x > 0). Always check candidates in the original equation when algebra might introduce extraneous results (especially after expanding logs of expressions).",
            simple: "Exponential equation: take log, or match bases and equate exponents. Check domain and originals.",
            prior: "Exponential lesson (bases and simple powers) plus the definition of log.")
        .Section("Graph and inverse relationship with exponentials",
            "y = log_b(x) and y = b^x are inverse functions (for valid b). Their graphs reflect across the line y = x. Exponential through (0, 1) and (1, b) corresponds to log through (1, 0) and (b, 1). Horizontal asymptote y = 0 for the exponential becomes vertical asymptote x = 0 for the log.\n\nThis picture explains why logs grow slowly and why their domain is only positive x.",
            simple: "Log and exponential undo each other; graphs flip over y = x.",
            prior: "Inverse functions idea: swap inputs and outputs, reflect across y = x.")
        .Section("Connecting to applications",
            "Decibels, pH, Richter scale, and some compound-interest solve-for-time problems use logs because they undo exponential scaling. When a model says amount = a(1+r)^t and you need t, take logs of both sides. The algebra is the same definition you practiced on log_2(8) = 3, just with messier numbers.")
        .Formula("Definition", @"\log_b a=c \Leftrightarrow b^c=a", "Log to exponential translation.")
        .Formula("Product rule", @"\log_b(mn)=\log_b m+\log_b n", "Products become sums.")
        .Formula("Power rule", @"\log_b(m^k)=k\log_b m", "Exponents factor out of logs.")
        .Formula("Change of base", @"\log_b a=\frac{\log_k a}{\log_k b}", "Compute with any convenient base k.")
        .Example("Evaluate a log by definition",
            "Find log_2(8).",
            [
                "Ask: 2 to what power equals 8?",
                "2^3 = 8, so the exponent is 3.",
                "Therefore log_2(8) = 3.",
                "Check with inverse: 2^{log_2(8)} should be 8, and 2^3 = 8.",
                "Common mistake callout: writing 8/2 = 4, treating log as division."
            ],
            "log_2(8) = 3.",
            problemLatex: @"\log_2 8",
            solutionLatex: @"3",
            stepLatex: [null, @"2^3=8", @"\log_2 8=3", null, null])
        .Example("Solve a basic log equation",
            "Solve log_3(x) = 4 for x.",
            [
                "Translate to exponential form: x = 3^4.",
                "3^4 = 81.",
                "Check domain: x = 81 > 0, valid.",
                "Check: log_3(81) = 4 because 3^4 = 81.",
                "Common mistake callout: writing x = 3 · 4 = 12, or x = 4^3."
            ],
            "x = 81.",
            problemLatex: @"\log_3 x=4",
            solutionLatex: @"x=81",
            stepLatex: [@"x=3^4", @"x=81", null, null, null])
        .Example("Solve an exponential by inspection or log",
            "Solve 5^x = 25.",
            [
                "Notice 25 = 5^2, so 5^x = 5^2.",
                "Same bases mean exponents equal: x = 2.",
                "Using logs: x = log_5(25) = 2, same answer.",
                "For numbers that are not nice powers, leave x = log_b(a) or use change of base on a calculator.",
                "Common mistake callout: dividing 25 by 5 to get x = 5."
            ],
            "x = 2.",
            problemLatex: @"5^x=25",
            solutionLatex: @"x=2",
            stepLatex: [@"25=5^2", @"x=2", null, null, null])
        .Example("Combine logs with the product rule",
            "Simplify log_10(2) + log_10(50), then evaluate.",
            [
                "Product rule: log 2 + log 50 = log(2 · 50) = log(100).",
                "log_10(100) = 2 because 10^2 = 100.",
                "So the sum is exactly 2 without needing decimal approximations of each log.",
                "This is why log tables and mental strategies work: products become sums of easier pieces.",
                "Common mistake callout: writing log 2 + log 50 = log(52), adding insides."
            ],
            "The expression equals 2.",
            problemLatex: @"\log_{10}2+\log_{10}50",
            solutionLatex: @"2",
            stepLatex: [@"\log(100)", @"10^2=100", @"2", null, null])
        .Mistake("Writing log(a + b) = log a + log b (false; only products split into sums).")
        .Mistake("Allowing log of zero or a negative number in the reals.")
        .Mistake("Canceling logs incorrectly when bases differ or without checking domain of arguments.")
        .Mistake("Confusing log_b(a) with a/b or b/a (logs are exponents, not quotients).")
        .Mistake("Forgetting to check that solutions keep every log argument positive.")
        .Numeric("log_10(1000) = ?", "3",
            ["10^3 = 1000.", "So the log is 3."],
            "3.", explanationLatex: @"3")
        .Numeric("log_2(16) = ?", "4",
            ["2^4 = 16."],
            "4.", explanationLatex: @"4")
        .Numeric("log_3(1) = ?", "0",
            ["Any valid base to the 0 power is 1.", "log_b(1) = 0."],
            "0.", explanationLatex: @"0")
        .Numeric("If log_5(x) = 2, x = ?", "25",
            ["x = 5^2 = 25."],
            "x = 25.", explanationLatex: @"25")
        .Numeric("Solve 2^x = 32. x = ?", "5",
            ["2^5 = 32.", "x = 5."],
            "x = 5.", explanationLatex: @"5")
        .Mcq("log(ab) equals:",
            ["log a · log b", "log a + log b", "log a - log b", "a log b"], 1,
            ["Product rule for logarithms."],
            "log a + log b.")
        .Numeric("ln(e^4) = ?", "4",
            ["ln and e^x are inverses.", "ln(e^4) = 4."],
            "4.", explanationLatex: @"4")
        .Numeric("log_2(8) + log_2(4) = ?", "5",
            ["log_2(8·4) = log_2(32), or 3 + 2.", "5."],
            "5.", explanationLatex: @"5")
        .Takeaways(
            "log_b(a) = c means b^c = a; logs answer \"what exponent?\"",
            "Real logs require positive arguments; log_b(1) = 0 and log_b(b) = 1.",
            "Product, quotient, and power rules mirror exponent laws (not for sums inside).",
            "Log equation: rewrite as exponential. Exponential equation: take log or equate exponents.",
            "Always check domain: every log argument must stay positive.")
        .Build();
}
