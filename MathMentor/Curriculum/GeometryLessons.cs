using MathMentor.Models;

namespace MathMentor.Curriculum;

public static class GeometryLessons
{
    public const string CategoryId = "geometry";

    public static Category Build()
    {
        var lessons = new[]
        {
            PointsLinesAngles(),
            Triangles(),
            RightTriangles(),
            Quadrilaterals(),
            Circles(),
            PerimeterAreaVolume()
        };
        return new Category(CategoryId, "Geometry",
            "Shapes, angles, congruence, circles, and measurement in 2D and 3D.",
            "\uE734", 8, lessons);
    }

    private static Lesson PointsLinesAngles() => new LessonBuilder("geo-angles", CategoryId, "Points, Lines, Angles & Basic Proofs")
        .Subtitle("Why geometry starts with undefined terms, and how angle relationships become tools for proof")
        .Order(1).Minutes("28 min")
        .Section("Why we begin with “undefined” terms",
            "Every mathematical system needs a starting place. In Euclidean geometry, point, line, and plane are treated as primitive ideas: we do not define them in terms of simpler objects, because there is nothing simpler to reduce them to. Instead we describe how they behave.\n\nA point has position but no size. A line extends forever in two opposite directions and is “straight” in the Euclidean sense. A plane is a flat surface that extends forever. From these, we build everything else: segments (two endpoints), rays (one endpoint, infinite the other way), angles (two rays sharing a vertex), and eventually polygons and 3D solids.\n\nWhy bother naming primitives carefully? Because every later theorem, vertical angles, triangle sum, parallel-line results, is a chain of reasoning that ultimately rests on agreed starting points. Clear language prevents “proving” something by accidentally assuming the conclusion.",
            simple: "Start with three atoms of geometry: a location (point), an endless straight path (line), and an endless flat sheet (plane). Everything fancy is built by combining those.",
            prior: "You already use these words informally. Here we pin down how they relate so we can reason instead of only memorize.")
        .Section("What an angle really measures",
            "An angle is formed by two rays (or segments) that share a vertex. The measure of an angle is the amount of turn from one ray to the other. Degrees are a human convention: a full turn is 360°, so a right angle is one-quarter turn = 90°, and a straight line is a half turn = 180°.\n\nClassification by size:\n• Acute: greater than 0° and less than 90°\n• Right: exactly 90°\n• Obtuse: greater than 90° and less than 180°\n• Straight: exactly 180°\n\nWhy classification matters: later theorems often assume “right,” “acute,” or “obtuse,” and choosing the wrong category breaks the logic (for example, Pythagoras applies to right triangles only).",
            simple: "An angle is a turn. Acute is a small turn, right is a square corner, obtuse is more than a square corner but less than a flat line.",
            prior: "If you can picture a clock hand sweeping, you already understand angle as rotation, degrees just count the size of that sweep.")
        .Section("Angle pairs that always work the same way",
            "Some relationships hold because of how lines meet, not because of special numbers on a diagram.\n\n• Complementary angles sum to 90°. Either angle is the complement of the other.\n• Supplementary angles sum to 180°. Either is the supplement of the other.\n• Linear pair: two adjacent angles whose non-shared rays form a straight line. They are always supplementary (they “fill” a half-turn).\n• Vertical angles: opposite angles formed when two lines intersect. They are always congruent. Why? Each is supplementary to the same adjacent angle, so they equal each other.\n\nThese are not decoration. They are short-cuts that let you find unknown angles without measuring with a protractor.",
            @"\angle1+\angle2=180^\circ\ \text{(linear pair)}",
            simple: "On a straight line, two neighboring angles add to 180°. When two lines cross, the X-shaped opposite angles match.",
            prior: "You need the idea of 90° and 180° as special turns. Complement and supplement are just names for “what is left to reach that special turn.”")
        .Section("Parallel lines and a transversal: why corresponding angles match",
            "A transversal is a line that cuts across two or more other lines. When those other lines are parallel, the transversal creates several congruent angle pairs:\n• Corresponding angles (same “corner position” at each intersection)\n• Alternate interior angles (inside the parallels, on opposite sides of the transversal)\n• Alternate exterior angles (outside the parallels, opposite sides)\n\nConsecutive (same-side) interior angles are supplementary, not congruent.\n\nWhy does parallelness force equal corresponding angles? Parallel lines keep a constant direction. The transversal meets each parallel at the “same slant,” so matching corners are equal. That single idea powers countless diagram problems and is a cornerstone of classical proofs about triangles and polygons.",
            simple: "If two roads are truly parallel and a third road crosses both, the matching corners at each crossing look the same, and measure the same.",
            prior: "You need linear pairs and vertical angles first; parallel-line proofs usually reduce to those two facts plus the parallel assumption.")
        .Formula("Linear pair", @"\angle1+\angle2=180^\circ", "Adjacent angles on a straight line fill a half-turn.")
        .Formula("Vertical angles", @"\angle1=\angle3", "Opposite angles at an intersection are congruent.")
        .Formula("Complement / supplement", @"C=90^\circ-A,\quad S=180^\circ-A", "What remains to reach a right or straight angle.")
        .Example("Find a complement with understanding",
            "An angle measures 35°. What is its complement, and what does that answer mean?",
            [
                "Complement means the two angles together make a right angle: sum 90°.",
                "Compute 90 − 35 = 55.",
                "So the complement is 55°. Together: 35° + 55° = 90°.",
                "Why not 180 − 35? That would be the supplement (straight angle), a different relationship."
            ],
            "The complement is 55°, the amount still needed to complete a 90° corner.",
            problemLatex: @"35^\circ",
            solutionLatex: @"90^\circ-35^\circ=55^\circ",
            stepLatex: [null, @"90-35=55", @"35+55=90", null])
        .Example("Linear pair from a straight line",
            "Two angles form a linear pair. One measures 112°. Find the other.",
            [
                "Linear pair ⇒ the angles are adjacent on a straight line ⇒ they are supplementary.",
                "Other angle = 180 − 112 = 68.",
                "Check: 112 + 68 = 180. The straight line is fully accounted for.",
                "Trap: if the angles look adjacent but do not sit on one straight ray-pair, you cannot use 180°."
            ],
            "The other angle is 68°.",
            solutionLatex: @"180^\circ-112^\circ=68^\circ")
        .Example("Vertical angles without measuring",
            "Two lines intersect and form an angle of 40°. What is the measure of the angle opposite it? What about an adjacent angle?",
            [
                "Opposite angles are vertical ⇒ congruent ⇒ opposite angle is also 40°.",
                "An adjacent angle forms a linear pair with the 40° angle ⇒ 180 − 40 = 140°.",
                "The other vertical pair must both be 140° as well (they are opposite each other).",
                "So at a crossing you only need one angle; the other three are determined."
            ],
            "Opposite: 40°. Adjacent: 140°.",
            solutionLatex: @"40^\circ\text{ (vertical)},\ 140^\circ\text{ (linear pair)}")
        .Example("Mini-proof with parallels",
            "Parallel lines are cut by a transversal. One corresponding angle is 70°. Explain why the other corresponding angle is also 70°, then find a consecutive interior angle.",
            [
                "Given: lines parallel; transversal creates corresponding angles.",
                "Theorem: corresponding angles formed by a transversal with parallel lines are congruent.",
                "Therefore the matching corresponding angle is 70° (not an assumption from the picture alone, it follows from parallel).",
                "Consecutive interior angles are supplementary: 180 − 70 = 110°."
            ],
            "Corresponding angle = 70°; a same-side interior partner = 110°.",
            solutionLatex: @"70^\circ,\quad 180^\circ-70^\circ=110^\circ")
        .Mistake("Calling angles “vertical” just because they look equal, vertical means opposite at an intersection, not merely equal.")
        .Mistake("Confusing complementary (sum 90°) with supplementary (sum 180°).")
        .Mistake("Using corresponding-angle congruence when the lines are not known to be parallel.")
        .Mistake("Assuming adjacent angles always sum to 180°, only linear pairs (or other supplementary pairs) do.")
        .Numeric("Complement of 22°?", "68",
            ["Complement means sum to 90°.", "90 − 22 = 68."],
            "Complement is 68°.", explanationLatex: @"90^\circ-22^\circ=68^\circ")
        .Numeric("Supplement of 125°?", "55",
            ["Supplement means sum to 180°.", "180 − 125 = 55."],
            "Supplement is 55°.", explanationLatex: @"180^\circ-125^\circ=55^\circ")
        .Numeric("Vertical angle to 93°?", "93",
            ["Vertical angles are congruent.", "Opposite angle matches 93°."],
            "Vertical angles are equal: 93°.", explanationLatex: @"93^\circ")
        .Mcq("A right angle measures:",
            ["45°", "90°", "180°", "360°"], 1,
            ["A right angle is one-quarter of a full turn.", "Full turn 360° ÷ 4 = 90°."],
            "By definition a right angle is 90°.")
        .Numeric("Linear pair: one angle is 2x, the other is x, and they sum to 180°. Find x.", "60",
            ["2x + x = 180.", "3x = 180 ⇒ x = 60."],
            "x = 60 (angles 120° and 60°).", explanationLatex: @"x=60")
        .Mcq("Acute angles are:",
            ["Equal to 90°", "Less than 90°", "Between 90° and 180°", "Greater than 180°"], 1,
            ["Compare each option to the definition of acute."],
            "Acute means greater than 0° and less than 90°.")
        .Numeric("Parallel lines; a corresponding angle to 110° measures?", "110",
            ["Corresponding angles with parallels are congruent.", "So the match is also 110°."],
            "Corresponding angles are equal: 110°.", explanationLatex: @"110^\circ")
        .Mcq("When two lines cross, angles that are opposite each other are called:",
            ["Complementary", "A linear pair", "Vertical angles", "Corresponding angles"], 2,
            ["Opposite at an intersection is the vertical-angle relationship."],
            "They are vertical angles (and congruent).")
        .Build();

