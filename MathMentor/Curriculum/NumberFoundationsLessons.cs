using MathMentor.Models;

namespace MathMentor.Curriculum;

/// <summary>Integers, factors, and the rational/irrational distinction.</summary>
public static class NumberFoundationsLessons
{
    public const string CategoryId = "number";

    public static Category Build()
    {
        var lessons = new[]
        {
            IntegersAbsoluteValue(),
            FactorsGcfLcm(),
            RationalIrrational()
        };
        return new Category(
            CategoryId,
            "Number Foundations",
            "Integers, absolute value, factors and multiples, and the first look at rational versus irrational numbers.",
            "\uE8EF",
            2,
            lessons);
    }

    private static Lesson IntegersAbsoluteValue() => new LessonBuilder("num-integers", CategoryId, "Integers & Absolute Value")
        .Subtitle("The number line extends both ways: opposites, distance from zero, and signed arithmetic")
        .Order(1).Minutes("32 min")
        .Section("Why integers exist",
            "Whole numbers (0, 1, 2, 3, ...) describe counting. Real life also needs below zero: debt, temperature below freezing, elevation below sea level, and positions left of a starting point. Integers are the set {..., -3, -2, -1, 0, 1, 2, 3, ...}. Every positive integer has an opposite (additive inverse) on the other side of zero. Zero is its own opposite.",
            prior: "If you are comfortable with place value and ordinary addition and subtraction of whole numbers, you already have the tools. Integers mainly add direction (sign) and a careful meaning of absolute value.")
        .Section("The number line picture",
            "Draw a horizontal line, mark 0, positives to the right, negatives to the left. Moving right increases a number; moving left decreases it. The integer -4 is the same distance from 0 as 4 is, but in the opposite direction. That distance idea is absolute value.",
            simple: "Think of zero as home. Positive means steps to the right. Negative means steps to the left. Absolute value is how many steps from home, ignoring direction.")
        .Section("Absolute value as distance",
            "The absolute value |a| is the distance from a to 0 on the number line. Distances are never negative, so |a| is always greater than or equal to 0. For example, |5| = 5 and |-5| = 5. Algebraically, |a| = a when a is at least 0, and |a| = -a when a is less than 0 (because if a is negative, -a is positive).",
            @"|a|=a\text{ if }a\ge 0;\; |a|=-a\text{ if }a<0")
        .Section("Adding integers",
            "Same signs: add the absolute values, keep the common sign. (-3) + (-5) = -8. Different signs: subtract the smaller absolute value from the larger, and keep the sign of the number with the larger absolute value. (-7) + 4 = -3, because you have more negatives than positives. On the number line, addition is walks: start at the first number, then walk the second amount (right for positive, left for negative).")
        .Section("Subtracting integers",
            "Subtraction means add the opposite: a - b = a + (-b). So 3 - 8 = 3 + (-8) = -5, and -2 - (-6) = -2 + 6 = 4. The double negative -(-6) is the opposite of -6, which is 6. Students who only memorize 'two negatives make a positive' without the opposite story often misapply it when subtracting a positive.")
        .Section("Multiplying and dividing integers",
            "The product or quotient of two integers is positive when the signs are the same, and negative when the signs differ. That rule comes from patterns and the distributive property (for example, 3 times (-4) is three groups of -4, totaling -12). Division follows the same sign pattern because it undoes multiplication.",
            simple: "Same signs multiply or divide to a positive result. Different signs multiply or divide to a negative result. Absolute values still multiply and divide as usual.")
        .Formula("Absolute value", @"|a|=\text{distance from }a\text{ to }0", "Always non-negative.")
        .Formula("Subtract as add opposite", @"a-b=a+(-b)", "Rewrite every subtraction before combining.")
        .Example("Absolute value on the line",
            "Evaluate |-12| and |0|.",
            [
                "Absolute value is distance from zero, not 'drop the sign' as a mindless rule (though that works for negatives).",
                "|-12| is 12 units from 0, so 12.",
                "|0| is 0, because zero is already at home."
            ],
            "Answers: 12 and 0.",
            solutionLatex: @"|-12|=12,\quad |0|=0")
        .Example("Add with different signs",
            "Compute (-9) + 5.",
            [
                "Absolute values: 9 and 5. Difference: 9 - 5 = 4.",
                "The larger absolute value belongs to -9, so the result is negative: -4.",
                "Number-line check: start at -9, walk 5 right, land on -4.",
                "Wrong path: writing -14 by treating it like same signs."
            ],
            "(-9) + 5 = -4.",
            solutionLatex: @"-9+5=-4")
        .Example("Subtract a negative",
            "Compute 4 - (-7).",
            [
                "Rewrite: 4 + 7, because subtracting -7 means adding its opposite 7.",
                "4 + 7 = 11.",
                "Story: removing a debt of 7 is like gaining 7."
            ],
            "4 - (-7) = 11.",
            solutionLatex: @"4-(-7)=4+7=11")
        .Example("Signed product",
            "Compute (-6) * (-3) and (-6) * 3.",
            [
                "First: same signs, product of absolutes 18, positive: 18.",
                "Second: different signs, product of absolutes 18, negative: -18.",
                "Check with patterns: 6*3=18, 6*(-3)=-18, (-6)*3=-18, (-6)*(-3)=18."
            ],
            "Results 18 and -18.",
            solutionLatex: @"(-6)(-3)=18,\quad (-6)(3)=-18")
        .Mistake("Treating absolute value as 'always make positive after any expression' without evaluating inside first: |-3-5| is not |3|-|5|.")
        .Mistake("Saying two negatives always make a positive even when you are only adding (-3)+(-5).")
        .Mistake("Rewriting a - b as b - a (order matters).")
        .Mistake("Forgetting that |0| = 0, not 1 or undefined.")
        .Numeric("What is |-15|?", "15", ["Distance from 0 to -15."], "|-15| = 15.")
        .Numeric("Compute (-8) + 3.", "-5", ["Different signs; 8-3=5; sign follows -8."], "-5.")
        .Numeric("Compute 6 - (-2).", "8", ["6 + 2."], "8.")
        .Numeric("Compute (-4) * 5.", "-20", ["Different signs."], "-20.")
        .Numeric("Compute (-7) * (-2).", "14", ["Same signs."], "14.")
        .Mcq("Which is true?",
            ["|-3| = -3", "|-3| = 3", "|-3| = 0", "|-3| is undefined"], 1,
            ["Absolute value is distance."],
            "|-3| = 3.")
        .Numeric("Compute (-10) / 2.", "-5", ["Different signs; 10/2=5."], "-5.")
        .Mcq("4 - 9 equals:",
            ["5", "-5", "13", "-13"], 1,
            ["4 + (-9)."],
            "4 - 9 = -5.")
        .Build();

