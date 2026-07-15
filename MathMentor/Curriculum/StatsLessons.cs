using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class StatsLessons
{
    public const string CategoryId = "stats";

    public static Category Build()
    {
        var lessons = new[]
        {
            DataDisplays(),
            CenterAndSpread(),
            BasicProbability(),
            ConditionalProbability()
        };
        return new Category(CategoryId, "Statistics & Probability",
            "Data displays, measures of center and spread, basic probability, and conditional probability with two-way tables.",
            "\uE9F9", 14, lessons);
    }

    private static Lesson DataDisplays() => new LessonBuilder("stats-displays", CategoryId, "Data Displays")
        .Subtitle("Turn raw lists into pictures you can read: tables, bars, histograms, and box plots")
        .Order(1).Minutes("30 min")
        .Section("Why we display data",
            "A raw list of numbers is hard to scan. Data displays reorganize the same information so patterns jump out: clusters, gaps, peaks, outliers, and overall shape. Choosing a display depends on whether the variable is categorical (labels like color or brand) or quantitative (measured numbers like height or time).\n\nGood displays do three jobs: (1) show every important group or range, (2) keep scales honest, and (3) match the question you care about (comparison, distribution, or both).",
            simple: "A chart is a story about numbers. Pick the chart type that matches the kind of data and the question you want answered.",
            prior: "You only need counting, ordering numbers, and reading axes with equal scales.")
        .Section("Frequency tables and bar graphs",
            "For categorical data, start with a frequency table: each category and how many times it appears. A relative frequency is that count divided by the total, often written as a decimal or percent.\n\nA bar graph draws one bar per category. Bars have equal width and gaps between them (categories are separate labels, not a continuous scale). Always label axes and title the graph so a stranger can read it without the original list.",
            @"\text{relative frequency}=\frac{\text{count in category}}{\text{total}}",
            simple: "Count how many in each label, then optionally divide by the total to get a percent-ready share.")
        .Section("Dot plots and stem-and-leaf plots",
            "A dot plot places a mark above each value on a number line. Repeats stack. Dot plots are excellent for small quantitative data sets: you still see every point.\n\nA stem-and-leaf plot splits each number into a stem (leading digit or digits) and a leaf (usually the last digit). Example: 47 has stem 4 and leaf 7. Stems are listed in a column; leaves line up to the right. The plot keeps the original values while showing shape, so you can rebuild the list later.",
            simple: "Dots show each score on a line. Stem-and-leaf keeps the actual digits while looking a bit like a sideways histogram.",
            prior: "Place value helps: tens as stems and ones as leaves is the usual first version.")
        .Section("Histograms for continuous-style data",
            "A histogram groups quantitative data into bins (intervals) of equal width and draws bars whose heights are frequencies (or relative frequencies). Unlike bar graphs, histogram bars touch because the variable is along a continuous number line.\n\nChoosing bin width matters. Too few bins hide detail; too many bins make the picture noisy. Always state the bin rule clearly (for example, 10-19, 20-29, ... and whether endpoints go left or right).",
            simple: "Histogram = bar chart for number ranges. Bars touch because the ranges sit next to each other on the number line.")
        .Section("Box plots (box-and-whisker)",
            "A box plot summarizes a quantitative distribution with five numbers: minimum, first quartile Q1, median, third quartile Q3, and maximum. The box runs from Q1 to Q3; a line inside marks the median; whiskers stretch to the min and max (or to non-outlier fences in some courses).\n\nBox plots trade detail for quick comparison: side-by-side boxes make two groups easy to compare on center and spread, even when sample sizes differ.",
            @"\text{five-number summary: min},\;Q_1,\;\text{median},\;Q_3,\;\max",
            simple: "The box shows the middle half of the data. The line in the box is the median. Whiskers show how far the extremes go.",
            prior: "You need the idea of median and quartiles (covered fully in the next lesson).")
        .Section("Shape, center, spread, and outliers by eye",
            "When you read a display, describe four things in plain language:\n• Shape: roughly symmetric, skewed right (long right tail), skewed left, unimodal, bimodal\n• Center: about where the bulk sits (mean or median later)\n• Spread: how spread out values are (range, IQR, or standard deviation later)\n• Unusual features: gaps, clusters, and outliers that sit far from the rest\n\nA display is not just art. It is evidence for claims like “most scores are between 70 and 85” or “one trial was unusually long.”",
            prior: "Skewed right means a few large values pull a long tail to the right, common with income or wait times.")
        .Formula("Relative frequency", @"\frac{\text{count}}{\text{total}}", "Share of the data in a category or bin.")
        .Formula("Five-number summary", @"\min,\;Q_1,\;M,\;Q_3,\;\max", "Skeleton of a box plot (M = median).")
        .Formula("Range (preview)", @"\text{range}=\max-\min", "Simplest spread measure from extremes.")
        .Example("Build a frequency table",
            "Colors chosen by 12 students: red, blue, blue, green, red, blue, yellow, green, blue, red, blue, green. Make a frequency table.",
            [
                "List distinct categories: red, blue, green, yellow.",
                "Count: red 3, blue 5, green 3, yellow 1.",
                "Check the total: 3+5+3+1 = 12, matches the sample size.",
                "Optional relative frequency for blue: 5/12."
            ],
            "Frequencies: red 3, blue 5, green 3, yellow 1.",
            solutionLatex: @"5/12")
        .Example("Relative frequency",
            "In a class of 40, 12 students walk to school. What is the relative frequency of walking?",
            [
                "Relative frequency = count / total = 12/40.",
                "Simplify: 12/40 = 3/10 = 0.3.",
                "As a percent: 30%.",
                "All relative frequencies in a complete table should sum to 1 (or 100%)."
            ],
            "0.3 or 30%.",
            problemLatex: @"\frac{12}{40}",
            solutionLatex: @"0.3")
        .Example("Read a stem-and-leaf",
            "Stems are tens and leaves are ones: stem 5 has leaves 2, 2, 7; stem 6 has leaves 0, 4. List the data values.",
            [
                "Stem 5, leaf 2 means 52 (appears twice).",
                "Stem 5, leaf 7 means 57.",
                "Stem 6, leaf 0 means 60; leaf 4 means 64.",
                "Data in order: 52, 52, 57, 60, 64."
            ],
            "52, 52, 57, 60, 64.",
            solutionLatex: @"52,52,57,60,64")
        .Example("Histogram bins",
            "Scores: 11, 14, 18, 21, 22, 27, 30. Using bins 10-19, 20-29, 30-39 (include left endpoint, exclude right except last if needed), find the bin frequencies.",
            [
                "10-19: 11, 14, 18 → frequency 3.",
                "20-29: 21, 22, 27 → frequency 3.",
                "30-39: 30 → frequency 1.",
                "Total 3+3+1 = 7, so every score is placed once."
            ],
            "Frequencies 3, 3, and 1.",
            solutionLatex: @"3,\;3,\;1")
        .Mistake("Using unequal bar widths or uneven gaps that visually exaggerate a category.")
        .Mistake("Drawing histogram bars with gaps as if categories were separate labels.")
        .Mistake("Forgetting a title, axis labels, or a key on stem-and-leaf plots.")
        .Mistake("Claiming a pattern from a display without checking sample size or scale.")
        .Numeric("A survey of 50 people finds 20 prefer tea. Relative frequency of tea?", "0.4",
            ["Relative frequency = 20/50.", "Simplify 20/50 = 2/5 = 0.4."],
            "20/50 = 0.4.",
            explanationLatex: @"0.4")
        .Numeric("Data: 3, 5, 8, 11. What is the range?", "8",
            ["Range = max - min.", "11 - 3 = 8."],
            "Range is 8.",
            explanationLatex: @"11-3=8")
        .Mcq("Which display is best for comparing frequencies of favorite sports (labels)?",
            ["Histogram", "Scatter plot", "Bar graph", "Box plot of heights"], 2,
            ["Sports are categories, not measurements on a number line.", "Bar graphs fit categorical counts."],
            "A bar graph matches categorical frequencies.")
        .Numeric("In a stem-and-leaf with stem 4 and leaf 9 (tens/ones), what value is shown?", "49",
            ["Stem is tens, leaf is ones.", "4 tens and 9 ones make 49."],
            "The value is 49.")
        .Mcq("Histogram bars typically:",
            ["Have large gaps between every bar", "Touch neighboring bins", "Must each have height 1", "Only work for categories like colors"], 1,
            ["Quantitative bins sit side by side on a number line.", "Touching bars signal continuous-style intervals."],
            "Bars touch because bins are adjacent intervals.")
        .Numeric("Frequencies 4, 6, and 10. What is the total sample size?", "20",
            ["Add all frequencies.", "4+6+10."],
            "n = 20.")
        .Numeric("Relative frequency 0.25 of 80 students. How many students is that?", "20",
            ["Count = relative frequency times total.", "0.25 * 80 = 20."],
            "20 students.",
            explanationLatex: @"0.25\cdot 80=20")
        .Mcq("A long right tail on a histogram usually means the shape is:",
            ["Symmetric", "Skewed left", "Skewed right", "Always bimodal"], 2,
            ["A long tail on the right is right skew.", "A few large values stretch the right side."],
            "Right skew has a long right tail.")
        .Build();

    private static Lesson CenterAndSpread() => new LessonBuilder("stats-center-spread", CategoryId, "Measures of Center & Spread")
        .Subtitle("Mean, median, mode, range, IQR, and a careful first look at standard deviation")
        .Order(2).Minutes("34 min")
        .Section("What center and spread answer",
            "A distribution needs more than a pretty graph. Measures of center answer “What is a typical value?” Measures of spread answer “How much do values vary?” Together they compress a list into a few honest numbers you can compare across groups.\n\nNo single number tells the whole story. Mean and median can disagree when data are skewed. A tiny range can hide a clump with one far outlier if you only look at max and min.",
            simple: "Center = typical value. Spread = how stretched out the data are. Use both.",
            prior: "You should already be able to order a list and read a simple dot plot or histogram.")
        .Section("Mean, median, and mode",
            "The mean (arithmetic average) is the sum of the values divided by how many values there are. It uses every data point, so outliers can pull it strongly.\n\nThe median is the middle value when the data are ordered. For an even count, average the two middle values. The median resists outliers better than the mean.\n\nThe mode is the most frequent value (there may be more than one mode, or none that stands out). Mode is especially natural for categorical data.",
            @"\bar{x}=\frac{x_1+x_2+\cdots+x_n}{n}",
            simple: "Mean = fair share total. Median = middle after sorting. Mode = most common.")
        .Section("Choosing mean vs median",
            "If the distribution is roughly symmetric with no wild outliers, mean and median are similar; the mean is often preferred because it uses all data and connects later to standard deviation.\n\nIf the distribution is strongly skewed or has extreme outliers, the median usually better represents a “typical” value. Example: house prices and incomes are often right-skewed, so news reports often quote medians.",
            prior: "Skew pulls the mean toward the long tail more than it pulls the median.")
        .Section("Range and interquartile range (IQR)",
            "Range = maximum − minimum. It is simple but uses only two points, so one extreme value can inflate it.\n\nQuartiles split ordered data into fourths. Q1 is the median of the lower half; Q3 is the median of the upper half; the overall median is Q2. The interquartile range is IQR = Q3 − Q1, the width of the middle 50% of the data. IQR is a resistant spread measure: outliers outside the middle half do not change it.",
            @"\mathrm{IQR}=Q_3-Q_1",
            simple: "Range looks at the extremes. IQR looks at the width of the middle half.")
        .Section("Outliers and the 1.5 IQR rule",
            "A common classroom rule flags potential outliers as values below Q1 − 1.5·IQR or above Q3 + 1.5·IQR. These fences are guidelines for investigation, not automatic “delete this point” orders.\n\nAlways ask whether an outlier is a data error, a special case, or an important rare event. Context matters more than the rule alone.",
            @"\text{low fence}=Q_1-1.5\cdot\mathrm{IQR}",
            simple: "Walk 1.5 IQRs beyond Q1 and Q3. Points outside those fences are candidate outliers.")
        .Section("Standard deviation (conceptual)",
            "Variance and standard deviation measure typical distance from the mean. Roughly: find each deviation (x − mean), square it (so negatives do not cancel), average those squares (details differ slightly for sample vs population), then take a square root to return to the original units. That square root is the standard deviation s (sample) or σ (population).\n\nLarger standard deviation means more spread around the mean. Standard deviation is not resistant: outliers inflate it. For skewed data, report median and IQR; for roughly symmetric data, mean and standard deviation are a classic pair.",
            @"s=\sqrt{\frac{1}{n-1}\sum (x_i-\bar{x})^2}",
            simple: "Standard deviation is a typical distance from the average, in the same units as the data.",
            prior: "Squaring and square roots from algebra; mean from earlier in this lesson.")
        .Formula("Sample mean", @"\bar{x}=\frac{1}{n}\sum_{i=1}^{n}x_i", "Sum of values divided by count.")
        .Formula("IQR", @"\mathrm{IQR}=Q_3-Q_1", "Spread of the middle 50%.")
        .Formula("Range", @"\text{range}=\max-\min", "Simplest spread from extremes.")
        .Formula("Sample standard deviation", @"s=\sqrt{\frac{1}{n-1}\sum(x_i-\bar{x})^2}", "Typical distance from the mean (sample form).")
        .Example("Mean and median",
            "Data: 2, 4, 4, 6, 14. Find the mean and the median.",
            [
                "Mean: sum = 2+4+4+6+14 = 30; n = 5; mean = 30/5 = 6.",
                "Order is already sorted. Middle (3rd) value is 4, so median = 4.",
                "The large 14 pulled the mean up to 6 while the median stayed at 4.",
                "Mode is 4 (appears twice)."
            ],
            "Mean 6, median 4, mode 4.",
            solutionLatex: @"\bar{x}=6,\;\text{median}=4")
        .Example("Even count median",
            "Data: 3, 5, 7, 11. Find the median.",
            [
                "n = 4 (even), so average the two middle values.",
                "Middle pair: 5 and 7.",
                "Median = (5+7)/2 = 6.",
                "Mean would be (3+5+7+11)/4 = 6.5, close but not identical."
            ],
            "Median is 6.",
            solutionLatex: @"\frac{5+7}{2}=6")
        .Example("IQR and fences",
            "Ordered data: 4, 6, 7, 8, 9, 10, 20. Approximate Q1 = 6, median = 8, Q3 = 10. Find IQR and the upper outlier fence.",
            [
                "IQR = Q3 − Q1 = 10 − 6 = 4.",
                "Upper fence = Q3 + 1.5·IQR = 10 + 1.5·4 = 10 + 6 = 16.",
                "The value 20 is above 16, so it is a candidate outlier.",
                "Lower fence = 6 − 6 = 0; no data fall below 0 here."
            ],
            "IQR = 4; upper fence = 16; 20 is a candidate outlier.",
            solutionLatex: @"\mathrm{IQR}=4,\;Q_3+1.5\mathrm{IQR}=16")
        .Example("Standard deviation idea",
            "Data: 2, 4, 6. Mean is 4. Compute the sample standard deviation s.",
            [
                "Deviations: 2−4=−2, 4−4=0, 6−4=2.",
                "Squared: 4, 0, 4. Sum of squares = 8.",
                "Divide by n−1 = 2: 8/2 = 4 (sample variance).",
                "s = √4 = 2."
            ],
            "s = 2.",
            problemLatex: @"2,4,6",
            solutionLatex: @"s=2",
            stepLatex: [@"-2,0,2", @"4+0+4=8", @"\frac{8}{2}=4", @"s=2"])
        .Mistake("Forgetting to order the data before finding the median or quartiles.")
        .Mistake("Using n instead of n−1 (or vice versa) inconsistently when a course specifies sample SD.")
        .Mistake("Calling every unusual point an outlier without a rule or context.")
        .Mistake("Preferring the mean for strongly skewed income-like data when the median is more typical.")
        .Numeric("Mean of 5, 7, 9?", "7",
            ["Sum = 21.", "21/3 = 7."],
            "Mean is 7.",
            explanationLatex: @"7")
        .Numeric("Median of 1, 2, 8, 10, 11?", "8",
            ["Already ordered; n = 5.", "Middle value is the 3rd: 8."],
            "Median is 8.")
        .Numeric("Range of 12, 15, 19, 30?", "18",
            ["Max 30, min 12.", "30 − 12 = 18."],
            "Range is 18.")
        .Numeric("If Q1 = 10 and Q3 = 22, what is IQR?", "12",
            ["IQR = Q3 − Q1.", "22 − 10 = 12."],
            "IQR = 12.",
            explanationLatex: @"22-10=12")
        .Numeric("Upper fence if Q3 = 22 and IQR = 12?", "40",
            ["Fence = Q3 + 1.5·IQR.", "22 + 1.5·12 = 22 + 18 = 40."],
            "Upper fence is 40.",
            explanationLatex: @"22+18=40")
        .Mcq("Which measure of center is most resistant to a single huge outlier?",
            ["Mean", "Median", "Range", "Standard deviation"], 1,
            ["The median depends on order position, not extreme magnitude as strongly.", "Mean and SD both move toward outliers."],
            "The median is more resistant than the mean.")
        .Numeric("Mean of 0, 0, 0, 12?", "3",
            ["Sum = 12, n = 4.", "12/4 = 3."],
            "Mean is 3 (pulled up by 12).")
        .Mcq("IQR measures:",
            ["Only the maximum", "Spread of the middle half", "Always the same as the range", "Only categorical mode"], 1,
            ["IQR = Q3 − Q1.", "That gap is the middle 50% width."],
            "IQR is the middle-half spread.")
        .Build();

    private static Lesson BasicProbability() => new LessonBuilder("stats-probability", CategoryId, "Basic Probability")
        .Subtitle("Chance from equally likely outcomes to complements, “and,” and “or”")
        .Order(3).Minutes("32 min")
        .Section("What probability measures",
            "Probability measures how likely an event is, on a scale from 0 (impossible) to 1 (certain). An event is a set of outcomes from a sample space S of all possible outcomes of a chance process.\n\nIf all outcomes in S are equally likely, the classical probability of event A is the number of favorable outcomes divided by the number of possible outcomes.",
            @"P(A)=\frac{\#\text{ favorable}}{\#\text{ possible}}",
            simple: "Probability is a fraction of equally likely outcomes when that model fits: want / total.",
            prior: "Fractions between 0 and 1, and basic counting, are the main tools.")
        .Section("Sample spaces and listing outcomes",
            "Build S carefully before computing. One coin: {H, T}. Two coins: {HH, HT, TH, TT}. A fair six-sided die: {1,2,3,4,5,6}.\n\nTree diagrams and organized lists prevent double-counting or missing cases. For independent stages (coin then die), multiply the counts of options: 2 × 6 = 12 equally likely pairs.",
            simple: "Write every possible result first. Probability questions are only as good as that list.")
        .Section("Complements",
            "The complement A^c (or A') is “A does not happen.” Always P(A) + P(A^c) = 1, so P(A^c) = 1 − P(A). Complements are powerful when “not A” is easier to count than A.\n\nExample: probability of at least one head in two coin flips equals 1 minus probability of no heads (TT).",
            @"P(A^c)=1-P(A)",
            simple: "If you know the chance something happens, one minus that is the chance it fails.")
        .Section("Mutually exclusive “or”",
            "Events A and B are mutually exclusive (disjoint) if they cannot both occur. Then P(A or B) = P(A) + P(B).\n\nIf they can overlap, adding blindly double-counts the overlap. The general addition rule is P(A or B) = P(A) + P(B) − P(A and B).",
            @"P(A\cup B)=P(A)+P(B)-P(A\cap B)",
            simple: "Add chances for “or,” but subtract the double-counted “both” when overlap exists.")
        .Section("Independent “and”",
            "Two events are independent if knowing one happened does not change the probability of the other. For independent events, P(A and B) = P(A)·P(B).\n\nIndependence is a modeling assumption (fair coins, separate draws with replacement). Without replacement, draws are usually dependent: the first card changes the deck for the second.",
            @"P(A\cap B)=P(A)P(B)\text{ if independent}",
            prior: "Multiplying fractions is the same skill used in compound probability.")
        .Section("Experimental vs theoretical probability",
            "Theoretical probability comes from a fair model (equally likely faces, ideal coin). Experimental (empirical) probability is the relative frequency from trials: successes / trials. By the law of large numbers, long-run relative frequencies tend to settle near the theoretical value, but short runs can look wild.\n\nAlways say which kind you are using. Ten coin flips ending at 7 heads does not prove the coin is unfair by itself.",
            simple: "Theory: perfect model fraction. Experiment: what the data did so far.")
        .Formula("Classical probability", @"P(A)=\frac{n(A)}{n(S)}", "Favorable over possible, equally likely outcomes.")
        .Formula("Complement", @"P(A^c)=1-P(A)", "Chance of not A.")
        .Formula("General addition", @"P(A\cup B)=P(A)+P(B)-P(A\cap B)", "Or rule with overlap correction.")
        .Formula("Independent and", @"P(A\cap B)=P(A)P(B)", "When A and B are independent.")
        .Example("Fair die",
            "A fair six-sided die is rolled. Find P(rolling a number greater than 4).",
            [
                "Sample space has 6 outcomes, equally likely.",
                "Greater than 4: {5, 6}, so 2 favorable.",
                "P = 2/6 = 1/3.",
                "Decimal form about 0.333."
            ],
            "1/3.",
            problemLatex: @"P(X>4)",
            solutionLatex: @"\frac{1}{3}")
        .Example("Complement with cards",
            "From a standard 52-card deck, P(not a heart) = ?",
            [
                "There are 13 hearts, so P(heart) = 13/52 = 1/4.",
                "Complement: P(not heart) = 1 − 1/4 = 3/4.",
                "Count check: 39 non-hearts; 39/52 = 3/4.",
                "Same answer two ways builds confidence."
            ],
            "3/4.",
            solutionLatex: @"\frac{3}{4}")
        .Example("Independent flips",
            "Fair coin flipped twice. Find P(two heads).",
            [
                "Outcomes: HH, HT, TH, TT, each probability 1/4.",
                "Only HH is two heads, so P = 1/4.",
                "Independence path: (1/2)·(1/2) = 1/4.",
                "Do not count HT as two heads."
            ],
            "1/4.",
            solutionLatex: @"\frac{1}{4}")
        .Example("Addition with overlap",
            "P(A) = 0.5, P(B) = 0.4, P(A and B) = 0.2. Find P(A or B).",
            [
                "Use general addition: 0.5 + 0.4 − 0.2.",
                "0.9 − 0.2 = 0.7.",
                "If you forgot to subtract, you would wrongly get 0.9.",
                "0.7 is still at most 1, as any probability must be."
            ],
            "0.7.",
            problemLatex: @"P(A\cup B)",
            solutionLatex: @"0.7")
        .Mistake("Adding probabilities for “and” instead of multiplying (when independence applies).")
        .Mistake("Forgetting to subtract the intersection in a non-disjoint “or” problem.")
        .Mistake("Writing probabilities greater than 1 or less than 0 after a setup error.")
        .Mistake("Treating experimental short-run frequencies as if they must match theory exactly.")
        .Numeric("Fair die: P(rolling a 2)? Enter a decimal.", "0.1667",
            ["One face out of six.", "1/6 ≈ 0.1667."],
            "1/6 ≈ 0.1667.",
            tolerance: 0.01,
            explanationLatex: @"\frac{1}{6}")
        .Numeric("P(A) = 0.3. What is P(not A)?", "0.7",
            ["Complement: 1 − 0.3."],
            "0.7.",
            explanationLatex: @"1-0.3=0.7")
        .Numeric("Two fair coins: P(two tails)? Enter a fraction as decimal.", "0.25",
            ["(1/2)·(1/2) = 1/4."],
            "0.25.",
            tolerance: 0.001)
        .Mcq("If A and B are mutually exclusive, P(A and B) is:",
            ["1", "P(A)+P(B)", "0", "P(A)P(B) always"], 2,
            ["Mutually exclusive means they cannot both happen.", "Intersection probability is 0."],
            "Disjoint events have P(A and B) = 0.")
        .Numeric("P(A)=0.6, P(B)=0.5, P(A and B)=0.3. P(A or B)?", "0.8",
            ["0.6+0.5−0.3."],
            "0.8.",
            explanationLatex: @"0.6+0.5-0.3=0.8")
        .Numeric("Bag with 3 red and 2 blue marbles. P(red) on one random draw?", "0.6",
            ["3 red out of 5 total.", "3/5 = 0.6."],
            "0.6.",
            tolerance: 0.001)
        .Mcq("Which must be true for any event A?",
            ["P(A) > 1", "0 ≤ P(A) ≤ 1", "P(A) = 0.5", "P(A) + P(A) = 1"], 1,
            ["Probabilities live in [0, 1].", "Complements sum with P(A) to 1, not P(A)+P(A)."],
            "Any probability is between 0 and 1 inclusive.")
        .Numeric("In 50 trials, event occurs 15 times. Experimental probability?", "0.3",
            ["15/50 = 0.3."],
            "0.3.",
            explanationLatex: @"\frac{15}{50}=0.3")
        .Build();

    private static Lesson ConditionalProbability() => new LessonBuilder("stats-conditional", CategoryId, "Two-way Tables & Conditional Probability")
        .Subtitle("Read joint, marginal, and conditional percents; use P(A|B) with care")
        .Order(4).Minutes("34 min")
        .Section("Two-way tables organize two categories",
            "A two-way frequency table classifies each individual by two categorical variables (for example, grade level and preferred sport). Interior cells are joint counts: how many have both labels. Row and column totals are marginal counts. The grand total is the sample size n.\n\nFrom counts you can form joint relative frequencies (cell/n), marginal relative frequencies (row or column total / n), and conditional relative frequencies (cell / row total or cell / column total).",
            simple: "Two-way table = grid of both/and counts, with totals on the edges.",
            prior: "Relative frequency from the data-displays lesson is the same idea inside each cell.")
        .Section("Conditional probability in words",
            "P(A | B) reads “probability of A given B.” Restrict attention to the cases where B is true, then see how often A also occurs. Formally, when P(B) > 0,\nP(A|B) = P(A and B) / P(B).\n\nIn a table, if B is a column, condition on that column’s total: take the cell count for A and B and divide by the column total for B (not by the grand total).",
            @"P(A\mid B)=\frac{P(A\cap B)}{P(B)}",
            simple: "Given B means: only look inside the B group, then find the fraction that are also A.")
        .Section("Joint vs marginal vs conditional",
            "• Joint: P(A and B) uses the grand total in the denominator.\n• Marginal: P(A) ignores the other variable; use a row or column total over grand total.\n• Conditional: P(A|B) uses the B total as the new “whole.”\n\nMixing these denominators is the number one table error. Always underline the words “of those who...” or “given...” to lock the denominator.",
            prior: "Fractions change meaning when the whole changes. Conditional probability changes the whole.")
        .Section("Independence check with conditionals",
            "A and B are independent if P(A|B) = P(A) (equivalently P(B|A) = P(B), or P(A and B) = P(A)P(B)). If learning B changes the chance of A, they are associated (dependent in the probability sense).\n\nIn tables, compare the conditional distribution of A across levels of B. If the row percents within each column look the same, that supports independence in the sample.",
            @"P(A\mid B)=P(A)\text{ if independent}",
            simple: "Independent means knowing B does not update the chance of A.")
        .Section("From counts to a worked conditional",
            "Suppose 200 students: 120 play a sport, and among all students 50 play a sport and take music. Then P(music | sport) = 50/120, not 50/200.\n\nIf a problem gives only percents, convert carefully or rebuild a table with a convenient total like 100 or 1000 to think in counts.",
            simple: "Find the given group size first; that number is your denominator.")
        .Section("Common real-world traps",
            "• Base rate neglect: a high P(positive test | disease) does not alone tell you P(disease | positive test) without prevalence.\n• Confusing P(A|B) with P(B|A) (the prosecutor’s fallacy style mix-up).\n• Using row totals when the English “given” refers to a column.\n\nSlow down and rewrite the question as “Among ___, what fraction are ___?”",
            prior: "This is still fraction sense, but the story labels which group is the whole.")
        .Formula("Conditional probability", @"P(A\mid B)=\frac{P(A\cap B)}{P(B)}", "Restrict to B, then measure A.")
        .Formula("From table counts", @"P(A\mid B)=\frac{n(A\cap B)}{n(B)}", "Cell over the given group's total.")
        .Formula("Independence", @"P(A\cap B)=P(A)P(B)", "Equivalent factorization when independent.")
        .Example("Read a two-way table",
            "Table: Sports Yes/No vs Music Yes/No. Yes-Yes 40, Yes-No 80, No-Yes 30, No-No 50. Find P(music | sports).",
            [
                "Sports total: 40+80 = 120.",
                "Music and sports: 40.",
                "P(music | sports) = 40/120 = 1/3.",
                "Grand total 200 is not the denominator for this conditional."
            ],
            "1/3.",
            solutionLatex: @"\frac{40}{120}=\frac{1}{3}")
        .Example("Joint probability",
            "Using the same table (n = 200), find P(sports and music).",
            [
                "Joint count in Yes-Yes cell: 40.",
                "P = 40/200 = 0.2.",
                "As a percent: 20% of all students do both.",
                "This is smaller than P(music|sports) because the whole is larger."
            ],
            "0.2.",
            solutionLatex: @"\frac{40}{200}=0.2")
        .Example("Formula form",
            "P(A and B) = 0.15 and P(B) = 0.5. Find P(A|B).",
            [
                "P(A|B) = 0.15 / 0.5.",
                "0.15/0.5 = 0.3.",
                "Interpretation: when B happens, A happens 30% of the time.",
                "Check: 0.3 is between 0 and 1."
            ],
            "0.3.",
            problemLatex: @"P(A\mid B)=\frac{0.15}{0.5}",
            solutionLatex: @"0.3")
        .Example("Independence test",
            "P(A) = 0.4, P(B) = 0.5, P(A and B) = 0.2. Are A and B independent?",
            [
                "If independent, P(A)P(B) should equal P(A and B).",
                "0.4 · 0.5 = 0.2, which matches 0.2.",
                "Alternatively P(A|B) = 0.2/0.5 = 0.4 = P(A).",
                "Yes, they are independent under this model."
            ],
            "Independent, because 0.4·0.5 = 0.2.",
            solutionLatex: @"0.4\cdot 0.5=0.2")
        .Mistake("Dividing by the grand total when the problem says “given” a subgroup.")
        .Mistake("Swapping P(A|B) with P(B|A).")
        .Mistake("Assuming independence without checking the product rule or equal conditionals.")
        .Mistake("Adding cell percents that already condition on different groups as if they share a whole.")
        .Numeric("n(A and B)=12, n(B)=40. P(A|B) as a decimal?", "0.3",
            ["12/40 = 0.3."],
            "0.3.",
            explanationLatex: @"\frac{12}{40}=0.3")
        .Numeric("P(A and B)=0.1, P(B)=0.4. P(A|B)?", "0.25",
            ["0.1/0.4 = 0.25."],
            "0.25.",
            explanationLatex: @"0.25")
        .Mcq("In a two-way table, P(A|B) uses which denominator?",
            ["Grand total only", "Total for B", "Total for A always", "Always 100"], 1,
            ["Condition on B means B is the new whole.", "Use n(B) or P(B)."],
            "Divide by the B total.")
        .Numeric("Joint cell 25 out of n=100. Joint relative frequency?", "0.25",
            ["25/100."],
            "0.25.")
        .Numeric("P(A)=0.5, P(B)=0.4, independent. P(A and B)?", "0.2",
            ["Multiply: 0.5·0.4."],
            "0.2.",
            explanationLatex: @"0.5\cdot 0.4=0.2")
        .Mcq("If P(A|B) differs from P(A), then A and B are:",
            ["Independent", "Mutually exclusive always", "Not independent", "Impossible events"], 2,
            ["Independence requires P(A|B)=P(A).", "A change means association."],
            "They are not independent.")
        .Numeric("Column B total 80; cell A and B is 16. P(A|B)?", "0.2",
            ["16/80 = 0.2."],
            "0.2.")
        .Numeric("P(B|A) if P(A and B)=0.12 and P(A)=0.3?", "0.4",
            ["0.12/0.3 = 0.4."],
            "0.4.",
            explanationLatex: @"0.4")
        .Build();
}