    private static Lesson Triangles() => new LessonBuilder("geo-triangles", CategoryId, "Triangles: Properties, Congruence & Similarity")
        .Subtitle("Why every triangle’s angles total 180°, and when same shape is not the same size")
        .Order(2).Minutes("30 min")
        .Section("Why the interior angles sum to 180°",
            "In Euclidean plane geometry, the three interior angles of any triangle add to exactly 180°. One classic reason: draw a line through one vertex parallel to the opposite side. The parallel-line angle theorems turn the other two angles into a linear pair with the third, so the three angles fill a straight line.\n\nConsequences you will use constantly:\n• If you know two angles, the third is forced: C = 180° − A − B.\n• A triangle can have at most one right or one obtuse angle (otherwise the sum would exceed 180°).\n• Equilateral ⇒ all angles 60°; isosceles ⇒ base angles equal.\n\nThe exterior-angle theorem is the same idea in another costume: an exterior angle equals the sum of the two remote interior angles (because exterior + adjacent interior = 180°, and the three interiors also total 180°).",
            @"A+B+C=180^\circ",
            simple: "The three corners of a triangle always make a flat half-turn when you put them together. Know two corners, subtract from 180° to find the third.",
            prior: "Linear pairs and parallel-line angle facts from the previous lesson are the engine behind the triangle-sum proof.")
        .Section("Congruence: same size and same shape",
            "Two triangles are congruent if one can be matched to the other by rigid motion (translate, rotate, reflect), every corresponding side and angle matches. In practice we rarely check all six parts. Shortcuts (postulates/theorems) guarantee congruence from fewer pieces:\n• SSS: three sides\n• SAS: two sides and the included angle\n• ASA: two angles and the included side\n• AAS: two angles and a non-included side\n• HL: hypotenuse and one leg (right triangles only)\n\nCritical non-shortcut: AAA is not congruence, it only gives the same shape (similarity). SSA is also not a general congruence theorem (the ambiguous case in trigonometry).\n\nWhy this matters: congruence lets you transfer lengths and angle measures from one triangle to another in proofs and constructions.",
            simple: "Congruent means a perfect clone: same sides, same angles. Certain short recipes (SSS, SAS, ASA, AAS, HL) are enough to prove the clone without measuring everything.",
            prior: "You need angle sum and careful reading of diagrams, “included angle” means the angle between the two sides you named.")
        .Section("Similarity: same shape, possibly different size",
            "Similar triangles have equal corresponding angles and proportional corresponding sides. The scale factor k multiplies every length on the original to produce the image: if sides are a, b, c then image sides are ka, kb, kc. Areas scale by k² (not k).\n\nAA is enough for similarity: if two angles match, the third matches automatically (angle sum), so the triangles are equiangular and thus similar in Euclidean geometry.\n\nMatching correspondence is everything. Align vertices so equal angles pair up; only then do side ratios like a′/a make sense. Mixing non-corresponding sides is one of the most common exam errors.",
            @"\frac{a'}{a}=\frac{b'}{b}=\frac{c'}{c}=k",
            simple: "Similar means a scaled photo of the same triangle. Angles match; sides stretch by one common multiplier k.",
            prior: "Congruence is the special case k = 1. If you understand congruence as “same,” similarity is “same after zooming.”")
        .Section("Isosceles and equilateral structure",
            "Isosceles: at least two sides equal; the angles opposite those sides (base angles) are equal. Equilateral: all three sides equal, so all three angles are 60°. The isosceles base-angle theorem and its converse are workhorses for finding missing angles without trig.",
            simple: "Equal sides sit opposite equal angles. All sides equal ⇒ every angle is 60°.")
        .Formula("Angle sum", @"A+B+C=180^\circ", "Every Euclidean triangle.")
        .Formula("Exterior angle", @"E=A+B", "Exterior equals sum of the two remote interiors.")
        .Formula("Similarity ratios", @"\frac{a'}{a}=\frac{b'}{b}=\frac{c'}{c}=k", "One scale factor for all corresponding sides.")
        .Example("Recover the third angle",
            "A triangle has angles 50° and 60°. Find the third angle and classify the triangle by angles.",
            [
                "Angle sum: third angle = 180 − 50 − 60 = 70°.",
                "All three angles are less than 90°, so the triangle is acute.",
                "It is not equilateral (angles not all 60°) and not isosceles from the angle data alone (all angles different).",
                "Sanity: 50 + 60 + 70 = 180."
            ],
            "Third angle 70°; acute scalene (from the given angles).",
            solutionLatex: @"70^\circ")
        .Example("Exterior angle as a shortcut",
            "The two remote interior angles are 40° and 65°. Find the exterior angle at the third vertex.",
            [
                "Exterior angle theorem: exterior = sum of remote interiors.",
                "40 + 65 = 105°.",
                "Check via the long way: interior at that vertex is 180 − 40 − 65 = 75°, so exterior linear pair is 180 − 75 = 105°. Same answer.",
                "Why the theorem is useful: you skip finding the adjacent interior first."
            ],
            "Exterior angle is 105°.",
            solutionLatex: @"40^\circ+65^\circ=105^\circ")
        .Example("Scale factor from corresponding sides",
            "Two triangles are similar. The smaller has sides 3, 4, 5. The largest side of the larger triangle is 10. Find the scale factor and the other two sides of the larger triangle.",
            [
                "Largest side corresponds to largest side: 5 maps to 10.",
                "Scale factor k = 10/5 = 2.",
                "Other sides: 3 × 2 = 6 and 4 × 2 = 8.",
                "Larger triangle sides 6, 8, 10, a scaled 3-4-5 right triangle. Corresponding angles stay equal."
            ],
            "k = 2; sides 6, 8, and 10.",
            solutionLatex: @"k=2;\ 6,8,10")
        .Example("Isosceles base angles",
            "An isosceles triangle has vertex angle 40°. Find each base angle.",
            [
                "Base angles are equal; call each x.",
                "Equation: 40 + x + x = 180 ⇒ 2x = 140 ⇒ x = 70.",
                "So each base angle is 70°.",
                "Check: 40 + 70 + 70 = 180. If the vertex had been 80°, each base would be 50°, same method."
            ],
            "Each base angle is 70°.",
            solutionLatex: @"\frac{180^\circ-40^\circ}{2}=70^\circ")
        .Mistake("Treating AAA as a congruence criterion (it only gives similarity).")
        .Mistake("Setting up side ratios with non-corresponding sides.")
        .Mistake("Forgetting that an exterior angle equals the sum of the remote interiors, not “whatever is left on the diagram.”")
        .Mistake("Assuming a triangle is isosceles from the picture alone without equal sides or equal base angles stated.")
        .Numeric("Angles 90° and 30°. Third angle?", "60",
            ["Sum to 180°.", "180 − 90 − 30 = 60."],
            "Third angle is 60°.", explanationLatex: @"60^\circ")
        .Numeric("One angle of an equilateral triangle?", "60",
            ["All angles equal and sum to 180°.", "180 ÷ 3 = 60."],
            "Each angle is 60°.", explanationLatex: @"60^\circ")
        .Numeric("Similar triangles with k = 3; short side 4 maps to?", "12",
            ["Multiply by the scale factor.", "3 × 4 = 12."],
            "Image side is 12.", explanationLatex: @"3\times4=12")
        .Mcq("Which proves congruence?",
            ["AAA", "SSA (always)", "SAS", "Two angles only, with no side"], 2,
            ["AAA is similarity, not congruence.", "SAS is a standard congruence criterion."],
            "SAS proves congruence.")
        .Numeric("Isosceles; vertex 80°. One base angle?", "50",
            ["Two equal base angles share the remaining 100°.", "(180 − 80) / 2 = 50."],
            "Each base angle is 50°.", explanationLatex: @"50^\circ")
        .Numeric("Exterior angle; remote interiors 25° and 40°. Exterior?", "65",
            ["Exterior = sum of remotes.", "25 + 40 = 65."],
            "Exterior is 65°.", explanationLatex: @"65^\circ")
        .Mcq("Similar triangles always have:",
            ["Equal corresponding sides", "Proportional corresponding sides", "No equal angles", "Equal areas"], 1,
            ["Similarity keeps angles and multiplies sides by k.", "Areas match only if k = 1."],
            "Corresponding sides are proportional.")
        .Mcq("A triangle with angles 40°, 60°, and 80° is:",
            ["Right", "Obtuse", "Acute", "Equilateral"], 2,
            ["All angles less than 90° ⇒ acute."],
            "It is an acute triangle.")
        .Build();

