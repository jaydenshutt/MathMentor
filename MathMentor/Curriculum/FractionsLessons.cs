using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class FractionsLessons
{
    public const string CategoryId = "fractions";

    public static Category Build()
    {
        var lessons = new[]
        {
            UnderstandingFractions(),
            AddSubtractFractions(),
            MultiplyDivideFractions(),
            Decimals(),
            Conversions(),
            PercentWordProblems()
        };
        return new Category(CategoryId, "Fractions, Decimals & Percentages",
            "Parts of a whole, decimal place value, and percent fluency for real life.",
            "\uE8EC", 3, lessons);
    }

    private static Lesson UnderstandingFractions() => new LessonBuilder("frac-understand", CategoryId, "Understanding, Comparing & Equivalent Fractions")
        .Subtitle("See fractions as fair shares, equal sizes, and fair comparisons, not just stacked numbers")
        .Order(1).Minutes("32 min")
        .Section("Why fractions exist (and why they feel different from whole numbers)",
            "Whole numbers answer “how many whole objects?” Fractions answer a quieter but equally important question: “how much of a whole do I have when the whole is split into equal pieces?”\n\nPizza, measuring cups, time left in a game, probability, slopes in algebra, all of them need a language for parts. A fraction is not “two numbers with a bar.” It is a relationship: the bottom tells you how fine the slicing is; the top tells you how many of those equal slices you hold.\n\nIf you only memorize rules, fractions feel like a bag of tricks. If you keep the “equal parts of a whole” picture alive, every later rule (equivalent fractions, comparing, adding) becomes a natural extension instead of a surprise.")
        .Section("Numerator and denominator: jobs, not decorations",
            "In the fraction a/b (with b ≠ 0):\n• The denominator b names the size of each piece: “we split the whole into b equal parts.” Larger b means smaller pieces of the same whole.\n• The numerator a counts how many of those pieces you have.\n\nSo 3/8 is three pieces when the whole is cut into eight equal pieces. The bar means “of that size,” not “divide randomly.” Also: the whole must be the same kind of thing when you compare or combine fractions, three-eighths of a pizza and three-eighths of a mile are both “3 out of 8 equal parts,” but of different wholes.",
            @"\frac{a}{b}",
            simple: "If this feels confusing, say it out loud: “bottom = how many equal pieces the whole is cut into; top = how many of those pieces I have.” Same whole, equal pieces, that is the whole story.",
            prior: "You already know fair sharing from arithmetic: 12 cookies shared equally among 4 people is 3 each. A fraction is the same idea when the share is less than (or more than) one whole object.")
        .Section("Unit fractions and building any fraction",
            "A unit fraction has numerator 1: 1/2, 1/3, 1/10. Every other positive fraction is a stack of unit fractions of the same size: 5/8 = 1/8 + 1/8 + 1/8 + 1/8 + 1/8. That is why “same denominators mean same piece size” is so powerful later when we add.\n\nImproper fractions have numerator ≥ denominator (like 11/4), more than one whole. Mixed numbers write the same amount as wholes plus a leftover fraction (2 3/4). Neither form is “more correct”; improper fractions are often easier for multiplying and algebra, while mixed numbers are friendlier for measuring and everyday talk.")
        .Section("Equivalent fractions: same amount, different packaging",
            "Two fractions are equivalent when they name the same part of the same whole. Visually, 1/2 of a bar is the same length as 2/4 of that bar if the bar is identical. Algebraically, multiplying (or dividing) the numerator and denominator by the same nonzero number k does not change the value:\n\na/b = (a·k)/(b·k).\n\nWhy does that work? You are cutting every piece into k smaller pieces and counting k times as many of them, finer packaging of the same amount. Simplifying is the reverse: divide top and bottom by a common factor, ideally the greatest common factor (GCF), until nothing bigger than 1 divides both.",
            @"\frac{a}{b}=\frac{ak}{bk}\;(k\neq 0)",
            simple: "If this feels confusing, think of money: 50 cents is half a dollar, and so is 2 quarters, or 5 dimes. Different numbers, same value. Equivalent fractions are the same idea with pieces of a whole.",
            prior: "This is the same spirit as renaming in place value: 1 ten = 10 ones. You repackage without changing the total.")
        .Section("Comparing fractions fairly",
            "You cannot always trust “bigger numbers look bigger.” 1/2 is larger than 1/8 even though 8 > 2, because the pieces are different sizes.\n\nReliable strategies:\n• Same denominator: larger numerator wins (more pieces of the same size).\n• Same numerator: larger denominator means smaller pieces, so the fraction is smaller (among positive fractions).\n• Different tops and bottoms: rewrite with a common denominator, or cross-multiply for positives: a/b ? c/d by comparing a·d with b·c.\n\nBenchmarks help number sense: is the fraction near 0, near 1/2, or near 1? 7/8 is close to 1; 3/7 is a bit under 1/2.")
        .Section("Why “canceling digits” is not simplifying",
            "A famous bad habit is “crossing out matching digits,” like turning 16/64 into 1/4 by erasing the 6s. Sometimes you luck into a correct answer; often you do not (19/95 is not 1/5). Real simplifying uses common factors of the whole numbers, not shared digits. Digits are symbols; factors are structure.")
        .Section("Connecting forward: fractions as numbers on a line",
            "Every fraction sits on the number line between integers (or beyond, if improper). That picture unifies comparing, estimating, and later operations. When you eventually study decimals and percentages, you are just naming the same number-line location in other languages, not inventing a new kind of quantity.")
        .Formula("Equivalence", @"\frac{a}{b}=\frac{ak}{bk}\;(k\neq 0)", "Scale top and bottom by the same nonzero k; value unchanged.")
        .Formula("Cross-multiply compare", @"\frac{a}{b}>\frac{c}{d}\Leftrightarrow ad>bc", "For positive b and d; compare products instead of finding a common denominator.")
        .Formula("Simplify with GCF", @"\frac{a}{b}=\frac{a\div g}{b\div g}\;(g=\mathrm{GCF}(a,b))", "Divide out the greatest common factor to reach lowest terms.")
        .Example("Simplify with meaning, not luck",
            "Simplify 18/24 to lowest terms.",
            [
                "Thinking: lowest terms means top and bottom share no common factor greater than 1.",
                "List factors or use primes: 18 = 2·3·3, 24 = 2·2·2·3. Shared factors: one 2 and one 3, so GCF = 6.",
                "Divide both by 6: 18÷6 = 3, 24÷6 = 4.",
                "3 and 4 share no common factor > 1, so 3/4 is simplified.",
                "Common mistake callout: canceling the digit 8 to invent 1/2, or stopping at 9/12 which is equal but not fully simplified."
            ],
            "18/24 packages the same amount as 3/4; 3/4 is the cleanest packaging.",
            problemLatex: @"\frac{18}{24}",
            solutionLatex: @"\frac{18}{24}=\frac{3}{4}",
            stepLatex: [null, @"\mathrm{GCF}(18,24)=6", @"\frac{18\div 6}{24\div 6}", @"\frac{3}{4}", null],
            closingLatex: @"\frac{3}{4}")
        .Example("Build equivalents on purpose",
            "Find two fractions equivalent to 2/5.",
            [
                "Thinking: keep the value, change the packaging, multiply top and bottom by the same k.",
                "Choose k = 2: (2·2)/(5·2) = 4/10.",
                "Choose k = 3: (2·3)/(5·3) = 6/15.",
                "Check by simplifying back: 4/10 ÷2/2 = 2/5; 6/15 ÷3/3 = 2/5. Good.",
                "Common mistake callout: multiplying only the numerator (getting 4/5), that enlarges the amount, not just the packaging."
            ],
            "2/5 = 4/10 = 6/15 (and infinitely many more).",
            problemLatex: @"\frac{2}{5}",
            solutionLatex: @"\frac{2}{5}=\frac{4}{10}=\frac{6}{15}",
            stepLatex: [null, @"\frac{2\cdot 2}{5\cdot 2}=\frac{4}{10}", @"\frac{2\cdot 3}{5\cdot 3}=\frac{6}{15}", null, null])
        .Example("Compare with cross-multiplying and number sense",
            "Which is larger: 3/7 or 2/5?",
            [
                "Thinking: different denominators, so piece sizes differ. Cross-multiply for positives, or find a common denominator.",
                "Cross products: 3·5 = 15 and 2·7 = 14.",
                "Because 15 > 14, we have 3/7 > 2/5.",
                "Sense check: 3/7 is a bit under 1/2 (since 3.5/7 would be half); 2/5 = 0.4, also under half but smaller. They are close, cross-multiply settles the close call.",
                "Common mistake callout: saying 2/5 is larger because 5 > something, or adding tops and bottoms, or comparing 3+7 with 2+5."
            ],
            "3/7 is slightly larger than 2/5.",
            problemLatex: @"\frac{3}{7}\;?\;\frac{2}{5}",
            solutionLatex: @"\frac{3}{7}>\frac{2}{5}",
            stepLatex: [null, @"3\cdot 5=15,\;2\cdot 7=14", @"15>14", null, null],
            closingLatex: @"\frac{3}{7}>\frac{2}{5}")
        .Example("Improper to mixed: wholes plus leftover pieces",
            "Write 11/4 as a mixed number.",
            [
                "Thinking: each whole is 4/4. How many full groups of 4 fit into 11 fourths?",
                "4 goes into 11 two times because 2·4 = 8 fourths (two wholes).",
                "Remainder: 11 − 8 = 3 fourths left over.",
                "So 11/4 = 2 + 3/4 = 2 3/4.",
                "Common mistake callout: writing 2 11/4 (forgetting to remove the used fourths) or 3 1/4 (rounding the division instead of using remainder)."
            ],
            "Improper 11/4 and mixed 2 3/4 name the same amount.",
            problemLatex: @"\frac{11}{4}",
            solutionLatex: @"\frac{11}{4}=2\frac{3}{4}",
            stepLatex: [null, @"2\cdot 4=8", @"11-8=3", @"2+\frac{3}{4}", null],
            closingLatex: @"2\frac{3}{4}")
        .Mistake("Treating the fraction bar as decoration and adding or comparing tops and bottoms as if they were independent whole numbers (1/2 + 1/3 is not 2/5).")
        .Mistake("Believing a larger denominator always means a larger fraction, among unit fractions the opposite is true: 1/8 < 1/2.")
        .Mistake("Canceling matching digits instead of common factors (16/64 → “cross out 6s” is not a method, even when luck gives 1/4).")
        .Mistake("Multiplying only the numerator (or only the denominator) when building an equivalent fraction, which changes the value.")
        .Mistake("When converting improper ↔ mixed, forgetting the remainder is still over the original denominator.")
        .Mistake("Comparing fractions that refer to different wholes without noticing (half of a small pizza vs half of a large pizza).")
        .Mcq("Which equals 1/2?",
            ["2/5", "3/6", "2/3", "1/3"], 1,
            [
                "Equivalent fractions keep the same value with different packaging.",
                "Multiply top and bottom of 1/2 by 3: (1·3)/(2·3) = 3/6."
            ],
            "3/6 is exactly half: three equal pieces out of six is the same as one out of two.",
            explanationLatex: @"\frac{1}{2}=\frac{3}{6}")
        .Numeric("Simplify 12/18 to lowest terms. Enter as a/b (e.g. 2/3).", "2/3",
            [
                "Find GCF(12,18). Both divisible by 6.",
                "12÷6 = 2 and 18÷6 = 3."
            ],
            "GCF is 6, so 12/18 = 2/3 in lowest terms.",
            tolerance: 0,
            explanationLatex: @"\frac{12}{18}=\frac{2}{3}")
        .Mcq("Compare 4/9 and 3/7:",
            ["4/9 larger", "3/7 larger", "equal", "cannot tell"], 0,
            [
                "Cross-multiply: compare 4·7 with 3·9.",
                "28 versus 27, which product is larger?"
            ],
            "4·7 = 28 and 3·9 = 27, so 4/9 > 3/7.",
            explanationLatex: @"\frac{4}{9}>\frac{3}{7}")
        .Numeric("Convert 17/5 to a mixed number. Enter as n m/d like 3 2/5.", "3 2/5",
            [
                "How many wholes of size 5 fit into 17?",
                "5·3 = 15; remainder 17 − 15 = 2, so 3 2/5."
            ],
            "17/5 = 3 wholes with 2 fifths left: 3 2/5.",
            tolerance: 0,
            explanationLatex: @"\frac{17}{5}=3\frac{2}{5}")
        .Mcq("Which is equivalent to 5/8?",
            ["10/16", "5/16", "8/5", "10/8"], 0,
            [
                "Multiply numerator and denominator by the same number.",
                "×2/2 gives 10/16."
            ],
            "5/8 · (2/2) = 10/16, same value.",
            explanationLatex: @"\frac{5}{8}=\frac{10}{16}")
        .Numeric("What is the GCF of 14 and 21? (used to simplify 14/21)", "7",
            [
                "Factors of 14: 1, 2, 7, 14.",
                "Factors of 21: 1, 3, 7, 21. Largest shared factor?"
            ],
            "GCF = 7, so 14/21 = 2/3 after simplifying.",
            tolerance: 0)
        .Mcq("Which fraction is smallest?",
            ["1/2", "1/3", "1/4", "1/5"], 3,
            [
                "Same numerator 1: you are comparing unit fractions.",
                "Larger denominator → smaller equal pieces of the same whole."
            ],
            "Among unit fractions, 1/5 is the smallest because fifths are tinier than halves, thirds, or fourths.")
        .Numeric("Write two and three-fifths as an improper fraction a/b.", "13/5",
            [
                "Two wholes = 2·5 = 10 fifths.",
                "10 fifths + 3 fifths = 13 fifths."
            ],
            "2 3/5 = 13/5.",
            tolerance: 0,
            explanationLatex: @"2\frac{3}{5}=\frac{13}{5}")
        .Build();

    private static Lesson AddSubtractFractions() => new LessonBuilder("frac-addsub", CategoryId, "Adding & Subtracting Fractions")
        .Subtitle("Why common denominators matter, and how LCM keeps the arithmetic kind")
        .Order(2).Minutes("34 min")
        .Section("Why we cannot just add tops and bottoms",
            "Adding 1/2 + 1/3 is not 2/5. Why? The denominators name different piece sizes. One half and one third are not “one piece + one piece” of the same size, they are different-sized slices. Adding numerators only is fair when every piece is the same size, which means the denominators already match.\n\nPicture a measuring cup marked in halves and another marked in thirds: to combine liquid amounts, you need a single scale (sixths work beautifully) so you are counting congruent units.")
        .Section("Same denominators: add the counts, keep the size",
            "When denominators already match, the pieces are the same size. Adding or subtracting is then just combining or removing how many pieces you have:\n\na/b + c/b = (a + c)/b, and a/b − c/b = (a − c)/b (when the result stays non-negative for now).\n\nThen simplify if the new numerator and denominator share a factor. Example: 2/7 + 3/7 = 5/7, five pieces of size one-seventh.",
            @"\frac{a}{b}+\frac{c}{b}=\frac{a+c}{b}",
            simple: "If this feels confusing: same bottom means same cookie-cutter size. Only the number of cookies changes when you add or subtract.",
            prior: "This is the unit-fraction idea from Understanding Fractions: 2/7 means two copies of 1/7.")
        .Section("Unlike denominators: the universal product formula",
            "If denominators differ, rewrite both fractions so they share a common denominator, then add or subtract numerators. One formula that always works uses the product of the denominators as a common denominator:\n\na/b + c/d = (a·d + b·c)/(b·d)\n\nand\n\na/b − c/d = (a·d − b·c)/(b·d).\n\nWhy those numerators? To write a/b with denominator b·d you multiply top and bottom by d, getting (a·d)/(b·d). To write c/d with denominator b·d you multiply top and bottom by b, getting (b·c)/(b·d). Now both are “something over bd,” so you add or subtract the somethings.",
            @"\frac{a}{b}+\frac{c}{d}=\frac{ad+bc}{bd}",
            simple: "If this feels confusing: first twin the fractions so they have the same bottom (using ·d on the first and ·b on the second), then add the tops and keep that shared bottom. The formula is just that process written in one line.",
            prior: "Equivalent fractions from the previous lesson are the engine: you are not changing values, only packaging.")
        .Section("LCM: the same idea with smaller numbers",
            "The product b·d always works as a common denominator, but it is not always the smallest. The least common multiple LCM(b, d) is the smallest positive common denominator. Smaller denominators mean smaller numerators and less simplifying at the end.\n\nExample: 1/4 + 1/6. Product of denominators is 24, and the formula gives (6 + 4)/24 = 10/24 = 5/12. Using LCM(4,6) = 12 is gentler: 1/4 = 3/12 and 1/6 = 2/12, so 3/12 + 2/12 = 5/12, same answer with less clutter.\n\nHow to find an LCM: list multiples, or use prime factors and take the highest power of each prime that appears.")
        .Section("Mixed numbers: two trustworthy paths",
            "Path A, convert everything to improper fractions, add/subtract with a common denominator, convert back if you like a mixed answer.\nPath B, add (or subtract) whole parts and fraction parts separately; if fraction parts need regrouping (like 1/3 + 5/6 = 7/6), carry an extra whole into the whole-number part.\n\nBoth are correct. Improper fractions are often cleaner for multi-step work; separate wholes can feel more like money ($2 and a quarter plus $1 and a half).")
        .Section("Estimation and checking",
            "Before exact work, ask roughly: is 5/6 − 1/4 near 1 − 1/4 = 3/4, or a bit less? After computing, simplify and, when possible, convert to a mixed number to see if the size matches life: a sum of two proper fractions each less than 1 should be less than 2.")
        .Section("Subtraction special care",
            "Order matters: a/b − c/d is not the same as c/d − a/b. With mixed numbers, if the fraction part of the first is too small, regroup one whole into the denominator’s worth of pieces (for fourths, 1 = 4/4), the same spirit as borrowing in whole-number subtraction.")
        .Formula("Unlike denominators (addition)", @"\frac{a}{b}+\frac{c}{d}=\frac{ad+bc}{bd}", "Cross-scale numerators to denominator bd, then add; simplify at the end.")
        .Formula("Unlike denominators (subtraction)", @"\frac{a}{b}-\frac{c}{d}=\frac{ad-bc}{bd}", "Same common denominator bd; subtract the scaled numerators.")
        .Formula("LCM form (preferred when easy)", @"\frac{1}{4}+\frac{1}{6}=\frac{3}{12}+\frac{2}{12}=\frac{5}{12}", "Rewrite with LCM(4,6)=12 before adding, same value as the product formula with less bulk.")
        .Example("Same denominator: only the count changes",
            "Compute 1/5 + 2/5.",
            [
                "Thinking: both pieces are fifths, same size. Add how many fifths you have.",
                "Numerators: 1 + 2 = 3; keep denominator 5 → 3/5.",
                "Is 3/5 simplifiable? 3 and 5 share no common factor > 1. Done.",
                "Common mistake callout: writing 3/10 by adding denominators, or 1/2 by some other invented rule."
            ],
            "1/5 + 2/5 = 3/5.",
            problemLatex: @"\frac{1}{5}+\frac{2}{5}",
            solutionLatex: @"\frac{1}{5}+\frac{2}{5}=\frac{3}{5}",
            stepLatex: [null, @"\frac{1+2}{5}=\frac{3}{5}", null, null],
            closingLatex: @"\frac{3}{5}")
        .Example("Unlike denominators with LCM (and the product formula)",
            "Compute 1/4 + 1/6.",
            [
                "Thinking: fourths and sixths are different sizes. Need a common unit.",
                "LCM(4,6): multiples of 4 are 4,8,12,…; of 6 are 6,12,… so LCM = 12.",
                "Rewrite: 1/4 = 3/12 (×3/3), and 1/6 = 2/12 (×2/2).",
                "Add: 3/12 + 2/12 = 5/12.",
                "Product-formula check: (1·6 + 4·1)/(4·6) = (6+4)/24 = 10/24 = 5/12 after ÷2. Same answer. LCM just stayed smaller.",
                "Common mistake callout: 1/4 + 1/6 = 2/10, or adding only numerators to get 2/12 without scaling."
            ],
            "1/4 + 1/6 = 5/12.",
            problemLatex: @"\frac{1}{4}+\frac{1}{6}",
            solutionLatex: @"\frac{1}{4}+\frac{1}{6}=\frac{3}{12}+\frac{2}{12}=\frac{5}{12}",
            stepLatex:
            [
                null,
                @"\mathrm{LCM}(4,6)=12",
                @"\frac{1}{4}=\frac{3}{12},\;\frac{1}{6}=\frac{2}{12}",
                @"\frac{3+2}{12}=\frac{5}{12}",
                @"\frac{1\cdot 6+4\cdot 1}{4\cdot 6}=\frac{10}{24}=\frac{5}{12}",
                null
            ],
            closingLatex: @"\frac{5}{12}")
        .Example("Subtraction with LCM",
            "Compute 5/6 − 1/4.",
            [
                "Thinking: subtract only after both amounts are measured in the same piece size.",
                "LCM(6,4) = 12.",
                "5/6 = 10/12 (×2/2); 1/4 = 3/12 (×3/3).",
                "10/12 − 3/12 = 7/12.",
                "Product formula: (5·4 − 6·1)/(6·4) = (20−6)/24 = 14/24 = 7/12. Matches.",
                "Common mistake callout: 5/6 − 1/4 = 4/2, or 5−1 over 6−4 = 4/2, which destroys meaning."
            ],
            "5/6 − 1/4 = 7/12.",
            problemLatex: @"\frac{5}{6}-\frac{1}{4}",
            solutionLatex: @"\frac{5}{6}-\frac{1}{4}=\frac{10}{12}-\frac{3}{12}=\frac{7}{12}",
            stepLatex:
            [
                null,
                @"\mathrm{LCM}(6,4)=12",
                @"\frac{5}{6}=\frac{10}{12},\;\frac{1}{4}=\frac{3}{12}",
                @"\frac{10-3}{12}=\frac{7}{12}",
                @"\frac{5\cdot 4-6\cdot 1}{24}=\frac{14}{24}=\frac{7}{12}",
                null
            ],
            closingLatex: @"\frac{7}{12}")
        .Example("Mixed numbers: wholes and pieces",
            "Compute 2 1/3 + 1 1/2.",
            [
                "Thinking: add whole parts, then fraction parts with a common denominator.",
                "Wholes: 2 + 1 = 3.",
                "Fractions: 1/3 + 1/2; LCM(3,2) = 6 → 2/6 + 3/6 = 5/6.",
                "Combine: 3 + 5/6 = 3 5/6.",
                "Improper path check: 7/3 + 3/2 = (14+9)/6 = 23/6 = 3 5/6. Same.",
                "Common mistake callout: adding denominators (2 2/5) or forgetting to convert 1/3 and 1/2 before adding the fraction parts."
            ],
            "2 1/3 + 1 1/2 = 3 5/6.",
            problemLatex: @"2\frac{1}{3}+1\frac{1}{2}",
            solutionLatex: @"2\frac{1}{3}+1\frac{1}{2}=3\frac{5}{6}",
            stepLatex:
            [
                null,
                @"2+1=3",
                @"\frac{1}{3}+\frac{1}{2}=\frac{2}{6}+\frac{3}{6}=\frac{5}{6}",
                @"3+\frac{5}{6}=3\frac{5}{6}",
                @"\frac{7}{3}+\frac{3}{2}=\frac{23}{6}",
                null
            ],
            closingLatex: @"3\frac{5}{6}")
        .Mistake("Adding denominators along with numerators (1/2 + 1/3 ≠ 2/5). Denominators name size; you unify size first, then combine counts.")
        .Mistake("Finding a common denominator but forgetting to scale the numerators (writing 1/4 + 1/6 = 1/12 + 1/12).")
        .Mistake("Using the product formula correctly but never simplifying (leaving 10/24 instead of 5/12).")
        .Mistake("Subtracting the smaller numerator from the larger regardless of which fraction came first.")
        .Mistake("With mixed numbers, adding fraction parts that exceed 1 without regrouping into an extra whole.")
        .Mistake("Choosing a common denominator that is not a multiple of both denominators (e.g. using 8 for 1/6 + 1/4).")
        .Numeric("1/8 + 3/8. Answer as a/b simplified.", "1/2",
            [
                "Same denominator: add numerators 1 + 3 = 4; keep 8.",
                "4/8 simplifies by ÷4."
            ],
            "1/8 + 3/8 = 4/8 = 1/2.",
            tolerance: 0,
            explanationLatex: @"\frac{1}{8}+\frac{3}{8}=\frac{1}{2}")
        .Numeric("1/3 + 1/6. Answer as a/b simplified.", "1/2",
            [
                "LCM(3,6) = 6, so 1/3 = 2/6.",
                "2/6 + 1/6 = 3/6 = 1/2."
            ],
            "1/3 + 1/6 = 1/2.",
            tolerance: 0,
            explanationLatex: @"\frac{1}{3}+\frac{1}{6}=\frac{1}{2}")
        .Numeric("3/4 − 1/3. Answer as a/b.", "5/12",
            [
                "LCM(4,3) = 12.",
                "3/4 = 9/12 and 1/3 = 4/12; 9 − 4 = 5."
            ],
            "3/4 − 1/3 = 5/12. (Product form: (9 − 4)/12 = 5/12.)",
            tolerance: 0,
            explanationLatex: @"\frac{3}{4}-\frac{1}{3}=\frac{5}{12}")
        .Mcq("2/5 + 1/10 =",
            ["3/15", "1/2", "3/10", "2/10"], 1,
            [
                "Common denominator 10: 2/5 = 4/10.",
                "4/10 + 1/10 = 5/10 = 1/2."
            ],
            "2/5 + 1/10 = 1/2.",
            explanationLatex: @"\frac{2}{5}+\frac{1}{10}=\frac{1}{2}")
        .Numeric("5/12 + 1/4. Answer as a/b simplified.", "2/3",
            [
                "1/4 = 3/12.",
                "5/12 + 3/12 = 8/12 = 2/3."
            ],
            "5/12 + 1/4 = 8/12 = 2/3.",
            tolerance: 0,
            explanationLatex: @"\frac{5}{12}+\frac{1}{4}=\frac{2}{3}")
        .Numeric("2 1/4 + 1 1/4. Enter as mixed n m/d or improper.", "3 1/2",
            [
                "Wholes 2 + 1 = 3; fractions 1/4 + 1/4 = 2/4.",
                "2/4 = 1/2, so total 3 1/2."
            ],
            "Sum is 3 1/2.",
            tolerance: 0,
            explanationLatex: @"3\frac{1}{2}")
        .Mcq("Common denominator for 1/8 and 1/12 (least):",
            ["20", "24", "96", "4"], 1,
            [
                "LCM of 8 and 12, not merely a product if a smaller shared multiple exists.",
                "8 = 2³, 12 = 2²·3 → LCM = 2³·3 = 24."
            ],
            "LCM(8,12) = 24 is the least common denominator.")
        .Numeric("Using the product formula, a/b + c/d has denominator b·d. For 2/3 + 1/5, what is the unsimplified numerator ad+bc?", "13",
            [
                "Here a=2, b=3, c=1, d=5.",
                "ad + bc = 2·5 + 3·1 = 10 + 3."
            ],
            "Numerator is 13, denominator 15, so 2/3 + 1/5 = 13/15.",
            tolerance: 0,
            explanationLatex: @"\frac{2}{3}+\frac{1}{5}=\frac{13}{15}")
        .Build();

    private static Lesson MultiplyDivideFractions() => new LessonBuilder("frac-muldiv", CategoryId, "Multiplying & Dividing Fractions")
        .Subtitle("Of means multiply; dividing is asking how many groups, via reciprocals")
        .Order(3).Minutes("32 min")
        .Section("Multiplying is different from adding (and that is a gift)",
            "When you multiply fractions, you do not need a common denominator. Multiplication answers a different question than addition. Addition combines amounts of the same type of piece. Multiplication often means “a fraction of a fraction” or “scale this amount.”\n\nThe rule is clean: multiply numerators, multiply denominators:\n\n(a/b)·(c/d) = (a·c)/(b·d).\n\nWhy? Taking c/d of something means “split into d equal parts and take c of them.” Applying that to a/b shrinks (or scales) both the “how many” and the “how fine” in a way that multiplies tops and bottoms.")
        .Section("“Of” means multiply",
            "English is a clue: “1/2 of 3/4” is (1/2)·(3/4) = 3/8. Half of three-fourths is three-eighths, a smaller piece of the bar.\n\nWhole numbers are fractions with denominator 1: 5 = 5/1. So 6 · (2/3) = (6/1)·(2/3) = 12/3 = 4. Story: six groups of two-thirds, or two-thirds of six, both give 4.",
            simple: "If this feels confusing, replace “of” with “×” every time you see it in a fraction word problem. “Half of twelve” is (1/2)×12.",
            prior: "Area models and arrays from whole-number multiplication still apply: a fraction times a fraction can be pictured as a shaded rectangle inside a unit square.")
        .Section("Cancel (simplify) before you multiply",
            "You may divide out common factors that appear in any numerator and any denominator before multiplying. That is legal because multiplication is commutative, factors can be regrouped. Canceling early keeps numbers small and reduces simplifying mistakes at the end.\n\nExample: (2/3)·(3/5): the 3 in the top and bottom cancel, leaving (2/1)·(1/5) = 2/5.")
        .Section("Division: how many of these fit into that?",
            "Dividing by a fraction asks how many groups of that size fit into the starting amount. Classic: 3 ÷ (1/4) asks how many fourths fit into 3 wholes, answer 12.\n\nThe computational rule: multiply by the reciprocal. The reciprocal of c/d (c ≠ 0) is d/c, flip top and bottom.\n\n(a/b) ÷ (c/d) = (a/b)·(d/c).\n\nMemory phrase: Keep-Change-Flip (keep the first fraction, change ÷ to ×, flip the second). The phrase is fine if you remember why: dividing by c/d is the same as multiplying by how many times c/d fits into 1, which is d/c.")
        .Section("Why the reciprocal works (intuition)",
            "Start with a whole number case: 6 ÷ 2 = 3, and 6 · (1/2) = 3. Dividing by 2 is multiplying by 1/2, the reciprocal of 2. For a general fraction c/d, the reciprocal d/c plays the same role: it undoes multiplication by c/d because (c/d)·(d/c) = 1.\n\nSo “÷ (c/d)” is the inverse operation of “× (c/d),” and inverse of multiplying by a number is multiplying by its reciprocal.")
        .Section("Mixed numbers and multi-step caution",
            "Convert mixed numbers to improper fractions before multiplying or dividing. Trying to “multiply wholes and fractions separately” usually fails (2 1/2 × 1 1/3 is not 2×1 with a separate 1/2×1/3).\n\nAlso: never cross-multiply when the operation is multiplication of two fractions. Cross-multiplying is a comparing/equation tool, not a product algorithm.")
        .Section("Sense checks",
            "Multiplying by a proper fraction (between 0 and 1) makes a positive amount smaller. Dividing by a proper fraction makes a positive amount larger (more groups fit). If your answer fights that sense, recheck the reciprocal flip.")
        .Formula("Product", @"\frac{a}{b}\cdot\frac{c}{d}=\frac{ac}{bd}", "Multiply across; cancel common factors early when you can.")
        .Formula("Quotient", @"\frac{a}{b}\div\frac{c}{d}=\frac{a}{b}\cdot\frac{d}{c}", "Multiply by the reciprocal of the divisor.")
        .Formula("Reciprocal", @"\frac{c}{d}\cdot\frac{d}{c}=1\;(c,d\neq 0)", "Reciprocals multiply to 1, that is why division becomes multiplication.")
        .Example("Multiply and cancel",
            "Compute 2/3 × 3/5.",
            [
                "Thinking: product means multiply across, but cancel shared factors first to stay neat.",
                "See a 3 in a numerator and a 3 in a denominator, cancel: 2/1 × 1/5.",
                "Multiply: 2/5.",
                "Without canceling: 6/15 = 2/5 after ÷3. Same result.",
                "Common mistake callout: cross-multiplying to get 10/9, which would be for a different problem structure (proportion)."
            ],
            "2/3 × 3/5 = 2/5.",
            problemLatex: @"\frac{2}{3}\times\frac{3}{5}",
            solutionLatex: @"\frac{2}{3}\times\frac{3}{5}=\frac{2}{5}",
            stepLatex: [null, @"\frac{2}{1}\times\frac{1}{5}", @"\frac{2}{5}", @"\frac{6}{15}=\frac{2}{5}", null],
            closingLatex: @"\frac{2}{5}")
        .Example("Whole number times a fraction",
            "Compute 6 × 2/3.",
            [
                "Thinking: 6 = 6/1, or think “six groups of two-thirds,” or “two-thirds of six.”",
                "Write (6/1)·(2/3) = 12/3.",
                "12/3 = 4.",
                "Cancel path: 6 and 3 share a factor 3 → (2/1)·(2/1) = 4.",
                "Common mistake callout: adding to get 6 2/3, or doing 6×2 / 6×3."
            ],
            "6 × 2/3 = 4.",
            problemLatex: @"6\times\frac{2}{3}",
            solutionLatex: @"6\times\frac{2}{3}=4",
            stepLatex: [null, @"\frac{6}{1}\cdot\frac{2}{3}=\frac{12}{3}", @"4", null, null],
            closingLatex: @"4")
        .Example("Divide by a fraction: how many halves?",
            "Compute 3/4 ÷ 1/2.",
            [
                "Thinking: how many halves fit into three-fourths? A bit more than one.",
                "Keep 3/4, change to ×, flip 1/2 → 2/1.",
                "(3/4)·(2/1) = 6/4 = 3/2.",
                "3/2 = 1 1/2, which matches the “one and a half halves fit” story.",
                "Common mistake callout: flipping the first fraction (2/3 × 1/2), or dividing numerators and denominators separately as 3÷1 over 4÷2 without care (sometimes works by accident)."
            ],
            "3/4 ÷ 1/2 = 3/2.",
            problemLatex: @"\frac{3}{4}\div\frac{1}{2}",
            solutionLatex: @"\frac{3}{4}\div\frac{1}{2}=\frac{3}{2}",
            stepLatex: [null, @"\frac{3}{4}\times\frac{2}{1}", @"\frac{6}{4}=\frac{3}{2}", null, null],
            closingLatex: @"\frac{3}{2}")
        .Example("Harder division with canceling",
            "Compute 5/6 ÷ 10/9.",
            [
                "Thinking: multiply by the reciprocal of 10/9, which is 9/10.",
                "Write (5/6)·(9/10).",
                "Cancel 5 with 10 (factor 5): (1/6)·(9/2) = 9/12.",
                "Simplify 9/12 by ÷3: 3/4.",
                "Sense check: 10/9 is a bit more than 1, so dividing by it should shrink 5/6 a little, 3/4 = 0.75, and 5/6 ≈ 0.83, sensible.",
                "Common mistake callout: flipping both fractions, or canceling across an addition if you had mixed the problem with adding."
            ],
            "5/6 ÷ 10/9 = 3/4.",
            problemLatex: @"\frac{5}{6}\div\frac{10}{9}",
            solutionLatex: @"\frac{5}{6}\div\frac{10}{9}=\frac{3}{4}",
            stepLatex:
            [
                null,
                @"\frac{5}{6}\times\frac{9}{10}",
                @"\frac{1}{6}\times\frac{9}{2}=\frac{9}{12}",
                @"\frac{9}{12}=\frac{3}{4}",
                null,
                null
            ],
            closingLatex: @"\frac{3}{4}")
        .Mistake("Cross-multiplying when the operation is multiplying two fractions (cross-multiply is for comparing or solving proportions).")
        .Mistake("When dividing, flipping the first fraction instead of the second (the divisor).")
        .Mistake("Forgetting to take a reciprocal at all and treating ÷ like ×.")
        .Mistake("Multiplying mixed numbers by handling whole and fractional parts separately instead of converting to improper fractions.")
        .Mistake("Canceling terms that are added, not factored (you may only cancel common factors in products).")
        .Mistake("Expecting a product of two proper fractions to be larger than both factors.")
        .Numeric("2/5 × 3/4 as a/b simplified.", "3/10",
            [
                "Multiply: 6/20.",
                "Simplify by ÷2, or cancel a factor of 2 before multiplying."
            ],
            "2/5 × 3/4 = 6/20 = 3/10.",
            tolerance: 0,
            explanationLatex: @"\frac{2}{5}\times\frac{3}{4}=\frac{3}{10}")
        .Numeric("1/2 of 5/6 as a/b.", "5/12",
            [
                "“Of” means multiply: (1/2)×(5/6).",
                "Numerator 5, denominator 12."
            ],
            "1/2 × 5/6 = 5/12.",
            tolerance: 0,
            explanationLatex: @"\frac{1}{2}\times\frac{5}{6}=\frac{5}{12}")
        .Numeric("4/5 ÷ 2/3 as a/b simplified.", "6/5",
            [
                "Multiply by reciprocal: (4/5)×(3/2).",
                "12/10 = 6/5."
            ],
            "4/5 ÷ 2/3 = 6/5.",
            tolerance: 0,
            explanationLatex: @"\frac{4}{5}\div\frac{2}{3}=\frac{6}{5}")
        .Numeric("3 ÷ 1/4 (how many fourths in 3)?", "12",
            [
                "Dividing by 1/4 is multiplying by 4.",
                "3 × 4 = 12."
            ],
            "Three wholes contain twelve fourths.",
            tolerance: 0,
            explanationLatex: @"3\div\frac{1}{4}=12")
        .Mcq("2/3 × 9/10 =",
            ["18/30", "3/5", "11/13", "2/10"], 1,
            [
                "Cancel a factor of 3: 2/1 × 3/10.",
                "6/10 = 3/5 in lowest terms."
            ],
            "After canceling and simplifying, the product is 3/5.",
            explanationLatex: @"\frac{2}{3}\times\frac{9}{10}=\frac{3}{5}")
        .Numeric("5/8 ÷ 5/6 as a/b simplified.", "3/4",
            [
                "(5/8)×(6/5); cancel the 5s.",
                "6/8 = 3/4."
            ],
            "5/8 ÷ 5/6 = 3/4.",
            tolerance: 0,
            explanationLatex: @"\frac{5}{8}\div\frac{5}{6}=\frac{3}{4}")
        .Mcq("Reciprocal of 7/2 is:",
            ["2/7", "7/2", "-7/2", "1/7"], 0,
            [
                "Swap numerator and denominator.",
                "Check: (7/2)·(2/7) should equal 1."
            ],
            "The reciprocal of 7/2 is 2/7.")
        .Numeric("2 1/2 × 1 1/5 as an improper fraction a/b or mixed.", "3",
            [
                "Convert: 5/2 × 6/5.",
                "Cancel 5s: 1/2 × 6/1 = 6/2 = 3."
            ],
            "2 1/2 × 1 1/5 = 3.",
            tolerance: 0,
            explanationLatex: @"\frac{5}{2}\times\frac{6}{5}=3")
        .Build();

    private static Lesson Decimals() => new LessonBuilder("frac-decimals", CategoryId, "Decimals: Operations & Conversions")
        .Subtitle("Tenths and hundredths are fractions in disguise, with place-value power")
        .Order(4).Minutes("30 min")
        .Section("Decimals are fractions with denominators 10, 100, 1000, …",
            "A decimal like 0.47 is not a mysterious second number system. It is a compact way to write 4 tenths + 7 hundredths, which is 47/100. The decimal point marks the ones place on its left; every step right is one-tenth as large as the place to its left, the same base-ten idea as whole numbers, continued past ones.\n\nThat is why decimals plug so smoothly into money ($0.47), metrics, and calculators: they inherit place value.")
        .Section("Reading place value to the right of the point",
            "Places after the decimal: tenths (0.1), hundredths (0.01), thousandths (0.001), and so on. The number 0.306 is 3 tenths + 0 hundredths + 6 thousandths = 306/1000 after clearing the idea of “empty” hundredths.\n\nTrailing zeros after the decimal can be added without changing value (3.6 = 3.60 = 3.600) because you are writing 36/10 = 360/100, equivalent fractions. Leading zeros before a whole number do not change it either, but zeros between the point and a digit do matter: 0.03 is not 0.3.",
            simple: "If this feels confusing, read the digits after the point as a whole number over 10, 100, or 1000 depending on how many digits you used: 0.47 → forty-seven hundredths.",
            prior: "Whole-number place value from arithmetic is the left side of the same chart; decimals are the right side continuing the ×1/10 pattern.")
        .Section("Adding and subtracting: line up the points",
            "Align decimal points so tenths sit under tenths and hundredths under hundredths, that is place value, not a fashion choice. Fill trailing zeros if it helps you see columns (3.6 + 2.45 → 3.60 + 2.45). Add or subtract as whole numbers, then bring the decimal point straight down into the answer.\n\nMisalignment (lining up rightmost digits like whole numbers without caring about the point) is the classic error: 3.6 + 2.45 is not 2.81 from stacking 36 over 245 wrong.")
        .Section("Multiplying decimals",
            "Multiply as if the numbers were whole numbers, then place the decimal in the product so that the number of digits to the right of the point equals the total number of decimal digits in the factors.\n\nWhy? 0.6 × 0.4 = (6/10)·(4/10) = 24/100 = 0.24, two decimal digits because each factor contributed a factor of 10 in the denominator. Counting decimal places is counting those tens in the denominator.",
            @"0.6\times 0.4=0.24")
        .Section("Dividing decimals",
            "A clean method: make the divisor a whole number by moving its decimal point right enough places, and move the dividend’s point the same number of places (equivalent to multiplying top and bottom by the same power of 10). Then divide.\n\nExample: 4.8 ÷ 0.2 → move one place → 48 ÷ 2 = 24. You did not change the quotient because you scaled dividend and divisor equally.")
        .Section("Fraction to decimal and terminating vs repeating",
            "To convert a fraction to a decimal, divide numerator by denominator. Some fractions terminate (1/4 = 0.25, 3/8 = 0.375) because the denominator’s primes (after simplifying) are only 2s and/or 5s, factors of powers of 10. Others repeat (1/3 = 0.333…, 1/6 = 0.1666…). Recognizing both types builds number sense for later algebra and percentages.")
        .Section("Estimation habits",
            "Before exact work: 1.9 × 3.1 is near 2 × 3 = 6. After work, compare. If you get 0.58 for that product, you likely misplaced the decimal.")
        .Formula("Decimal meaning", @"0.d_1 d_2 d_3=\frac{d_1}{10}+\frac{d_2}{100}+\frac{d_3}{1000}", "Expand by place value, decimals are sums of tenths, hundredths, thousandths.")
        .Formula("Fraction form", @"0.47=\frac{47}{100}", "As many zeros in the denominator as digits after the point (for a terminating decimal).")
        .Formula("Product places", @"\text{decimal digits in product}=\text{sum of digits in factors}", "From multiplying denominators that are powers of 10.")
        .Example("Add with aligned places",
            "Compute 3.6 + 2.45.",
            [
                "Thinking: line up points; write 3.60 so hundredths match.",
                "Hundredths: 0 + 5 = 5; tenths: 6 + 4 = 10 → write 0, carry 1 one; ones: 3 + 2 + 1 = 6.",
                "Sum 6.05.",
                "Estimate: about 3.5 + 2.5 = 6, matches.",
                "Common mistake callout: treating as 36 + 245 or aligning right edges to get 2.81."
            ],
            "3.6 + 2.45 = 6.05.",
            problemLatex: @"3.6+2.45",
            solutionLatex: @"3.60+2.45=6.05",
            stepLatex: [@"3.60+2.45", null, @"6.05", null, null],
            closingLatex: @"6.05")
        .Example("Multiply and count places",
            "Compute 1.2 × 0.3.",
            [
                "Thinking: ignore points briefly, 12 × 3 = 36.",
                "1.2 has one decimal digit; 0.3 has one; total two digits in the product.",
                "36 with two decimal places is 0.36.",
                "Fraction check: (12/10)·(3/10) = 36/100 = 0.36.",
                "Common mistake callout: writing 3.6 or 36 by undercounting places."
            ],
            "1.2 × 0.3 = 0.36.",
            problemLatex: @"1.2\times 0.3",
            solutionLatex: @"1.2\times 0.3=0.36",
            stepLatex: [@"12\times 3=36", null, @"0.36", @"\frac{36}{100}", null],
            closingLatex: @"0.36")
        .Example("Divide by moving points together",
            "Compute 4.8 ÷ 0.2.",
            [
                "Thinking: divisor 0.2 should become whole; move point 1 place → 2.",
                "Move dividend’s point 1 place the same way: 4.8 → 48.",
                "48 ÷ 2 = 24.",
                "Meaning: how many 0.2s fit into 4.8? Twenty-four of them.",
                "Common mistake callout: moving only one point, or dividing 4.8 by 2 to get 2.4 without fixing the divisor."
            ],
            "4.8 ÷ 0.2 = 24.",
            problemLatex: @"4.8\div 0.2",
            solutionLatex: @"4.8\div 0.2=24",
            stepLatex: [null, @"48\div 2", @"24", null, null],
            closingLatex: @"24")
        .Example("Fraction to decimal by division",
            "Convert 3/8 to a decimal.",
            [
                "Thinking: divide 3 ÷ 8. Write 3.000 because we need decimal places.",
                "8 into 30 is 3 times (24), remainder 6.",
                "Bring down 0 → 60; 8 into 60 is 7 (56), remainder 4.",
                "Bring down 0 → 40; 8 into 40 is 5 exactly.",
                "Digits after the point: 375, so 0.375.",
                "Common mistake callout: stopping at 0.3 or 0.37, or writing 3.8."
            ],
            "3/8 = 0.375 (terminates because 8 = 2³).",
            problemLatex: @"\frac{3}{8}",
            solutionLatex: @"\frac{3}{8}=0.375",
            stepLatex: [@"3\div 8", null, null, null, @"0.375", null],
            closingLatex: @"0.375")
        .Mistake("Aligning decimals by the last digit instead of by the decimal point when adding or subtracting.")
        .Mistake("Miscounting decimal places in a product (especially with factors like 0.10 that look “small”).")
        .Mistake("Moving the decimal in only the divisor or only the dividend when dividing.")
        .Mistake("Reading 0.03 as “three tenths” instead of “three hundredths.”")
        .Mistake("Assuming every fraction becomes a short terminating decimal (1/3 does not).")
        .Mistake("Dropping zeros that hold place (treating 0.40 × 2 as if it had one decimal place total incorrectly).")
        .Numeric("3.25 + 1.4", "4.65",
            [
                "Write 1.40 under 3.25 with points aligned.",
                "Add by place: 3.25 + 1.40."
            ],
            "Sum is 4.65.",
            explanationLatex: @"4.65")
        .Numeric("5 − 2.75", "2.25",
            [
                "Write 5 as 5.00.",
                "Subtract: 5.00 − 2.75."
            ],
            "Difference is 2.25.",
            explanationLatex: @"2.25")
        .Numeric("0.6 × 0.5", "0.3",
            [
                "6 × 5 = 30 with two decimal places → 0.30.",
                "0.30 = 0.3."
            ],
            "0.6 × 0.5 = 0.3.",
            tolerance: 0.001,
            explanationLatex: @"0.3")
        .Numeric("7.2 ÷ 0.8", "9",
            [
                "Move both points one place: 72 ÷ 8.",
                "72 ÷ 8 = 9."
            ],
            "7.2 ÷ 0.8 = 9.",
            explanationLatex: @"9")
        .Mcq("0.03 means:",
            ["3 tenths", "3 hundredths", "3 thousandths", "3 ones"], 1,
            [
                "Count digits after the decimal point.",
                "Two places → hundredths."
            ],
            "0.03 is 3 hundredths (3/100).")
        .Numeric("Convert 1/4 to a decimal.", "0.25",
            [
                "Divide 1 ÷ 4.",
                "4 into 10 is 2 remainder 2; then 20 ÷ 4 = 5."
            ],
            "1/4 = 0.25.",
            explanationLatex: @"0.25")
        .Numeric("2.5 × 4", "10",
            [
                "25 × 4 = 100 with one decimal place → 10.0.",
                "Or 2.5 × 4 = 10."
            ],
            "2.5 × 4 = 10.",
            explanationLatex: @"10")
        .Numeric("Write 0.125 as a fraction a/b in lowest terms.", "1/8",
            [
                "0.125 = 125/1000.",
                "Divide top and bottom by 125: 1/8."
            ],
            "0.125 = 1/8.",
            tolerance: 0,
            explanationLatex: @"0.125=\frac{1}{8}")
        .Build();

    private static Lesson Conversions() => new LessonBuilder("frac-convert", CategoryId, "Fractions ↔ Decimals ↔ Percentages")
        .Subtitle("Three languages for the same part-to-whole idea")
        .Order(5).Minutes("30 min")
        .Section("The big idea: one amount, three dialects",
            "A fraction, a decimal, and a percent can all name the same location on the number line, the same part of a whole. 1/2, 0.5, and 50% are not three different quantities; they are three notations for “half.”\n\nWhy bother with all three? Fractions are exact and natural for ratios; decimals are perfect for place-value calculation and money; percents are the language of “out of 100” used in stores, news, sports, and science. Fluent conversion means you can pick the representation that makes the next step easiest.")
        .Section("Percent means per hundred",
            "The word percent comes from Latin ideas of “per hundred.” So p% means p per 100, which is the fraction p/100 and the decimal p ÷ 100.\n\nExamples: 35% = 35/100 = 0.35; 8% = 8/100 = 0.08; 150% = 150/100 = 1.5 (more than one whole). Percents can exceed 100% when you describe growth or multiples of a whole.")
        .Section("Conversion recipes you can trust",
            "• Fraction → decimal: divide numerator by denominator.\n• Decimal → percent: multiply by 100 (move the point two places right). 0.125 → 12.5%.\n• Percent → decimal: divide by 100 (move the point two places left). 8% → 0.08.\n• Fraction → percent: convert to decimal then to percent, or build an equivalent fraction with denominator 100 when easy (3/5 = 60/100 = 60%).\n• Percent → fraction: write p/100 and simplify.\n\nThe “two places” rule works because percent is always tied to hundredths.",
            simple: "If this feels confusing: percent ↔ decimal is just sliding the decimal point two steps, right to get a percent display, left to get a decimal for calculating.",
            prior: "You already convert fractions to decimals by dividing (previous lesson). Percent is that decimal written “per 100.”")
        .Section("Benchmark conversions worth memorizing",
            "Instant fluency pays off forever:\n• 1/2 = 0.5 = 50%\n• 1/4 = 0.25 = 25%\n• 3/4 = 0.75 = 75%\n• 1/5 = 0.2 = 20%\n• 1/10 = 0.1 = 10%\n• 1/3 ≈ 0.333… ≈ 33 1/3%\n• 1/8 = 0.125 = 12.5%\n\nBenchmarks let you estimate: 48% of a number is a little under half; 9% is near one-tenth.")
        .Section("Tricky spots: tiny percents and big percents",
            "0.5% is not 0.5. Half of one percent is 0.5 ÷ 100 = 0.005. Conversely, 200% of a number is twice the number. Students often treat the % symbol as optional decoration, it is not; it always means “÷100 when you need a pure number for multiplying.”")
        .Section("Choosing the smart form mid-problem",
            "To take 25% of 80, you can do 0.25×80 or (1/4)×80, the fraction form is faster mentally. To compare 3/8 and 40%, convert both to decimals (0.375 vs 0.40) or both to percents (37.5% vs 40%). Same amount, best packaging for the job.")
        .Section("Connecting back to equivalent fractions",
            "Writing 45% as 45/100 and simplifying to 9/20 is exactly the equivalent-fraction skill from Lesson 1. Writing 3/5 as 60/100 to see 60% is scaling by 20/20. Conversions are not a new island, they reuse equivalence and place value.")
        .Formula("Percent definition", @"p\%=\frac{p}{100}", "Percent is a fraction with denominator 100.")
        .Formula("Decimal to percent", @"0.ab=(100\cdot 0.ab)\%", "Multiply by 100; move the point two places right.")
        .Formula("Percent to decimal", @"k\%=\frac{k}{100}", "Divide by 100; move the point two places left.")
        .Example("Fraction to percent two ways",
            "Convert 3/5 to a percent.",
            [
                "Thinking: percent wants “out of 100,” or decimal then ×100.",
                "Path A: 3÷5 = 0.6; 0.6×100 = 60%.",
                "Path B: 3/5 = 60/100 (×20/20), which is 60% by definition.",
                "Both paths agree, use whichever is faster for the numbers you have.",
                "Common mistake callout: saying 3/5 = 3.5% or 15% by mixing numerator and denominator incorrectly."
            ],
            "3/5 = 60%.",
            problemLatex: @"\frac{3}{5}",
            solutionLatex: @"\frac{3}{5}=60\%",
            stepLatex: [null, @"0.6\times 100=60\%", @"\frac{3}{5}=\frac{60}{100}", null, null],
            closingLatex: @"60\%")
        .Example("Percent to simplified fraction",
            "Write 45% as a simplified fraction.",
            [
                "Thinking: percent → fraction over 100, then simplify with GCF.",
                "45% = 45/100.",
                "GCF(45,100) = 5; 45÷5 = 9, 100÷5 = 20.",
                "9/20 is lowest terms (9 and 20 share no common factor > 1).",
                "Common mistake callout: writing 45/100 and stopping, or simplifying to 9/10 by dividing only the numerator wrongly."
            ],
            "45% = 9/20.",
            problemLatex: @"45\%",
            solutionLatex: @"45\%=\frac{9}{20}",
            stepLatex: [null, @"\frac{45}{100}", @"\frac{45\div 5}{100\div 5}=\frac{9}{20}", null, null],
            closingLatex: @"\frac{9}{20}")
        .Example("Decimal to percent",
            "Write 0.125 as a percent.",
            [
                "Thinking: multiply by 100 to convert decimal → percent.",
                "0.125 × 100 = 12.5.",
                "So 0.125 = 12.5%.",
                "Fraction path: 0.125 = 125/1000 = 1/8, and 1/8 = 12.5% as a benchmark.",
                "Common mistake callout: writing 0.125% or 125% by moving the point the wrong number of places."
            ],
            "0.125 = 12.5%.",
            problemLatex: @"0.125",
            solutionLatex: @"0.125=12.5\%",
            stepLatex: [null, @"0.125\times 100=12.5", @"12.5\%", null, null],
            closingLatex: @"12.5\%")
        .Example("Percent to decimal (including a small percent mindset)",
            "Write 8% as a decimal.",
            [
                "Thinking: divide by 100, move point two left.",
                "8% → start with 8.0, move two left → 0.08.",
                "Check: 8/100 = 0.08.",
                "Contrast: 0.8 would be 80%, not 8%. Zeros matter.",
                "Common mistake callout: writing 0.8 or 8.0 as the decimal form of 8%."
            ],
            "8% = 0.08.",
            problemLatex: @"8\%",
            solutionLatex: @"8\%=0.08",
            stepLatex: [null, @"8\div 100=0.08", null, null, null],
            closingLatex: @"0.08")
        .Mistake("Writing 0.5% as 0.5 instead of 0.005 (forgetting that % still means ÷100).")
        .Mistake("Moving the decimal the wrong direction when converting percent ↔ decimal.")
        .Mistake("Treating 150% as 0.150 or 15% instead of 1.5.")
        .Mistake("Leaving percent-fraction conversions unsimplified when lowest terms are expected.")
        .Mistake("Confusing “percent of” setup with conversion (conversion does not multiply by a second quantity yet).")
        .Mistake("Assuming 1/3 = 33% exactly without noting the repeating 1/3% remainder in precise work.")
        .Numeric("Convert 1/2 to a percent (number only, e.g. 50).", "50",
            [
                "1÷2 = 0.5.",
                "0.5 × 100 = 50 → 50%."
            ],
            "1/2 = 50%.",
            explanationLatex: @"50\%")
        .Numeric("Convert 0.4 to a percent (number only).", "40",
            [
                "Multiply by 100.",
                "0.4 × 100 = 40."
            ],
            "0.4 = 40%.",
            explanationLatex: @"40\%")
        .Numeric("Convert 25% to a decimal.", "0.25",
            [
                "Divide by 100.",
                "25 ÷ 100 = 0.25."
            ],
            "25% = 0.25.",
            explanationLatex: @"0.25")
        .Numeric("Convert 20% to a fraction a/b simplified.", "1/5",
            [
                "20% = 20/100.",
                "Divide by 20: 1/5."
            ],
            "20% = 1/5.",
            tolerance: 0,
            explanationLatex: @"20\%=\frac{1}{5}")
        .Mcq("7/10 as a percent is:",
            ["7%", "70%", "0.7%", "700%"], 1,
            [
                "7/10 = 0.7.",
                "0.7 × 100 = 70."
            ],
            "7/10 = 70%.",
            explanationLatex: @"\frac{7}{10}=70\%")
        .Numeric("Write 0.03 as a percent (number only).", "3",
            [
                "0.03 × 100 = 3.",
                "So 3%."
            ],
            "0.03 = 3%.",
            explanationLatex: @"3\%")
        .Mcq("Which equals 150%?",
            ["1.5", "0.15", "15", "0.015"], 0,
            [
                "150 ÷ 100 = 1.5.",
                "Percents over 100 represent more than one whole."
            ],
            "150% = 1.5.",
            explanationLatex: @"150\%=1.5")
        .Numeric("Convert 3/8 to a percent (number only; may include decimal).", "37.5",
            [
                "3÷8 = 0.375.",
                "0.375 × 100 = 37.5."
            ],
            "3/8 = 37.5%.",
            tolerance: 0.01,
            explanationLatex: @"37.5\%")
        .Build();

    private static Lesson PercentWordProblems() => new LessonBuilder("frac-percent-apps", CategoryId, "Percentage Word Problems & Applications")
        .Subtitle("Discounts, tax, tips, percent change, real uses of “parts per hundred”")
        .Order(6).Minutes("34 min")
        .Section("What percent problems are really asking",
            "Almost every percent word problem is one of a few structures:\n• Find p% of N (part = rate × whole).\n• Find what percent one number is of another (rate = part ÷ whole).\n• Find the whole when you know a percent of it.\n• Change a quantity by a percent (increase/decrease, tax, discount, markup).\n\nIf you can translate the English into “part,” “whole,” and “rate,” the arithmetic becomes a short calculation, usually a multiplication or a division by the original amount.")
        .Section("Percent of a number: the core formula",
            "To find p% of N, convert the percent to a decimal or fraction, then multiply:\n\np% of N = (p/100) × N.\n\nExample: 15% of 80 = 0.15 × 80 = 12. Mentally, 10% of 80 is 8, so 5% is 4, and 15% is 12, benchmarks speed you up.",
            @"p\% \text{ of } N=\frac{p}{100}N",
            simple: "If this feels confusing: turn the percent into a plain number first (15% → 0.15), then multiply by the quantity. The % sign never multiplies as if it were still “15.”",
            prior: "Conversions lesson: p% = p/100 = decimal. This lesson only multiplies that rate by a real-world amount.")
        .Section("Discounts, tax, and tips: pay a percent of the price",
            "Discount of r% off means you pay (100 − r)% of the original, or equivalently original − (r% of original). A 20% off coupon on $40: pay 80% → 0.80 × 40 = 32, or save 0.20 × 40 = 8 and pay 32.\n\nSales tax or tip of r% means you pay (100 + r)% of the pre-tax amount. Tax 8% on $50: total 1.08 × 50 = 53.\n\nUsing a single multiplier (0.80 or 1.08) is efficient and reduces “I subtracted the tax instead of adding” errors.")
        .Section("Percent increase and decrease",
            "If a quantity grows by rate r (as a decimal), new = original × (1 + r). If it shrinks by rate r, new = original × (1 − r).\n\nPopulation 200 grows 15%: 1.15 × 200 = 230. Price 90 falls 10%: 0.90 × 90 = 81.\n\nImportant: successive percent changes do not simply add when they chain. 10% off then another 10% off is not 20% off total, the second 10% applies to the already-reduced price.")
        .Section("Percent change: always compare to the original base",
            "Percent change = ((new − old) / old) × 100%.\n\nThe base in the denominator is almost always the original (starting) amount. From 50 to 60: change 10, base 50, 10/50 × 100% = 20% increase. Using 60 in the denominator is a different question (“what percent less is 50 than 60?”) and is a common mix-up on tests.",
            @"\frac{\text{new}-\text{old}}{\text{old}}\times 100\%")
        .Section("“What percent of A is B?” and finding the whole",
            "“What percent of 50 is 20?” means (20/50)×100% = 40%. Part over whole, then ×100.\n\n“12 is 30% of what number?” means 0.30 × N = 12, so N = 12/0.30 = 40. Knowing when to multiply and when to divide is the heart of setup.")
        .Section("Units, money, and reasonableness",
            "Keep dollar signs and units clear: tip amount vs total bill are different answers. Estimate: 18% tip on $40 is a bit under 0.20 × 40 = $8. If you compute $72, you likely multiplied wrong or treated 18 as dollars. Always ask whether your answer should be smaller or larger than the original amount.")
        .Formula("Percent of", @"p\% \text{ of } N=\frac{p}{100}N", "Core formula: rate as a decimal (or fraction) times the whole.")
        .Formula("Percent change", @"\frac{\text{new}-\text{old}}{\text{old}}\times 100\%", "Signed: positive means increase, negative means decrease; base is the original.")
        .Formula("After change", @"N_{\text{new}}=N(1\pm r)", "Use + for increase/tax/markup; − for decrease/discount.")
        .Example("Discount two ways",
            "A $40 shirt is 25% off. What is the sale price?",
            [
                "Thinking: 25% off means pay 75% of $40, or subtract 25% of $40 from $40.",
                "Save: 0.25 × 40 = 10 dollars off.",
                "Sale price: 40 − 10 = 30.",
                "Single multiplier: 0.75 × 40 = 30. Same answer, one multiply.",
                "Common mistake callout: answering $10 (the discount) when the question asked for sale price; or doing 40 − 25 = 15 by treating percent as dollars."
            ],
            "Sale price is $30.",
            problemLatex: @"25\% \text{ off of } 40",
            solutionLatex: @"0.75\times 40=30",
            stepLatex: [null, @"0.25\times 40=10", @"40-10=30", @"0.75\times 40=30", null],
            closingLatex: @"30")
        .Example("Tax on a purchase",
            "An item costs $50 before tax. Tax is 6%. What is the total?",
            [
                "Thinking: total = original + tax, or original × 1.06.",
                "Tax amount: 0.06 × 50 = 3.",
                "Total: 50 + 3 = 53.",
                "Multiplier: 1.06 × 50 = 53.",
                "Common mistake callout: multiplying by 0.6 (confusing 6% with 60%), or subtracting tax."
            ],
            "Total is $53.",
            problemLatex: @"50\times(1+0.06)",
            solutionLatex: @"1.06\times 50=53",
            stepLatex: [null, @"0.06\times 50=3", @"50+3=53", @"1.06\times 50=53", null],
            closingLatex: @"53")
        .Example("What percent is one number of another?",
            "What percent of 50 is 20?",
            [
                "Thinking: part ÷ whole × 100%. Here part = 20, whole = 50.",
                "20/50 = 0.4.",
                "0.4 × 100 = 40, so 40%.",
                "Sense: 20 is a bit under half of 50, so near 40% not 20% or 50%.",
                "Common mistake callout: computing 50/20 = 2.5 and calling it 2.5%, or 250% without relating to the question’s wording."
            ],
            "20 is 40% of 50.",
            problemLatex: @"\frac{20}{50}\times 100\%",
            solutionLatex: @"40\%",
            stepLatex: [null, @"\frac{20}{50}=0.4", @"0.4\times 100=40", null, null],
            closingLatex: @"40\%")
        .Example("Percent increase with the multiplier",
            "A population of 200 grows by 15%. What is the new size?",
            [
                "Thinking: growth of 15% → multiply by 1.15, not by 0.15 alone (that would only be the change).",
                "Change amount: 0.15 × 200 = 30.",
                "New: 200 + 30 = 230.",
                "Or 1.15 × 200 = 230 in one step.",
                "Common mistake callout: answering 30 (the increase only) when asked for new size; or multiplying by 15."
            ],
            "New population is 230.",
            problemLatex: @"200\times 1.15",
            solutionLatex: @"200\times 1.15=230",
            stepLatex: [null, @"0.15\times 200=30", @"200+30=230", @"1.15\times 200=230", null],
            closingLatex: @"230")
        .Mistake("Using the new value as the base for percent change (denominator must be the original for standard percent change).")
        .Mistake("Treating the percent number as dollars or items (taking 20% of 80 as 20).")
        .Mistake("Finding only the discount/tax/increase amount when the question asked for the final price or total.")
        .Mistake("Confusing “% of” with “% more than” without adjusting the multiplier (1 + r vs r).")
        .Mistake("Adding chained discounts as if they applied to the same original base.")
        .Mistake("Dividing in the wrong direction when finding “what percent of A is B” (using A/B instead of B/A).")
        .Numeric("15% of 200?", "30",
            [
                "0.15 × 200, or 10% is 20 and 5% is 10.",
                "20 + 10 = 30."
            ],
            "15% of 200 = 30.",
            explanationLatex: @"0.15\times 200=30")
        .Numeric("$80 with 10% off. Sale price?", "72",
            [
                "Pay 90% of 80.",
                "0.9 × 80 = 72."
            ],
            "Sale price is $72.",
            explanationLatex: @"0.9\times 80=72")
        .Numeric("$25 meal, 20% tip. Tip amount?", "5",
            [
                "Tip is 20% of 25, not the total bill.",
                "0.2 × 25 = 5."
            ],
            "Tip is $5.",
            explanationLatex: @"0.2\times 25=5")
        .Numeric("From 50 to 60: percent increase? (number only)", "20",
            [
                "Change = 10; base = 50.",
                "10/50 × 100 = 20."
            ],
            "20% increase.",
            explanationLatex: @"\frac{10}{50}\times 100\%=20\%")
        .Mcq("Price $100 + 8% tax. Total:",
            ["$8", "$108", "$92", "$180"], 1,
            [
                "Total multiplier is 1.08.",
                "1.08 × 100 = 108, not just the $8 tax alone if the question asks for total."
            ],
            "Total is $108.",
            explanationLatex: @"1.08\times 100=108")
        .Numeric("What is 12% of 350?", "42",
            [
                "0.12 × 350.",
                "12 × 350 = 4200, then two decimal places from 0.12 → 42."
            ],
            "12% of 350 = 42.",
            explanationLatex: @"0.12\times 350=42")
        .Numeric("A $200 item is marked up 30%. New price?", "260",
            [
                "Markup → multiply by 1.30.",
                "1.3 × 200 = 260."
            ],
            "New price is $260.",
            explanationLatex: @"1.3\times 200=260")
        .Numeric("A jacket was $80 and is now $60. Percent decrease? (number only)", "25",
            [
                "Change = 20; original base = 80.",
                "20/80 × 100 = 25."
            ],
            "25% decrease.",
            explanationLatex: @"\frac{20}{80}\times 100\%=25\%")
        .Build();
}
