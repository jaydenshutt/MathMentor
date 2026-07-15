using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class TrigExtraLessons
{
    public const string CategoryId = "trig-advanced";

    public static Category Build()
    {
        var lessons = new[]
        {
            InverseTrig(),
            Vectors()
        };
        return new Category(CategoryId, "Advanced Trigonometry",
            "Inverse trig, solving equations with inverses, and vector magnitude with components.",
            "\uE9D9", 13, lessons);
    }

    private static Lesson InverseTrig() => new LessonBuilder("trig-inverse", CategoryId, "Inverse Trig & Equations")
        .Subtitle("Principal values of arcsine, arccosine, arctangent, and using them to solve equations")
        .Order(1).Minutes("34 min")
        .Visual(VisualKind.UnitCircle, "Inverse trig returns one principal angle; you still list all solutions on a full period.")
        .Section("Why inverse trig functions exist",
            "Sine, cosine, and tangent are not one-to-one on the whole real line, so they do not have unrestricted inverses. By restricting each to a principal domain, we define inverse functions that return a single principal angle:\n• y = sin⁻¹(x) = arcsin(x) has domain [−1, 1] and range [−π/2, π/2].\n• y = cos⁻¹(x) = arccos(x) has domain [−1, 1] and range [0, π].\n• y = tan⁻¹(x) = arctan(x) has domain all reals and range (−π/2, π/2).\n\nThese ranges are choices that make the inverses functions; other textbooks use the same standard ranges.",
            @"y=\sin^{-1}x",
            simple: "Inverse sine answers: what angle between −90° and 90° has this sine? Cosine and tangent use their own standard angle windows.",
            prior: "Unit circle values, one-to-one restrictions, and solving basic trig equations.")
        .Section("Reading the calculator output",
            "A calculator’s sin⁻¹ button returns only the principal value. If sin θ = 1/2, the calculator may show π/6 (or 30°), but on [0, 2π) you also need 5π/6. Always expand principal answers to the full solution set using reference angles and quadrant signs.\n\nMode matters: degree mode versus radian mode. Match the problem’s unit.",
            simple: "The calculator gives one angle. You still hunt for every angle on the required interval that shares the same trig value.",
            prior: "ASTC signs and reference angles from core trigonometry.")
        .Section("Solving equations with inverses",
            "Strategy:\n1) Isolate a single trig function: sin(something) = k.\n2) If |k| > 1 for sin or cos, no real solution.\n3) Find the principal value α = sin⁻¹(k) (or cos⁻¹, tan⁻¹).\n4) Build all angles with that sine (or cosine, tangent) in the target interval, or write a general solution with period.\n5) If the argument is Bx + C, solve for the inside first, then for x.\n\nExample: 2 cos x = 1 ⇒ cos x = 1/2 ⇒ x = ±π/3 + 2πk.",
            simple: "Isolate, take inverse for one answer, then complete the family of angles that work.",
            prior: "General solutions and multiple-angle adjustments from the trig equations lesson.")
        .Section("Composition notes",
            "sin(sin⁻¹ x) = x for x in [−1, 1]. But sin⁻¹(sin θ) equals θ only when θ is already in [−π/2, π/2]. For example sin⁻¹(sin(2π/3)) is not 2π/3; it is π − 2π/3 = π/3, the principal angle with the same sine. Similar caveats hold for cos and tan.")
        .Section("Exact values to know",
            "Memorize principal exact values for special inputs: sin⁻¹(1/2) = π/6, sin⁻¹(√2/2) = π/4, sin⁻¹(√3/2) = π/3, sin⁻¹(0) = 0, sin⁻¹(1) = π/2, and the negative counterparts for negative inputs. Cosine and tangent have parallel tables.")
        .Section("Modeling angles from ratios",
            "In right triangles, θ = tan⁻¹(opposite/adjacent) gives the acute angle when sides are positive. In navigation and physics, arctan of component ratios finds direction angles; adjust quadrant from the signs of the components, not only the calculator’s principal value.")
        .Formula("Arcsine range", @"\sin^{-1}x\in\left[-\frac{\pi}{2},\frac{\pi}{2}\right]", "Principal values only.")
        .Formula("Arctangent range", @"\tan^{-1}x\in\left(-\frac{\pi}{2},\frac{\pi}{2}\right)", "All real inputs.")
        .Example("Principal value",
            "Evaluate sin⁻¹(1/2) in radians.",
            [
                "Find θ in [−π/2, π/2] with sin θ = 1/2.",
                "θ = π/6 works and lies in the range.",
                "π − π/6 = 5π/6 has the same sine but is outside the arcsine range.",
                "Answer: π/6."
            ],
            "π/6.",
            problemLatex: @"\sin^{-1}\left(\frac{1}{2}\right)",
            solutionLatex: @"\frac{\pi}{6}",
            stepLatex: [null, @"\frac{\pi}{6}", @"\frac{5\pi}{6}", null])
        .Example("Full solution set from a principal value",
            "Solve sin x = 1/2 on [0, 2π).",
            [
                "Principal: sin⁻¹(1/2) = π/6.",
                "Sine is also positive in QII: x = π − π/6 = 5π/6.",
                "Both lie in [0, 2π).",
                "Solutions: π/6, 5π/6."
            ],
            "x = π/6, 5π/6.",
            solutionLatex: @"x=\frac{\pi}{6},\;\frac{5\pi}{6}")
        .Example("Arctan equation",
            "Solve tan x = 1 on (−π/2, π/2).",
            [
                "Within this open interval, tan is one-to-one.",
                "x = tan⁻¹(1) = π/4.",
                "Only one solution in (−π/2, π/2).",
                "On a larger interval you would add πk."
            ],
            "x = π/4.",
            solutionLatex: @"x=\frac{\pi}{4}")
        .Example("Cosine isolation",
            "Solve 2 cos x − √3 = 0 on [0, 2π).",
            [
                "cos x = √3/2.",
                "Principal arccos(√3/2) = π/6.",
                "Cosine positive in QI and QIV: x = π/6 and x = 11π/6 (or −π/6 + 2π).",
                "Check both in the interval."
            ],
            "x = π/6, 11π/6.",
            solutionLatex: @"x=\frac{\pi}{6},\;\frac{11\pi}{6}")
        .Mistake("Treating the calculator’s one answer as the complete solution set.")
        .Mistake("Using degree mode when the problem is in radians (or the reverse).")
        .Mistake("Writing sin⁻¹(x) as 1/sin(x) = csc(x).")
        .Mistake("Assuming sin⁻¹(sin θ) = θ for every θ.")
        .Numeric("sin⁻¹(0) in degrees?", "0",
            ["sin 0° = 0 and 0 is in range."],
            "0°.", explanationLatex: @"0")
        .Numeric("sin⁻¹(1) in degrees?", "90",
            ["sin 90° = 1."],
            "90°.", explanationLatex: @"90")
        .Numeric("How many solutions of sin x = 1/2 on [0, 2π)?", "2",
            ["QI and QII."],
            "2.", explanationLatex: @"2")
        .Mcq("Range of cos⁻¹(x) is:",
            ["[−π/2, π/2]", "[0, π]", "All reals", "(0, π/2) only"], 1,
            ["Standard arccos range."],
            "[0, π].")
        .Numeric("tan⁻¹(1) in degrees?", "45",
            ["tan 45° = 1."],
            "45°.", explanationLatex: @"45")
        .Numeric("If cos x = 0 on [0, 2π), how many solutions?", "2",
            ["π/2 and 3π/2."],
            "2.", explanationLatex: @"2")
        .Mcq("sin⁻¹(x) is defined for x in:",
            ["All reals", "[−1, 1]", "(0, 1) only", "Only integers"], 1,
            ["Sine outputs only [−1, 1]."],
            "[−1, 1].")
        .Numeric("arccos(1) in degrees?", "0",
            ["cos 0° = 1."],
            "0°.", explanationLatex: @"0")
        .Build();

    private static Lesson Vectors() => new LessonBuilder("trig-vectors", CategoryId, "Vectors: Magnitude & Components")
        .Subtitle("Directed lengths in the plane: break into components, rebuild magnitude and direction")
        .Order(2).Minutes("32 min")
        .Visual(VisualKind.GeometryCanvas, "A plane vector is an arrow: length is magnitude, angle is direction.")
        .Section("What a vector is",
            "A vector has magnitude (length) and direction. In the plane we often write v = ⟨v_x, v_y⟩ or as an arrow from the origin to (v_x, v_y). Two arrows represent the same vector if they have the same length and direction (free vectors), even if they start at different points.\n\nScalars are plain numbers. Multiplying a vector by a positive scalar stretches it; a negative scalar flips direction.",
            @"\mathbf{v}=\langle v_x,v_y\rangle",
            simple: "Think of a vector as a travel instruction: how far and which way, not where you started.",
            prior: "Coordinate plane, right-triangle trig, and the distance formula.")
        .Section("Magnitude",
            "The magnitude (norm, length) of v = ⟨a, b⟩ is\n\n|v| = √(a² + b²)\n\nThat is the distance from (0, 0) to (a, b). Unit vectors have magnitude 1. The zero vector ⟨0, 0⟩ has magnitude 0 and no meaningful direction.",
            @"|\mathbf{v}|=\sqrt{a^2+b^2}",
            simple: "Magnitude is the arrow’s length: Pythagorean theorem on its components.",
            prior: "Distance formula and Pythagorean theorem.")
        .Section("Components from magnitude and angle",
            "If a vector has magnitude r and direction angle θ measured from the positive x-axis (standard position), then\n\nv_x = r cos θ,   v_y = r sin θ.\n\nConversely, r = √(v_x² + v_y²) and θ = tan⁻¹(v_y/v_x) with quadrant fixed by the signs of v_x and v_y. Navigational bearings use different angle conventions; read the problem’s diagram.",
            @"v_x=r\cos\theta,\;v_y=r\sin\theta",
            simple: "Cosine multiplies length to get the horizontal part; sine multiplies length to get the vertical part.",
            prior: "cos and sin on the unit circle; scale by r for non-unit lengths.")
        .Section("Addition and resultant",
            "Add vectors componentwise: ⟨a, b⟩ + ⟨c, d⟩ = ⟨a + c, b + d⟩. Geometrically, place them tip-to-tail; the resultant runs from the free tail to the free tip. Subtraction is adding the opposite: u − v = u + (−v).\n\nPhysics: forces and velocities add as vectors. The resultant magnitude is not always the sum of magnitudes unless they point the same way.")
        .Section("Dot product snapshot (optional preview)",
            "u · v = a c + b d = |u||v| cos φ, where φ is the angle between them. If the dot product is zero, the vectors are perpendicular. This links components back to geometry.")
        .Section("Unit vector in a direction",
            "If v ≠ 0, then v/|v| is a unit vector in the same direction. Useful for writing a vector as magnitude times direction: v = |v| · (v/|v|).")
        .Formula("Magnitude", @"|\langle a,b\rangle|=\sqrt{a^2+b^2}", "Length of the arrow.")
        .Formula("Components", @"\langle r\cos\theta,\;r\sin\theta\rangle", "From polar-style data.")
        .Example("Magnitude of a component vector",
            "Find the magnitude of ⟨3, 4⟩.",
            [
                "|v| = √(3² + 4²) = √(9 + 16) = √25 = 5.",
                "Same arithmetic as a 3-4-5 triangle.",
                "Direction is not asked here, only length.",
                "A unit vector in the same direction is ⟨3/5, 4/5⟩."
            ],
            "Magnitude is 5.",
            problemLatex: @"\langle 3,4\rangle",
            solutionLatex: @"5",
            stepLatex: [@"\sqrt{9+16}", @"5", null, @"\langle 3/5,4/5\rangle"])
        .Example("Components from magnitude and angle",
            "A vector has length 10 at angle 60° from the positive x-axis. Find components.",
            [
                "v_x = 10 cos 60° = 10 · 1/2 = 5.",
                "v_y = 10 sin 60° = 10 · √3/2 = 5√3.",
                "Vector: ⟨5, 5√3⟩.",
                "Check magnitude: √(25 + 75) = √100 = 10."
            ],
            "⟨5, 5√3⟩.",
            solutionLatex: @"\langle 5,\;5\sqrt{3}\rangle")
        .Example("Add two vectors",
            "Find ⟨2, 5⟩ + ⟨−4, 1⟩ and its magnitude.",
            [
                "Sum: ⟨2 − 4, 5 + 1⟩ = ⟨−2, 6⟩.",
                "Magnitude: √(4 + 36) = √40 = 2√10.",
                "Decimal ≈ 6.32 if needed.",
                "Resultant points left and up (QII)."
            ],
            "⟨−2, 6⟩ with magnitude √40.",
            solutionLatex: @"\langle -2,6\rangle")
        .Example("Direction angle caution",
            "Vector ⟨−3, 3⟩. Find magnitude and a direction angle in degrees.",
            [
                "Magnitude √(9 + 9) = √18 = 3√2.",
                "tan⁻¹(3/3) = tan⁻¹(1) = 45°, but that is the reference only.",
                "Components: x negative, y positive ⇒ QII.",
                "Direction angle 180° − 45° = 135° from positive x-axis."
            ],
            "Magnitude 3√2; direction 135°.",
            solutionLatex: @"3\sqrt{2},\;135^\circ")
        .Mistake("Adding magnitudes instead of adding components for a resultant.")
        .Mistake("Using tan⁻¹(y/x) without fixing the quadrant from signs.")
        .Mistake("Swapping sine and cosine when building components from an angle.")
        .Mistake("Forgetting that magnitude is never negative.")
        .Numeric("Magnitude of ⟨0, 5⟩?", "5",
            ["√(0 + 25) = 5."],
            "5.", explanationLatex: @"5")
        .Numeric("Magnitude of ⟨6, 8⟩?", "10",
            ["√(36 + 64) = 10."],
            "10.", explanationLatex: @"10")
        .Numeric("r = 8, θ = 0°. x-component?", "8",
            ["8 cos 0° = 8."],
            "8.", explanationLatex: @"8")
        .Numeric("r = 8, θ = 0°. y-component?", "0",
            ["8 sin 0° = 0."],
            "0.", explanationLatex: @"0")
        .Mcq("⟨1, 0⟩ + ⟨0, 1⟩ equals:",
            ["⟨0, 0⟩", "⟨1, 1⟩", "⟨1, 0⟩", "2"], 1,
            ["Add components."],
            "⟨1, 1⟩.")
        .Numeric("⟨3, 1⟩ + ⟨2, 4⟩ has y-component?", "5",
            ["1 + 4 = 5."],
            "5.", explanationLatex: @"5")
        .Numeric("Unit vector: ⟨3, 4⟩ / 5 has x-component?", "0.6",
            ["3/5 = 0.6."],
            "0.6.", tolerance: 0.01, explanationLatex: @"0.6")
        .Mcq("Two nonzero vectors are perpendicular if their dot product is:",
            ["1", "0", "Equal to the product of magnitudes", "Undefined"], 1,
            ["u · v = |u||v| cos 90° = 0."],
            "0.")
        .Build();
}