    private static Lesson RightTriangles() => new LessonBuilder("geo-pythag", CategoryId, "Right Triangles & Pythagorean Theorem")
        .Subtitle("Why a² + b² = c², how the converse classifies triangles, and the 30-60-90 / 45-45-90 shortcuts")
        .Order(3).Minutes("30 min")
        .Section("What makes a right triangle special",
            "A right triangle has one angle of exactly 90°. The side opposite the right angle is the hypotenuse, always the longest side. The other two sides are legs; they form the right angle.\n\nRight triangles appear everywhere: distance in the coordinate plane, diagonals of rectangles, ramps and roofs, and the foundation of trigonometry (sine and cosine as side ratios). Before trig, the main computational engine is the Pythagorean theorem.",
            simple: "One square corner. The side across from that corner is the long side (hypotenuse). The other two sides are the legs.",
            prior: "You need the triangle angle sum (so the other two angles are acute and add to 90°) and comfort with squares and square roots.")
        .Section("Pythagorean theorem: the deep “why” in plain language",
            "In a right triangle with legs a, b and hypotenuse c:\n\na² + b² = c².\n\nOne famous geometric story: if you build a square outward on each side of the triangle, the area of the square on the hypotenuse equals the sum of the areas of the squares on the two legs. That is not a coincidence of numbers, it is a theorem about area that can be proved with rearrangements, similarity, or algebra.\n\nHow to use it:\n• Missing hypotenuse: c = √(a² + b²)\n• Missing leg: b = √(c² − a²) (only when c is truly the hypotenuse)\n\nUnits: if a and b are in meters, c is in meters; a² is in square meters only if you are thinking of the area interpretation.",
            @"a^2+b^2=c^2",
            simple: "Square the two legs, add, then take the square root to get the long side. Or rearrange to hunt a missing leg.",
            prior: "Squaring and square-rooting positive numbers. Always identify which side is the hypotenuse first.")
        .Section("Converse: detecting right angles from side lengths",
            "If a triangle has sides a, b, c (with c the longest) and a² + b² = c², then the angle opposite c is a right angle. That is the converse of Pythagoras, equally useful.\n\nClassification with the longest side c:\n• a² + b² = c² → right\n• a² + b² > c² → acute (all angles acute)\n• a² + b² < c² → obtuse (angle opposite c is obtuse)\n\nPythagorean triples are integer solutions, like 3-4-5, 5-12-13, 8-15-17, and their multiples (6-8-10, 9-12-15, …).",
            simple: "If the side squares fit Pythagoras, you have a right triangle, even if nobody drew a square corner.",
            prior: "You must compare using the longest side as the candidate hypotenuse; otherwise the test is meaningless.")
        .Section("Special right triangles: memorized side ratios",
            "Two families appear constantly:\n• 45-45-90 (isosceles right): angles 45°, 45°, 90°; sides x : x : x√2 (legs equal; hypotenuse = leg × √2).\n• 30-60-90: sides x : x√3 : 2x (short leg opposite 30°; long leg opposite 60°; hypotenuse twice the short leg).\n\nWhy they work: a 45-45-90 is half a square; a 30-60-90 is half an equilateral triangle. Deriving them once from Pythagoras makes the ratios unforgettable.",
            simple: "Isosceles right: legs equal, hyp = leg√2. 30-60-90: hyp = 2 × short, long = short√3.",
            prior: "Pythagorean theorem plus equilateral / isosceles angle facts.")
        .Formula("Pythagorean theorem", @"a^2+b^2=c^2", "Right triangle; c is the hypotenuse.")
        .Formula("45-45-90 sides", @"x,\;x,\;x\sqrt{2}", "Isosceles right triangle.")
        .Formula("30-60-90 sides", @"x,\;x\sqrt{3},\;2x", "Short leg, long leg, hypotenuse.")
        .Example("Find the hypotenuse",
            "A right triangle has legs 3 and 4. Find the hypotenuse.",
            [
                "Identify: legs a = 3, b = 4; need c.",
                "Compute a² + b² = 9 + 16 = 25.",
                "c = √25 = 5.",
                "This is the classic 3-4-5 triple, a mental checkpoint for many problems."
            ],
            "Hypotenuse c = 5.",
            problemLatex: @"a=3,\ b=4",
            solutionLatex: @"c=5",
            stepLatex: [null, @"3^2+4^2=25", @"c=\sqrt{25}=5", null])
        .Example("Find a missing leg",
            "Hypotenuse 13, one leg 5. Find the other leg.",
            [
                "Use b² = c² − a² (rearranged Pythagoras).",
                "b² = 169 − 25 = 144.",
                "b = √144 = 12 (length is positive).",
                "Check: 5² + 12² = 25 + 144 = 169 = 13²."
            ],
            "Other leg is 12.",
            solutionLatex: @"b=12")
        .Example("Converse classifies the triangle",
            "A triangle has sides 6, 8, and 10. Is it right, acute, or obtuse?",
            [
                "Longest side is 10, candidate hypotenuse.",
                "Test: 6² + 8² = 36 + 64 = 100, and 10² = 100.",
                "Equality holds ⇒ right triangle (angle opposite 10 is 90°).",
                "Note 6-8-10 is a multiple of 3-4-5 (scale factor 2)."
            ],
            "It is right-angled.",
            solutionLatex: @"6^2+8^2=10^2")
        .Example("45-45-90 without trig",
            "An isosceles right triangle has legs of length 7. Find the hypotenuse exactly.",
            [
                "45-45-90 pattern: hyp = leg × √2.",
                "Hypotenuse = 7√2.",
                "Optional check with Pythagoras: 7² + 7² = 98 = (7√2)².",
                "Decimal approximation 7 × 1.414 ≈ 9.90 is fine for estimation, but exact form is preferred."
            ],
            "Hypotenuse is 7√2.",
            solutionLatex: @"7\sqrt{2}")
        .Mistake("Plugging the longest side in as a leg in a² + b² = c².")
        .Mistake("Forgetting to take the square root at the end (reporting 25 instead of 5).")
        .Mistake("Using Pythagoras on non-right triangles without switching to the converse/classification carefully.")
        .Mistake("In 30-60-90, doubling the long leg instead of the short leg to get the hypotenuse.")
        .Numeric("Legs 5 and 12. Hypotenuse?", "13",
            ["5² + 12² = 25 + 144 = 169.", "√169 = 13."],
            "Hypotenuse is 13.", explanationLatex: @"13")
        .Numeric("Hypotenuse 10, leg 6. Other leg?", "8",
            ["Other² = 100 − 36 = 64.", "√64 = 8."],
            "Other leg is 8.", explanationLatex: @"8")
        .Mcq("A 3-4-5 triangle is:",
            ["Obtuse", "Acute", "Right", "Equilateral"], 2,
            ["3² + 4² = 9 + 16 = 25 = 5².", "Pythagorean triple ⇒ right."],
            "It is a right triangle.")
        .Numeric("Is 5, 12, 13 a right triangle? Enter 1 for yes, 0 for no.", "1",
            ["25 + 144 = 169 = 13².", "Yes, it satisfies Pythagoras."],
            "Yes (1).", explanationLatex: @"1")
        .Numeric("45-45-90 with leg 5; hypotenuse ≈ ? (use √2 ≈ 1.414)", "7.07",
            ["Hyp = 5√2 ≈ 5 × 1.414.", "About 7.07."],
            "Approximately 7.07.", explanationLatex: @"5\sqrt{2}\approx7.07", tolerance: 0.05)
        .Numeric("30-60-90 short leg 4; hypotenuse?", "8",
            ["Hypotenuse = 2 × short leg.", "2 × 4 = 8."],
            "Hypotenuse is 8.", explanationLatex: @"8")
        .Numeric("Distance: move 9 horizontal and 12 vertical. Path length?", "15",
            ["Right triangle legs 9 and 12.", "81 + 144 = 225; √225 = 15."],
            "Length is 15.", explanationLatex: @"15")
        .Mcq("In a right triangle, the hypotenuse is:",
            ["Always a leg", "Opposite the right angle", "The shortest side", "Opposite an acute angle only"], 1,
            ["Definition: hypotenuse faces the 90° angle."],
            "It is opposite the right angle (and longest).")
        .Build();

