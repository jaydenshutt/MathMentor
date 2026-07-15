using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class PreAlgebraLessons
{
    public const string CategoryId = "prealgebra";

    public static Category Build()
    {
        var lessons = new[]
        {
            Variables(),
            Equations(),
            Inequalities(),
            Ratios(),
            ExponentsRoots()
        };
        return new Category(CategoryId, "Pre-Algebra",
            "Variables, equations, inequalities, ratios, and powers, the bridge to algebra.",
            "\uE8EF", 4, lessons);
    }

    private static Lesson Variables() => new LessonBuilder("pre-variables", CategoryId, "Variables, Expressions & Substitution")
        .Subtitle("Letters stand for numbers; expressions wait to be evaluated, and that is the doorway to algebra")
        .Order(1).Minutes("30 min")
        .Section("Why variables exist (and why they are not “unknowns only”)",
            "Arithmetic works with fixed numbers: 3 + 5 is always 8. Life, science, and design often need a pattern that can change. How much do 4 tickets cost? What about 7? What about n?\n\nA variable is a symbol, usually a letter like x, n, or t, that stands for a number that can take different values. The letter is not “mystery poetry.” It is a placeholder in a recipe: same structure, different inputs. That is why algebra can describe “any number of tickets” instead of one special case at a time.\n\nImportant mindset shift: a variable is not always something you must solve for. In an expression, it is often just a slot waiting for a value. In an equation, it is a value that must make a statement true. Same letter idea; different job.")
        .Section("Expressions vs equations: recipes vs true/false statements",
            "An algebraic expression is a mathematical phrase with numbers, variables, and operations, for example 3x + 7 or 2a − b. It does not claim that anything equals anything. You can evaluate it when you know the values, or simplify it, but you do not “solve” an expression the way you solve an equation.\n\nAn equation uses an equals sign to assert two expressions are the same value: 3x + 7 = 19. Equations can be true or false depending on x. That true/false nature is what makes solving meaningful.\n\nIf you mix these up, you will try to “solve” 2x + 1 as if it had an answer, or treat x + 3 = 7 as if it were just a string of symbols with no claim.",
            simple: "Expression = a recipe with blanks. Equation = a claim that two recipes give the same result. Only claims can be true or false.",
            prior: "You already evaluate arithmetic like 2(5)+3. Algebra adds letters into those same operations and order rules (PEMDAS).")
        .Section("Substitution: replace, then compute carefully",
            "To evaluate an expression, replace every occurrence of each variable with the given number, then compute using order of operations. Parentheses help: 3x when x = 4 is 3(4), not 34.\n\nWatch signs and powers. (−2)² is 4, but −2² is usually read as −(2²) = −4 in school order-of-operations conventions. When a value is negative, use parentheses on purpose: 2x with x = −5 becomes 2(−5) = −10.\n\nSubstitution is the bridge between “abstract letter” and “concrete number.” If you can substitute reliably, every later algebra check becomes possible.",
            @"E(x)|_{x=a}\;\text{means replace }x\text{ with }a")
        .Section("Terms, coefficients, and like terms",
            "A term is a product of a number and variables (and powers of variables), or a standalone constant. In 4x² − 3x + 7, the terms are 4x², −3x, and 7. The coefficient is the numerical factor of a term: 4 is the coefficient of x²; −3 is the coefficient of x. A constant term has no variable part.\n\nLike terms share the same variable part with the same exponents. 2x and 5x are like terms; 2x and 2x² are not; 3xy and 7yx are like terms (multiplication is commutative). You may only combine like terms: 2x + 5x = 7x, but 2x + 3 stays 2x + 3.\n\nWhy this rule? Because 2x means “two groups of x” and 5x means “five groups of x,” so together they are seven groups of x. You cannot merge “groups of x” with “groups of x²” any more than you can add 2 apples and 3 oranges into 5 “apple-oranges.”",
            simple: "Like terms are matching labels. Add or subtract the numbers in front; keep the label. Different labels stay separate.")
        .Section("Simplifying expressions: clean up without changing value",
            "Simplifying means rewriting an expression so it is shorter or clearer while always representing the same value for every allowed input. Combine like terms. Use the distributive property: a(b + c) = ab + ac. Drop unnecessary parentheses after distributing.\n\nExample of the mindset: 4x + 3 − x + 7 is not “done.” Group variable terms and constant terms: (4x − x) + (3 + 7) = 3x + 10. You have not solved for x; you have made the expression easier to evaluate later.\n\nDistributing is the reverse of factoring out a common factor. Both skills reappear constantly in algebra, so treat them as vocabulary you will reuse, not one-off tricks.")
        .Section("Why order of operations still rules everything",
            "Variables do not invent new operation order. PEMDAS (or your local equivalent) still decides: grouping symbols, then exponents, then multiply/divide left to right, then add/subtract left to right.\n\nThe classic trap is treating 3x as 3 + x, or computing 2 + 3x when x = 4 as (2 + 3)·4. Correct: 2 + 3(4) = 2 + 12 = 14. Another trap: “distributing” addition into exponents incorrectly. Keep the structure of the expression; only replace letters with numbers when evaluating.")
        .Section("Reading expressions in words and in the world",
            "Translating language is part of pre-algebra fluency. “Five more than a number” is n + 5. “Three times a number decreased by 2” is 3n − 2. “The product of 4 and a number” is 4n. Perimeter of a rectangle is often 2l + 2w, an expression in two variables.\n\nWhen two variables appear, substitute both before computing. Order does not magically pair them; each letter has its own value. If a = 5 and b = 4, then 3a − 2b = 3(5) − 2(4) = 15 − 8 = 7.",
            prior: "Word problems in arithmetic already asked you to choose operations from language. Now the unknown amount is named with a letter instead of a blank.")
        .Formula("Substitution", @"E(x)|_{x=a}=\text{replace }x\text{ with }a", "Evaluation fills every slot, then uses ordinary arithmetic.")
        .Formula("Like terms", @"cx+dx=(c+d)x", "Add coefficients only when the variable parts match exactly.")
        .Formula("Distributive property", @"a(b+c)=ab+ac", "Multiply every term inside the parentheses by a.")
        .Example("Evaluate with one variable (tutor walkthrough)",
            "Evaluate 2x + 5 when x = 7.",
            [
                "Read the structure first: twice a number, then add 5. The letter is not decoration, it will become 7.",
                "Replace x with 7. Prefer parentheses so multiplication is obvious: 2(7) + 5.",
                "Multiply first: 2 · 7 = 14. Then add: 14 + 5 = 19.",
                "Quick check: if x were 0, the expression would be 5. At x = 7 it should be noticeably larger, 19 is plausible, not wild."
            ],
            "The value of 2x + 5 at x = 7 is 19.",
            problemLatex: @"2x+5,\; x=7",
            solutionLatex: @"19",
            stepLatex: [null, @"2(7)+5", @"14+5=19", null])
        .Example("Two variables, careful signs",
            "Evaluate 3a − 2b when a = 5 and b = 4.",
            [
                "Two independent slots: a becomes 5, b becomes 4. Do not swap them.",
                "Write 3(5) − 2(4). Both multiplications happen before subtraction.",
                "3 · 5 = 15 and 2 · 4 = 8, so the expression becomes 15 − 8.",
                "15 − 8 = 7. Common error: computing 3 · 5 − 2 = 13, then ignoring b, or writing 3a − 2b as 3(a − 2b)."
            ],
            "3a − 2b equals 7 when a = 5 and b = 4.",
            problemLatex: @"3a-2b,\; a=5,\; b=4",
            solutionLatex: @"7",
            stepLatex: [null, @"3(5)-2(4)", @"15-8", @"7"])
        .Example("Exponents in evaluation",
            "Evaluate x² − 3x when x = 4.",
            [
                "x² means (x)(x), not 2x. At x = 4, x² = 16.",
                "3x means 3 times x: 3 · 4 = 12.",
                "Now combine: 16 − 12 = 4. Order: powers and multiplications before subtraction.",
                "Wrong path to avoid: “x² − 3x = x(x − 3) is fine to notice, but then 4(4 − 3) = 4 still works, the danger is writing x² as 2x and getting 8 − 12 = −4.”"
            ],
            "At x = 4, the expression equals 4.",
            problemLatex: @"x^2-3x,\; x=4",
            solutionLatex: @"4",
            stepLatex: [@"x^2=16", @"3x=12", @"16-12=4", null])
        .Example("Simplify first, then (optionally) evaluate",
            "Simplify 4x + 3 − x + 7.",
            [
                "Identify like terms: 4x and −x are variable terms; 3 and 7 are constants.",
                "Combine variables: 4x − x = 3x. (Think 4 groups of x minus 1 group of x.)",
                "Combine constants: 3 + 7 = 10.",
                "Simplified form: 3x + 10. You did not find a single number for x, you cleaned the expression so future substitution is easier."
            ],
            "4x + 3 − x + 7 simplifies to 3x + 10.",
            problemLatex: @"4x+3-x+7",
            solutionLatex: @"3x+10",
            stepLatex: [null, @"4x-x=3x", @"3+7=10", @"3x+10"])
        .Mistake("Writing 3x as 3 + x when substituting (juxtaposition means multiplication, not addition).")
        .Mistake("Combining unlike terms, e.g. rewriting 2x + 3 as 5x.")
        .Mistake("Evaluating 2 + 3x at x = 4 as (2 + 3) · 4 instead of 2 + 12.")
        .Mistake("Treating x² as 2x (confusing exponent with coefficient).")
        .Numeric("Evaluate 5x − 2 when x = 3.", "13",
            ["Replace x with 3: 5(3) − 2.", "Multiply first, then subtract."],
            "5(3) − 2 = 15 − 2 = 13.",
            explanationLatex: @"5(3)-2=13")
        .Numeric("Evaluate 2a + b when a = 4 and b = 5.", "13",
            ["2(4) + 5.", "8 + 5."],
            "2(4) + 5 = 8 + 5 = 13.",
            explanationLatex: @"2(4)+5=13")
        .Numeric("Evaluate x² when x = 6.", "36",
            ["x² means x times x.", "6 · 6."],
            "6² = 36.",
            explanationLatex: @"6^2=36")
        .Mcq("Simplify 7y − 2y + 4:",
            ["5y + 4", "9y + 4", "5y", "7y − 2y4"], 0,
            ["Combine like terms 7y and −2y first.", "Constants stay: +4."],
            "7y − 2y = 5y, so the simplified form is 5y + 4.")
        .Numeric("If perimeter = 2l + 2w with l = 8 and w = 3, find the perimeter.", "22",
            ["2(8) + 2(3).", "16 + 6."],
            "2(8) + 2(3) = 16 + 6 = 22.",
            explanationLatex: @"2(8)+2(3)=22")
        .Numeric("Evaluate 10 − 3x when x = 2.", "4",
            ["3x = 6.", "10 − 6."],
            "10 − 3(2) = 10 − 6 = 4.",
            explanationLatex: @"10-3(2)=4")
        .Mcq("Which is an expression (not an equation)?",
            ["x + 3 = 7", "2x + 1", "x = 5", "3 = 3"], 1,
            ["An equation has an equals sign claiming two sides match.", "An expression is a phrase without that claim."],
            "2x + 1 has no equals sign, so it is an expression.")
        .Numeric("Evaluate −2x + 9 when x = 4.", "1",
            ["−2(4) = −8.", "−8 + 9."],
            "−2(4) + 9 = −8 + 9 = 1.",
            explanationLatex: @"-2(4)+9=1")
        .Build();

    private static Lesson Equations() => new LessonBuilder("pre-equations", CategoryId, "Solving One- and Two-Step Equations")
        .Subtitle("Undo operations to isolate the variable, and always check that your answer works")
        .Order(2).Minutes("32 min")
        .Section("Why equations are different from expressions",
            "An equation is a balance statement: left side equals right side. The variable is not a free placeholder you merely evaluate; it is a value (or values) that make the statement true.\n\nSolving means finding those values. Guess-and-check can work for tiny problems, but inverse operations scale to harder equations. The big idea is conservation of equality: if two quantities are equal, and you treat both sides the same way, they stay equal.")
        .Section("The balance model: do the same thing to both sides",
            "Picture a balanced scale. If you add 3 grams to the left pan only, the scale tips. If you add 3 grams to both pans, balance is preserved. Subtraction, multiplication, and division (by a nonzero number) work the same way.\n\nThat is why “subtract 5 from both sides” is not a magic spell, it is the fair move that keeps truth intact while making the equation simpler. Every legal solving step is a fair move on both sides.",
            simple: "Whatever you do to one side, do the same to the other. Fair moves keep a true equation true (and a false one false).",
            prior: "You already know inverse pairs from arithmetic: add/subtract and multiply/divide undo each other. Equations just aim those undos at isolating a letter.")
        .Section("One-step equations: one undo",
            "If the equation has a single operation applied to the variable, undo that one operation.\n\n• x + 5 = 12 → subtract 5 from both sides → x = 7\n• x − 4 = 9 → add 4 → x = 13\n• 5x = 45 → divide by 5 → x = 9\n• x/3 = 9 → multiply by 3 → x = 27\n\nAsk: “What is happening to x?” Then apply the inverse. The goal is a line that looks like x = (a number).",
            @"x+a=b\;\Rightarrow\; x=b-a")
        .Section("Two-step equations: peel the onion from the outside",
            "Most school two-step equations look like ax + b = c or (x/a) + b = c. The usual efficient order is: undo addition/subtraction first, then undo multiplication/division. That peels the outer layer (the constant added or subtracted) before undoing the coefficient.\n\nExample: 2x + 3 = 11.\n1) Subtract 3 from both sides: 2x = 8.\n2) Divide both sides by 2: x = 4.\n\nWhy not divide by 2 first? You could, but then you must divide every term carefully: (2x)/2 + 3/2 = 11/2, which introduces fractions earlier. Undoing ± first often keeps integers longer. Both approaches are valid if done fairly to both sides.",
            @"2x+3=11\;\Rightarrow\; x=4",
            simple: "First cancel the add/subtract sitting next to the variable term. Then cancel the multiply/divide attached to the variable.")
        .Section("Fraction coefficients and “clearing” carefully",
            "If the coefficient is a fraction, multiplying by the reciprocal is often cleanest. For (1/2)x + 3 = 7: subtract 3 to get (1/2)x = 4, then multiply both sides by 2 to get x = 8.\n\nYou may also multiply both sides of the original equation by a common denominator to clear fractions early. That is a fair move too, just multiply every term, not only the fraction term.")
        .Section("Check your solution (the step students skip)",
            "Substitute your answer into the original equation. Both sides should match exactly. Checking catches arithmetic slips and “moved a term the wrong way” errors.\n\nIf 3x − 4 = 11 and you got x = 5: left side is 3(5) − 4 = 15 − 4 = 11, which equals the right side. Confidence earned. If it fails, the algebra somewhere was unfair or the arithmetic was wrong, go back.",
            prior: "Substitution skills from the previous lesson are exactly the checking tool for this lesson.")
        .Section("What “isolate the variable” really means",
            "Isolation means the variable stands alone on one side with coefficient 1 (or is written as x = …). You are not inventing a value; you are revealing the value that was already determined by the equation’s structure.\n\nAlso remember: dividing by zero is never allowed. If a step would require dividing by zero, something is wrong with the setup. Multiplying or dividing both sides by a negative number is allowed for equations (the equals sign does not flip, that rule is special to inequalities).")
        .Formula("Addition/subtraction inverses", @"x+a=b\;\Rightarrow\; x=b-a", "Add or subtract the same number on both sides.")
        .Formula("Multiplication/division inverses", @"kx=b\;\Rightarrow\; x=\frac{b}{k}\;(k\neq 0)", "Divide (or multiply by the reciprocal) on both sides.")
        .Formula("Two-step pattern", @"ax+b=c\;\Rightarrow\; x=\frac{c-b}{a}\;(a\neq 0)", "Undo b first, then divide by a.")
        .Example("One-step addition",
            "Solve x + 9 = 20.",
            [
                "Diagnose: 9 is added to x. Inverse of adding 9 is subtracting 9.",
                "Subtract 9 from both sides: x + 9 − 9 = 20 − 9.",
                "Simplify: x = 11.",
                "Check: 11 + 9 = 20. True, so x = 11 is the solution."
            ],
            "x = 11.",
            problemLatex: @"x+9=20",
            solutionLatex: @"x=11",
            stepLatex: [null, @"x+9-9=20-9", @"x=11", @"11+9=20"])
        .Example("One-step multiplication",
            "Solve 5x = 45.",
            [
                "Diagnose: x is multiplied by 5. Inverse is divide by 5.",
                "Divide both sides by 5: (5x)/5 = 45/5.",
                "x = 9.",
                "Check: 5 · 9 = 45. Good."
            ],
            "x = 9.",
            problemLatex: @"5x=45",
            solutionLatex: @"x=9",
            stepLatex: [null, @"\frac{5x}{5}=\frac{45}{5}", @"x=9", null])
        .Example("Two-step classic",
            "Solve 3x − 4 = 11.",
            [
                "Structure: x is multiplied by 3, then 4 is subtracted. Peel the outer −4 first.",
                "Add 4 to both sides: 3x − 4 + 4 = 11 + 4 → 3x = 15.",
                "Divide both sides by 3: x = 5.",
                "Check in the original: 3(5) − 4 = 15 − 4 = 11. Perfect match."
            ],
            "x = 5.",
            problemLatex: @"3x-4=11",
            solutionLatex: @"x=5",
            stepLatex: [null, @"3x=15", @"x=5", @"3(5)-4=11"])
        .Example("Fraction coefficient",
            "Solve (1/2)x + 3 = 7.",
            [
                "Subtract 3 from both sides to clear the added constant: (1/2)x = 4.",
                "Multiply both sides by 2 (the reciprocal of 1/2): x = 8.",
                "Alternative view: (1/2)x means “half of x,” so half of x is 4, and x is 8.",
                "Check: (1/2)(8) + 3 = 4 + 3 = 7. True."
            ],
            "x = 8.",
            problemLatex: @"\frac{1}{2}x+3=7",
            solutionLatex: @"x=8",
            stepLatex: [@"\frac{1}{2}x=4", @"x=8", null, @"\frac{1}{2}(8)+3=7"])
        .Mistake("Doing an operation to only one side of the equation (breaking the balance).")
        .Mistake("Dividing only one term on a side (e.g. from 2x + 4 = 10, writing x + 4 = 5).")
        .Mistake("Undoing operations in a sloppy order and then mishandling every term.")
        .Mistake("Forgetting to substitute back into the original equation to check.")
        .Numeric("Solve x + 12 = 30. What is x?", "18",
            ["Subtract 12 from both sides.", "30 − 12."],
            "x = 18 because 18 + 12 = 30.",
            explanationLatex: @"x=18")
        .Numeric("Solve 4x = 28. What is x?", "7",
            ["Divide both sides by 4.", "28 ÷ 4."],
            "x = 7 because 4 · 7 = 28.",
            explanationLatex: @"x=7")
        .Numeric("Solve 2x + 5 = 17. What is x?", "6",
            ["Subtract 5: 2x = 12.", "Divide by 2."],
            "2x + 5 = 17 → 2x = 12 → x = 6.",
            explanationLatex: @"x=6")
        .Numeric("Solve 5x − 3 = 22. What is x?", "5",
            ["Add 3: 5x = 25.", "Divide by 5."],
            "5x − 3 = 22 → 5x = 25 → x = 5.",
            explanationLatex: @"x=5")
        .Mcq("First step for 4x + 7 = 19:",
            ["Divide by 4", "Subtract 7", "Add 4x", "Multiply by 7"], 1,
            ["Undo the addition/subtraction attached outside the variable term first.", "Subtract 7 from both sides to get 4x = 12."],
            "Subtract 7 from both sides; then divide by 4.")
        .Numeric("Solve x/3 = 9. What is x?", "27",
            ["Multiply both sides by 3.", "9 · 3."],
            "x = 27 because 27/3 = 9.",
            explanationLatex: @"x=27")
        .Numeric("Solve 6x + 2 = 20. What is x?", "3",
            ["Subtract 2: 6x = 18.", "Divide by 6."],
            "6x + 2 = 20 → 6x = 18 → x = 3.",
            explanationLatex: @"x=3")
        .Numeric("Solve (1/3)x − 2 = 4. What is x?", "18",
            ["Add 2: (1/3)x = 6.", "Multiply by 3."],
            "(1/3)x − 2 = 4 → (1/3)x = 6 → x = 18.",
            explanationLatex: @"x=18")
        .Build();

    private static Lesson Inequalities() => new LessonBuilder("pre-inequalities", CategoryId, "Inequalities & Number Line Representation")
        .Subtitle("Greater, less, and the one critical flip when you multiply or divide by a negative")
        .Order(3).Minutes("30 min")
        .Section("Why inequalities matter more than single answers",
            "Equations often have one solution. Real constraints usually allow a range: “You need at least $20,” “Speed limit is at most 65,” “Temperature below 32°F means freezing.” Those are inequalities.\n\nAn inequality solution set is often infinite. That is not a problem, it is the point. Your job is to describe all numbers that work, not just one example that works.")
        .Section("The four relations and what they claim",
            "• x < 3: x is strictly less than 3 (3 itself fails).\n• x ≤ 3: x is less than or equal to 3 (3 works).\n• x > 3: x is strictly greater than 3.\n• x ≥ 3: x is greater than or equal to 3.\n\nReading direction matters. 5 > x means the same as x < 5. Always rewrite so the variable is on the left when you want standard “x is …” language, but only by flipping the inequality if you reverse the sides (because “greater than” becomes “less than” when the order of comparison reverses).",
            simple: "Open ideas (<, >) exclude the boundary. Closed ideas (≤, ≥) include it. Think “open door / closed door” on the number line.",
            prior: "You already compare numbers. Inequalities name a whole region of the number line that passes a comparison test.")
        .Section("Solving inequalities like equations, almost",
            "You may add or subtract the same number on both sides without changing the inequality direction. You may multiply or divide both sides by a positive number without flipping.\n\nExample: 2x − 1 ≥ 7 → add 1 → 2x ≥ 8 → divide by 2 → x ≥ 4.\n\nThe process mirrors equation solving because the balance idea is similar: fair operations preserve the truth of the comparison when the scale factor is positive.",
            @"2x-1\ge 7\;\Rightarrow\; x\ge 4")
        .Section("The flip rule: why negatives reverse the inequality",
            "Multiplying or dividing both sides by a negative number reverses the inequality sign. Why? Compare 3 < 5. Multiply both by −1: −3 and −5. Now −3 > −5, not −3 < −5. The numbers swapped order on the number line because multiplying by −1 reflects through zero.\n\nSo −2x > 6 → divide by −2 and flip → x < −3.\n\nForgetting the flip is the #1 inequality error in pre-algebra. When you see a negative coefficient on x, slow down on purpose.",
            @"k<0,\; kx>a\;\Rightarrow\; x<\frac{a}{k}",
            simple: "Negative multiply/divide = mirror reverse. The inequality arrow flips so the statement stays true.")
        .Section("Graphing on a number line",
            "Number lines make infinite solution sets visible.\n• Use an open circle at the boundary for < or > (boundary not included).\n• Use a closed (filled) circle for ≤ or ≥ (boundary included).\n• Shade left for “less” directions, right for “greater” directions (on the standard number line).\n\nFor x < 6: open circle at 6, shade left. For x ≥ 4: closed circle at 4, shade right. Always mark a few test points in your head: pick a number in the shaded region and check the original inequality.")
        .Section("Checking and compound sense-making",
            "To verify, pick a sample from your solution set and one outside it. For x < −4 after solving −3x > 12, try x = −5: −3(−5) = 15 > 12 true; try x = 0: 0 > 12 false. Samples confirm both the flip and the shading direction.\n\nAlso practice reading inequalities written “backwards”: 5 > x is x < 5. Students who only memorize “arrow points to the smaller” sometimes get confused when the variable is on the right, rewrite with x on the left.",
            prior: "Checking inequalities reuses substitution. The new skill is describing a set, not a single number.")
        .Section("Boundary values: included or not?",
            "The boundary is the number that would solve the related equation. For 3x + 6 < 15, the boundary equation 3x + 6 = 15 gives x = 3. Because the inequality is strict (<), x = 3 is not a solution: 3(3) + 6 = 15, which is not less than 15. So the solution is x < 3 with an open circle.\n\nThat “related equation” idea connects inequalities back to equation solving.")
        .Formula("Flip rule", @"k<0,\; kx>a\;\Rightarrow\; x<\frac{a}{k}", "Multiply or divide by a negative → reverse the inequality.")
        .Formula("Add/subtract invariance", @"x<a\;\Rightarrow\; x+c<a+c", "Adding or subtracting the same value never flips the sign.")
        .Formula("Positive scale", @"c>0,\; x<a\;\Rightarrow\; cx<ca", "Positive multiply/divide preserves direction.")
        .Example("Simple one-step inequality",
            "Solve x + 4 < 10 and describe the graph.",
            [
                "Subtract 4 from both sides (no flip for add/subtract): x < 6.",
                "Boundary is 6; inequality is strict, so 6 itself is not included.",
                "Graph: open circle at 6, shade to the left (smaller numbers).",
                "Check: x = 5 → 5 + 4 = 9 < 10 true; x = 6 → 10 < 10 false."
            ],
            "Solution: x < 6.",
            problemLatex: @"x+4<10",
            solutionLatex: @"x<6",
            stepLatex: [@"x<6", null, null, null])
        .Example("Two-step inequality",
            "Solve 2x − 1 ≥ 7.",
            [
                "Add 1 to both sides: 2x ≥ 8.",
                "Divide by positive 2 (no flip): x ≥ 4.",
                "Graph: closed circle at 4 (equals allowed), shade right.",
                "Check boundary: 2(4) − 1 = 7 ≥ 7 true. Check left of 4: x = 3 → 5 ≥ 7 false."
            ],
            "Solution: x ≥ 4.",
            problemLatex: @"2x-1\ge 7",
            solutionLatex: @"x\ge 4",
            stepLatex: [@"2x\ge 8", @"x\ge 4", null, null])
        .Example("Negative coefficient, flip required",
            "Solve −3x > 12.",
            [
                "x is multiplied by −3. To isolate x, divide both sides by −3.",
                "Because −3 is negative, flip the inequality: x < 12/(−3).",
                "x < −4.",
                "Sanity check with a point: x = −5 → −3(−5) = 15 > 12 true. If you forgot to flip (x > −4), x = 0 would be “allowed” but −3(0) = 0 is not > 12."
            ],
            "Solution: x < −4.",
            problemLatex: @"-3x>12",
            solutionLatex: @"x<-4",
            stepLatex: [null, @"x<\frac{12}{-3}", @"x<-4", null])
        .Example("Is a value a solution?",
            "Is x = 0 a solution of 5 − x ≥ 2?",
            [
                "Substitute carefully: 5 − 0 = 5.",
                "Is 5 ≥ 2? Yes.",
                "So x = 0 works. (For practice: solve fully, subtract 5: −x ≥ −3; multiply by −1 and flip: x ≤ 3. Zero is in that set.)",
                "This problem trains checking without needing the full solution set first."
            ],
            "Yes, x = 0 satisfies 5 − x ≥ 2.",
            problemLatex: @"5-x\ge 2",
            solutionLatex: @"\text{yes}")
        .Mistake("Forgetting to flip the inequality when multiplying or dividing by a negative number.")
        .Mistake("Using a closed circle for strict inequalities (< or >).")
        .Mistake("Shading the wrong direction after a correct boundary value.")
        .Mistake("Treating 5 > x as x > 5 instead of x < 5.")
        .Numeric("Solve x − 5 > 3. What is the critical boundary value?", "8",
            ["Add 5: x > 8.", "The boundary is the related equation value."],
            "x > 8, so the critical boundary is 8 (not included).",
            explanationLatex: @"x>8")
        .Numeric("Solve 4x ≤ 20. What is the largest integer solution?", "5",
            ["Divide by 4: x ≤ 5.", "Largest integer ≤ 5 is 5."],
            "x ≤ 5; the largest integer solution is 5.",
            explanationLatex: @"x\le 5")
        .Mcq("Solve −2x ≥ 10:",
            ["x ≥ −5", "x ≤ −5", "x ≥ 5", "x ≤ 5"], 1,
            ["Divide by −2 and flip the inequality.", "10/(−2) = −5."],
            "Dividing by −2 flips ≥ to ≤, so x ≤ −5.")
        .Mcq("Graph of x < 2 uses:",
            ["Closed circle, shade right", "Open circle, shade left", "Closed circle, shade left", "Open circle, shade right"], 1,
            ["Strict inequality → open circle.", "Less than → smaller values to the left."],
            "Open circle at 2, shade left.")
        .Numeric("Solve 3x + 6 < 15. What is the exclusive upper bound for x?", "3",
            ["Subtract 6: 3x < 9.", "Divide by 3: x < 3."],
            "x < 3, so 3 is the exclusive upper bound.",
            explanationLatex: @"x<3")
        .Numeric("Is 4 a solution of x ≥ 4? Enter 1 for yes, 0 for no.", "1",
            ["≥ includes equality.", "Plug in: 4 ≥ 4 is true."],
            "Yes, equality is included in ≥.")
        .Mcq("Which is equivalent to 5 > x?",
            ["x > 5", "x < 5", "x ≥ 5", "x ≤ 5"], 1,
            ["Reverse the sides and flip the comparison.", "5 greater than x means x is less than 5."],
            "5 > x is the same as x < 5.")
        .Numeric("Solve −x < 6. What is the critical bound for x after isolating (the number in x > …)?", "-6",
            ["Multiply by −1 and flip: x > −6.", "Or add x and subtract 6 carefully."],
            "−x < 6 → x > −6, so the bound is −6.",
            explanationLatex: @"x>-6")
        .Build();

    private static Lesson Ratios() => new LessonBuilder("pre-ratios", CategoryId, "Ratios, Rates & Proportions")
        .Subtitle("Compare quantities fairly and solve missing values with equal ratios")
        .Order(4).Minutes("32 min")
        .Section("Why ratios are the language of comparison",
            "A ratio compares two quantities measured in the same type of unit or in a meaningful pairing: “3 parts flour to 2 parts sugar,” “8 boys to 12 girls,” “2 cm on a map to 5 km in reality.”\n\nRatios can be written 3:2, 3 to 2, or as a fraction 3/2. The fraction form is powerful because fraction skills (equivalence, simplifying, cross-multiplying) transfer directly.\n\nRatios answer “how does this relate to that?” rather than only “how much is this?” That relational thinking shows up in scale drawings, unit prices, recipes, probability, and later slope.")
        .Section("Rates and unit rates",
            "A rate compares quantities with different units: miles per hour, price per pound, words per minute. A unit rate has 1 in the denominator after simplifying: 150 miles in 3 hours → 50 miles per 1 hour → 50 mph.\n\nUnit rates make comparisons fair. Is 12 oz for $3 better than 20 oz for $4.50? Compare unit prices (cost per ounce). Without unit rates, bigger packages can trick you.",
            simple: "Rate = ratio with units that differ. Unit rate = “per one” of the second quantity.",
            prior: "Division is the engine: total ÷ number of units gives the per-one amount.")
        .Section("Equivalent ratios and simplifying",
            "Just like equivalent fractions, multiply or divide both parts of a ratio by the same nonzero number. 8:12 ÷ 4 = 2:3. Simplified ratios use smallest whole numbers (when possible).\n\nKeeping order is essential. 2:3 is not the same comparison as 3:2. In word problems, lock the correspondence: “students to teachers” must stay students in the first part, teachers in the second, through the entire solution.")
        .Section("Proportions: two equal ratios",
            "A proportion states that two ratios are equal: a/b = c/d (with b, d ≠ 0). If the ratios truly match, the cross products are equal: a·d = b·c.\n\nWhy cross-multiplying works: starting from a/b = c/d, multiply both sides by bd (a fair equation move) to get ad = bc. So cross-multiplication is not a new random rule, it is clearing denominators on an equation of fractions.",
            @"\frac{a}{b}=\frac{c}{d}\Leftrightarrow ad=bc",
            simple: "Proportion means “these two comparisons are the same.” Cross-multiply to find a missing piece.")
        .Section("Setting up proportions without scrambling parts",
            "Most proportion errors are setup errors, not arithmetic errors. Choose a consistent pattern:\n\n• Same units in numerators, same units in denominators: (cups flour)/(people) = (cups flour)/(people)\n• Or parallel verbal order: “map/real = map/real”\n\nWrite the known ratio, leave a variable for the unknown, then cross-multiply. Include units in your thinking even if you cancel them in the algebra.")
        .Section("Scale drawings, maps, and recipes",
            "Scale problems are proportions with a scale factor. If 1 inch represents 5 miles, then 3.5 inches represent d miles via 1/5 = 3.5/d, so d = 17.5 miles.\n\nRecipes scale the same way: if 4 servings need 2 cups flour, 10 servings need f cups with 2/4 = f/10. Keep the “ingredient to servings” pairing consistent.\n\nSimilar figures in geometry later will reuse this exact idea: corresponding sides are proportional.")
        .Section("When cross-multiplying is the wrong first move",
            "If you only need a unit rate, divide once, you may not need a full proportion. If a ratio should be simplified, divide both parts by a common factor first so later arithmetic is friendlier.\n\nAlso: cross-adding (a + d = b + c) is not a proportion test. Only cross products detect equal ratios (for positive quantities in the usual school setting).",
            prior: "Fraction equivalence and solving one-step equations are the two tools inside every proportion.")
        .Formula("Cross product", @"\frac{a}{b}=\frac{c}{d}\;\Rightarrow\; ad=bc", "Equal ratios have equal cross products (b, d ≠ 0).")
        .Formula("Unit rate", @"\text{unit rate}=\frac{\text{quantity}}{\text{number of units}}", "How much per one unit.")
        .Formula("Scale", @"\frac{\text{map}}{\text{real}}=\frac{\text{map}_2}{\text{real}_2}", "Keep corresponding measurements aligned.")
        .Example("Find a unit rate",
            "A car travels 150 miles in 3 hours. What is the speed in miles per hour?",
            [
                "Speed is a rate: miles compared to hours.",
                "Unit rate means “per 1 hour,” so divide 150 by 3.",
                "150 ÷ 3 = 50. Units: miles per hour.",
                "Check: 50 mph for 3 hours predicts 150 miles, matches the given total."
            ],
            "50 miles per hour.",
            problemLatex: @"\frac{150\text{ mi}}{3\text{ h}}",
            solutionLatex: @"50",
            stepLatex: [null, @"\frac{150}{3}", @"50", null])
        .Example("Solve a proportion",
            "Solve 3/4 = x/20.",
            [
                "Cross-multiply: 3 · 20 = 4 · x.",
                "60 = 4x.",
                "Divide by 4: x = 15.",
                "Check: 3/4 = 0.75 and 15/20 = 0.75. Same ratio."
            ],
            "x = 15.",
            problemLatex: @"\frac{3}{4}=\frac{x}{20}",
            solutionLatex: @"x=15",
            stepLatex: [@"3\cdot 20=4x", @"60=4x", @"x=15", null])
        .Example("Recipe scaling",
            "A recipe for 4 people uses 2 cups of flour. How much flour for 10 people?",
            [
                "Set a consistent proportion: flour/people = flour/people → 2/4 = f/10.",
                "Cross-multiply: 2 · 10 = 4 · f → 20 = 4f.",
                "f = 5 cups.",
                "Sense check: 10 people is 2.5 times 4 people, and 2.5 · 2 cups = 5 cups. Same answer, different path."
            ],
            "5 cups of flour.",
            problemLatex: @"\frac{2}{4}=\frac{f}{10}",
            solutionLatex: @"5",
            stepLatex: [@"\frac{2}{4}=\frac{f}{10}", @"20=4f", @"f=5", null])
        .Example("Map scale",
            "A map scale is 1 inch = 5 miles. A road measures 3.5 inches on the map. How many real miles is that?",
            [
                "Proportion: 1/5 = 3.5/d (inches/miles = inches/miles).",
                "Cross-multiply: 1 · d = 5 · 3.5.",
                "d = 17.5 miles.",
                "Shortcut after understanding: each inch is 5 miles, so multiply map inches by 5. Same structure as the proportion."
            ],
            "17.5 miles.",
            problemLatex: @"\frac{1}{5}=\frac{3.5}{d}",
            solutionLatex: @"17.5",
            stepLatex: [null, @"d=5\cdot 3.5", @"d=17.5", null])
        .Mistake("Setting up ratios with mismatched corresponding parts (mixing which quantity is first).")
        .Mistake("Cross-adding instead of cross-multiplying to test or solve proportions.")
        .Mistake("Simplifying only one part of a ratio.")
        .Mistake("Comparing package deals without converting to unit rates.")
        .Numeric("Simplify the ratio 8:12 to a:b in smallest integers. Enter a/b.", "2/3",
            ["Divide both parts by 4.", "8÷4 = 2, 12÷4 = 3."],
            "8:12 = 2:3, so enter 2/3.",
            tolerance: 0,
            explanationLatex: @"\frac{2}{3}")
        .Numeric("200 km in 4 hours. Unit rate in km/h?", "50",
            ["Divide distance by time.", "200 ÷ 4."],
            "200/4 = 50 km/h.",
            explanationLatex: @"50")
        .Numeric("Solve 2/5 = x/25. Find x.", "10",
            ["Cross-multiply: 2 · 25 = 5x.", "50 = 5x."],
            "x = 10.",
            explanationLatex: @"x=10")
        .Numeric("Solve 7/x = 21/15. Find x.", "5",
            ["Cross-multiply: 7 · 15 = 21 · x.", "105 = 21x."],
            "x = 5.",
            explanationLatex: @"x=5")
        .Mcq("Which is a true proportion?",
            ["2/3 = 4/5", "2/3 = 4/6", "2/3 = 3/2", "1/2 = 2/2"], 1,
            ["Cross-check products.", "2 · 6 = 12 and 3 · 4 = 12."],
            "2/3 = 4/6 is true because both equal 2:3.")
        .Numeric("If 5 pencils cost $2, what is the cost of 20 pencils?", "8",
            ["Set 5/2 = 20/c or use unit price.", "Unit price $0.40; 20 · 0.40 = 8."],
            "Cost is $8.",
            explanationLatex: @"8")
        .Numeric("Scale 1 cm : 20 m. A length of 4.5 cm represents how many meters?", "90",
            ["Multiply by the scale factor 20.", "4.5 · 20."],
            "4.5 × 20 = 90 m.",
            explanationLatex: @"90")
        .Numeric("A printer makes 180 pages in 4 minutes. Pages per minute?", "45",
            ["Unit rate: 180 ÷ 4.", "Simplify the rate pages/minutes."],
            "45 pages per minute.",
            explanationLatex: @"45")
        .Build();

    private static Lesson ExponentsRoots() => new LessonBuilder("pre-exponents", CategoryId, "Exponents, Roots & Scientific Notation")
        .Subtitle("Powers pack repeated multiplication; roots undo squares; scientific notation tames huge and tiny numbers")
        .Order(5).Minutes("34 min")
        .Section("Why exponents exist",
            "Writing 2 × 2 × 2 × 2 × 2 is clumsy. Exponents compress repeated multiplication: 2⁵ = 32. The base is the number being multiplied; the exponent (power) counts how many factors of the base appear.\n\nExponents are not only shortcuts. They describe growth (doubling, compounding), area and volume formulas (squares and cubes), and the structure of place value (10³ = 1,000). Scientific work leans on powers of ten constantly.")
        .Section("Positive integer powers, zero, and negatives",
            "For a positive integer n, aⁿ means n factors of a. Special cases you must own:\n• a¹ = a\n• a⁰ = 1 for a ≠ 0 (empty product idea / consistency with aⁿ/aⁿ = a⁰ = 1)\n• a⁻ⁿ = 1/aⁿ for a ≠ 0 (negative exponents mean reciprocal powers, not negative answers by themselves)\n\nExample: 2⁻³ = 1/2³ = 1/8. The answer is positive. The minus is in the exponent’s meaning, not automatically on the value.",
            @"a^{-n}=\frac{1}{a^n}\;(a\neq 0)",
            simple: "Positive exponent = multiply the base by itself that many times. Zero exponent (nonzero base) = 1. Negative exponent = 1 over the positive power.",
            prior: "Multiplication of equal factors is the foundation. Exponents are a compact way to write that pattern.")
        .Section("Product and quotient rules (same base)",
            "When bases match, rules collapse long products:\n• aᵐ · aⁿ = aᵐ⁺ⁿ (count factors: three x’s times four x’s is seven x’s)\n• aᵐ / aⁿ = aᵐ⁻ⁿ for a ≠ 0\n• (aᵐ)ⁿ = aᵐⁿ\n\nCommon error: aᵐ · aⁿ = aᵐⁿ (multiplying exponents too early). Multiplying exponents is for a power of a power, not for a product of powers.\n\nThese rules are not arbitrary memorization, they are counting factors. If you forget a formula, expand a small case like x² · x³ = (x·x)(x·x·x) = x⁵.",
            @"a^m a^n=a^{m+n}")
        .Section("Roots as inverse thinking",
            "A square root asks: “What nonnegative number squared gives this?” √49 = 7 because 7² = 49. The principal square root symbol √ denotes the nonnegative root. Equations like x² = 49 have two solutions x = ±7, but √49 is only 7.\n\nAlso: √(a²) = |a|, not always a, because squares forget sign. Cube roots are different: ∛(−8) = −2 works because (−2)³ = −8. Odd roots can be negative; even roots of negatives are not real numbers in pre-algebra.",
            simple: "Square root undoes squaring for the principal (nonnegative) answer. Check by squaring your result.")
        .Section("Scientific notation: one digit pattern times a power of ten",
            "Scientific notation writes a number as a × 10ᵏ where 1 ≤ |a| < 10 and k is an integer. Large numbers get positive k; tiny numbers get negative k.\n\n• 3,200,000 = 3.2 × 10⁶ (decimal point moved 6 places left)\n• 0.00056 = 5.6 × 10⁻⁴ (decimal point moved 4 places right)\n\nWhy bother? Comparing magnitudes, estimating, and computing with very large/small quantities become cleaner. It also connects place value to exponents of 10.",
            @"3{,}200{,}000=3.2\times 10^6")
        .Section("Moving between standard and scientific form",
            "To scientific: place the decimal so the absolute value of the leading factor is between 1 and 10; k equals how many places you moved (left → positive k, right → negative k).\n\nTo standard: move the decimal k places right if k > 0, left if k < 0, filling zeros as needed.\n\nAvoid “almost scientific” forms like 45 × 10³ for 45,000, that equals 45,000, but scientific form wants 4.5 × 10⁴ so comparisons and logs later stay standardized.")
        .Section("Mistakes that break exponent sense",
            "• √(a + b) is not √a + √b in general (try a = 9, b = 16).\n• (a + b)² is not a² + b².\n• Negative bases with fractional exponents can be subtle, stick to integer exponents and principal roots at this stage.\n• 5⁰ is 1, not 0. Zero to the zero power is left undefined in most school contexts.\n\nWhen unsure, rewrite with multiplication or with 10-powers you can count.",
            prior: "Order of operations still applies: evaluate powers before multiply/add unless grouping says otherwise. (−2)² and −2² are different parsings.")
        .Formula("Product rule", @"a^m a^n=a^{m+n}", "Same base: add exponents when multiplying.")
        .Formula("Negative exponent", @"a^{-n}=\frac{1}{a^n}\;(a\neq 0)", "Negative powers are reciprocals of positive powers.")
        .Formula("Scientific notation", @"N=a\times 10^k,\; 1\le |a|<10", "Standard form for very large or small scale.")
        .Example("Compute a positive power",
            "Compute 2⁵.",
            [
                "Base 2, exponent 5 → five factors of 2.",
                "2 · 2 = 4, ·2 = 8, ·2 = 16, ·2 = 32.",
                "So 2⁵ = 32. (Memorizing small powers of 2 helps later: 2, 4, 8, 16, 32, 64, 128…)",
                "Wrong path: 2 · 5 = 10 confuses exponent with multiplication by the exponent."
            ],
            "2⁵ = 32.",
            problemLatex: @"2^5",
            solutionLatex: @"32",
            stepLatex: [null, @"2\cdot 2\cdot 2\cdot 2\cdot 2", @"32", null])
        .Example("Product rule with variables",
            "Simplify x³ · x⁴.",
            [
                "Same base x. Product rule: add exponents.",
                "3 + 4 = 7, so x³ · x⁴ = x⁷.",
                "Expand once to believe it: (x·x·x)(x·x·x·x) has seven x factors.",
                "Not x¹² (that would be multiplying exponents, which is for (x³)⁴)."
            ],
            "x⁷.",
            problemLatex: @"x^3\cdot x^4",
            solutionLatex: @"x^7",
            stepLatex: [@"x^{3+4}", @"x^7", null, null])
        .Example("Principal square root",
            "Find √49.",
            [
                "Ask: what nonnegative number squares to 49?",
                "7 · 7 = 49, so √49 = 7.",
                "Note: (−7) · (−7) = 49 also, but the principal square root symbol returns 7 only.",
                "If an equation said x² = 49, then x = ±7, different question than evaluating √49."
            ],
            "√49 = 7.",
            problemLatex: @"\sqrt{49}",
            solutionLatex: @"7",
            stepLatex: [null, @"7^2=49", @"\sqrt{49}=7", null])
        .Example("Scientific notation for a tiny number",
            "Write 0.00056 in scientific notation.",
            [
                "Move the decimal point so the coefficient is between 1 and 10: 5.6.",
                "You moved the decimal 4 places to the right to get from 0.00056 to 5.6.",
                "Moving right means the power of ten is negative: 10⁻⁴.",
                "Result: 5.6 × 10⁻⁴. Check: 5.6 × 0.0001 = 0.00056."
            ],
            "5.6 × 10⁻⁴.",
            problemLatex: @"0.00056",
            solutionLatex: @"5.6\times 10^{-4}",
            stepLatex: [@"5.6", @"4\text{ places}", @"10^{-4}", @"5.6\times 10^{-4}"])
        .Mistake("Thinking aᵐ · aⁿ = aᵐⁿ (multiplying exponents instead of adding for a product).")
        .Mistake("Believing √(a + b) = √a + √b in general.")
        .Mistake("Writing 45,000 as 45 × 10³ instead of proper scientific form 4.5 × 10⁴.")
        .Mistake("Treating a⁻ⁿ as −aⁿ instead of 1/aⁿ.")
        .Mistake("Claiming √49 = ±7 when evaluating the radical symbol (principal root is 7).")
        .Numeric("Compute 3⁴.", "81",
            ["3 · 3 · 3 · 3.", "9 · 9 = 81."],
            "3⁴ = 81.",
            explanationLatex: @"3^4=81")
        .Numeric("Compute 5⁰.", "1",
            ["Any nonzero number to the power 0 is 1.", "This is a definition that keeps exponent rules consistent."],
            "5⁰ = 1.",
            explanationLatex: @"5^0=1")
        .Numeric("Simplify x² · x⁵. What is the exponent in the result x^?", "7",
            ["Add exponents: 2 + 5.", "Product rule for same base."],
            "x² · x⁵ = x⁷, so the exponent is 7.",
            explanationLatex: @"x^7")
        .Numeric("√81 = ?", "9",
            ["What nonnegative number squares to 81?", "9 · 9 = 81."],
            "√81 = 9.",
            explanationLatex: @"\sqrt{81}=9")
        .Numeric("Write 7,500,000 as a × 10^k in scientific notation. What is k?", "6",
            ["7.5 × 10^k.", "Decimal moves 6 places from 7.5 to 7,500,000."],
            "7.5 × 10⁶, so k = 6.",
            explanationLatex: @"7.5\times 10^6")
        .Mcq("2⁻³ equals:",
            ["−6", "1/8", "−8", "8"], 1,
            ["Negative exponent means reciprocal.", "1/2³ = 1/8."],
            "2⁻³ = 1/8.")
        .Numeric("∛27 = ?", "3",
            ["What number cubes to 27?", "3 · 3 · 3 = 27."],
            "∛27 = 3.",
            explanationLatex: @"\sqrt[3]{27}=3")
        .Numeric("Write 0.004 as a × 10^k. What is k?", "-3",
            ["4 × 10^k with 1 ≤ |a| < 10 would be 4.0 × 10⁻³.", "Decimal moves 3 places."],
            "0.004 = 4 × 10⁻³, so k = −3.",
            explanationLatex: @"4\times 10^{-3}")
        .Build();
}