    private static Lesson FactorsGcfLcm() => new LessonBuilder("num-factors", CategoryId, "Factors, Primes, GCF & LCM")
        .Subtitle("How numbers break into pieces, and why GCF and LCM show up in fractions and algebra")
        .Order(2).Minutes("34 min")
        .Section("Factors and multiples",
            "A factor of n is a whole number that divides n with no remainder. The factors of 12 are 1, 2, 3, 4, 6, and 12. A multiple of n is n, 2n, 3n, ... so multiples of 12 include 12, 24, 36, 48. Factors are pieces that multiply to the number; multiples are what you get when you keep stacking the number.",
            prior: "You use factors when simplifying fractions and when factoring polynomials later. LCM is the same idea that makes common denominators.")
        .Section("Primes and prime factorization",
            "A prime number has exactly two distinct positive factors: 1 and itself. Examples: 2, 3, 5, 7, 11. The number 1 is not prime (it has only one positive factor). Composite numbers have more than two factors. The fundamental theorem of arithmetic says every integer greater than 1 factors uniquely into primes (order aside). Example: 60 = 2^2 * 3 * 5.")
        .Section("GCF: greatest common factor",
            "The GCF of two numbers is the largest positive integer that divides both. For 18 and 24, common factors include 1, 2, 3, 6; GCF is 6. Using primes: 18 = 2 * 3^2 and 24 = 2^3 * 3, so GCF takes the minimum powers: 2^1 * 3^1 = 6. GCF is what you divide by when simplifying a fraction a/b.",
            simple: "GCF is the biggest shared building block. If you can pull that block out of both numbers, you have simplified or factored as far as that shared block allows.")
        .Section("LCM: least common multiple",
            "The LCM is the smallest positive integer that is a multiple of both numbers. For 4 and 6, multiples of 4: 4, 8, 12, 16, ...; of 6: 6, 12, 18, ...; LCM is 12. With primes: take the maximum powers: 4 = 2^2, 6 = 2 * 3, LCM = 2^2 * 3 = 12. LCM is the classic common denominator for adding fractions.")
        .Section("A useful relationship",
            "For positive integers a and b, GCF(a,b) * LCM(a,b) = a * b. Check: GCF(18,24)=6, LCM(18,24)=72, and 6*72=432, while 18*24=432. This is a good error check when you compute both.",
            @"\mathrm{GCF}(a,b)\cdot\mathrm{LCM}(a,b)=ab")
        .Section("Why algebra cares",
            "Factoring out a GCF of coefficients and variables is the first step in almost every factoring strategy for polynomials. Finding common denominators for rational expressions is the LCM idea again, with polynomials instead of integers. Mastering GCF and LCM with numbers makes those later moves feel familiar.")
        .Formula("Prime idea", @"n=p_1^{e_1}p_2^{e_2}\cdots", "Unique prime factorization for n > 1.")
        .Formula("GCF and LCM link", @"\mathrm{GCF}(a,b)\cdot\mathrm{LCM}(a,b)=ab", "For positive integers a, b.")
        .Example("List factors",
            "List all positive factors of 36.",
            [
                "Pairs that multiply to 36: 1*36, 2*18, 3*12, 4*9, 6*6.",
                "Factors: 1, 2, 3, 4, 6, 9, 12, 18, 36.",
                "Notice 36 is not prime; it has many factors."
            ],
            "Nine positive factors as listed.")
        .Example("Prime factorization",
            "Write 84 as a product of primes.",
            [
                "84 is even: 84 = 2 * 42 = 2 * 2 * 21 = 2 * 2 * 3 * 7.",
                "So 84 = 2^2 * 3 * 7.",
                "Check: 4 * 3 * 7 = 84."
            ],
            "2^2 * 3 * 7.",
            solutionLatex: @"84=2^2\cdot 3\cdot 7")
        .Example("GCF via primes",
            "Find GCF(48, 180).",
            [
                "48 = 2^4 * 3.",
                "180 = 2^2 * 3^2 * 5.",
                "Minimum powers: 2^2 * 3 = 12.",
                "Check: 48/12=4, 180/12=15, no larger common factor remains."
            ],
            "GCF is 12.",
            solutionLatex: @"\mathrm{GCF}(48,180)=12")
        .Example("LCM for denominators",
            "What common denominator is best for 1/8 + 1/12?",
            [
                "Need LCM(8,12).",
                "8 = 2^3, 12 = 2^2 * 3, so LCM = 2^3 * 3 = 24.",
                "Then 1/8 = 3/24 and 1/12 = 2/24, sum 5/24.",
                "Using 96 would work but is messier; LCM is the kindest choice."
            ],
            "LCM is 24.",
            solutionLatex: @"\mathrm{LCM}(8,12)=24")
        .Mistake("Calling 1 a prime number.")
        .Mistake("Confusing GCF with LCM (GCF is shared factor; LCM is shared multiple).")
        .Mistake("Taking maximum powers for GCF or minimum powers for LCM (roles swapped).")
        .Mistake("Stopping prime factorization early (leaving a composite like 9 unfactored).")
        .Numeric("How many positive factors does 7 have?", "2", ["7 is prime: 1 and 7."], "2 factors.")
        .Numeric("GCF of 15 and 25?", "5", ["Common factors 1 and 5."], "5.")
        .Numeric("LCM of 6 and 8?", "24", ["Primes: 2^3 * 3."], "24.")
        .Numeric("Prime factorization of 100: exponent of 2?", "2", ["100=2^2*5^2."], "2.")
        .Mcq("Which is prime?",
            ["1", "9", "15", "19"], 3,
            ["Only two factors: 1 and itself."],
            "19 is prime.")
        .Numeric("GCF(18,24) * LCM(18,24) should equal?", "432", ["18*24."], "432.")
        .Numeric("LCM of 5 and 7?", "35", ["Coprime numbers: product."], "35.")
        .Mcq("Best common denominator for 1/9 + 1/6 uses LCM:",
            ["15", "18", "54", "3"], 1,
            ["9=3^2, 6=2*3, LCM=2*3^2=18."],
            "18.")
        .Build();

