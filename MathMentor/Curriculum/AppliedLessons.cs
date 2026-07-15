using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class AppliedLessons
{
    public const string CategoryId = "applied";

    public static Category Build()
    {
        var lessons = new[]
        {
            PersonalFinance(),
            UnitConversion()
        };
        return new Category(CategoryId, "Applied Math",
            "Personal finance growth and interest, plus unit conversion and rates for real measurements.",
            "\uE8A5", 15, lessons);
    }

    private static Lesson PersonalFinance() => new LessonBuilder("app-finance", CategoryId, "Personal Finance: Interest & Growth")
        .Subtitle("Simple interest, compound interest, and how time multiplies growth")
        .Order(1).Minutes("34 min")
        .Section("Why interest exists",
            "When you borrow money, lenders charge interest as the cost of using their funds. When you save or invest, interest (or investment return) is what your money can earn over time. Understanding interest protects you from costly debt and helps you compare savings options fairly.\n\nTwo big ideas: principal (starting amount) and rate (usually an annual percent). Time and compounding frequency decide how fast the balance changes.",
            simple: "Interest is a rental fee for money. You pay it on loans and can earn it on savings.",
            prior: "Percents as decimals (5% = 0.05) and exponents for repeated growth are the core skills.")
        .Section("Simple interest",
            "Simple interest is computed only on the original principal. The interest earned (or owed) after time t years at annual rate r (as a decimal) is I = Prt. The total amount is A = P + I = P(1 + rt).\n\nSimple interest is common in short-term notes and some classroom models. It grows linearly in time: double the years, double the interest (rate and principal fixed).",
            @"I=Prt,\quad A=P(1+rt)",
            simple: "Simple interest: multiply principal × rate × time. Add that to principal for the total.")
        .Section("Compound interest",
            "Compound interest pays interest on the current balance, so earlier interest itself earns interest. If interest compounds n times per year at annual rate r for t years,\nA = P(1 + r/n)^(nt).\n\nCompared with simple interest at the same r, compounding grows faster as t increases. That is why long-term savings loves compounding, and long-term high-interest debt is dangerous.",
            @"A=P\left(1+\frac{r}{n}\right)^{nt}",
            simple: "Compound: each period multiplies the balance by (1 + rate per period).",
            prior: "The exponent nt counts how many compounding periods occur in t years.")
        .Section("APR ideas and comparing rates",
            "Annual percentage rate (APR) language in real products can include fees; in this lesson we focus on the pure interest formulas. Still, when comparing offers, match the compounding assumptions and the time horizon.\n\nEffective annual growth depends on n: compounding more often at the same nominal r produces a slightly higher effective yearly factor (1 + r/n)^n. Monthly (n = 12) and daily models are common.",
            @"\left(1+\frac{r}{n}\right)^n",
            simple: "Same headline rate can grow differently if one account compounds more often.")
        .Section("Growth mindset for balances",
            "For estimates, the rule of 72 says a rough doubling time in years is about 72 divided by the percent rate (for compound growth near typical rates). Example: 8% yearly compounding roughly doubles in 72/8 ≈ 9 years. It is an estimate, not a theorem for every case.\n\nAlways separate “interest earned” from “final amount,” and watch units: rate as a decimal, time in years (or convert months to years).",
            prior: "If a problem gives 6 months, use t = 0.5 year when the rate is annual.")
        .Section("Loans vs savings (same math, different story)",
            "The formulas look similar whether money is growing for you or against you. On savings, larger A is good. On a loan that only tracks interest this way, larger A is what you may owe. Real loans often use amortization schedules (regular payments that mix interest and principal). This lesson builds the pure growth engine those schedules rest on.",
            simple: "Same formulas; interpret the result as wealth when saving and as cost when borrowing.")
        .Formula("Simple interest", @"I=Prt", "Interest only on original principal.")
        .Formula("Simple amount", @"A=P(1+rt)", "Principal plus simple interest.")
        .Formula("Compound amount", @"A=P\left(1+\frac{r}{n}\right)^{nt}", "Balance after nt compounding periods.")
        .Formula("Annual rate as decimal", @"5\%=0.05", "Always convert percents before substituting.")
        .Example("Simple interest earned",
            "Principal $800 at 4% simple interest for 3 years. Find the interest and the total amount.",
            [
                "Write r = 0.04, P = 800, t = 3.",
                "I = Prt = 800 · 0.04 · 3 = 96.",
                "A = P + I = 800 + 96 = 896.",
                "Or A = 800(1 + 0.04·3) = 800(1.12) = 896."
            ],
            "Interest $96; amount $896.",
            problemLatex: @"P=800,\;r=0.04,\;t=3",
            solutionLatex: @"I=96,\;A=896")
        .Example("Months as a fraction of a year",
            "P = $500, r = 6% simple, time = 6 months. Find I.",
            [
                "t = 6/12 = 0.5 year.",
                "I = 500 · 0.06 · 0.5 = 15.",
                "Using t = 6 by mistake (as if 6 years) would explode the answer.",
                "Total amount would be 515 if asked."
            ],
            "Interest is $15.",
            solutionLatex: @"I=15")
        .Example("Annual compound interest",
            "P = $1000, r = 5% compounded annually (n = 1) for 2 years. Find A.",
            [
                "A = 1000(1 + 0.05/1)^(1·2) = 1000(1.05)^2.",
                "(1.05)^2 = 1.1025.",
                "A = 1000 · 1.1025 = 1102.5.",
                "Simple interest for comparison: I = 1000·0.05·2 = 100, A = 1100, a bit less than compound."
            ],
            "A = $1102.50.",
            problemLatex: @"A=1000(1.05)^2",
            solutionLatex: @"1102.50")
        .Example("Monthly compounding setup",
            "P = $2000, r = 6%, compounded monthly for 1 year. Write A and compute.",
            [
                "n = 12, t = 1, so nt = 12.",
                "A = 2000(1 + 0.06/12)^12 = 2000(1.005)^12.",
                "(1.005)^12 ≈ 1.06168.",
                "A ≈ 2000 · 1.06168 = 2123.36."
            ],
            "About $2123.36.",
            problemLatex: @"A=2000\left(1+\frac{0.06}{12}\right)^{12}",
            solutionLatex: @"2123.36")
        .Mistake("Leaving the rate as 5 instead of 0.05 in the formula.")
        .Mistake("Using months as t without converting to years when r is annual.")
        .Mistake("Confusing interest I with final amount A.")
        .Mistake("Using simple interest for a situation that compounds (or the reverse) without reading the problem.")
        .Numeric("Simple interest: P=400, r=0.05, t=2. Find I.", "40",
            ["I = 400·0.05·2.", "40."],
            "I = 40.",
            explanationLatex: @"I=40")
        .Numeric("Simple amount: P=250, r=0.08, t=1. Find A.", "270",
            ["A = 250(1+0.08·1) = 250·1.08."],
            "A = 270.",
            explanationLatex: @"270")
        .Numeric("t for 9 months in years (decimal)?", "0.75",
            ["9/12 = 0.75."],
            "0.75 year.",
            tolerance: 0.001)
        .Numeric("Compound annually: P=500, r=0.1, t=2, n=1. Find A.", "605",
            ["A = 500(1.1)^2 = 500·1.21."],
            "A = 605.",
            explanationLatex: @"500(1.1)^2=605")
        .Mcq("Compound interest differs from simple interest because it:",
            ["Ignores the principal", "Earns interest on prior interest", "Always uses r = 1", "Only works for one day"], 1,
            ["The base grows each period.", "Interest is calculated on the updated balance."],
            "Compounding applies interest to interest already earned.")
        .Numeric("I = Prt with P=1000, r=0.04, t=0.5. Find I.", "20",
            ["1000·0.04·0.5 = 20."],
            "I = 20.")
        .Numeric("A = 1000(1.03)^1. What is A?", "1030",
            ["One year of 3% annual compound."],
            "A = 1030.")
        .Mcq("In A = P(1 + r/n)^(nt), the exponent nt counts:",
            ["Only the principal", "Number of compounding periods", "Always exactly 12", "The percent rate twice"], 1,
            ["n times per year for t years.", "Monthly for 2 years → 24 periods."],
            "nt is the total number of compoundings.")
        .Build();

    private static Lesson UnitConversion() => new LessonBuilder("app-units", CategoryId, "Unit Conversion & Rates")
        .Subtitle("Multiply by conversion factors, cancel units, and work cleanly with rates")
        .Order(2).Minutes("32 min")
        .Section("Units are part of the number",
            "A measurement is a number plus a unit: 3 meters is not the same as 3 feet. Unit conversion changes the unit while keeping the same physical quantity. The reliable method is multiplying by conversion factors that equal 1, such as (100 cm)/(1 m) or (1 m)/(100 cm), chosen so unwanted units cancel.",
            simple: "Multiply by a carefully chosen form of 1 so old units cancel and new units remain.",
            prior: "Fraction multiplication and canceling common factors is exactly the skill you reuse on units.")
        .Section("Metric prefixes you should know",
            "Metric units scale by powers of ten. Common prefixes: kilo- (10^3), centi- (10^{-2}), milli- (10^{-3}). So 1 km = 1000 m, 1 m = 100 cm, 1 m = 1000 mm.\n\nMoving between metric units is often a decimal-point shift, but writing the conversion factor still prevents mistakes when several units chain together.",
            @"1\,\mathrm{km}=1000\,\mathrm{m}",
            simple: "Metric is base-ten: kilo big, milli small, centi hundredths.")
        .Section("US customary bridges",
            "Memorize a short bridge list: 12 in = 1 ft, 3 ft = 1 yd, 5280 ft = 1 mi; 16 oz = 1 lb; 4 qt = 1 gal; 60 s = 1 min, 60 min = 1 h. For metric-customary links, problems usually provide the factor (for example, 1 in = 2.54 cm).\n\nNever invent a bridge. If the factor is not given or standard in your course list, you cannot convert.",
            prior: "Time conversions (60 and 24) show up inside speed and work-rate problems constantly.")
        .Section("Rates as fractions with units",
            "A rate is a ratio of two different units: miles per hour, dollars per pound, people per square mile. Unit rates have 1 in the second place after simplifying (60 miles / 1 hour).\n\nTo convert a rate, convert the numerator unit, the denominator unit, or both, using conversion factors. Example: ft/s to mi/h needs feet → miles and seconds → hours.",
            @"\frac{60\text{ mi}}{1\text{ h}}",
            simple: "Write the rate as a fraction. Cancel units until only the target units remain.")
        .Section("Dimensional analysis chains",
            "Multi-step conversions multiply several factors in one line:\n(3.5 h) · (60 min)/(1 h) · (60 s)/(1 min) = 12600 s.\n\nKeep units in every factor. If the final units are wrong, the setup is wrong even if the arithmetic looks neat. This habit is dimensional analysis, used in science as much as in math class.",
            simple: "String conversion factors in a row; cancel as you go; check the leftover unit.")
        .Section("Precision and sense checks",
            "Ask: should the number get larger or smaller? Converting meters to centimeters should increase the count (more small units). Converting hours to days should decrease the count. If your answer fails that sense check, a factor was upside down.\n\nAlso match problem precision: if data are given to the nearest tenth, do not pretend you know twenty decimal places after a messy conversion.",
            prior: "Sense checks are the same habit used when estimating products and quotients.")
        .Formula("Conversion factor", @"\frac{100\,\mathrm{cm}}{1\,\mathrm{m}}=1", "Multiply by 1 written to cancel units.")
        .Formula("Unit rate", @"\frac{\text{quantity}}{\text{one unit}}", "How many per single unit of the second measure.")
        .Formula("Speed", @"\text{speed}=\frac{\text{distance}}{\text{time}}", "Classic rate with cancelable units.")
        .Example("Metric length",
            "Convert 2.5 km to meters.",
            [
                "Use 1 km = 1000 m.",
                "2.5 km · (1000 m)/(1 km) = 2500 m.",
                "Kilometers cancel; meters remain.",
                "Sense check: more meters than kilometers, count increased."
            ],
            "2500 m.",
            problemLatex: @"2.5\,\mathrm{km}",
            solutionLatex: @"2500\,\mathrm{m}")
        .Example("Time chain",
            "Convert 2 hours to seconds.",
            [
                "2 h · (60 min)/(1 h) = 120 min.",
                "120 min · (60 s)/(1 min) = 7200 s.",
                "Or one chain: 2·60·60 = 7200.",
                "Upside-down factor (h/min) would destroy the units."
            ],
            "7200 seconds.",
            solutionLatex: @"7200")
        .Example("Unit price",
            "A 12 oz bag costs $3.00. What is the price per ounce?",
            [
                "Unit rate: dollars per ounce = 3.00/12.",
                "3/12 = 0.25.",
                "So $0.25 per ounce.",
                "Compare another bag by the same per-ounce unit rate."
            ],
            "$0.25 per oz.",
            solutionLatex: @"0.25")
        .Example("Speed conversion setup",
            "A car travels 90 ft/s. About how many mi/h is that? Use 5280 ft = 1 mi.",
            [
                "Start with 90 ft/s.",
                "Multiply by (1 mi)/(5280 ft) and (3600 s)/(1 h).",
                "90 · 3600 / 5280 = 324000/5280 = 61.36... ≈ 61.4 mi/h.",
                "Sense check: roughly 60 mi/h is a familiar highway speed, so the magnitude is plausible."
            ],
            "About 61.4 mi/h.",
            problemLatex: @"90\,\frac{\mathrm{ft}}{\mathrm{s}}",
            solutionLatex: @"61.4\,\frac{\mathrm{mi}}{\mathrm{h}}")
        .Mistake("Flipping a conversion factor so units do not cancel.")
        .Mistake("Converting only one part of a rate and forgetting the other unit.")
        .Mistake("Mixing metric prefixes (treating milli- like centi-).")
        .Mistake("Dropping units mid-work so errors hide until the end.")
        .Numeric("How many centimeters in 3 meters?", "300",
            ["1 m = 100 cm.", "3·100 = 300."],
            "300 cm.",
            explanationLatex: @"300")
        .Numeric("How many minutes in 2.5 hours?", "150",
            ["2.5·60."],
            "150 minutes.")
        .Numeric("Convert 5000 m to km.", "5",
            ["Divide by 1000.", "5000/1000 = 5."],
            "5 km.")
        .Numeric("Unit price: $10 for 4 lb. Dollars per pound?", "2.5",
            ["10/4 = 2.5."],
            "2.5 dollars per pound.",
            tolerance: 0.01)
        .Mcq("To cancel meters in the numerator, multiply by a factor with meters in the:",
            ["Numerator only", "Denominator", "Exponent", "Percent"], 1,
            ["Cancel like factors in fractions.", "Matching unit must appear opposite."],
            "Put meters in the denominator to cancel.")
        .Numeric("How many seconds in 3 minutes?", "180",
            ["3·60 = 180."],
            "180 s.")
        .Numeric("A runner goes 12 km in 1.5 h. Speed in km/h?", "8",
            ["12/1.5 = 8."],
            "8 km/h.",
            explanationLatex: @"8")
        .Numeric("Inches in 5 feet (12 in = 1 ft)?", "60",
            ["5·12 = 60."],
            "60 inches.")
        .Build();
}