    private static Lesson Quadrilaterals() => new LessonBuilder("geo-quads", CategoryId, "Quadrilaterals, Polygons & Interior Angles")
        .Subtitle("Family tree of four-sided shapes and why an n-gon’s angles sum to (n − 2)×180°")
        .Order(4).Minutes("28 min")
        .Section("Why polygon angle sums work",
            "Any convex n-gon can be divided into n − 2 triangles by drawing non-overlapping diagonals from one vertex. Each triangle contributes 180° of interior angle measure, so the interior angle sum is (n − 2)×180°.\n\nExamples:\n• Quadrilateral (n = 4): (2)×180° = 360°\n• Pentagon (n = 5): 540°\n• Hexagon (n = 6): 720°\n\nFor a regular n-gon (all sides equal, all angles equal), each interior angle is the sum divided by n: ((n − 2)×180°)/n.\n\nExterior angles of any convex polygon sum to 360°, one full turn as you walk around the shape. For a regular n-gon each exterior is 360°/n.",
            @"(n-2)180^\circ",
            simple: "Chop an n-sided polygon into n − 2 triangles. Multiply that count by 180° to get the total of the interior angles.",
            prior: "Triangle angle sum (180°) is the single ingredient. Diagonals from one vertex do the chopping.")
        .Section("Quadrilateral family: definitions that control properties",
            "A quadrilateral is a four-sided polygon. Special types are defined by parallel sides, equal sides, or right angles, and those definitions force further properties:\n• Parallelogram: both pairs of opposite sides parallel.\n• Rectangle: parallelogram with four right angles (equivalently: equiangular parallelogram).\n• Rhombus: parallelogram with all sides equal.\n• Square: rectangle and rhombus (regular quadrilateral).\n• Trapezoid (US usage): at least one pair of parallel sides (the bases).\n• Kite: two pairs of adjacent equal sides.\n\nWhy definitions first? Every “property list” is a theorem chain starting from the definition. If you memorize properties without definitions, you will mis-apply them to near-miss shapes.",
            simple: "Names are not decorations, they encode which sides are parallel or equal. Properties follow from those promises.",
            prior: "Parallel lines, transversals, and triangle congruence/similarity give the proofs behind parallelogram facts.")
        .Section("Parallelogram properties worth owning",
            "In a parallelogram:\n• Opposite sides are congruent and parallel.\n• Opposite angles are congruent.\n• Consecutive angles are supplementary (same-side interior with parallel sides).\n• Diagonals bisect each other (each diagonal cuts the other into two equal segments).\n\nSpecializations add more:\n• Rectangle: diagonals congruent.\n• Rhombus: diagonals perpendicular and bisect vertex angles.\n• Square: all of the above.\n\nThese facts solve for missing sides and angles without coordinates.",
            simple: "In a parallelogram, opposites match; neighbors on a side add to 180°; diagonals cut each other in half.",
            prior: "Supplementary consecutive angles are the parallel-line same-side interior theorem in disguise.")
        .Section("Solving polygon problems systematically",
            "Typical moves: (1) write the sum formula with the correct n, (2) for regular polygons divide by n, (3) for irregular quads use 360° and subtract known angles, (4) for parallelograms use opposite-equal and consecutive-supplementary. Always check that your answer is positive and less than the sum.",
            simple: "Pick the right tool: sum formula for n-gons, 360° for any quad, opposite/consecutive rules for parallelograms.")
        .Formula("Interior sum", @"(n-2)180^\circ", "Convex n-gon interior angle sum.")
        .Formula("Regular interior", @"\frac{(n-2)180^\circ}{n}", "One interior angle of a regular n-gon.")
        .Formula("Exterior (regular)", @"\frac{360^\circ}{n}", "Each exterior angle of a regular n-gon.")
        .Example("Pentagon interior sum",
            "Find the sum of the interior angles of a pentagon.",
            [
                "A pentagon has n = 5 sides.",
                "Sum = (5 − 2) × 180° = 3 × 180° = 540°.",
                "Story: from one vertex you draw 2 diagonals and form 3 triangles; 3 × 180° = 540°.",
                "If the pentagon is regular, each interior angle is 540°/5 = 108°."
            ],
            "Interior sum is 540°.",
            solutionLatex: @"540^\circ")
        .Example("Regular octagon angle",
            "Find one interior angle of a regular octagon.",
            [
                "n = 8; sum = (8 − 2) × 180° = 1080°.",
                "Regular ⇒ equal angles: 1080° / 8 = 135°.",
                "Quick exterior check: exterior = 360°/8 = 45°, and interior + exterior = 180° ⇒ interior = 135°. Same result.",
                "Why two methods? Exterior is often faster for regular polygons."
            ],
            "Each interior angle is 135°.",
            solutionLatex: @"135^\circ")
        .Example("Parallelogram consecutive angles",
            "In a parallelogram, one angle measures 70°. Find an adjacent angle and the opposite angle.",
            [
                "Consecutive angles of a parallelogram are supplementary: adjacent = 180 − 70 = 110°.",
                "Opposite angles are congruent: opposite = 70°.",
                "The remaining angle (opposite the 110°) is also 110°.",
                "Check sum of four angles: 70 + 110 + 70 + 110 = 360°."
            ],
            "Adjacent 110°; opposite 70°.",
            solutionLatex: @"110^\circ,\ 70^\circ")
        .Example("Any quadrilateral’s angle sum",
            "Why do the interior angles of every quadrilateral sum to 360°? Then find the fourth angle if three angles are 90°, 80°, and 100°.",
            [
                "n = 4 ⇒ sum = (4 − 2) × 180° = 360°. (One diagonal splits a quad into two triangles: 180 + 180 = 360.)",
                "Fourth angle = 360 − 90 − 80 − 100 = 90°.",
                "So the angles are 90°, 80°, 100°, 90°.",
                "Note: having two right angles does not force a rectangle, sides may not be appropriately related."
            ],
            "Fourth angle is 90°; total always 360° for a quad.",
            solutionLatex: @"90^\circ")
        .Mistake("Using n × 180° for interior sum instead of (n − 2) × 180°.")
        .Mistake("Assuming every parallelogram is a rectangle (right angles are extra structure).")
        .Mistake("Dividing (n − 2)×180° by n for a non-regular polygon (only regular polygons have equal interior angles guaranteed by symmetry).")
        .Mistake("Confusing “diagonals bisect each other” (parallelogram) with “diagonals are equal” (rectangle).")
        .Numeric("Hexagon interior angle sum?", "720",
            ["n = 6 ⇒ (6 − 2) × 180.", "4 × 180 = 720."],
            "Sum is 720°.", explanationLatex: @"720^\circ")
        .Numeric("One interior angle of a regular pentagon?", "108",
            ["Sum 540°; regular ⇒ divide by 5.", "540 / 5 = 108."],
            "Each interior angle is 108°.", explanationLatex: @"108^\circ")
        .Numeric("Quad angles 90°, 80°, 100°. Fourth?", "90",
            ["Quad sum 360°.", "360 − 270 = 90."],
            "Fourth angle is 90°.", explanationLatex: @"90^\circ")
        .Mcq("Diagonals of a parallelogram:",
            ["Are always equal", "Bisect each other", "Are always perpendicular", "Never bisect"], 1,
            ["Equal diagonals need a rectangle (or isosceles trapezoid, etc.).", "All parallelograms have diagonals that bisect each other."],
            "They bisect each other.")
        .Numeric("Regular 12-gon: one interior angle?", "150",
            ["Sum = 10 × 180 = 1800.", "1800 / 12 = 150."],
            "Each interior angle is 150°.", explanationLatex: @"150^\circ")
        .Numeric("Parallelogram angle 55°; opposite angle?", "55",
            ["Opposite angles of a parallelogram are congruent."],
            "Opposite angle is 55°.", explanationLatex: @"55^\circ")
        .Numeric("Interior sum of an n-gon is 900°. Find n.", "7",
            ["(n − 2) × 180 = 900.", "n − 2 = 5 ⇒ n = 7."],
            "It is a heptagon (n = 7).", explanationLatex: @"n=7")
        .Mcq("A square is always a:",
            ["Rhombus only, not a rectangle", "Rectangle and a rhombus", "Trapezoid only", "Triangle"], 1,
            ["Square has four right angles and four equal sides."],
            "A square is both a rectangle and a rhombus.")
        .Build();

