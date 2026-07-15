using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class AdvancedGeometryLessons
{
    public const string CategoryId = "geo-advanced";

    public static Category Build()
    {
        var lessons = new[]
        {
            CoordinateGeometry(),
            SimilarityApps()
        };
        return new Category(CategoryId, "Coordinate & Similarity Geometry",
            "Distance, midpoint, slope proofs, and real similarity with scale drawings.",
            "\uE734", 9, lessons);
    }

    private static Lesson CoordinateGeometry() => new LessonBuilder("geo-coordinate", CategoryId, "Coordinate Geometry")
        .Subtitle("Put geometry on the plane: distance, midpoint, slope, and simple coordinate proofs")
        .Order(1).Minutes("32 min")
        .Visual(VisualKind.GeometryCanvas, "Points become ordered pairs; segments become distances and slopes.")
        .Section("Why coordinates help geometry",
            "Coordinate geometry (analytic geometry) places figures in the Cartesian plane so algebra can prove geometric facts. A point is an ordered pair (x, y). A segment becomes a distance formula. Parallel lines become equal slopes. Right angles become opposite-reciprocal slopes (or a zero dot product of direction vectors).\n\nThis is the bridge between pure geometry and algebra, and it is how computers store shapes.",
            simple: "Draw the figure on graph paper. Then compute with formulas instead of only chasing angle marks.",
            prior: "Plotting points, slope of a line, and the Pythagorean theorem.")
        .Section("Distance between two points",
            "The distance between A(x₁, y₁) and B(x₂, y₂) is the length of segment AB:\n\nd = √[(x₂ − x₁)² + (y₂ − y₁)²]\n\nWhy? The run |x₂ − x₁| and rise |y₂ − y₁| form a right triangle; Pythagoras gives the hypotenuse. Order of subtraction does not matter after squaring.",
            @"d=\sqrt{(x_2-x_1)^2+(y_2-y_1)^2}",
            simple: "Horizontal gap squared plus vertical gap squared, then square root. That is the straight-line length.",
            prior: "Pythagorean theorem a² + b² = c².")
        .Section("Midpoint of a segment",
            "The midpoint M of AB averages the coordinates:\n\nM = ( (x₁ + x₂)/2 , (y₁ + y₂)/2 )\n\nEach coordinate is halfway between the endpoints. Midpoints appear in median problems, parallelogram diagonal theorems, and symmetry arguments.",
            @"M=\left(\frac{x_1+x_2}{2},\frac{y_1+y_2}{2}\right)",
            simple: "Average the x-values and average the y-values. That point sits in the middle of the segment.",
            prior: "Mean of two numbers.")
        .Section("Slope and geometric relationships",
            "Slope m = (y₂ − y₁)/(x₂ − x₁) for nonvertical lines.\n• Parallel lines: equal slopes (and not the same line).\n• Perpendicular lines: product of slopes is −1 (for nonvertical/nonhorizontal pairs), i.e. slopes are opposite reciprocals.\n• Horizontal: m = 0. Vertical: undefined slope.\n\nThese facts turn parallel and perpendicular proofs into slope calculations.",
            @"m=\frac{y_2-y_1}{x_2-x_1}",
            simple: "Same steepness means parallel. Flip the fraction and change the sign for perpendicular.",
            prior: "Slope from Algebra I.")
        .Section("Coordinate proof strategy",
            "Place the figure cleverly to simplify algebra: put a right angle at the origin, align a side on an axis, or center a figure at the origin. Assign general coordinates (use variables, not only numbers) when you must prove a general theorem. Then compute distances or slopes and interpret the results (equal lengths ⇒ isosceles; slopes product −1 ⇒ right angle).")
        .Section("Circle equation connection",
            "The set of points at fixed distance r from center (h, k) is (x − h)² + (y − k)² = r². That is the distance formula rearranged. Coordinate geometry and circle geometry share the same distance idea.")
        .Formula("Distance", @"d=\sqrt{(x_2-x_1)^2+(y_2-y_1)^2}", "Length of a segment.")
        .Formula("Midpoint", @"\left(\frac{x_1+x_2}{2},\frac{y_1+y_2}{2}\right)", "Center of a segment.")
        .Formula("Perpendicular slopes", @"m_1 m_2=-1", "Nonvertical perpendicular lines.")
        .Example("Distance calculation",
            "Find the distance between (1, 2) and (4, 6).",
            [
                "Δx = 4 − 1 = 3, Δy = 6 − 2 = 4.",
                "d = √(3² + 4²) = √(9 + 16) = √25 = 5.",
                "This is the classic 3-4-5 right triangle.",
                "Units match the coordinate units on each axis."
            ],
            "Distance is 5.",
            problemLatex: @"(1,2),\;(4,6)",
            solutionLatex: @"d=5",
            stepLatex: [@"\Delta x=3,\;\Delta y=4", @"\sqrt{9+16}", @"5", null])
        .Example("Midpoint",
            "Find the midpoint of (−2, 5) and (4, 1).",
            [
                "x-coordinate: (−2 + 4)/2 = 1.",
                "y-coordinate: (5 + 1)/2 = 3.",
                "Midpoint is (1, 3).",
                "Check: it is halfway in both directions."
            ],
            "Midpoint (1, 3).",
            solutionLatex: @"(1,3)")
        .Example("Perpendicular check",
            "Are the lines through (0, 0) & (2, 1) and through (0, 0) & (−1, 2) perpendicular?",
            [
                "Slope 1: m₁ = (1 − 0)/(2 − 0) = 1/2.",
                "Slope 2: m₂ = (2 − 0)/(−1 − 0) = −2.",
                "Product: (1/2)(−2) = −1.",
                "Yes, the lines are perpendicular."
            ],
            "Yes; slopes multiply to −1.",
            solutionLatex: @"m_1 m_2=-1")
        .Example("Isosceles on the plane",
            "Triangle with vertices A(0, 0), B(4, 0), C(2, 3). Show AB is the base of an isosceles triangle.",
            [
                "AC = √[(2 − 0)² + (3 − 0)²] = √(4 + 9) = √13.",
                "BC = √[(2 − 4)² + (3 − 0)²] = √(4 + 9) = √13.",
                "AC = BC, so the triangle is isosceles with AB as base.",
                "AB = 4 by inspection on the x-axis."
            ],
            "AC = BC = √13; isosceles.",
            solutionLatex: @"AC=BC=\sqrt{13}")
        .Mistake("Forgetting to square both differences before adding under the distance radical.")
        .Mistake("Averaging only one coordinate for a midpoint.")
        .Mistake("Using m₁ = m₂ to claim perpendicular (that is parallel).")
        .Mistake("Subtracting coordinates in inconsistent order for slope (signs must match).")
        .Numeric("Distance between (0, 0) and (6, 8)?", "10",
            ["√(36 + 64) = 10."],
            "10.", explanationLatex: @"10")
        .Numeric("Midpoint of (0, 0) and (10, 4): x-coordinate?", "5",
            ["(0 + 10)/2 = 5."],
            "5.", explanationLatex: @"5")
        .Numeric("Midpoint of (0, 0) and (10, 4): y-coordinate?", "2",
            ["(0 + 4)/2 = 2."],
            "2.", explanationLatex: @"2")
        .Numeric("Slope between (1, 2) and (3, 8)?", "3",
            ["(8 − 2)/(3 − 1) = 6/2 = 3."],
            "3.", explanationLatex: @"3")
        .Mcq("If two nonvertical lines are parallel, their slopes are:",
            ["Opposite reciprocals", "Equal", "Always zero", "Always undefined"], 1,
            ["Parallel means same steepness."],
            "Equal.")
        .Numeric("If m₁ = 2, perpendicular slope m₂ = ?", "-0.5",
            ["Opposite reciprocal: −1/2."],
            "−1/2.", tolerance: 0.01, explanationLatex: @"-\frac{1}{2}")
        .Numeric("Distance between (2, 3) and (2, 9)?", "6",
            ["Vertical segment: |9 − 3| = 6."],
            "6.", explanationLatex: @"6")
        .Mcq("The circle (x − 1)² + (y + 2)² = 9 has radius:",
            ["9", "3", "1", "√9 only as equation form error"], 1,
            ["r² = 9 ⇒ r = 3."],
            "3.")
        .Build();

    private static Lesson SimilarityApps() => new LessonBuilder("geo-similarity-apps", CategoryId, "Similarity Applications & Scale")
        .Subtitle("Scale factors, proportional sides, and real measurements from maps and models")
        .Order(2).Minutes("30 min")
        .Visual(VisualKind.GeometryCanvas, "Similar figures share angles; sides stay in one constant ratio.")
        .Section("Similarity in plain language",
            "Two figures are similar when one is a scaled copy of the other (possibly rotated or reflected). Corresponding angles are congruent. Corresponding sides are proportional with one scale factor k.\n\nIf figure B is similar to figure A with scale factor k = (size of B)/(size of A), then every length in B is k times the matching length in A. Areas scale by k². Volumes (in 3D) scale by k³.",
            @"k=\frac{L'}{L}",
            simple: "Same shape, possibly different size. Angles match; sides grow or shrink by one shared multiplier.",
            prior: "Triangle similarity criteria (AA, SAS similarity, SSS similarity) from basic geometry.")
        .Section("Setting up proportions",
            "Always match corresponding sides: short to short, or sides opposite matching angles. Write\n\n(side in figure 1)/(matching side in figure 2) = (another side 1)/(matching side 2)\n\nor equate each to the scale factor. Cross-multiply to solve. Mixing non-corresponding sides is the most common error.",
            simple: "Pair the matching sides first. Then make a fraction equation and cross-multiply.",
            prior: "Solving proportions a/b = c/d.")
        .Section("Scale drawings and maps",
            "A map scale like 1:50000 or 1 cm = 2 km is a scale factor statement. Convert units carefully so both sides of a proportion use consistent units.\n\nExample: if 1 cm on the map represents 3 km in reality, then 4.5 cm on the map represents 13.5 km. Indirect measurement with similar triangles (mirror method, shadow method, surveying) uses the same proportion idea.")
        .Section("Shadows and height problems",
            "When the sun’s rays are parallel, a person and a tree cast shadows that form similar right triangles (corresponding angles match: both include a right angle and the same sun angle). Person height / person shadow = tree height / tree shadow. Solve for the unknown height.")
        .Section("Area and perimeter under scaling",
            "If lengths multiply by k:\n• perimeter multiplies by k (one-dimensional outline).\n• area multiplies by k².\n• surface area multiplies by k²; volume by k³ for solid copies.\n\nDoubling all lengths of a photo (k = 2) multiplies area by 4, not by 2.")
        .Section("Congruence as special similarity",
            "Congruent figures are similar with k = 1. Every corresponding length is equal, not merely proportional. Congruence criteria (SSS, SAS, ASA, AAS, HL) are stronger than similarity criteria.")
        .Formula("Scale factor", @"k=\frac{L'}{L}", "Constant ratio of corresponding sides.")
        .Formula("Area scaling", @"A'=k^2 A", "Areas scale with the square of lengths.")
        .Example("Find a missing side",
            "Triangles are similar. Sides 3 and 5 on the small triangle correspond to sides x and 20 on the large. Find x.",
            [
                "Corresponding pairs: 3 ↔ x and 5 ↔ 20.",
                "Proportion: 3/x = 5/20, or 3/5 = x/20.",
                "Using 3/5 = x/20: cross-multiply 5x = 60 ⇒ x = 12.",
                "Scale factor large/small = 20/5 = 4, so x = 3·4 = 12."
            ],
            "x = 12.",
            problemLatex: @"\frac{3}{x}=\frac{5}{20}",
            solutionLatex: @"x=12",
            stepLatex: [null, @"\frac{3}{5}=\frac{x}{20}", @"5x=60", @"x=12"])
        .Example("Map scale",
            "A map uses 1 cm : 4 km. A road measures 6.5 cm on the map. How long is the road?",
            [
                "Scale: 1 cm represents 4 km.",
                "Real length = 6.5 · 4 = 26 km.",
                "Proportion: 1/4 = 6.5/L ⇒ L = 26.",
                "Keep units: answer in km, not cm."
            ],
            "26 km.",
            solutionLatex: @"26")
        .Example("Shadow height",
            "A student 1.6 m tall casts a 2 m shadow. A flagpole casts a 15 m shadow at the same time. Find the flagpole height.",
            [
                "Similar triangles: 1.6/2 = h/15.",
                "Cross-multiply: 2h = 1.6 · 15 = 24.",
                "h = 12 m.",
                "Check: scale factor from student shadow to pole shadow is 15/2 = 7.5; 1.6·7.5 = 12."
            ],
            "Height is 12 m.",
            solutionLatex: @"h=12")
        .Example("Area scale factor",
            "Two similar rectangles have scale factor k = 3 (large to small). If the small area is 10, what is the large area?",
            [
                "Areas scale by k² = 9.",
                "Large area = 9 · 10 = 90.",
                "Not 3 · 10 = 30; that would only scale one length, not area.",
                "Perimeter would scale by 3, not 9."
            ],
            "Large area is 90.",
            solutionLatex: @"90")
        .Mistake("Matching sides that are not corresponding.")
        .Mistake("Using area scale factor k when lengths should use k (or vice versa).")
        .Mistake("Mixing map units (cm vs km) without converting.")
        .Mistake("Writing the scale factor upside down and not checking which figure is larger.")
        .Numeric("Similar sides 4 and 10. Scale factor large/small?", "2.5",
            ["10/4 = 2.5."],
            "2.5.", tolerance: 0.01, explanationLatex: @"2.5")
        .Numeric("If k = 2 and small side is 7, large side is?", "14",
            ["2 · 7 = 14."],
            "14.", explanationLatex: @"14")
        .Numeric("k = 3 for lengths. Area multiplies by?", "9",
            ["k² = 9."],
            "9.", explanationLatex: @"9")
        .Numeric("Map: 1 cm = 5 km. Map length 3 cm. Real km?", "15",
            ["3 · 5 = 15."],
            "15.", explanationLatex: @"15")
        .Mcq("Congruent figures are similar with scale factor:",
            ["0", "1", "2 always", "Undefined"], 1,
            ["Same size and shape."],
            "1.")
        .Numeric("Proportion 2/x = 6/15. x = ?", "5",
            ["2/x = 2/5 ⇒ x = 5."],
            "5.", explanationLatex: @"5")
        .Numeric("k = 4 for lengths. Volume multiplies by?", "64",
            ["k³ = 64."],
            "64.", explanationLatex: @"64")
        .Mcq("Which multiplies by k under similarity scaling of lengths?",
            ["Area", "Perimeter", "Volume", "Density always"], 1,
            ["Perimeter is a length measure."],
            "Perimeter.")
        .Build();
}
