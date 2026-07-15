using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class ArithmeticLessons
{
    public const string CategoryId = "arithmetic";

    public static Category Build()
    {
        var lessons = new List<Lesson>
        {
            PlaceValue(),
            Addition(),
            Subtraction(),
            Multiplication(),
            Division(),
            OrderOfOperations()
        };
        return new Category(
            CategoryId,
            "Arithmetic Foundations",
            "Number sense, the four operations, and the rules that keep multi-step work accurate.",
            "\uE8EF",
            1,
            lessons);
    }

    private static Lesson PlaceValue() => new LessonBuilder("arith-place-value", CategoryId, "Place Value, Number Sense & Rounding")
        .Subtitle("See what every digit is worth, and why that unlocks everything else")
        .Order(1).Minutes("28 min")
        .Section("Why place value is the foundation of all school math",
            "When you write the number 3,472, you are not listing four unrelated digits. You are packing a huge amount of information into a short symbol. The 3 means three thousands, the 4 means four hundreds, the 7 means seven tens, and the 2 means two ones. That packing system is place value.\n\nWithout place value, adding multi-digit numbers, understanding decimals, reading measurements, and even using money would be nearly impossible. Every later topic, fractions, algebra, scientific notation, quietly relies on the idea that a digit’s job depends on where it sits.")
        .Section("What each place means (and why it multiplies by 10)",
            "Whole-number places grow by tens as you move left: ones, tens, hundreds, thousands, ten thousands, and so on. Why tens? Our number system is base ten, likely because humans count on ten fingers. So each step left is worth ten of the place to its right.\n\nThat means:\n• 1 ten = 10 ones\n• 1 hundred = 10 tens = 100 ones\n• 1 thousand = 10 hundreds = 1,000 ones\n\nWhen someone says “the digit 5 in 5,280 is in the thousands place,” they mean that 5 contributes 5 × 1,000 = 5,000 to the total, not 5.",
            simple: "Think of each column as a labeled bin. The rightmost bin holds single items. The next bin holds bundles of 10. The next holds bundles of 100. The digit tells you how many full bundles sit in that bin.",
            prior: "If you can count and you know that 10 ones make a ten, you already have the seed of place value. We are just naming the bundles and writing them in order.")
        .Section("The place-value chart",
            "A chart makes the invisible structure visible. Read the example number from left to right, but understand values from right to left when you are first learning. Notice how zeros matter: they hold empty places so the other digits stay in the correct columns. The number 305 is not “thirty-five”, the 0 keeps the 3 in the hundreds place.",
            diagram: SectionDiagramKind.PlaceValueChart,
            diagramData: "3472",
            simple: "Look at 3,472 in the chart. The 3 is not “three.” It is three groups of one thousand. The 4 is four groups of one hundred. Add those values together and you rebuild the whole number.")
        .Section("Number sense: estimating before you compute",
            "Number sense is the habit of asking “about how big?” before racing to an exact answer. Good number sense helps you catch impossible results (like 48 + 51 equaling 9,900) and choose smart strategies.\n\nTry these mental questions often:\n• Is this closer to 10, 100, or 1,000?\n• Is it a little more or a little less than a friendly number (like 50 or 200)?\n• If I round first, does the estimate still help me check my work?")
        .Section("Rounding: looking one place to the right",
            "Rounding replaces a number with a nearby “nice” number. To round to a chosen place: (1) find that place’s digit, (2) look at the digit immediately to its right, (3) if that neighbor is 5 or greater, increase the chosen digit by 1; if 0-4, leave it alone, (4) change all digits to the right of the chosen place to zeros (for whole numbers).\n\nWhy does 5 round up in school math? It is a conventional rule (half-up) so everyone gets the same answer. The important skill is applying the rule consistently.",
            @"3{,}472 \approx 3{,}500 \text{ (nearest hundred)}",
            simple: "Find the place you care about. Peek at the next digit to the right. Big (5-9) → bump up. Small (0-4) → stay. Clear everything after the place you rounded to.")
        .Formula("Digit value", @"\text{digit value}=\text{digit}\times 10^{k}", "k = 0 for ones, 1 for tens, 2 for hundreds, …")
        .Formula("Rounding check", @"d\ge 5 \Rightarrow \text{round up}", "d is the digit one place to the right of your target place.")
        .Example("What is a digit really worth?",
            "What is the value of the digit 6 in 56,304?",
            [
                "First, do not answer “6.” Value depends on place.",
                "Locate 6: it is in the thousands place (56,304 = fifty-six thousand…).",
                "Thousands means groups of 1,000, so compute 6 × 1,000.",
                "Value = 6,000. A common mistake is saying 60,000 (confusing with ten-thousands) or 600 (confusing with hundreds)."
            ],
            "The 6 contributes six thousand to the number, that is its place value.",
            problemLatex: @"56{,}304",
            solutionLatex: @"6\times 1{,}000=6{,}000",
            stepLatex: [null, null, @"6\times 1000", @"6000"])
        .Example("Compare by walking left to right",
            "Which is greater: 4,089 or 4,809?",
            [
                "Line the numbers up by place. Both have 4 in the thousands place, tie so far.",
                "Move to hundreds: 0 versus 8. Already 8 > 0, so 4,809 is larger.",
                "You do not need to look at tens or ones after the first difference.",
                "Wrong habit to avoid: comparing digit sums or “which looks longer.” Place by place from the left is the reliable method."
            ],
            "4,809 is greater because its hundreds digit is larger while thousands match.")
        .Example("Round to the nearest ten",
            "Round 347 to the nearest ten.",
            [
                "Target place: tens digit is 4 (so we are near 340 or 350).",
                "Look right at the ones digit: 7.",
                "7 ≥ 5, so the tens digit rounds up from 4 to 5.",
                "Ones become 0. Result: 350. (If the ones had been 2, we would keep 340.)"
            ],
            "347 is closer to 350 than to 340, which matches the rule.",
            solutionLatex: @"347 \rightarrow 350")
        .Example("Round across a larger place",
            "Round 12,460 to the nearest thousand.",
            [
                "Thousands digit is 2. Neighbor to the right is the hundreds digit: 4.",
                "4 < 5, so do not round the 2 up.",
                "Everything right of thousands becomes zero: 12,000.",
                "Sanity check: 12,460 is closer to 12,000 than to 13,000."
            ],
            "12,460 rounds to 12,000.",
            solutionLatex: @"12{,}460 \rightarrow 12{,}000")
        .Mistake("Saying a digit “is 4” when the question asks for its value (4 may mean 4, 40, 400, …).")
        .Mistake("Starting place-value from the left without lining up ones on the right for whole numbers.")
        .Mistake("Rounding 5 down, or changing only one digit and leaving the rest (e.g. turning 3,472 into 3,572).")
        .Mcq("What is the place value of 7 in 7,205?",
            ["7 ones", "7 tens", "7 hundreds", "7 thousands"], 3,
            ["Name the column of the 7.", "The number reads “seven thousand…”"],
            "7 is in the thousands place, so its value is 7,000.")
        .Mcq("Round 6,450 to the nearest hundred.",
            ["6,400", "6,500", "6,000", "6,450"], 1,
            ["Look at the tens digit next to the hundreds place.", "Tens digit is 5 → round up."],
            "Hundreds digit 4 with tens 5 rounds up to 6,500.")
        .Numeric("What is the value of the digit 9 in 19,304?", "9000",
            ["Which place is the 9 in?", "Thousands → 9 × 1,000."],
            "The 9 is in the thousands place: 9,000.", explanationLatex: @"9{,}000")
        .Numeric("Round 2,847 to the nearest ten.", "2850",
            ["Look at the ones digit.", "7 ≥ 5, so tens go from 4 to 5."],
            "2,847 rounds to 2,850.", explanationLatex: @"2{,}850")
        .Mcq("Which number is greatest?",
            ["3,099", "3,909", "3,990", "3,900"], 2,
            ["Compare thousands (all 3), then hundreds, then tens.", "3,990 has the most hundreds and tens among the options."],
            "3,990 is largest.")
        .Numeric("Write the number: 5 thousands + 0 hundreds + 3 tens + 8 ones.", "5038",
            ["Drop each amount into its column.", "5 0 3 8."],
            "Expanded form rebuilds as 5,038.", explanationLatex: @"5{,}038")
        .Mcq("Estimate 198 + 203 by rounding each to the nearest hundred.",
            ["300", "400", "500", "200"], 1,
            ["198 ≈ 200 and 203 ≈ 200.", "200 + 200 = 400."],
            "A good estimate is 400.")
        .Build();

    private static Lesson Addition() => new LessonBuilder("arith-addition", CategoryId, "Addition Strategies & Multi-Digit Addition")
        .Subtitle("Combine quantities with understanding, not just “stack and hope”")
        .Order(2).Minutes("30 min")
        .Section("What addition really means",
            "Addition answers “how many altogether?” if you join two groups. It also answers “how much more than a start?” when you add on. Those stories feel different in words, but they share the same arithmetic structure: combining quantities.\n\nTwo powerful truths make addition flexible:\n• Order does not matter: 3 + 8 = 8 + 3 (commutative property).\n• Grouping does not matter: (2 + 5) + 4 = 2 + (5 + 4) (associative property).\n\nThose properties are why mental strategies work, you can rearrange numbers to make friendlier problems without changing the total.")
        .Section("Mental strategies that build understanding",
            "Before always using the paper algorithm, try strategies that reveal structure:\n• Make a ten: 8 + 5 = 8 + 2 + 3 = 10 + 3.\n• Count on from the larger number: for 3 + 19, start at 19 and count three.\n• Break apart by place: 46 + 32 = (40 + 30) + (6 + 2).\n• Compensation: 98 + 47 = 100 + 47 − 2.\n\nWhy bother? These strategies train you to see numbers as flexible objects, which later helps with algebra (rewriting expressions) and estimation.",
            simple: "If a problem feels hard, ask: can I move a little from one number to the other to make a ten or a hundred? Friendly numbers are easier to hold in your head.",
            prior: "Place value matters here: breaking 46 into 40 + 6 only makes sense if you know what tens and ones are.")
        .Section("The standard algorithm: why carrying works",
            "The column method is not a magic ritual. It is organized place-value addition. You add ones with ones, tens with tens, and so on. When ones add to 14, that is really 1 ten and 4 ones, so you write 4 in the ones place and carry 1 ten into the tens column. Carrying is renaming, not inventing an extra number.",
            @"47+28=75",
            simple: "Add the right column. If you get 10 or more, keep the ones digit and send the extra ten to the next column. Then include that carry when you add the next column.")
        .Section("Align carefully and check with estimation",
            "Always line numbers up on the right (ones under ones). A common disaster is writing 87 under the 90 of 905 instead of under 05. After you finish, estimate: 348 + 276 should be near 350 + 280 = 630. If your exact answer is 1,200, something went wrong.")
        .Formula("Commutative property", @"a+b=b+a", "Order of addends does not change the sum.")
        .Formula("Carrying as renaming", @"\text{column sum}=10q+r", "Write r; carry q tens to the next place.")
        .Example("Make a ten (mental)",
            "Compute 8 + 7 mentally.",
            [
                "Notice 8 is 2 away from 10.",
                "Borrow 2 from the 7 to complete the ten: 8 + 2 = 10, and 5 remain from the 7.",
                "10 + 5 = 15.",
                "Why this is better than counting on fingers for every problem: you reuse the landmark 10."
            ],
            "8 + 7 = 15.",
            solutionLatex: @"8+7=15")
        .Example("Two-digit addition with a carry",
            "Add 67 + 58.",
            [
                "Ones: 7 + 8 = 15. That is 1 ten and 5 ones, write 5, carry 1 ten.",
                "Tens: 6 + 5 = 11, plus the carried 1 is 12 tens. Write 12 (or write 2 and carry 1 hundred).",
                "Result 125.",
                "Check: 70 + 60 = 130, and we slightly overestimated, 125 is sensible. Wrong path: forgetting the carry and writing 115."
            ],
            "67 + 58 = 125.",
            problemLatex: @"67+58",
            solutionLatex: @"125",
            stepLatex: [@"7+8=15", @"6+5+1=12", @"125", null])
        .Example("Three-digit addition",
            "Add 348 + 276.",
            [
                "Ones: 8 + 6 = 14 → write 4, carry 1.",
                "Tens: 4 + 7 + 1 = 12 → write 2, carry 1.",
                "Hundreds: 3 + 2 + 1 = 6.",
                "Sum 624. Estimate 350 + 280 = 630, close enough to trust 624."
            ],
            "348 + 276 = 624.",
            solutionLatex: @"624")
        .Example("Short number under a long number",
            "Add 905 + 87.",
            [
                "Write 87 under 05, not under 90. Ones under ones.",
                "Ones: 5 + 7 = 12 → write 2, carry 1.",
                "Tens: 0 + 8 + 1 = 9.",
                "Hundreds: 9. Result 992. Misalignment is the #1 multi-digit error."
            ],
            "905 + 87 = 992.",
            solutionLatex: @"992")
        .Mistake("Starting from the left when carries are needed (easy to lose track).")
        .Mistake("Forgetting to add a carry into the next column.")
        .Mistake("Misaligning place values when one number has fewer digits.")
        .Numeric("What is 46 + 39?", "85",
            ["Ones: 6 + 9 = 15 → write 5, carry 1.", "Tens: 4 + 3 + 1 = 8."],
            "46 + 39 = 85.", explanationLatex: @"85")
        .Numeric("Compute 257 + 186.", "443",
            ["Ones 7+6=13; tens 5+8+1=14; hundreds 2+1+1=4."],
            "257 + 186 = 443.", explanationLatex: @"443")
        .Mcq("Which property says 19 + 4 = 4 + 19?",
            ["Distributive", "Commutative", "Associative", "Identity"], 1,
            ["The order of addends can swap."],
            "That is the commutative property of addition.")
        .Numeric("Add 1,299 + 45.", "1344",
            ["Align 45 under 99.", "Carry carefully through the hundreds."],
            "1,299 + 45 = 1,344.", explanationLatex: @"1{,}344")
        .Mcq("A good mental strategy for 98 + 47 is:",
            ["Add 100 + 47 then subtract 2", "Multiply them", "Only use a calculator", "Subtract first"], 0,
            ["98 is 2 less than 100.", "100 + 47 = 147; 147 − 2 = 145."],
            "Compensation: 98 + 47 = 145.")
        .Numeric("What is 609 + 78?", "687",
            ["Ones: 9+8=17; tens: 0+7+1=8; hundreds: 6."],
            "609 + 78 = 687.")
        .Numeric("Sum of 333 + 444 + 222?", "999",
            ["Add by place: 3+4+2 = 9 in each place."],
            "333 + 444 + 222 = 999.")
        .Build();

    private static Lesson Subtraction() => new LessonBuilder("arith-subtraction", CategoryId, "Subtraction with Borrowing")
        .Subtitle("Take away, find differences, and regroup with meaning")
        .Order(3).Minutes("30 min")
        .Section("Subtraction’s two everyday stories",
            "Subtraction answers “how many are left?” when you remove some (take-away) and “how far apart are these?” when you compare (difference). Both use the same calculation. That is why 12 − 5 can mean “I had 12 cookies and ate 5” or “12 is 5 more than 7, wait, 12 is how much more than 5?” → 7.\n\nSubtraction is the inverse of addition: if a − b = c, then c + b = a. That single relationship is your best error-check for the rest of your life.")
        .Section("Why we regroup (borrow)",
            "Sometimes a digit is too small to subtract in its place. In 52 − 18, you cannot take 8 ones from 2 ones. Regrouping means renaming 1 ten as 10 ones. So 5 tens and 2 ones become 4 tens and 12 ones. Now 12 − 8 is possible, and the tens become 4 − 1.\n\nYou are not “stealing.” You are exchanging equal amounts, like breaking a $10 bill into ten $1 bills. The total value of the number stays the same; only the packaging changes.",
            simple: "If the top digit is too small, open one bundle from the next higher place. That gives you 10 more in the current place and one fewer in the place you opened.",
            prior: "This only makes sense if place value is solid: one ten really is ten ones.")
        .Section("Zeros in the middle: stay calm",
            "Problems like 500 − 237 look scary because zeros have “nothing to lend.” Rename step by step: think of 500 as 5 hundreds = 4 hundreds + 10 tens, then turn one ten into 10 ones if needed. Many students skip a rename and invent impossible digits. Slow renaming prevents that.")
        .Section("Always check",
            "Add your answer to the number you subtracted. You should recover the starting number. Also estimate: 604 − 358 should be near 600 − 360 = 240.")
        .Formula("Inverse check", @"(a-b)+b=a", "Difference plus subtrahend restores the minuend.")
        .Formula("Regroup ones", @"10 + d_{\text{ones}} \text{ after borrowing 1 ten}", "Standard rename when ones are too small.")
        .Example("No regrouping needed",
            "Compute 86 − 42.",
            [
                "Ones: 6 − 2 = 4.",
                "Tens: 8 − 4 = 4.",
                "Result 44. Check: 44 + 42 = 86."
            ],
            "86 − 42 = 44.",
            solutionLatex: @"44")
        .Example("Borrow once",
            "Compute 52 − 18.",
            [
                "Ones: 2 < 8, so rename 1 ten. Tens become 4; ones become 12.",
                "Ones: 12 − 8 = 4.",
                "Tens: 4 − 1 = 3.",
                "Result 34. Check: 34 + 18 = 52. Wrong habit: subtracting 2 from 8 because “smaller from larger”, that invents 16 and destroys place value."
            ],
            "52 − 18 = 34.",
            problemLatex: @"52-18",
            solutionLatex: @"34",
            stepLatex: [@"12-8=4", @"4-1=3", @"34", null])
        .Example("Across zeros",
            "Compute 500 − 237.",
            [
                "You need ones; zeros force a chain of renames.",
                "Think: 500 = 4 hundreds + 9 tens + 10 ones after full regrouping.",
                "Ones: 10 − 7 = 3; tens: 9 − 3 = 6; hundreds: 4 − 2 = 2.",
                "Result 263. Check: 263 + 237 = 500."
            ],
            "500 − 237 = 263.",
            solutionLatex: @"263")
        .Example("Word problem with meaning",
            "A book has 320 pages. You read 145. How many remain?",
            [
                "Story is take-away: 320 − 145.",
                "Compute carefully with regrouping: ones and tens both need support.",
                "Result 175 pages left.",
                "Check: 175 + 145 = 320. Estimate: 320 − 150 ≈ 170, matches."
            ],
            "175 pages remain.",
            solutionLatex: @"175")
        .Mistake("Subtracting the smaller digit from the larger regardless of which is on top (upside-down subtraction).")
        .Mistake("Forgetting to reduce the place you borrowed from.")
        .Mistake("Skipping renames across zeros (especially in numbers like 300 or 1,000).")
        .Numeric("Compute 91 − 47.", "44",
            ["Ones need a borrow.", "11 − 7 = 4; 8 − 4 = 4."],
            "91 − 47 = 44.")
        .Numeric("What is 1,000 − 456?", "544",
            ["Regroup across zeros carefully.", "Check with addition: answer + 456 = 1,000."],
            "1,000 − 456 = 544.", explanationLatex: @"544")
        .Mcq("To check 73 − 29 = 44, compute:",
            ["73 − 44", "44 + 29", "73 + 29", "29 − 44"], 1,
            ["Difference plus subtrahend should restore the minuend."],
            "44 + 29 = 73 confirms the subtraction.")
        .Numeric("604 − 358 = ?", "246",
            ["Borrow through the tens.", "Ones: 14−8; tens: 9−5; hundreds: 5−3."],
            "604 − 358 = 246.")
        .Numeric("A rope is 250 cm. You cut off 87 cm. How many cm remain?", "163",
            ["250 − 87."],
            "250 − 87 = 163 cm.")
        .Mcq("Which shows correct borrowing for 40 − 16?",
            ["Ones become 0, tens stay 4", "Ones become 10, tens become 3", "Ones become 20", "No borrow needed"], 1,
            ["0 < 6 requires a borrow from tens."],
            "Tens drop to 3; ones become 10.")
        .Numeric("Compute 2,050 − 1,276.", "774",
            ["Align place values and borrow carefully."],
            "2,050 − 1,276 = 774.")
        .Build();

    private static Lesson Multiplication() => new LessonBuilder("arith-multiplication", CategoryId, "Multiplication: Basics to Multi-Digit")
        .Subtitle("Groups, area, and why the multi-digit algorithm works")
        .Order(4).Minutes("32 min")
        .Section("Multiplication as equal groups, and as area",
            "Multiplication begins as “groups of the same size.” 3 × 4 means 3 groups of 4 (or 4 groups of 3). That is why 3 × 4 = 4 × 3: rearranging the same array does not change how many dots you have.\n\nA second picture is area: a 3-by-4 rectangle contains 12 unit squares. Area thinking later becomes length × width formulas and, eventually, products of binomials in algebra.")
        .Section("Why fluency with facts still matters",
            "You do not need shame about practicing 7 × 8. Automatic facts free working memory so you can focus on place value and multi-step problems. Look for patterns: ×10 appends a zero (in whole numbers), ×5 ends in 0 or 5, squares like 6 × 6 = 36 form a familiar ladder.")
        .Section("Distributive property: the secret behind multi-digit work",
            "The distributive property says a(b + c) = ab + ac. In plain English: if you split one factor, you can multiply the pieces and add. That is exactly what partial products do: 23 × 14 = 23 × (10 + 4) = 230 + 92. The standard algorithm is a compressed way of writing those partial products.",
            @"23\times 14=23\times 10+23\times 4",
            simple: "Break a hard product into easier products you know, then add the pieces. You are not cheating, you are using the distributive property.",
            prior: "Addition and place value are the ingredients. Multiplication organizes many additions of equal groups.")
        .Section("The multi-digit algorithm, step by step",
            "Multiply by the ones digit first (with carries inside that partial product). Then multiply by the tens digit, but shift one place left because those results are really tens. Add partial products. The shift is not decoration, it encodes place value.")
        .Formula("Distributive property", @"a(b+c)=ab+ac", "Split factors into friendly pieces.")
        .Formula("Partial products", @"m(10q+r)=10mq+mr", "Basis of multi-digit multiplication.")
        .Example("A basic product with a strategy",
            "What is 7 × 8?",
            [
                "One path: 7 × 10 = 70, then subtract 7 × 2 = 14 because 8 = 10 − 2 → 70 − 14 = 56.",
                "Another path: 7 × 8 = 7 × 4 × 2 = 28 × 2 = 56.",
                "Either way, aim for a method you can explain, not only a memorized sound."
            ],
            "7 × 8 = 56.",
            solutionLatex: @"56")
        .Example("Two-digit × one-digit",
            "Compute 36 × 4.",
            [
                "Think (30 + 6) × 4 = 120 + 24 = 144.",
                "Algorithm: 4 × 6 = 24 → write 4, carry 2; 4 × 3 = 12, plus 2 = 14.",
                "Same answer both ways, that builds trust."
            ],
            "36 × 4 = 144.",
            solutionLatex: @"144")
        .Example("Two-digit × two-digit",
            "Compute 23 × 14.",
            [
                "Split 14 = 10 + 4.",
                "23 × 4 = 92.",
                "23 × 10 = 230.",
                "92 + 230 = 322. Wrong shift (forgetting the zero/place for tens) often produces 122 or 292."
            ],
            "23 × 14 = 322.",
            problemLatex: @"23\times 14",
            solutionLatex: @"322",
            stepLatex: [@"14=10+4", @"23\times 4=92", @"23\times 10=230", @"92+230=322"])
        .Example("Trailing zeros",
            "Compute 50 × 30.",
            [
                "5 × 3 = 15.",
                "Each factor contributes a zero → two zeros → 1,500.",
                "Or 50 × 3 × 10 = 150 × 10 = 1,500. Common error: writing 150 or 1500 with one zero missing."
            ],
            "50 × 30 = 1,500.",
            solutionLatex: @"1{,}500")
        .Mistake("Forgetting the place-value shift when multiplying by the tens digit.")
        .Mistake("Carrying incorrectly inside a partial product.")
        .Mistake("Treating 20 × 30 as 60 instead of 600.")
        .Numeric("What is 9 × 6?", "54", ["6×10=60; subtract 6."], "9 × 6 = 54.")
        .Numeric("Compute 45 × 7.", "315", ["7×5=35 write 5 carry 3; 7×4+3=31."], "45 × 7 = 315.")
        .Numeric("What is 12 × 15?", "180", ["12×10 + 12×5 = 120+60."], "12 × 15 = 180.")
        .Mcq("Which equals 25 × 16?",
            ["25×10 + 25×6", "25+16", "25×10 only", "16−25"], 0,
            ["Distributive property over 16 = 10 + 6."],
            "25×16 = 250 + 150 = 400.")
        .Numeric("Compute 108 × 5.", "540", ["5×8=40; 5×0+4=4; 5×1=5 → 540."], "108 × 5 = 540.")
        .Numeric("A classroom has 18 rows of 12 seats. How many seats?", "216",
            ["18×12 = 18×10 + 18×2."], "18 × 12 = 216 seats.")
        .Mcq("Partial products for 21 × 13 are:",
            ["21×3 and 21×10", "21+13 only", "2×1×3", "21×1 only"], 0,
            ["Break 13 into 3 + 10."],
            "Then add 63 + 210 = 273.")
        .Build();

    private static Lesson Division() => new LessonBuilder("arith-division", CategoryId, "Division Concepts & Long Division")
        .Subtitle("Sharing, grouping, remainders, and checking with multiplication")
        .Order(5).Minutes("32 min")
        .Section("Two meanings, one operation",
            "Division answers two related questions.\n• Partitive (sharing): 12 cookies shared among 3 people → how many each?\n• Quotative (grouping): how many groups of 3 fit into 12?\n\nBoth are 12 ÷ 3 = 4. Seeing both meanings helps word problems. “Each bus holds 24 students” is usually grouping; “split the class into 3 equal teams” is sharing.")
        .Section("Division undoes multiplication",
            "If 4 × 6 = 24, then 24 ÷ 6 = 4 and 24 ÷ 4 = 6. Whenever you divide, ask: “What times the divisor gives the dividend?” That inverse relationship is how you check long division and how you later solve equations like 3x = 15.")
        .Section("Remainders: leftover that is smaller than the divisor",
            "Not every division is exact. 50 ÷ 6 is 8 groups of 6 with 2 left over, written 8 R2, or 8 + 2/6. The leftover must be smaller than the divisor; if it is not, you can still make another full group. In real life, remainders may force you to round up (enough buses for leftover students).",
            @"a=bq+r,\quad 0\le r<b",
            simple: "Divide means “how many full groups?” The remainder is what is left that is too small to make another full group.")
        .Section("Long division as organized guessing",
            "Long division is not mystical. At each step you estimate how many times the divisor fits into the current chunk, multiply, subtract, and bring down the next digit. Those four beats, divide, multiply, subtract, bring down, repeat until finished. Estimation skill (from number sense) makes the guesses better.",
            prior: "You need multiplication facts and subtraction with regrouping. Long division recycles both.")
        .Formula("Division algorithm", @"a=bq+r,\quad 0\le r<b", "Unique quotient and remainder for whole numbers.")
        .Formula("Check", @"(q\times b)+r=a", "Always verify.")
        .Example("Exact division",
            "Divide 84 ÷ 4.",
            [
                "4 into 8 is 2; 4×2=8; subtract → 0; bring down 4.",
                "4 into 4 is 1.",
                "Quotient 21. Check: 21 × 4 = 84."
            ],
            "84 ÷ 4 = 21.",
            solutionLatex: @"21")
        .Example("With remainder",
            "Divide 50 ÷ 6.",
            [
                "How many 6s fit into 50? Try 8: 6×8=48.",
                "50 − 48 = 2 leftover.",
                "Write 8 R2. Note 2 < 6, so the remainder is valid.",
                "As a mixed idea: 8 2/6 = 8 1/3 if you convert."
            ],
            "50 = 6×8 + 2.",
            solutionLatex: @"8\\ R2")
        .Example("Two-digit divisor",
            "Divide 945 ÷ 15.",
            [
                "15 into 94: try 6 because 15×6=90.",
                "Subtract 4; bring down 5 → 45.",
                "15 into 45 is 3 exactly.",
                "Quotient 63. Check: 63 × 15 = 945."
            ],
            "945 ÷ 15 = 63.",
            solutionLatex: @"63")
        .Example("Word problem: round up for people/buses",
            "148 students, buses seat 24 each. How many buses?",
            [
                "148 ÷ 24 = 6 remainder 4.",
                "Six buses are not enough for the leftover 4 students.",
                "You need 7 buses in the real world (ceiling the quotient).",
                "Math result 6 R4; modeling result 7 vehicles."
            ],
            "Context decides how to handle the remainder.")
        .Mistake("Leaving a remainder ≥ divisor (means you under-divided).")
        .Mistake("Misaligning digits when bringing down.")
        .Mistake("Forgetting to check with multiplication.")
        .Numeric("What is 72 ÷ 8?", "9", ["8×9=72."], "72 ÷ 8 = 9.")
        .Numeric("Compute 144 ÷ 12.", "12", ["12×12=144."], "144 ÷ 12 = 12.")
        .Mcq("25 ÷ 4 equals:",
            ["6 R1", "6 R0", "5 R5", "7 R0"], 0,
            ["4×6=24; remainder 1."],
            "25 = 4×6 + 1.")
        .Numeric("Long divide: 836 ÷ 4.", "209",
            ["4 into 8 = 2; 4 into 3 needs 0; 4 into 36 = 9."],
            "836 ÷ 4 = 209.")
        .Numeric("What remainder when 100 is divided by 9?", "1",
            ["9×11=99; remainder 1."],
            "100 = 9×11 + 1.")
        .Mcq("To check 91 ÷ 7 = 13, compute:",
            ["91 − 7", "13 × 7", "91 + 7", "7 ÷ 13"], 1,
            ["Quotient times divisor should restore dividend."],
            "13 × 7 = 91.")
        .Numeric("A factory packs 320 bottles into boxes of 8. How many full boxes?", "40",
            ["320 ÷ 8."],
            "320 ÷ 8 = 40 boxes.")
        .Build();

    private static Lesson OrderOfOperations() => new LessonBuilder("arith-pemdas", CategoryId, "Order of Operations (PEMDAS)")
        .Subtitle("A shared traffic system so everyone gets the same answer")
        .Order(6).Minutes("30 min")
        .Section("Why we need an order at all",
            "The expression 3 + 4 × 2 could mean (3 + 4) × 2 = 14 or 3 + (4 × 2) = 11. Without a rule, math language would be ambiguous, like a sentence without punctuation. PEMDAS (Parentheses, Exponents, Multiplication/Division, Addition/Subtraction) is the shared punctuation of arithmetic.\n\nThe goal is not bureaucracy. The goal is that two careful people always compute the same value.")
        .Section("The hierarchy, carefully stated",
            "1) Grouping symbols first: parentheses, brackets, fraction bars.\n2) Exponents (powers).\n3) Multiplication and division, left to right, they share a level. Division is not “weaker” than multiplication.\n4) Addition and subtraction, left to right, also a shared level.\n\nThe left-to-right rule is the part most often missed. 24 ÷ 6 × 2 is 8, not 2.",
            @"3+4\times 2=3+8=11",
            simple: "Do the powerful stuff first (groups, then powers). Then multiply/divide as they appear from left to right. Then add/subtract from left to right.",
            prior: "You already know how to add, subtract, multiply, and divide. PEMDAS only decides the order when those operations are mixed.")
        .Section("Nested grouping",
            "When groups nest, start with the innermost. Brackets [ ] and braces { } work like parentheses in school math. A fraction bar is a silent grouping symbol: the entire numerator is computed before dividing by the denominator.")
        .Section("Exponents are repeated multiplication, not “times the little number”",
            "2³ means 2 × 2 × 2 = 8, not 2 × 3 = 6. That single confusion creates many wrong PEMDAS results. If exponents still feel new, rewrite them as multiplications before continuing.")
        .Formula("PEMDAS order", @"P \rightarrow E \rightarrow M/D \rightarrow A/S", "Same-level ops run left to right.")
        .Formula("Left-to-right example", @"24\div 6\times 2=8", "Not 24÷(6×2) unless parentheses say so.")
        .Example("Basic PEMDAS",
            "Evaluate 3 + 4 × 2.",
            [
                "Scan for parentheses: none. Exponents: none.",
                "Multiplication before addition: 4 × 2 = 8.",
                "Then 3 + 8 = 11.",
                "Common wrong answer 14 comes from adding first, that would require parentheses: (3+4)×2."
            ],
            "3 + 4 × 2 = 11.",
            problemLatex: @"3+4\times 2",
            solutionLatex: @"3+4\times 2=3+8=11",
            stepLatex: [null, @"4\times 2=8", @"3+8=11", null],
            closingLatex: @"(3+4)\times 2=14")
        .Example("Shared level, left to right",
            "Evaluate 24 ÷ 6 × 2.",
            [
                "Multiplication and division share priority.",
                "Left first: 24 ÷ 6 = 4.",
                "Then 4 × 2 = 8.",
                "If the author wanted 24 ÷ (6×2), they must write the parentheses."
            ],
            "Result is 8.",
            problemLatex: @"24\div 6\times 2",
            solutionLatex: @"24\div 6\times 2=4\times 2=8",
            stepLatex: [null, @"24\div 6=4", @"4\times 2=8", null])
        .Example("Parentheses and exponents",
            "Evaluate (5 + 3)² − 4 × 3.",
            [
                "Parentheses first: 5 + 3 = 8.",
                "Exponent: 8² = 64.",
                "Multiplication: 4 × 3 = 12.",
                "Subtraction: 64 − 12 = 52."
            ],
            "Value is 52.",
            problemLatex: @"(5+3)^2-4\times 3",
            solutionLatex: @"(5+3)^2-4\times 3=64-12=52",
            stepLatex: [@"5+3=8", @"8^2=64", @"4\times 3=12", @"64-12=52"])
        .Example("Nested with a negative result",
            "Evaluate 2 × [10 − (3 + 1)²].",
            [
                "Innermost: 3 + 1 = 4.",
                "Exponent: 4² = 16.",
                "Brackets: 10 − 16 = −6.",
                "Multiply: 2 × (−6) = −12. Signs matter after subtraction inside grouping."
            ],
            "Result −12.",
            problemLatex: @"2\times\left(10-(3+1)^2\right)",
            solutionLatex: @"2\times(10-16)=2\times(-6)=-12",
            stepLatex: [@"3+1=4", @"4^2=16", @"10-16=-6", @"2\times(-6)=-12"])
        .Mistake("Always doing all multiplication before any division, even when division is on the left.")
        .Mistake("Ignoring parentheses or fraction bars as grouping.")
        .Mistake("Reading 2³ as 2×3 instead of 2×2×2.")
        .Numeric("Evaluate 5 + 3 × 4.", "17", ["3×4 first."], "5 + 12 = 17.")
        .Numeric("Evaluate 18 − 6 ÷ 3.", "16", ["6÷3=2; 18−2=16."], "18 − 2 = 16.")
        .Numeric("Evaluate (8 − 3) × 2 + 1.", "11", ["5×2+1=11."], "(8−3)×2+1 = 11.")
        .Mcq("20 ÷ 5 × 2 equals:",
            ["2", "8", "10", "1"], 1,
            ["Left to right: 20÷5=4; 4×2=8."],
            "Shared level: left to right yields 8.")
        .Numeric("Evaluate 2³ + 4.", "12", ["8+4."], "2³ = 8; 8+4=12.")
        .Numeric("Evaluate 100 − 3 × (4 + 6).", "70", ["4+6=10; 3×10=30; 100−30=70."], "100 − 30 = 70.")
        .Mcq("Which is evaluated first in 6 + (2×5)²?",
            ["6+", "2×5", "squaring then multiply", "all at once"], 1,
            ["Innermost parentheses first."],
            "Then square 10, then add 6 → 106.")
        .Numeric("Evaluate 4 × 5 − 3 × 2.", "14", ["20 − 6."], "20 − 6 = 14.")
        .Build();
}