    private static Lesson Circles() => new LessonBuilder("geo-circles", CategoryId, "Circles: Parts, Arcs, Chords, Circumference & Area")
        .Subtitle("Radius, arcs, and why fractions of 360° unlock arc length and sector area")
        .Order(5).Minutes("30 min")
        .Section("Circle vocabulary that prevents mix-ups",
            "A circle is the set of all points in a plane at a fixed distance r (the radius) from a center. Key parts:\n• Diameter d = 2r: a chord through the center; longest chord.\n• Chord: segment joining two points on the circle.\n• Arc: a continuous piece of the circle between two points (minor arc < 180°, major arc > 180° unless semicircle).\n• Central angle: vertex at the center; its measure equals the intercepted arc’s degree measure.\n• Inscribed angle: vertex on the circle; sides are chords; measure is half the intercepted arc.\n• Semicircle: arc of 180°; angle inscribed in a semicircle is 90° (Thales’ theorem).\n\nKeeping center vs. on-circle vertices straight is half of circle geometry.",
            simple: "Radius is center-to-edge. Diameter is full width through the center. Central angles live at the middle; inscribed angles live on the rim.",
            prior: "Angle measure in degrees and the idea of a full turn = 360°.")
        .Section("Circumference and area: measuring around vs. inside",
            "Circumference is the perimeter of the circle: C = 2πr = πd. Area is the region enclosed: A = πr².\n\nWhy π appears: circumference is proportional to diameter; the constant of proportionality is π ≈ 3.14159…. Area scales with the square of the radius because if you scale a circle by k, lengths × k and areas × k².\n\nCommon disaster: using diameter in the area formula as if it were radius (that makes the area four times too large if you square d by mistake, or wrong by factor 4 when d = 2r).",
            @"C=2\pi r,\quad A=\pi r^2",
            simple: "Around: 2πr. Inside: π times radius squared. Radius, not diameter, in the area formula.",
            prior: "Comfort with π as a constant and with squaring a length.")
        .Section("Arcs and sectors as fractional circles",
            "A central angle of θ degrees grabs a fraction θ/360 of the whole circle. Therefore:\n• Arc length = (θ/360) × C = (θ/360) × 2πr\n• Sector area = (θ/360) × A = (θ/360) × πr²\n\nIn radians (advanced link): arc length = rθ and sector area = (1/2)r²θ, same ideas with a different angle unit.\n\nWhy fractional thinking helps: you are not memorizing four unrelated formulas; you are reusing C and A with a piece of the pie.",
            @"\text{arc}=\frac{\theta}{360}(2\pi r)",
            simple: "Ask what fraction of the full pizza you have (θ out of 360). Multiply that fraction by full circumference or full area.",
            prior: "Circumference and area formulas; ability to simplify fractions like 60/360 = 1/6.")
        .Section("Inscribed vs. central angles",
            "Central angle measure = intercepted arc measure. Inscribed angle measure = half of the intercepted arc. So an inscribed angle intercepting the same arc as a central angle is half as large.\n\nAngle in a semicircle: the arc is 180°, so the inscribed angle is 90°. That is a powerful right-triangle generator.",
            simple: "Angle at the center matches the arc. Angle on the rim is half the arc it “sees.”")
        .Formula("Circumference", @"C=2\pi r", "Distance around the circle.")
        .Formula("Area", @"A=\pi r^2", "Region inside the circle.")
        .Formula("Arc length (degrees)", @"L=\frac{\theta}{360}\cdot 2\pi r", "Fraction of circumference.")
        .Formula("Sector area (degrees)", @"S=\frac{\theta}{360}\cdot \pi r^2", "Fraction of circle area.")
        .Example("Circumference in exact form",
            "A circle has radius 5. Find the circumference in terms of π and approximate it.",
            [
                "C = 2πr = 2π·5 = 10π.",
                "Approximate: 10 × 3.14 = 31.4 (or use 3.1416 for more precision).",
                "If you were given diameter 10 instead, C = πd = 10π, same result.",
                "Exact form 10π is preferred unless a decimal is requested."
            ],
            "C = 10π ≈ 31.4.",
            solutionLatex: @"C=10\pi")
        .Example("Area from radius",
            "Radius 3. Find the area in terms of π.",
            [
                "A = πr² = π·3² = 9π.",
                "If someone wrongly uses diameter 6 in πr², they get 36π, four times too big.",
                "Units: if r is in cm, area is in cm².",
                "9π is exact; ≈ 28.27 if a decimal is needed."
            ],
            "A = 9π.",
            solutionLatex: @"A=9\pi")
        .Example("Arc length as a fraction of circumference",
            "Radius 6, central angle 60°. Find the arc length in terms of π.",
            [
                "Full circumference C = 2π·6 = 12π.",
                "Fraction of the circle: 60/360 = 1/6.",
                "Arc length = (1/6)·12π = 2π.",
                "Same via formula: (60/360)·2π·6 = (1/6)·12π = 2π."
            ],
            "Arc length is 2π.",
            solutionLatex: @"2\pi")
        .Example("Inscribed angle from an arc",
            "An inscribed angle intercepts an arc of 80°. Find the inscribed angle. What would a central angle intercepting the same arc measure?",
            [
                "Inscribed angle = half the arc = 40°.",
                "Central angle intercepting the same arc = 80° (equal to the arc).",
                "So the central angle is twice the inscribed angle that sees the same arc.",
                "If the arc were a semicircle (180°), the inscribed angle would be 90°."
            ],
            "Inscribed 40°; central 80°.",
            solutionLatex: @"40^\circ")
        .Mistake("Using diameter in A = πr² without converting to radius first.")
        .Mistake("Computing arc length as (θ/360)×r instead of a fraction of circumference.")
        .Mistake("Forgetting that inscribed angles are half the arc (using the full arc by accident).")
        .Mistake("Mixing degree formulas with a calculator in radian mode for other topics.")
        .Numeric("Diameter if r = 9?", "18",
            ["Diameter is twice the radius.", "2 × 9 = 18."],
            "Diameter is 18.", explanationLatex: @"d=18")
        .Numeric("Area of r = 4 in terms of π: coefficient of π?", "16",
            ["A = πr² = 16π.", "Coefficient is 16."],
            "Coefficient 16 (area 16π).", explanationLatex: @"16\pi")
        .Numeric("C for d = 10; coefficient of π?", "10",
            ["C = πd = 10π.", "Coefficient 10."],
            "C = 10π; coefficient 10.", explanationLatex: @"10\pi")
        .Numeric("Central angle 90°, r = 2; arc length divided by π equals?", "1",
            ["C = 4π; fraction 90/360 = 1/4.", "Arc = π; so arc/π = 1."],
            "Arc/π = 1.", explanationLatex: @"1", tolerance: 0.01)
        .Mcq("Inscribed angle intercepting a 100° arc measures:",
            ["100°", "50°", "200°", "25°"], 1,
            ["Inscribed angle is half the intercepted arc.", "100 / 2 = 50."],
            "50°.")
        .Numeric("Sector 90° with r = 2; sector area / π equals?", "1",
            ["Full area 4π; fraction 1/4.", "Sector = π; so sector/π = 1."],
            "Sector area / π = 1.", explanationLatex: @"1")
        .Numeric("Angle inscribed in a semicircle?", "90",
            ["Arc is 180°; inscribed = half of arc.", "90°."],
            "Always 90° (Thales).", explanationLatex: @"90^\circ")
        .Mcq("A chord that passes through the center is a:",
            ["Radius", "Diameter", "Secant only", "Tangent"], 1,
            ["Longest chord through the center is the diameter."],
            "It is a diameter.")
        .Build();

