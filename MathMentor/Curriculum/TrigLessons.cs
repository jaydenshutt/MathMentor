using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class TrigLessons
{
    public const string CategoryId = "trig";

    public static Category Build()
    {
        var lessons = new[]
        {
            UnitCircle(),
            SinCosTan(),
            Identities(),
            TrigEquations(),
            LawsOfSinesCosines(),
            TrigApplications()
        };
        return new Category(CategoryId, "Trigonometry",
            "Unit circle, graphs, identities, equations, and triangle applications.",
            "\uE9D9", 12, lessons);
    }

    private static Lesson UnitCircle() => new LessonBuilder("trig-circle", CategoryId, "The Unit Circle & Special Angle Values")
        .Subtitle("Cosine and sine as coordinates, the single picture that unifies all angles")
        .Order(1).Minutes("32 min")
        .Visual(VisualKind.UnitCircle, "Every angle θ in standard position hits the unit circle at the point (cos θ, sin θ).")
        .Section("Why the unit circle is the heart of trigonometry",
            "In geometry class, sine and cosine often appear only for acute angles in right triangles: opposite over hypotenuse, adjacent over hypotenuse. That definition is useful, but it is incomplete. What is sin 120°? What is cos(−π/3)? A right triangle with a 120° angle does not sit politely inside a standard SOH-CAH-TOA diagram.\n\nThe unit circle solves this once and for all. Draw the circle of radius 1 centered at the origin: every point (x, y) on it satisfies x² + y² = 1. Place an angle θ in standard position: vertex at the origin, initial side along the positive x-axis, terminal side rotated counterclockwise for positive θ. That terminal side meets the circle at exactly one point. By definition:\n• the x-coordinate is cos θ\n• the y-coordinate is sin θ\n\nSo cosine and sine are not “magic ratios”, they are coordinates. Tangent is the slope-like ratio sin θ / cos θ (when cos θ ≠ 0). This single picture extends trig to every real angle, positive or negative, and makes identities like sin²θ + cos²θ = 1 obvious: they are just the circle equation.")
        .Section("Radians: measuring angle by arc length",
            "Degrees are a human convention (360° in a full turn, from ancient astronomy). Radians are the natural mathematical unit: the radian measure of a central angle is the length of the arc it cuts on the unit circle. A full turn has circumference 2π, so 360° = 2π rad and 180° = π rad.\n\nConversion formulas:\n• degrees to radians: multiply by π/180\n• radians to degrees: multiply by 180/π\n\nWhy care? Calculus formulas for derivatives of sin and cos are cleanest in radians. In this course, learn both languages fluently and always know which mode a calculator is using.",
            @"\pi\text{ rad}=180^\circ",
            simple: "On a circle of radius 1, the angle in radians is literally the curved distance you walk along the rim. Half a circle is about 3.14 units of walk, that is π radians.",
            prior: "You only need the idea of a circle, coordinates (x, y), and that a full turn is 360°. Nothing more.")
        .Section("Special angles you must know cold",
            "Certain angles appear constantly because their coordinates involve simple numbers built from 0, 1/2, √2/2, and √3/2. Memorize the first-quadrant “core” and then reflect using signs:\n• 0° = 0 rad → (1, 0)\n• 30° = π/6 → (√3/2, 1/2)\n• 45° = π/4 → (√2/2, √2/2)\n• 60° = π/3 → (1/2, √3/2)\n• 90° = π/2 → (0, 1)\n\nA memory pattern for sine of 0°, 30°, 45°, 60°, 90° is √0/2, √1/2, √2/2, √3/2, √4/2. Cosine is that list reversed. Once you know the acute values, every other special angle is a reflection or coterminal copy.")
        .Section("Reference angles and signs by quadrant",
            "A reference angle is the acute angle between the terminal side and the x-axis. The absolute values of sine and cosine equal the sine and cosine of the reference angle; the quadrant only decides the sign.\n\nAll Students Take Calculus (ASTC) is a common memory phrase, going counterclockwise from QI:\n• QI: all of sin, cos, tan positive\n• QII: sine positive (cosine and tan negative)\n• QIII: tangent positive (sin and cos negative)\n• QIV: cosine positive (sin and tan negative)\n\nExample: 150° has reference 30° and sits in QII, so sin 150° = +sin 30° = 1/2 and cos 150° = −cos 30° = −√3/2.",
            simple: "Find the “related acute angle” first. Copy its sin/cos values, then slap on + or − based on which quadrant you landed in.",
            prior: "You need the special-angle table for 0°, 30°, 45°, 60°, 90° and the idea that the plane has four quadrants.")
        .Section("Coterminal angles and negative angles",
            "Angles that share the same terminal side are coterminal: add or subtract full turns (360° or 2π). Negative angles rotate clockwise. So cos(−θ) = cos θ (even function) and sin(−θ) = −sin θ (odd function), reflections across the x-axis. These symmetries cut memorization work in half.")
        .Formula("Unit circle definition", @"(\cos\theta,\sin\theta)\text{ on }x^2+y^2=1", "Coordinates of the terminal-side intersection.")
        .Formula("Pythagorean identity", @"\cos^2\theta+\sin^2\theta=1", "The circle equation in trig form.")
        .Formula("Degree-radian bridge", @"\theta_{\text{rad}}=\theta_{\text{deg}}\cdot\frac{\pi}{180}", "Multiply by π/180 to convert degrees to radians.")
        .Example("Reading the circle at 0",
            "Find cos 0 and sin 0 using the unit circle.",
            [
                "Angle 0 means no rotation: the terminal side is the positive x-axis.",
                "That ray meets the unit circle at (1, 0).",
                "By definition, cos 0 is the x-coordinate 1 and sin 0 is the y-coordinate 0.",
                "Sanity check: a right triangle with angle 0 has opposite side 0, so sin = 0 matches the old ratio idea."
            ],
            "cos 0 = 1 and sin 0 = 0.",
            problemLatex: @"\theta=0",
            solutionLatex: @"\cos 0=1,\;\sin 0=0",
            stepLatex: [null, @"(1,0)", @"\cos 0=1,\;\sin 0=0", null])
        .Example("The 45° pair",
            "Find sin 45° and cos 45°.",
            [
                "At 45°, the terminal side is the line y = x in QI.",
                "It meets x² + y² = 1 with x = y, so 2x² = 1 → x² = 1/2 → x = √2/2 (positive in QI).",
                "Thus cos 45° = sin 45° = √2/2.",
                "Common slip: writing √2/4 by incorrectly “distributing” the square root, √(1/2) is √2/2, not 1/2."
            ],
            "Both equal √2/2.",
            problemLatex: @"45^\circ=\frac{\pi}{4}",
            solutionLatex: @"\sin 45^\circ=\cos 45^\circ=\frac{\sqrt{2}}{2}",
            stepLatex: [@"y=x", @"2x^2=1", @"x=\frac{\sqrt{2}}{2}", null])
        .Example("Quadrant II special angle",
            "Find sin 120° and cos 120°.",
            [
                "120° is in QII. Reference angle: 180° − 120° = 60°.",
                "sin 60° = √3/2 and cos 60° = 1/2.",
                "In QII, sine is positive and cosine is negative.",
                "Therefore sin 120° = √3/2 and cos 120° = −1/2."
            ],
            "sin 120° = √3/2, cos 120° = −1/2.",
            problemLatex: @"120^\circ",
            solutionLatex: @"\sin 120^\circ=\frac{\sqrt{3}}{2},\;\cos 120^\circ=-\frac{1}{2}",
            stepLatex: [@"180^\circ-120^\circ=60^\circ", @"\sin 60^\circ=\frac{\sqrt{3}}{2}", @"\text{QII: sin}+,\;\text{cos}-", null])
        .Example("Convert and interpret",
            "Convert π/3 radians to degrees, then state sin(π/3) and cos(π/3).",
            [
                "Multiply by 180/π: (π/3)·(180/π) = 60°.",
                "π/3 is the familiar 60° angle in QI.",
                "sin(π/3) = √3/2 and cos(π/3) = 1/2.",
                "If a calculator were in degree mode and you typed sin(π/3) thinking “radians,” you would get a wrong tiny number, mode errors are the classic trap."
            ],
            "π/3 = 60°; sin = √3/2; cos = 1/2.",
            problemLatex: @"\frac{\pi}{3}",
            solutionLatex: @"\frac{\pi}{3}=60^\circ,\;\sin=\frac{\sqrt{3}}{2},\;\cos=\frac{1}{2}",
            stepLatex: [@"\frac{\pi}{3}\cdot\frac{180}{\pi}=60", null, @"\sin\frac{\pi}{3}=\frac{\sqrt{3}}{2}", null])
        .Mistake("Using degrees in a calculator set to radians (or vice versa), always check the mode.")
        .Mistake("Copying the reference-angle value but forgetting the quadrant sign.")
        .Mistake("Writing cos²θ as cos(θ²), or treating √(1/2) as 1/2.")
        .Mistake("Thinking the unit circle only works for acute angles.")
        .Numeric("What is cos 0°?", "1",
            ["Point is (1, 0) on the unit circle.", "Cosine is the x-coordinate."],
            "cos 0° = 1.")
        .Numeric("What is sin 90°?", "1",
            ["Point is (0, 1).", "Sine is the y-coordinate."],
            "sin 90° = 1.")
        .Numeric("What is cos 60°? Enter as a decimal.", "0.5",
            ["Special angle: cos 60° = 1/2."],
            "cos 60° = 1/2 = 0.5.", tolerance: 0.001)
        .Numeric("What is sin 30°? Enter as a decimal.", "0.5",
            ["sin 30° = 1/2."],
            "sin 30° = 0.5.", tolerance: 0.001)
        .Numeric("Convert π/2 radians to degrees.", "90",
            ["Multiply by 180/π.", "(π/2)·(180/π) = 90."],
            "π/2 rad = 90°.")
        .Mcq("The unit-circle point for 180° is:",
            ["(1, 0)", "(-1, 0)", "(0, 1)", "(0, -1)"], 1,
            ["180° points left along the negative x-axis.", "Radius 1 lands at (−1, 0)."],
            "At 180°, (cos, sin) = (−1, 0).")
        .Numeric("What is cos 90°?", "0",
            ["Point (0, 1).", "x-coordinate is 0."],
            "cos 90° = 0.")
        .Mcq("In which quadrant is sine positive and cosine negative?",
            ["I", "II", "III", "IV"], 1,
            ["ASTC: sine positive in QII.", "Cosine is negative left of the y-axis."],
            "Quadrant II.")
        .Numeric("sin 150° equals sin of what acute reference angle (degrees)?", "30",
            ["Reference = 180 − 150."],
            "Reference angle is 30°; sin 150° = +sin 30°.")
        .Build();

    private static Lesson SinCosTan() => new LessonBuilder("trig-functions", CategoryId, "Sine, Cosine, Tangent: Graphs & Transformations")
        .Subtitle("From triangle ratios to waves: amplitude, period, phase, and midline")
        .Order(2).Minutes("32 min")
        .Visual(VisualKind.LineGraph, "Sine and cosine are smooth waves of period 2π; tangent repeats every π with vertical asymptotes.")
        .Section("Three definitions that should live in your head together",
            "Trigonometric functions can be introduced three compatible ways:\n1) Right-triangle ratios (acute angles): sin = opp/hyp, cos = adj/hyp, tan = opp/adj.\n2) Unit-circle coordinates (all angles): cos θ = x, sin θ = y on the unit circle.\n3) Graphs as functions of a real variable: y = sin x, y = cos x, y = tan x.\n\nWhen an angle is acute and you draw a right triangle, (1) and (2) agree. When the angle is obtuse or negative, lean on (2). When you study sound, tides, or circular motion over time, lean on (3). Fluency means choosing the view that fits the problem.",
            simple: "Triangle ratios for sharp angles inside a triangle; unit circle for any angle; graphs when the angle is the input variable of a wave.")
        .Section("How sine and cosine look as waves",
            "Imagine a point racing around the unit circle at constant speed. Its height (y = sin θ) oscillates between −1 and 1. Its horizontal position (x = cos θ) does the same, but shifted: cos θ = sin(θ + π/2).\n\nKey features of y = sin x and y = cos x (x in radians):\n• Domain: all real x\n• Range: [−1, 1]\n• Amplitude: 1 (half the vertical distance from min to max)\n• Period: 2π (one full cycle)\n• Midline: y = 0\n\nSine starts at 0 when x = 0; cosine starts at 1. Knowing five landmarks per cycle (start, max, mid, min, end) is enough to sketch either graph by hand.",
            prior: "You need the unit-circle values at 0, π/2, π, 3π/2, 2π and the idea of a periodic pattern.")
        .Section("Tangent: slope of the terminal ray",
            "tan θ = sin θ / cos θ whenever cos θ ≠ 0. On the unit circle, that is y/x, the slope of the line from the origin to the point (cos θ, sin θ). When cos θ = 0 (θ = π/2 + πk), the ray is vertical and tan is undefined: vertical asymptotes on the graph.\n\nPeriod of tangent is π, not 2π, because after half a turn the slope repeats even though sine and cosine have both flipped sign (the ratio is unchanged).",
            @"\tan\theta=\frac{\sin\theta}{\cos\theta}",
            simple: "Tangent is “rise over run” for the terminal side. When run is zero, tangent blows up.")
        .Section("Transformations: the ABCD template",
            "The general sine wave used in applications is\ny = A sin(B(x − C)) + D\n(or the same form with cos).\n\n• |A| = amplitude (vertical stretch; if A < 0 the wave flips)\n• Period = 2π / |B| for sine/cosine (horizontal compress when |B| > 1)\n• C = phase shift (horizontal translation; careful with the factored form B(x − C))\n• D = vertical shift (new midline y = D)\n\nMax value is D + |A|; min value is D − |A|. Always identify midline first when graphing, it is the “home height” of the wave.",
            @"y=A\sin(B(x-C))+D",
            simple: "A tallens the wave, B squishes the cycle left-right, C slides it sideways, D lifts the whole graph up or down.",
            prior: "If you have seen function transformations y = a f(b(x − c)) + d for any f, this is the same toolkit applied to sin and cos.")
        .Formula("Tangent as ratio", @"\tan\theta=\frac{\sin\theta}{\cos\theta}", "Undefined where cos θ = 0.")
        .Formula("Sine/cosine period", @"T=\frac{2\pi}{|B|}\text{ for }\sin(Bx)\text{ or }\cos(Bx)", "Horizontal scaling by B.")
        .Formula("Amplitude and midline", @"\text{amp}=|A|,\;\text{midline }y=D", "From y = A sin(…) + D.")
        .Example("Right-triangle ratio",
            "In a right triangle, opposite = 3 and hypotenuse = 5. Find sin of the angle.",
            [
                "Use the ratio definition: sin = opposite / hypotenuse.",
                "sin θ = 3/5 = 0.6.",
                "You could also find the adjacent side with Pythagoras (4) and then cos = 4/5, tan = 3/4.",
                "Check: sin² + cos² = 9/25 + 16/25 = 1, consistent."
            ],
            "sin θ = 3/5.",
            problemLatex: @"\sin\theta=\frac{3}{5}",
            solutionLatex: @"\frac{3}{5}",
            stepLatex: [@"\sin=\frac{\text{opp}}{\text{hyp}}", @"\frac{3}{5}", null, @"\left(\frac{3}{5}\right)^2+\left(\frac{4}{5}\right)^2=1"])
        .Example("Amplitude from a formula",
            "What is the amplitude of y = 4 sin x? Of y = −3 cos x?",
            [
                "Amplitude is |A|, the absolute value of the coefficient in front of sin or cos.",
                "For 4 sin x, |4| = 4. The wave peaks at 4 and troughs at −4.",
                "For −3 cos x, |−3| = 3. The negative sign reflects the graph over the x-axis but does not change amplitude.",
                "Mistake to avoid: calling the amplitude −3."
            ],
            "Amplitudes 4 and 3 respectively.",
            solutionLatex: @"|A|=4,\;|A|=3")
        .Example("Period of a compressed sine",
            "Find the period of y = sin(2x).",
            [
                "Standard sine has period 2π. Here B = 2.",
                "Period formula: T = 2π / |B| = 2π / 2 = π.",
                "Meaning: the wave finishes a full cycle twice as fast, one cycle on [0, π] instead of [0, 2π].",
                "Do not confuse B with amplitude. Amplitude of sin(2x) is still 1."
            ],
            "Period is π.",
            problemLatex: @"y=\sin(2x)",
            solutionLatex: @"T=\pi",
            stepLatex: [@"B=2", @"T=\frac{2\pi}{2}=\pi", null, null])
        .Example("Tangent at a special angle",
            "Evaluate tan 45°.",
            [
                "tan θ = sin θ / cos θ.",
                "At 45°, sin = cos = √2/2.",
                "Ratio: (√2/2) / (√2/2) = 1.",
                "Geometrically: the terminal ray is y = x, which has slope 1."
            ],
            "tan 45° = 1.",
            solutionLatex: @"\tan 45^\circ=1")
        .Mistake("Using period 2π for y = tan x (actual fundamental period is π).")
        .Mistake("Treating the coefficient B in sin(Bx) as amplitude instead of frequency/period control.")
        .Mistake("Forgetting that a negative A reflects the graph; amplitude is still |A|.")
        .Mistake("Writing the phase shift incorrectly when the form is sin(Bx − φ) instead of sin(B(x − C)).")
        .Numeric("If opp = 5 and hyp = 13, what is sin θ? Enter a decimal.", "0.3846",
            ["sin = 5/13."],
            "5/13 ≈ 0.3846.", tolerance: 0.01)
        .Numeric("Amplitude of y = −3 cos x?", "3",
            ["Amplitude is |A|.", "|−3| = 3."],
            "Amplitude is 3.")
        .Numeric("Period of sin(4x) is π/k. What is k?", "2",
            ["T = 2π/4 = π/2, so k = 2."],
            "Period is π/2.")
        .Mcq("tan θ is undefined when:",
            ["sin θ = 0", "cos θ = 0", "tan θ = 1", "θ = 0"], 1,
            ["tan = sin/cos.", "Division by zero when cos = 0."],
            "Whenever cos θ = 0.")
        .Numeric("If adj = 8 and hyp = 10, what is cos θ?", "0.8",
            ["cos = adj/hyp = 8/10."],
            "cos θ = 0.8.")
        .Numeric("For y = 2 sin x + 5, what is the vertical shift D?", "5",
            ["The +5 lifts the midline to y = 5."],
            "Midline/vertical shift is 5.")
        .Numeric("What is tan 0°?", "0",
            ["sin 0 = 0, cos 0 = 1.", "0/1 = 0."],
            "tan 0° = 0.")
        .Mcq("The maximum value of y = 2 cos x + 3 is:",
            ["2", "3", "5", "1"], 2,
            ["Max = D + |A| = 3 + 2."],
            "Maximum is 5.")
        .Numeric("Period of y = cos(x/2) is how many π? (enter the coefficient of π, e.g. 4 for 4π)", "4",
            ["B = 1/2; T = 2π / (1/2) = 4π."],
            "Period is 4π.")
        .Build();

    private static Lesson Identities() => new LessonBuilder("trig-id", CategoryId, "Fundamental Trigonometric Identities")
        .Subtitle("True for all allowed angles, your rewrite toolkit")
        .Order(3).Minutes("30 min")
        .Section("What an identity is (and is not)",
            "An equation like sin²θ + cos²θ = 1 is an identity: it holds for every θ where both sides are defined. An equation like sin θ = 1/2 is conditional: it is true only for certain angles.\n\nIdentities are tools. You use them to simplify expressions, rewrite equations into solvable form, and prove other identities by transforming one side into the other (or both sides into a common form). Think of them as legal “moves” in a algebra-of-trig game, every move must preserve equality for all allowed inputs.",
            simple: "An identity is always true (where defined). A conditional equation is a puzzle that is true only for some angles.")
        .Section("The Pythagorean family",
            "Start from the unit circle: cos²θ + sin²θ = 1. That is the parent identity.\n\nDivide both sides by cos²θ (where cos θ ≠ 0):\n1 + tan²θ = sec²θ.\n\nDivide both sides by sin²θ (where sin θ ≠ 0):\n1 + cot²θ = csc²θ.\n\nThese three are the same geometric fact written three ways. When you see 1 − sin²θ, replace it with cos²θ without thinking twice, that single habit unlocks dozens of simplifications.",
            @"\sin^2\theta+\cos^2\theta=1",
            prior: "You need sin and cos as unit-circle coordinates so that x² + y² = 1 becomes the Pythagorean identity.")
        .Section("Reciprocal and quotient identities",
            "Reciprocal:\n• csc θ = 1/sin θ\n• sec θ = 1/cos θ\n• cot θ = 1/tan θ\n\nQuotient:\n• tan θ = sin θ / cos θ\n• cot θ = cos θ / sin θ\n\nThese are definitions as much as identities. They explain why sec is undefined where cos is 0, and why tan has the same zeros as sin (when cos ≠ 0).",
            simple: "sec and csc are “flip cos” and “flip sin.” tan is “sin over cos.”")
        .Section("How to verify or simplify with discipline",
            "Recommended workflow:\n1) Convert everything to sin and cos if the expression is messy.\n2) Use Pythagorean replacements (1 − sin² = cos², etc.).\n3) Factor common pieces; cancel only when the factor is known nonzero or you note domain holes.\n4) For proving identities, pick the more complicated side and drive it toward the simpler side. Do not move terms across the equals sign as if solving an equation, you are rewriting, not solving.\n\nEven/odd and cofunction ideas also help later: sin(−θ) = −sin θ, cos(−θ) = cos θ, and sin(π/2 − θ) = cos θ.")
        .Formula("Pythagorean", @"\sin^2\theta+\cos^2\theta=1", "Parent identity from the unit circle.")
        .Formula("Tan form", @"1+\tan^2\theta=\sec^2\theta", "Divide the parent by cos²θ.")
        .Formula("Quotient", @"\tan\theta=\frac{\sin\theta}{\cos\theta}", "Definition when cos θ ≠ 0.")
        .Example("Find the other coordinate",
            "If sin θ = 3/5 and θ is in Quadrant I, find cos θ.",
            [
                "Use sin²θ + cos²θ = 1.",
                "cos²θ = 1 − (3/5)² = 1 − 9/25 = 16/25.",
                "cos θ = ±4/5. In QI, cosine is positive.",
                "cos θ = 4/5. (In QII you would choose −4/5.)"
            ],
            "cos θ = 4/5.",
            problemLatex: @"\sin\theta=\frac{3}{5}\;(\text{QI})",
            solutionLatex: @"\cos\theta=\frac{4}{5}",
            stepLatex: [@"\sin^2+\cos^2=1", @"\cos^2=1-\frac{9}{25}=\frac{16}{25}", @"\cos=\pm\frac{4}{5}", @"\cos=\frac{4}{5}"])
        .Example("Simplify an expression",
            "Simplify (1 − cos²θ) / sin θ for sin θ ≠ 0.",
            [
                "Replace 1 − cos²θ with sin²θ (Pythagorean).",
                "Expression becomes sin²θ / sin θ.",
                "Cancel one sin θ: result sin θ (provided sin θ ≠ 0).",
                "Check with a number: θ = π/2 → original (1 − 0)/1 = 1, and sin(π/2) = 1."
            ],
            "Simplifies to sin θ.",
            problemLatex: @"\frac{1-\cos^2\theta}{\sin\theta}",
            solutionLatex: @"\sin\theta",
            stepLatex: [@"1-\cos^2\theta=\sin^2\theta", @"\frac{\sin^2\theta}{\sin\theta}", @"\sin\theta", null])
        .Example("Build tan from sin and cos",
            "If sin θ = 5/13 and cos θ = 12/13, find tan θ.",
            [
                "tan θ = sin θ / cos θ.",
                "tan θ = (5/13) / (12/13) = 5/12.",
                "Note both sin and cos positive → QI → tan positive, which matches.",
                "Also sec θ = 13/12 and csc θ = 13/5 if needed."
            ],
            "tan θ = 5/12.",
            solutionLatex: @"\tan\theta=\frac{5}{12}")
        .Example("Reciprocal value",
            "If cos θ = 1/2, find sec θ.",
            [
                "sec θ = 1 / cos θ by definition.",
                "sec θ = 1 / (1/2) = 2.",
                "This matches the 60° (or π/3) family where cos = 1/2.",
                "Domain note: if cos were 0, sec would not exist."
            ],
            "sec θ = 2.",
            solutionLatex: @"\sec\theta=2")
        .Mistake("Writing sin²θ as sin(θ²), the square applies to the output of sine.")
        .Mistake("Dropping the ± when solving cos²θ = k; quadrant decides the sign.")
        .Mistake("Canceling a factor that could be zero without stating domain restrictions.")
        .Mistake("“Proving” an identity by starting with what you want and working backwards without reversible steps.")
        .Numeric("If sin²θ = 0.36, what is cos²θ?", "0.64",
            ["cos² = 1 − sin²."],
            "1 − 0.36 = 0.64.")
        .Numeric("If cos θ = 0.25, what is sec θ?", "4",
            ["sec = 1/cos."],
            "1/0.25 = 4.")
        .Numeric("If sin θ = 0.5, what is csc θ?", "2",
            ["csc = 1/sin."],
            "1/0.5 = 2.")
        .Mcq("1 + tan²θ equals:",
            ["sin²θ", "sec²θ", "cos²θ", "csc²θ"], 1,
            ["Divide sin² + cos² = 1 by cos²."],
            "1 + tan²θ = sec²θ.")
        .Numeric("In QI, sin θ = 8/17. What is cos θ as a decimal?", "0.8824",
            ["cos² = 1 − 64/289 = 225/289.", "cos = 15/17."],
            "15/17 ≈ 0.882.", tolerance: 0.01)
        .Numeric("If sin = 0.6 and cos = 0.8, what is tan?", "0.75",
            ["tan = sin/cos = 0.6/0.8."],
            "tan = 0.75.")
        .Numeric("For any θ where defined, sin²θ + cos²θ = ?", "1",
            ["Pythagorean identity."],
            "Always 1.")
        .Mcq("Which is a reciprocal identity?",
            ["tan = sin/cos", "sec = 1/cos", "sin² + cos² = 1", "sin(−θ) = −sin θ"], 1,
            ["Reciprocal means multiplicative inverse."],
            "sec θ = 1/cos θ.")
        .Build();

    private static Lesson TrigEquations() => new LessonBuilder("trig-eq", CategoryId, "Solving Trigonometric Equations")
        .Subtitle("Isolate the function, find reference angles, then list every solution in the domain")
        .Order(4).Minutes("32 min")
        .Section("The big picture strategy",
            "Solving a trig equation means finding all angles that make a statement true, often on a restricted interval like [0, 2π), or else as a general family with +2πk.\n\nA reliable sequence:\n1) Simplify using algebra and identities (expand, factor, rewrite).\n2) Isolate a single trig function if possible (e.g. sin θ = 1/2).\n3) Find the reference angle / principal solution.\n4) Place solutions in the correct quadrants (or use general solution formulas).\n5) If the argument is not θ but 2θ or 3θ + π/4, solve for the inside first, then unwrap carefully, the period scales.\n6) Check for extraneous results if you squared both sides or divided.",
            simple: "Make it look like “sin(something) = number,” find the angles that work, then adjust if the something is not just θ.")
        .Section("Sine, cosine, and tangent patterns",
            "On one full turn [0, 2π):\n• sin θ = s (with |s| < 1) has two solutions: one in QI and one in QII for s > 0 (or QIII/QIV for s < 0).\n• cos θ = c similarly has two solutions symmetric about the x-axis.\n• tan θ = t has one solution in [0, π) and then repeats every π.\n\nSpecial values (|s| or |c| equal to 0, 1/2, √2/2, √3/2, 1) should be exact. Use inverse trig for non-special numbers, but still list both quadrants.",
            prior: "You need unit-circle special angles and the ASTC sign chart from the first lesson.")
        .Section("Multiple angles and factoring",
            "For sin(2x) = 1/2, first write the general (or interval) solutions for 2x, then divide by 2. If 2x = π/6 + 2πk, then x = π/12 + πk, notice the period in x becomes π, not 2π.\n\nWhen a product is zero after factoring, solve each factor case separately. Example: 2 sin θ cos θ − sin θ = 0 → sin θ(2 cos θ − 1) = 0 → sin θ = 0 or cos θ = 1/2. Never divide both sides by sin θ; you would lose the solutions where sin θ = 0.",
            simple: "If the angle is doubled, the solutions come twice as often. If you factor, set each factor to zero, do not divide away solutions.")
        .Section("Domain and calculator caution",
            "Always read whether the problem wants degrees or radians and whether it wants all solutions or only those in an interval. Calculator inverse sine returns one value (usually in [−π/2, π/2]); you must still build the full solution set from that reference.")
        .Formula("Sine on a period", @"\sin\theta=s\;(|s|\le 1)", "Two solutions per 2π when |s| < 1.")
        .Formula("General cosine idea", @"\cos\theta=c\Rightarrow\theta=\pm\alpha+2\pi k", "α = arccos c; k integer.")
        .Example("Two solutions for sine",
            "Solve sin θ = 1/2 on [0, 2π).",
            [
                "Reference angle: sin = 1/2 at π/6 (30°).",
                "Sine is positive in QI and QII.",
                "QI: θ = π/6. QII: θ = π − π/6 = 5π/6.",
                "No other solutions in [0, 2π)."
            ],
            "θ = π/6, 5π/6.",
            problemLatex: @"\sin\theta=\frac{1}{2}",
            solutionLatex: @"\theta=\frac{\pi}{6},\;\frac{5\pi}{6}",
            stepLatex: [@"\alpha=\frac{\pi}{6}", @"\text{QI and QII}", @"\frac{\pi}{6},\;\pi-\frac{\pi}{6}", null])
        .Example("Cosine zeros",
            "Solve cos θ = 0 on [0, 2π).",
            [
                "Cosine is the x-coordinate; it is zero at the top and bottom of the unit circle.",
                "θ = π/2 and θ = 3π/2.",
                "These are where tan is undefined, a useful cross-check.",
                "General form: θ = π/2 + πk."
            ],
            "θ = π/2, 3π/2.",
            solutionLatex: @"\frac{\pi}{2},\;\frac{3\pi}{2}")
        .Example("Linear in cosine",
            "Solve 2 cos θ − 1 = 0 on [0, 2π).",
            [
                "Isolate: cos θ = 1/2.",
                "Reference α = π/3.",
                "Cosine positive in QI and QIV: θ = π/3 and θ = 5π/3 (which is −π/3 + 2π).",
                "Check: cos(π/3) = 1/2 and cos(5π/3) = 1/2."
            ],
            "θ = π/3, 5π/3.",
            problemLatex: @"2\cos\theta-1=0",
            solutionLatex: @"\theta=\frac{\pi}{3},\;\frac{5\pi}{3}",
            stepLatex: [@"\cos\theta=\frac{1}{2}", @"\alpha=\frac{\pi}{3}", @"\frac{\pi}{3},\;\frac{5\pi}{3}", null])
        .Example("Tangent on a short interval",
            "Solve tan θ = 1 on [0, π).",
            [
                "tan = 1 when sin and cos are equal in sign and magnitude: θ = π/4 in QI.",
                "Period of tan is π, so the next solution is π/4 + π = 5π/4, which is outside [0, π).",
                "Inside [0, π) there is exactly one solution: π/4.",
                "If the interval were [0, 2π), you would also include 5π/4."
            ],
            "θ = π/4.",
            solutionLatex: @"\theta=\frac{\pi}{4}")
        .Mistake("Losing solutions by dividing by a trig expression instead of factoring.")
        .Mistake("Finding only the calculator’s principal value and forgetting the second quadrant solution.")
        .Mistake("For sin(Bx) = k, treating the period as 2π in the x-variable without dividing by B.")
        .Mistake("Mixing degrees and radians in the same write-up.")
        .Numeric("How many solutions does sin θ = 0 have on [0, 2π)?", "2",
            ["θ = 0 and θ = π (2π is the same angle as 0 if the interval is half-open)."],
            "Two solutions: 0 and π on [0, 2π).")
        .Numeric("How many solutions does cos θ = 1 have on [0, 2π)?", "1",
            ["Only θ = 0 (or 2π if closed on the right)."],
            "One solution at θ = 0 on [0, 2π).")
        .Mcq("The acute solution of sin θ = 1/2 in degrees is:",
            ["30", "45", "60", "90"], 0,
            ["Special angle table."],
            "30°.")
        .Numeric("If 2 sin θ = √3, what is sin θ as a decimal?", "0.866",
            ["sin θ = √3/2."],
            "√3/2 ≈ 0.866.", tolerance: 0.01)
        .Numeric("If cos θ = −1 on [0, 2π), θ in degrees is?", "180",
            ["Leftmost unit-circle point."],
            "180°.")
        .Numeric("How many solutions does tan θ = 0 have on [0, 2π)?", "2",
            ["θ = 0 and θ = π."],
            "Two solutions.")
        .Mcq("Can sin θ = 0 and cos θ = 0 at the same time?",
            ["Yes, always", "Never", "Only at π/4", "Only at π/2"], 1,
            ["Point would need x = y = 0, not on the unit circle."],
            "Never, impossible on the unit circle.")
        .Numeric("Solve cos θ = 1/2 on [0, 2π). Enter the larger solution in degrees.", "300",
            ["Solutions 60° and 300°."],
            "Larger is 300°.")
        .Build();

    private static Lesson LawsOfSinesCosines() => new LessonBuilder("trig-laws", CategoryId, "Law of Sines & Law of Cosines")
        .Subtitle("Solve any triangle, and handle the ambiguous SSA case carefully")
        .Order(5).Minutes("34 min")
        .Section("Beyond right triangles",
            "SOH-CAH-TOA needs a right angle. Most real triangles are oblique (no right angle). Two tools extend trig to every triangle:\n• Law of sines: a/sin A = b/sin B = c/sin C (= 2R, where R is the circumradius).\n• Law of cosines: c² = a² + b² − 2ab cos C (and cyclic permutations).\n\nStandard labeling: side a opposite angle A, side b opposite B, side c opposite C. Matching letters correctly is half the battle.",
            simple: "Sines link each side to its opposite angle. Cosines generalize Pythagoras when the angle is not 90°.")
        .Section("When to use which law",
            "• AAS or ASA: law of sines (you can find the third angle first: 180° − A − B).\n• SAS: law of cosines for the third side, then sines or cosines for another angle.\n• SSS: law of cosines for an angle, then another angle, then the third from the angle sum.\n• SSA: law of sines, but this is the ambiguous case: 0, 1, or 2 triangles possible.\n\nRule of thumb: if you know two sides and the included angle (SAS) or three sides (SSS), start with cosines. If you know a side opposite a known angle, sines are natural.",
            prior: "You need triangle angle sum 180° and basic right-triangle trig; the laws reduce to Pythagoras when C = 90°.")
        .Section("The ambiguous case SSA in plain language",
            "Suppose angle A is known (acute), side a opposite it, and side b adjacent. Drop a height h = b sin A from the opposite vertex.\n• If a < h: no triangle (side a is too short to reach side c’s line).\n• If a = h: one right triangle.\n• If h < a < b: two triangles (the “swing” of side a can land two ways).\n• If a ≥ b: one triangle.\n\nIf A is obtuse, the story changes: you need a > b just to form a triangle at all. Always sketch; the sketch catches impossible configurations before algebra goes wild.",
            simple: "SSA is like swinging a hinge: sometimes the free side hits the base once, twice, or not at all.")
        .Section("Law of cosines as “Pythagoras with a correction”",
            "When C = 90°, cos C = 0 and c² = a² + b². When C is acute, cos C > 0, so you subtract a positive correction, the side c is shorter than the right-triangle prediction. When C is obtuse, cos C < 0, and −2ab cos C becomes an addition, side c is longer. That intuition helps you check whether an answer is plausible.",
            @"c^2=a^2+b^2-2ab\cos C")
        .Formula("Law of sines", @"\frac{a}{\sin A}=\frac{b}{\sin B}=\frac{c}{\sin C}", "Sides proportional to sines of opposite angles.")
        .Formula("Law of cosines", @"c^2=a^2+b^2-2ab\cos C", "Generalized Pythagorean theorem.")
        .Example("Law of sines for a missing side",
            "In triangle ABC, A = 30°, B = 45°, a = 10. Find b.",
            [
                "Check: we have A, B, a, find third angle if needed: C = 105°, but we do not need C yet.",
                "Law of sines: a/sin A = b/sin B.",
                "b = a · sin B / sin A = 10 · sin 45° / sin 30°.",
                "sin 45° = √2/2, sin 30° = 1/2 → b = 10 · (√2/2) / (1/2) = 10√2."
            ],
            "b = 10√2.",
            problemLatex: @"A=30^\circ,\;B=45^\circ,\;a=10",
            solutionLatex: @"b=10\sqrt{2}",
            stepLatex: [null, @"\frac{a}{\sin A}=\frac{b}{\sin B}", @"b=10\cdot\frac{\sin 45^\circ}{\sin 30^\circ}", @"b=10\sqrt{2}"])
        .Example("Law of cosines for a side",
            "Sides a = 5, b = 6, included angle C = 60°. Find c.",
            [
                "SAS configuration → law of cosines.",
                "c² = a² + b² − 2ab cos C = 25 + 36 − 2·5·6·cos 60°.",
                "cos 60° = 1/2 → c² = 61 − 30 = 31.",
                "c = √31 (positive length)."
            ],
            "c = √31.",
            problemLatex: @"c^2=5^2+6^2-2\cdot 5\cdot 6\cos 60^\circ",
            solutionLatex: @"c=\sqrt{31}",
            stepLatex: [null, @"c^2=25+36-60\cdot\frac{1}{2}", @"c^2=31", @"c=\sqrt{31}"])
        .Example("Law of cosines for an angle (SSS)",
            "Sides a = 3, b = 4, c = 5. Find angle C opposite side c.",
            [
                "cos C = (a² + b² − c²) / (2ab).",
                "cos C = (9 + 16 − 25) / (2·3·4) = 0/24 = 0.",
                "C = 90°.",
                "Recognition: 3-4-5 is a right triangle, cosines correctly recover the right angle."
            ],
            "C = 90°.",
            solutionLatex: @"C=90^\circ",
            stepLatex: [@"\cos C=\frac{a^2+b^2-c^2}{2ab}", @"\cos C=0", @"C=90^\circ", null])
        .Example("Ambiguous SSA boundary",
            "SSA: A = 30°, a = 2, b = 4. How many triangles?",
            [
                "Height from the unknown vertex to side b’s line: h = b sin A = 4 · sin 30° = 4 · 1/2 = 2.",
                "Compare a to h: a = h = 2.",
                "When a equals the height, the triangle is right-angled at the “landing” vertex, exactly one triangle.",
                "If a were 1.5 < 2, zero triangles; if a were 3 with 2 < 3 < 4, two triangles."
            ],
            "Exactly one triangle (right triangle).",
            solutionLatex: @"1\text{ triangle}",
            stepLatex: [@"h=b\sin A=2", @"a=h", null, null])
        .Mistake("Using law of sines first for SAS when cosines give the included-side relation directly.")
        .Mistake("Ignoring a second possible triangle in the ambiguous SSA case.")
        .Mistake("Pairing side a with the wrong angle (label mismatch).")
        .Mistake("Forgetting that angles in a triangle sum to 180° when finding the third angle.")
        .Numeric("In a right triangle with C = 90°, a = 3, b = 4, what is c?", "5",
            ["Law of cosines reduces to Pythagoras.", "c² = 9 + 16."],
            "c = 5.")
        .Numeric("If a/sin A = 10 and A = 30°, what is a?", "5",
            ["a = 10 · sin 30° = 10 · 0.5."],
            "a = 5.")
        .Mcq("SSS is best started with:",
            ["Law of sines only", "Law of cosines", "SOH-CAH-TOA only", "Unit circle only"], 1,
            ["You know three sides; cosines finds an angle."],
            "Law of cosines.")
        .Numeric("For a = b = c = 2, cos C = (a²+b²−c²)/(2ab). What is cos C?", "0.5",
            ["(4+4−4)/8 = 4/8 = 0.5."],
            "cos C = 0.5 (60° in equilateral).")
        .Numeric("Equilateral side 6: height is (√3/2)·6 ≈ ?", "5.196",
            ["Height = 3√3 ≈ 5.196."],
            "≈ 5.196.", tolerance: 0.05)
        .Numeric("If A = B in a triangle, the ratio a/b equals?", "1",
            ["Equal angles opposite equal sides."],
            "a/b = 1.")
        .Mcq("The ambiguous case is which configuration?",
            ["AAS", "SSA", "ASA", "SAS"], 1,
            ["Two sides and a non-included angle opposite one of them."],
            "SSA.")
        .Numeric("SAS: a = 7, b = 7, C = 60°. What is c²? (exact integer)", "49",
            ["c² = 49+49−2·7·7·0.5 = 98−49 = 49."],
            "c² = 49 so c = 7 (equilateral).")
        .Build();

    private static Lesson TrigApplications() => new LessonBuilder("trig-apps", CategoryId, "Real-World Trigonometry Applications")
        .Subtitle("Heights, bearings, forces of right triangles, and periodic models")
        .Order(6).Minutes("30 min")
        .Section("Angles of elevation and depression",
            "An angle of elevation is measured upward from the horizontal to a line of sight. An angle of depression is measured downward from the horizontal. They are equal when two observers look at each other along the same line (alternate interior angles with a transversal, horizontal lines are parallel in the usual model).\n\nMost height/distance problems become right triangles: opposite = height, adjacent = ground distance, hypotenuse = line of sight. Choose sin, cos, or tan based on which sides you know and which you want. tan is especially common for “height and shadow / distance along the ground.”",
            simple: "From a flat horizontal, look up (elevation) or down (depression). Build a right triangle and pick the ratio that matches your known sides.",
            prior: "Right-triangle definitions of sin, cos, tan and the ability to solve simple equations like tan θ = h/d.")
        .Section("Navigation, bearings, and multi-triangle stories",
            "Bearings describe direction: for example, N 30° E means start facing north, then rotate 30° toward east. Sketch north as up, mark the angle carefully, then drop perpendiculars to make right triangles or use law of sines/cosines for non-right paths.\n\nMulti-step applications often chain two triangles: a ship sails one leg, turns, sails another. Draw the whole path before computing.")
        .Section("Periodic models with sine and cosine",
            "Many real quantities rise and fall: Ferris-wheel height, tides, temperature over a day, alternating current. A standard model is\nh(t) = A sin(B(t − C)) + D\nor with cosine.\n\n• D is the average / midline (center height of a wheel, mean tide level).\n• |A| is how far you swing from that average.\n• Period 2π/|B| is the time for one full cycle.\n\nReading a word problem into A, B, C, D is a major modeling skill: identify max, min, period, and when a peak or zero occurs.",
            @"h(t)=A\sin(Bt)+D",
            simple: "Midline = average height. Amplitude = how far above/below average. Period = time for one full up-down cycle.")
        .Section("Choosing the tool and checking units",
            "Ask: Is there a right angle? Use right-triangle trig. Oblique triangle? Sines/cosines. Repeating over time? Sine model. Always check calculator mode (degrees vs radians) against the problem statement. Include units in the final sentence of an application answer.")
        .Formula("Elevation (tan setup)", @"\tan\theta=\frac{\text{height}}{\text{ground distance}}", "Classic tower/tree/building setup.")
        .Formula("Sinusoidal model", @"h(t)=A\sin(B(t-C))+D", "Amplitude |A|, period 2π/|B|, midline D.")
        .Example("Tree height from elevation",
            "You stand 50 m from a tree. The angle of elevation to the top is 30°. About how tall is the tree (ignore your eye height)?",
            [
                "Sketch: horizontal 50 m, angle 30° at your eye, opposite side = height h.",
                "tan 30° = h / 50.",
                "h = 50 tan 30° = 50 · (1/√3) = 50/√3 ≈ 28.9 m.",
                "Sanity: 30° is fairly flat, so height should be less than the 50 m distance, 29 m is plausible."
            ],
            "About 28.9 m (exactly 50/√3 m).",
            problemLatex: @"\tan 30^\circ=\frac{h}{50}",
            solutionLatex: @"h=\frac{50}{\sqrt{3}}",
            stepLatex: [null, @"\tan 30^\circ=\frac{h}{50}", @"h=50\cdot\frac{1}{\sqrt{3}}", null])
        .Example("Angle of depression to a boat",
            "From an 80 m cliff, the angle of depression to a boat is 25°. How far is the boat from the base of the cliff?",
            [
                "Depression from horizontal equals the elevation angle from the boat to the cliff top in the usual parallel-horizontal model.",
                "tan 25° = 80 / d, so d = 80 / tan 25°.",
                "d ≈ 80 / 0.4663 ≈ 171.7 m.",
                "Check: 25° is steeper than a tiny angle, so d should be a few times 80, about 172 m is reasonable."
            ],
            "About 172 m from the base.",
            solutionLatex: @"d=\frac{80}{\tan 25^\circ}")
        .Example("Ramp angle",
            "A ramp is 10 ft long and rises 2 ft. What is the angle of inclination?",
            [
                "Hypotenuse 10, opposite 2 → sin θ = 2/10 = 0.2.",
                "θ = arcsin(0.2) ≈ 11.5°.",
                "You could also use tan if you had the run: run = √(10² − 2²) = √96.",
                "Accessibility codes often limit ramp angles, this is why the trig matters outside class."
            ],
            "About 11.5°.",
            problemLatex: @"\sin\theta=\frac{2}{10}",
            solutionLatex: @"\theta=\arcsin(0.2)")
        .Example("Ferris wheel midline",
            "A rider’s height is modeled by h(t) = 10 sin(πt/10) + 12 (meters, t in seconds). What is the midline, amplitude, and maximum height?",
            [
                "Compare to A sin(Bt) + D: A = 10, D = 12.",
                "Midline is y = 12 (center of the wheel above ground, in this model).",
                "Amplitude is 10 → rises 10 m above and below the center.",
                "Maximum height = D + |A| = 22 m. Minimum = 2 m."
            ],
            "Midline 12 m, amplitude 10 m, max 22 m.",
            problemLatex: @"h(t)=10\sin\frac{\pi t}{10}+12",
            solutionLatex: @"D=12,\;|A|=10,\;h_{\max}=22")
        .Mistake("Using sine when the known pair of sides calls for tangent (or vice versa).")
        .Mistake("Degree/radian mode errors when evaluating tan, sin, or arcsin.")
        .Mistake("Forgetting to add eye height when the problem measures elevation from eye level, not ground.")
        .Mistake("Reading amplitude as the maximum height instead of the swing from the midline.")
        .Numeric("Elevation 45°, distance 40 m. Height?", "40",
            ["tan 45° = 1 → h = 40."],
            "Height = 40 m.")
        .Numeric("opp = 6, adj = 8. What is tan θ?", "0.75",
            ["tan = opp/adj."],
            "tan θ = 0.75.")
        .Numeric("hyp = 13, opp = 5. What is sin θ as a decimal?", "0.3846",
            ["5/13."],
            "≈ 0.385.", tolerance: 0.01)
        .Mcq("An angle of depression is measured from the:",
            ["Vertical", "Horizontal", "Ground slope only", "North direction always"], 1,
            ["Definition of depression/elevation."],
            "Horizontal.")
        .Numeric("h = 5 sin t + 7. What is the maximum h?", "12",
            ["Max = 7 + 5."],
            "Maximum is 12.")
        .Numeric("Shadow 20 m long, sun elevation 30°. Object height ≈ ?", "11.55",
            ["h = 20 tan 30° = 20/√3."],
            "≈ 11.55 m.", tolerance: 0.1)
        .Numeric("Ramp rise 3, run 4. Hypotenuse length?", "5",
            ["3-4-5 right triangle."],
            "Length 5.")
        .Numeric("For h = 4 cos(2t) + 9, the midline is?", "9",
            ["D = 9."],
            "Midline y = 9.")
        .Build();
}
