# MathMentor

**A free, offline math tutor for Windows**, from absolute basics through single-variable calculus.

No account. No subscription. No ads. Progress stays on your PC. Jump to any topic whenever you want.

**Created by [Jayden Shutt](https://www.linkedin.com/in/jaydenshutt/)**

![MathMentor dashboard](docs/mathmentor.png)

---

## Download (Windows)

**[Download MathMentor.exe](https://github.com/jaydenshutt/MathMentor/releases/download/v1.0.1/MathMentor.exe)**  
(~63 MB · current release: **v1.0.1** · [all releases](https://github.com/jaydenshutt/MathMentor/releases/latest))

| | |
|---|---|
| **OS** | Windows 10 or 11, **64-bit** |
| **.NET install** | **Not required** (self-contained) |
| **Internet** | Not needed after download |
| **Installer** | None. Run the single `.exe`. |

### Start in under a minute

1. Download `MathMentor.exe` and run it.
2. If **Windows SmartScreen** appears: **More info** → **Run anyway** (unsigned personal builds often trigger this; the app does not need admin rights for normal use).
3. Open a lesson from the dashboard or **Curriculum**, read the explanation, then try **Practice**.

First launch can take a few seconds while the app unpacks.

---

## Why MathMentor

Most online tutors want a login, a connection, and sometimes a subscription. MathMentor is built for the opposite:

| | MathMentor |
|---|---|
| **Price** | Free |
| **Account** | None |
| **Ads / paywall** | None |
| **Internet** | Optional after download |
| **Progress** | Local only (on your PC) |
| **Path** | Structured lessons, not random videos |
| **Pace** | Learn any topic in any order |

Use it on a shared family PC, offline on a laptop, or anywhere you do not want another web account.

---

## Who it is for

- **Students** catching up on foundations, or preparing for algebra, precalc, or calculus  
- **Adults** relearning math for school, work, or confidence, without a classroom  
- **Parents** who want a calm, structured tool to put in front of a learner  
- Anyone who wants a clear path from "what is place value?" to "what is a derivative?" without a subscription  

It does **not** replace a great teacher. It **does** give a patient, always-available practice path.

---

## What you get

### Scale

- **About 82 focused lessons**
- **18 progressive categories** (arithmetic → calculus)
- **No forced gates**: open any lesson anytime for learning or review
- **Local progress**: best quiz scores, attempts, and a needs-review queue

### Categories

1. **Arithmetic Foundations**: place value, the four operations, order of operations  
2. **Number Foundations**: integers, absolute value, factors/GCF/LCM, rational vs irrational  
3. **Fractions, Decimals & Percentages**: operations, conversions, real-world percent  
4. **Pre-Algebra**: variables, equations, inequalities, ratios, exponents  
5. **Algebra I**: linear equations, slope, systems, polynomials, factoring, division, applications  
6. **Algebra II Essentials**: absolute value, radicals, complex numbers, rational equations, completing the square  
7. **Quadratics**: solving, discriminant, graphing/vertex form, applications  
8. **Geometry**: angles, triangles, Pythagorean theorem, polygons, circles, measurement  
9. **Coordinate & Similarity Geometry**: distance/midpoint, similarity and scale  
10. **Functions & Advanced Algebra**: definition, transformations, exponential growth/decay, logarithms  
11. **Precalculus Extensions**: composition, inverses, sequences, rational functions  
12. **Trigonometry**: unit circle, graphs, identities, equations, law of sines/cosines, applications  
13. **Advanced Trigonometry**: inverse trig, vectors  
14. **Statistics & Probability**: displays, center/spread, probability, conditional probability  
15. **Applied Math**: personal finance, unit conversion and rates  
16. **Calculus**: limits, derivatives, rules, applications, integrals, FTC, techniques  
17. **Calculus Extensions**: implicit differentiation, related rates, partial fractions, intro differential equations  
18. **Cumulative Reviews**: mixed practice across major bands  

### Inside a typical lesson

- Progressive **explanations** (why, not only how)  
- **Key formulas** with high-quality math typesetting  
- **Worked examples** with tutor-style steps  
- **Common mistakes** and **key takeaways**  
- **Practice** (multiple choice + numeric) with hints and full solutions  
- Retakes anytime; **best score** is kept  

Mastery stars: **70%** = 1★ · **85%** = 2★ · **95%** = 3★  

### App experience

- Dark theme (light theme option) and adjustable font size  
- Dashboard: continue learning, lessons started, mastery overview  
- Searchable curriculum browser  
- Needs-review queue for weaker or older topics  
- Export / import / reset progress in Settings  

---

## Privacy

- **No account system**  
- **No cloud upload** built into the app  
- Progress and settings live under your Windows AppData folder only  

---

## Share

If this might help a student, parent, or adult learner you know, feel free to send them this page:

> Free offline math tutor for Windows (basics through calculus). No account, no subscription.  
> https://github.com/jaydenshutt/MathMentor

---

## Optional gratitude

MathMentor is free. If it has been helpful, a small gift via PayPal is a thoughtful thank-you. It is never required. Details are on the in-app **About** page (including a QR code).

---

## Connect

**Jayden Shutt** · [linkedin.com/in/jaydenshutt](https://www.linkedin.com/in/jaydenshutt/)

Questions, bugs, or ideas: [open an issue](https://github.com/jaydenshutt/MathMentor/issues).

---

## For developers

Source code is in this repository. The ready-to-run Windows EXE is published on the [Releases](https://github.com/jaydenshutt/MathMentor/releases) page (not stored in git history).

```powershell
dotnet restore
dotnet build
dotnet run --project MathMentor
```

Publish a single-file EXE:

```powershell
powershell -ExecutionPolicy Bypass -File .\publish.ps1
```

---

## License / use

You may download and use MathMentor.exe freely for personal learning. Redistribution of the binary is fine when creator credit is preserved.