    private static Lesson PerimeterAreaVolume() => new LessonBuilder("geo-measure", CategoryId, "Perimeter, Area, Surface Area & Volume")
        .Subtitle("Around, covering, wrapping, and filling, four different measurements and when to use each")
        .Order(6).Minutes("32 min")
        .Section("Four measurements people constantly confuse",
            "Geometry measurement is not one skill, it is four related ideas with different units:\n• Perimeter (2D): length of the boundary (units of length).\n• Area (2D): amount of surface inside a region (square units).\n• Surface area (3D): total area of the outer skin (square units).\n• Volume (3D): space inside a solid (cubic units).\n\nWhy students mix them up: formulas are memorized as letter soup without the story. Always ask: “Am I walking the fence, painting the floor, wrapping the box, or filling the box?”",
            simple: "Fence → perimeter. Floor tile → area. Wrapping paper → surface area. Water in a tank → volume.",
            prior: "Rectangle, triangle, and circle area basics help; here we organize them and extend to 3D.")
        .Section("Core 2D area formulas and why they connect",
            "• Rectangle: A = ℓw (rows of unit squares).\n• Parallelogram: A = bh (same base and height as a rearranged rectangle).\n• Triangle: A = (1/2)bh (half of a parallelogram with same base and height).\n• Trapezoid: A = (1/2)(b₁ + b₂)h (average of the two bases times height).\n• Circle: A = πr².\n\nHeight means perpendicular height, not a slanted side. Using a slant as h is a classic error in parallelograms and triangles.",
            @"A=\frac12 bh",
            simple: "Triangle is half a parallelogram. Parallelogram area is base times straight-up height, not the long slanted side.",
            prior: "You can count unit squares for rectangles; other shapes rearrange into rectangles or halves of them.")
        .Section("Surface area: add the faces",
            "Surface area is the sum of the areas of all faces (or the net of the solid).\n• Rectangular prism: 2(ℓw + ℓh + wh), three pairs of congruent rectangles.\n• Cube side s: 6s².\n• Right cylinder: 2πr² + 2πrh (two bases + lateral rectangle that wraps with width = circumference).\n\nNets make surface area concrete: unfold, find each region’s area, add. Missing a face or double-counting a base is common.",
            simple: "Pretend you paint every outside face. Compute each face area, then add. Cylinders: two circles plus the wrap-around label.",
            prior: "Rectangle and circle area are enough for standard prisms and cylinders.")
        .Section("Volume: base area times height, with pyramid exceptions",
            "For a prism or cylinder, volume is V = Bh, where B is the area of the base and h is the perpendicular height. Stacking layers of the base is the intuition.\n\nPyramids and cones fill only one-third of the related prism/cylinder with the same base and height: V = (1/3)Bh. Sphere: V = (4/3)πr³ (memorize and compare to cylinder intuition later in calculus).\n\nScaling: if all lengths × k, areas × k² and volumes × k³. That is why doubling every edge of a cube multiplies volume by 8, not 2.",
            @"V=Bh",
            simple: "Prism/cylinder: base area × height. Pyramid/cone: take one-third of that. Sphere uses the (4/3)πr³ formula.",
            prior: "Area of the base shape (rectangle, circle, triangle, …) must be computed first; then multiply by height.")
        .Formula("Rectangle perimeter & area", @"P=2(\ell+w),\ A=\ell w", "Around vs. inside a rectangle.")
        .Formula("Prism / cylinder volume", @"V=Bh", "B = base area; h = height.")
        .Formula("Pyramid / cone volume", @"V=\frac13 Bh", "One-third of the related prism/cylinder.")
        .Formula("Sphere volume", @"V=\frac43\pi r^3", "Space inside a sphere.")
        .Example("Rectangle perimeter and area together",
            "A rectangle measures 5 by 8. Find perimeter and area, and state units if the sides are in meters.",
            [
                "Perimeter: walk all four sides: P = 2(5 + 8) = 2 × 13 = 26 m.",
                "Area: fill with squares: A = 5 × 8 = 40 m².",
                "Notice the different unit dimensions, 26 m is not comparable to 40 m² as “which is bigger.”",
                "Check: if both sides double, P doubles (scale k) but A multiplies by 4 (k²)."
            ],
            "P = 26; A = 40.",
            solutionLatex: @"P=26,\ A=40")
        .Example("Triangle area with true height",
            "A triangle has base 10 and corresponding height 6. Find the area.",
            [
                "Area = (1/2) × base × height = (1/2) × 10 × 6 = 30.",
                "The 6 must be perpendicular to the side chosen as base.",
                "If 6 were a slanted side instead of height, you would need another method (e.g. Heron or trig).",
                "Half of a 10-by-6 parallelogram is 30, same story."
            ],
            "Area is 30 square units.",
            solutionLatex: @"30")
        .Example("Box volume",
            "A rectangular box measures 2 × 3 × 4. Find its volume and surface area.",
            [
                "Volume V = ℓwh = 2 × 3 × 4 = 24 cubic units.",
                "Surface area: 2(2·3 + 2·4 + 3·4) = 2(6 + 8 + 12) = 2 × 26 = 52 square units.",
                "V uses three length factors; SA is only area of faces.",
                "If you only needed volume for shipping capacity, 24 is the answer; if wrapping paper, use 52."
            ],
            "V = 24; SA = 52.",
            solutionLatex: @"V=24,\ SA=52")
        .Example("Cylinder volume in terms of π",
            "A cylinder has radius 3 and height 5. Find the volume.",
            [
                "Base is a circle: B = πr² = 9π.",
                "V = Bh = 9π × 5 = 45π.",
                "Lateral surface area would be 2πrh = 30π (not asked, but related).",
                "Keep 45π exact unless a decimal is required."
            ],
            "Volume is 45π cubic units.",
            solutionLatex: @"45\pi")
        .Mistake("Mixing perimeter formulas with area formulas (and mixing length units with square units).")
        .Mistake("Using V = Bh for pyramids or cones without the factor 1/3.")
        .Mistake("Using a slanted edge as height in triangle or parallelogram area.")
        .Mistake("Forgetting the two bases when computing cylinder surface area (only counting the lateral wrap).")
        .Numeric("Perimeter of a 6×10 rectangle?", "32",
            ["P = 2(6 + 10) = 2 × 16.", "32."],
            "Perimeter is 32.", explanationLatex: @"32")
        .Numeric("Area of a 6×10 rectangle?", "60",
            ["A = ℓw = 6 × 10.", "60."],
            "Area is 60.", explanationLatex: @"60")
        .Numeric("Triangle area with b = 8, h = 5?", "20",
            ["(1/2) × 8 × 5 = 20."],
            "Area is 20.", explanationLatex: @"20")
        .Numeric("Cube side 3: volume?", "27",
            ["V = s³ = 27."],
            "Volume is 27.", explanationLatex: @"27")
        .Numeric("Cube side 3: surface area?", "54",
            ["SA = 6s² = 6 × 9 = 54."],
            "Surface area is 54.", explanationLatex: @"54")
        .Numeric("Cylinder r = 2, h = 3; V/π equals?", "12",
            ["B = 4π; V = 12π.", "V/π = 12."],
            "V/π = 12.", explanationLatex: @"12")
        .Mcq("Cone volume compared to a cylinder with the same base and height:",
            ["Equal", "Half", "One third", "Double"], 2,
            ["Cone formula is (1/3)Bh; cylinder is Bh."],
            "The cone is one third of the cylinder.")
        .Numeric("Trapezoid bases 4 and 10, height 3. Area?", "21",
            ["A = (1/2)(b₁ + b₂)h = (1/2)(14)×3.", "7 × 3 = 21."],
            "Area is 21.", explanationLatex: @"21")
        .Build();
}
