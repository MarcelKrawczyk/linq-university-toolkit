# linq-university-toolkit

A .NET 9 console lab for practising LINQ (method syntax) on a small in-memory "university" dataset. It contains 16 exercises and 4 challenges. Every exercise is a method that returns `IEnumerable<string>`, and each one has its task description and the equivalent SQL in a comment above it, so the LINQ query can be compared with the SQL it replaces.

Identifiers are in Polish (`Student`, `Przedmiot` = course, `Prowadzacy` = instructor, `Zapis` = enrollment); the seed values are ASCII.

---

## Dataset

| Entity | Key fields | Rows |
|---|---|---|
| `Student` | `Id`, `NumerIndeksu`, `Miasto`, `Email`, `DataUrodzenia` | 8 |
| `Prowadzacy` | `Id`, `Katedra`, `DataZatrudnienia` | 4 |
| `Przedmiot` | `Id`, `Kategoria`, `Ects`, `ProwadzacyId`, `DataStartu`, `DataZakonczenia` | 6 |
| `Zapis` | `StudentId`, `PrzedmiotId`, `DataZapisu`, `OcenaKoncowa` (`double?`), `CzyAktywny` | 16 |

Relations: an instructor teaches many courses, a student has many enrollments, a course has many enrollments. A grade of `null` means "not graded yet". The data is fixed and lives in `Data/DaneUczelni.cs`; there is no database and no randomness, so every run produces the same output.

## Exercises

| Menu | Topic | LINQ operators |
|---|---|---|
| 1-4 | filtering, projection, sorting, first match | `Where`, `Select`, `OrderBy`/`ThenBy`, `FirstOrDefault` |
| 5-7 | quantifiers and counting | `Any`, `Count` |
| 8-10 | distinct values, top N, pagination | `Distinct`, `Take`, `Skip` + `Take` |
| 11-12 | inner joins | `Join` |
| 13-16 | grouping and aggregates, left join | `GroupBy`, `Average`, `Max`, `GroupJoin` |
| 17-20 | challenges: `HAVING`, filtered groups, chained left joins, ordered aggregates | `GroupBy` + `Where`, `GroupJoin` + `SelectMany` + `DefaultIfEmpty` |

Menu entry 0 prints a summary of the dataset.

## Running

```bash
dotnet run     # .NET 9 SDK required
```

Type the number of an exercise to run it, or `X` to exit.

```
Program.cs                    menu loop
Data/DaneUczelni.cs           seed data (static lists)
Exercises/ZadaniaLinq.cs      the 20 exercises
Models/                       entities
```

---

## Engineering notes

The values and outputs quoted below come from running the exercises on the seed data.

### 1. Aggregation semantics
- **Simple mean, not weighted.** `Ects` exists on every course but no aggregate uses it. A grade average across courses is normally weighted by credits.
- **Pooled mean vs mean of means.** The instructor average (challenge 19) pools all grades of all the instructor's courses. That differs from averaging the per-course averages. For one instructor in the data the pooled value is 3.8333... and the mean of the two course means is 3.75, because the courses have a different number of grades.
- **Inactive enrollments are included** in every average. Excluding them would change "Podstawy LINQ" from 4.0 to 4.5. The task text does not say which is intended, so it is an assumption that should be explicit.
- **Empty aggregates.** `Average` and `Max` over `double?` return `null` for an empty or all-null group, while over a non-nullable `double` they throw `InvalidOperationException`. The exercises are safe because the groups are non-empty by construction (a `Where` on `null` grades comes first), but it is the first thing to check when the shape of the data changes.
- **Floating point.** Grades are `double` and averages are printed unrounded, so output such as `3.8333333333333335` appears. `decimal` with an explicit rounding rule is the safer type for values that are compared or reported.

### 2. Joins and missing data
- The exercises use inner joins where the SQL says `JOIN`, so rows without a match disappear. That is correct for most of them, but it changes the meaning of "none" questions.
- Challenge 18 ("courses starting in April with no final grades") returns an **empty result** on the seed data: both April courses have at least one grade. The exercise therefore cannot show that it works. Its inner join also means a course with no enrollments at all would not be listed, although "no enrollment has a grade" is vacuously true for it.
- Challenge 19 says to keep instructors in the result even when they have no grades, but the query (and the SQL in the comment above it) filters `OcenaKoncowa != null` after the left joins. A filter on the right-hand side of a left join turns it back into an inner join. It works here only because every instructor has at least one grade.

### 3. Keys and identity
- Several groupings use a display value instead of the key: students are grouped by `{Imie, Nazwisko}` (exercises 16 and 17), instructors by `{Imie, Nazwisko}` (challenge 19), and courses by `Nazwa` (exercises 13 and 14). Two people with the same name, or two courses with the same title, would silently merge. Grouping by `Id` (and projecting the name afterwards) is the robust form.

### 4. Ordering and determinism
- `OrderBy` is a stable sort, so ties keep their input order. That makes the output deterministic, but arbitrary: challenge 20 lists Krakow, Poznan and Lublin (all 2 active enrollments) in insertion order. A `ThenBy` on the key makes the tie-break explicit.
- Pagination (`Skip` + `Take`, exercise 10) is only well defined over a total order; here it is, because the sort key is unique.
- String ordering with `OrderBy` uses the default comparer, which is **culture-sensitive**. `Distinct` is ordinal and case-sensitive, while exercise 1 compares with `OrdinalIgnoreCase`, so "Warsaw" and "warsaw" would be equal in one exercise and distinct in another. `StringComparer.Ordinal` (or an explicit culture) makes the choice visible.

### 5. Culture-dependent output
- Dates and numbers are interpolated with the current culture. The same exercise prints `04/01/2026 00:00:00` and `4.375` under the invariant culture, and `1.04.2026 00:00:00` and `4,375` under `pl-PL`. The dataset summary (menu 0) already uses `yyyy-MM-dd`; the exercises do not.

### 6. Deferred execution and cost
- The exercises return lazy queries. Nothing runs until `WyswietlWynik` calls `ToList()`, and that call is inside the `try` block in `Program.cs`, so exceptions raised during enumeration are caught.
- `Join`, `GroupJoin` and `GroupBy` in LINQ to Objects build hash lookups, so they are O(n + m), and `Any`, `First` and `Take` short-circuit. At this data size the cost is irrelevant; it matters when the same expressions are moved to a large collection or to EF Core, where they turn into SQL.
- Challenge 19 chains two `GroupJoin` + `SelectMany(DefaultIfEmpty)` steps. The same result can be computed per instructor in one pass over that instructor's enrollments, which is shorter and does not need the left joins at all.

### 7. Input handling
- If standard input ends (Ctrl+D on Unix, Ctrl+Z on Windows, or redirected input that runs out), `Console.ReadLine()` returns `null`. The menu treats it as an unknown option and loops forever. Running with input redirected from `/dev/null` printed over a million lines in 3 seconds.
- The `NotImplementedException` handler and the `Niezaimplementowano` helper are leftovers from the exercise template and are no longer used. The "first Analytics course" exercise returns the Polish word for "error" when nothing matches.

### 8. Testability
- There are no tests. The data is deterministic, which makes golden-output tests straightforward. `DaneUczelni` exposes static, mutable lists, so a test that changes them would leak into the next one unless the data is reset or passed in.