    private static Lesson RationalIrrational() => new LessonBuilder("num-rational-irrational", CategoryId, "Rational & Irrational Numbers")
        .Subtitle("Which numbers can be written as fractions, and why some cannot")
        .Order(3).Minutes("30 min")
        .Section("What is a rational number?",
            "A rational number can be written as a ratio of integers a/b with b not zero. Integers are rational (5 = 5/1). Terminating decimals are rational (0.25 = 1/4). Repeating decimals are rational (0.333... = 1/3). The word rational comes from ratio.",
            prior: "Fractions and decimals you already use are almost always rational. This lesson names the set and contrasts it with irrationals.")
        .Section("What is an irrational number?",
            "An irrational number cannot be written as a ratio of integers. Its decimal expansion never ends and never settles into a repeating block. Classic examples: √2, √3, π, and e. Between any two rationals there are irrationals, and between any two irrationals there are rationals. The real line is densely packed with both.")
        .Section("Why √2 is not a fraction (idea)",
            "Suppose √2 = a/b in lowest terms. Then a^2 = 2 b^2, so a^2 is even, so a is even. Write a = 2k; then 4k^2 = 2b^2 so b^2 is even and b is even. But then a and b share a factor of 2, contradicting lowest terms. So √2 cannot be rational. You do not need a full proof memorized, but you should know the conclusion: perfect squares have integer roots; 2 is not a perfect square, and √2 is irrational.")
        .Section("Recognizing common cases",
            "√n is either an integer (if n is a perfect square) or irrational (for positive integers n that are not perfect squares). Cube roots and other roots follow similar ideas. π is irrational (deep theorem; for school purposes, treat π as irrational and do not rewrite it as 22/7 except as an approximation).")
        .Section("Operations and closure (school level)",
            "Rationals are closed under addition, subtraction, multiplication, and division (except by zero): combining rationals with these operations yields rationals. Mixing with irrationals is subtler: √2 + (-√2) = 0 (rational), but √2 + 1 is irrational. Do not assume 'rational + irrational = irrational' without care when cancellation can happen.")
        .Section("Why this matters later",
            "Domain of square root functions, exact answers in geometry (√2 side lengths), and distinguishing exact vs approximate values in algebra and trigonometry all use this vocabulary. Saying 'leave in exact form' often means keep √ and π rather than decimal approximations.")
        .Formula("Rational form", @"r=\frac{a}{b},\quad a,b\in\mathbb{Z},\; b\neq 0", "Definition of a rational number.")
        .Formula("Classic irrational", @"\sqrt{2}\notin\mathbb{Q}", "Not equal to any integer ratio.")
        .Example("Classify",
            "Is 0.75 rational?",
            [
                "0.75 = 75/100 = 3/4 after simplifying.",
                "It is a ratio of integers, so rational.",
                "Terminating decimals are always rational."
            ],
            "Rational.",
            solutionLatex: @"0.75=\frac{3}{4}")
        .Example("Repeating decimal",
            "Is 0.121212... (12 repeating) rational?",
            [
                "Repeating decimals can be converted to fractions.",
                "Let x = 0.121212..., then 100x = 12.1212..., subtract: 99x = 12, x = 12/99 = 4/33.",
                "So yes, rational."
            ],
            "Rational (4/33).",
            solutionLatex: @"0.\overline{12}=\frac{4}{33}")
        .Example("Square root",
            "Classify √49 and √50.",
            [
                "√49 = 7, an integer, hence rational.",
                "50 is not a perfect square, so √50 is irrational (can write √(25*2)=5√2, still irrational)."
            ],
            "√49 rational; √50 irrational.")
        .Example("π in formulas",
            "Circumference 2πr with r = 3 is 6π. Is that exact value rational?",
            [
                "6π is a nonzero rational times π.",
                "Because π is irrational, 6π is irrational.",
                "A calculator decimal for 6π is only an approximation."
            ],
            "6π is irrational (exact form preferred).")
        .Mistake("Thinking every decimal is irrational (terminating and repeating decimals are rational).")
        .Mistake("Thinking √n is always irrational (perfect squares give integers).")
        .Mistake("Treating 22/7 as exactly π rather than an approximation.")
        .Mistake("Believing 0 is not rational (0 = 0/1).")
        .Mcq("Which is irrational?",
            ["1/3", "0.25", "√9", "√7"], 3,
            ["√7 is not a perfect-square root."],
            "√7 is irrational.")
        .Mcq("Which is rational?",
            ["π", "√2", "0.333...", "√10"], 2,
            ["0.333... = 1/3."],
            "Repeating 0.333... is rational.")
        .Numeric("Write 0.2 as a fraction a/b in lowest terms: numerator?", "1", ["1/5."], "1/5.")
        .Numeric("Write 0.2 as fraction: denominator?", "5", ["1/5."], "5.")
        .Mcq("√36 is:",
            ["Irrational", "Rational", "Not real", "Undefined"], 1,
            ["√36 = 6."],
            "Rational.")
        .Mcq("Is 0 rational?",
            ["No", "Yes", "Only sometimes", "Only as a decimal"], 1,
            ["0 = 0/1."],
            "Yes.")
        .Numeric("If x = 0.555..., then 10x - x = 5 implies 9x = 5. What is x as a/b? numerator?", "5", ["5/9."], "5/9.")
        .Numeric("Denominator of that fraction?", "9", ["5/9."], "9.")
        .Build();
}
