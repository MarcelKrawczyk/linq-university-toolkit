using LinqConsoleLab.PL.Models;

namespace LinqConsoleLab.PL.Data;

public static class DaneUczelni
{
    private static bool _zainicjalizowano;

    public static List<Student> Studenci { get; } = [];

    public static List<Przedmiot> Przedmioty { get; } = [];

    public static List<Prowadzacy> Prowadzacy { get; } = [];

    public static List<Zapis> Zapisy { get; } = [];

    public static void Inicjalizuj()
    {
        if (_zainicjalizowano)
        {
            return;
        }

        Studenci.AddRange(
        [
            new Student { Id = 1, NumerIndeksu = "s30101", Imie = "Anna", Nazwisko = "Kowalska", Email = "anna.kowalska@uni.local", Miasto = "Warsaw", DataUrodzenia = new DateTime(2002, 5, 12) },
            new Student { Id = 2, NumerIndeksu = "s30102", Imie = "Marek", Nazwisko = "Nowak", Email = "marek.nowak@uni.local", Miasto = "Gdansk", DataUrodzenia = new DateTime(2001, 11, 3) },
            new Student { Id = 3, NumerIndeksu = "s30103", Imie = "Julia", Nazwisko = "Zielinska", Email = "julia.zielinska@uni.local", Miasto = "Krakow", DataUrodzenia = new DateTime(2003, 1, 8) },
            new Student { Id = 4, NumerIndeksu = "s30104", Imie = "Tomasz", Nazwisko = "Lis", Email = "tomasz.lis@uni.local", Miasto = "Warsaw", DataUrodzenia = new DateTime(2002, 9, 17) },
            new Student { Id = 5, NumerIndeksu = "s30105", Imie = "Olga", Nazwisko = "Maj", Email = "olga.maj@uni.local", Miasto = "Wroclaw", DataUrodzenia = new DateTime(2001, 7, 26) },
            new Student { Id = 6, NumerIndeksu = "s30106", Imie = "Pawel", Nazwisko = "Kurek", Email = "pawel.kurek@uni.local", Miasto = "Poznan", DataUrodzenia = new DateTime(2000, 12, 14) },
            new Student { Id = 7, NumerIndeksu = "s30107", Imie = "Lena", Nazwisko = "Adamska", Email = "lena.adamska@uni.local", Miasto = "Warsaw", DataUrodzenia = new DateTime(2002, 3, 30) },
            new Student { Id = 8, NumerIndeksu = "s30108", Imie = "Karol", Nazwisko = "Wysocki", Email = "karol.wysocki@uni.local", Miasto = "Lublin", DataUrodzenia = new DateTime(2001, 2, 20) }
        ]);

        Prowadzacy.AddRange(
        [
            new Prowadzacy { Id = 1, Imie = "Ewa", Nazwisko = "Morawska", Katedra = "Data Engineering", DataZatrudnienia = new DateTime(2018, 10, 1) },
            new Prowadzacy { Id = 2, Imie = "Piotr", Nazwisko = "Jaworski", Katedra = "Cloud Solutions", DataZatrudnienia = new DateTime(2020, 2, 15) },
            new Prowadzacy { Id = 3, Imie = "Marta", Nazwisko = "Lewandowska", Katedra = "Business Analytics", DataZatrudnienia = new DateTime(2017, 9, 1) },
            new Prowadzacy { Id = 4, Imie = "Adam", Nazwisko = "Sowa", Katedra = "Software Design", DataZatrudnienia = new DateTime(2019, 5, 10) }
        ]);

        Przedmioty.AddRange(
        [
            new Przedmiot { Id = 1, Nazwa = "Podstawy LINQ", Kategoria = ".NET", Ects = 4, ProwadzacyId = 1, DataStartu = new DateTime(2026, 3, 10), DataZakonczenia = new DateTime(2026, 6, 20) },
            new Przedmiot { Id = 2, Nazwa = "Projektowanie API", Kategoria = "Web", Ects = 5, ProwadzacyId = 4, DataStartu = new DateTime(2026, 3, 15), DataZakonczenia = new DateTime(2026, 6, 30) },
            new Przedmiot { Id = 3, Nazwa = "Analiza Danych w C#", Kategoria = "Analytics", Ects = 6, ProwadzacyId = 3, DataStartu = new DateTime(2026, 4, 1), DataZakonczenia = new DateTime(2026, 7, 10) },
            new Przedmiot { Id = 4, Nazwa = "Chmura dla Programistow", Kategoria = "Cloud", Ects = 5, ProwadzacyId = 2, DataStartu = new DateTime(2026, 4, 10), DataZakonczenia = new DateTime(2026, 7, 15) },
            new Przedmiot { Id = 5, Nazwa = "Bazy Danych Aplikacyjnych", Kategoria = "Databases", Ects = 6, ProwadzacyId = 1, DataStartu = new DateTime(2026, 5, 5), DataZakonczenia = new DateTime(2026, 7, 25) },
            new Przedmiot { Id = 6, Nazwa = "Testowanie Oprogramowania", Kategoria = "Quality", Ects = 4, ProwadzacyId = 4, DataStartu = new DateTime(2026, 3, 22), DataZakonczenia = new DateTime(2026, 6, 18) }
        ]);

        Zapisy.AddRange(
        [
            new Zapis { Id = 1, StudentId = 1, PrzedmiotId = 1, DataZapisu = new DateTime(2026, 2, 15), OcenaKoncowa = 4.5, CzyAktywny = true },
            new Zapis { Id = 2, StudentId = 1, PrzedmiotId = 3, DataZapisu = new DateTime(2026, 2, 18), OcenaKoncowa = null, CzyAktywny = true },
            new Zapis { Id = 3, StudentId = 2, PrzedmiotId = 1, DataZapisu = new DateTime(2026, 2, 20), OcenaKoncowa = 3.5, CzyAktywny = false },
            new Zapis { Id = 4, StudentId = 2, PrzedmiotId = 4, DataZapisu = new DateTime(2026, 2, 21), OcenaKoncowa = 4.0, CzyAktywny = true },
            new Zapis { Id = 5, StudentId = 3, PrzedmiotId = 2, DataZapisu = new DateTime(2026, 2, 22), OcenaKoncowa = 5.0, CzyAktywny = true },
            new Zapis { Id = 6, StudentId = 3, PrzedmiotId = 5, DataZapisu = new DateTime(2026, 2, 23), OcenaKoncowa = null, CzyAktywny = true },
            new Zapis { Id = 7, StudentId = 4, PrzedmiotId = 2, DataZapisu = new DateTime(2026, 2, 24), OcenaKoncowa = 3.0, CzyAktywny = false },
            new Zapis { Id = 8, StudentId = 4, PrzedmiotId = 6, DataZapisu = new DateTime(2026, 2, 26), OcenaKoncowa = null, CzyAktywny = true },
            new Zapis { Id = 9, StudentId = 5, PrzedmiotId = 3, DataZapisu = new DateTime(2026, 2, 27), OcenaKoncowa = 4.0, CzyAktywny = true },
            new Zapis { Id = 10, StudentId = 6, PrzedmiotId = 4, DataZapisu = new DateTime(2026, 2, 28), OcenaKoncowa = 4.5, CzyAktywny = true },
            new Zapis { Id = 11, StudentId = 7, PrzedmiotId = 1, DataZapisu = new DateTime(2026, 3, 1), OcenaKoncowa = null, CzyAktywny = true },
            new Zapis { Id = 12, StudentId = 7, PrzedmiotId = 5, DataZapisu = new DateTime(2026, 3, 2), OcenaKoncowa = 5.0, CzyAktywny = true },
            new Zapis { Id = 13, StudentId = 8, PrzedmiotId = 6, DataZapisu = new DateTime(2026, 3, 3), OcenaKoncowa = 3.5, CzyAktywny = true },
            new Zapis { Id = 14, StudentId = 8, PrzedmiotId = 2, DataZapisu = new DateTime(2026, 3, 5), OcenaKoncowa = null, CzyAktywny = true },
            new Zapis { Id = 15, StudentId = 5, PrzedmiotId = 5, DataZapisu = new DateTime(2026, 3, 6), OcenaKoncowa = 4.5, CzyAktywny = false },
            new Zapis { Id = 16, StudentId = 6, PrzedmiotId = 3, DataZapisu = new DateTime(2026, 3, 7), OcenaKoncowa = null, CzyAktywny = true }
        ]);

        _zainicjalizowano = true;
    }

    public static IEnumerable<string> PobierzPodsumowanie()
    {
        yield return $"Studenci: {Studenci.Count}";
        yield return $"Prowadzący: {Prowadzacy.Count}";
        yield return $"Przedmioty: {Przedmioty.Count}";
        yield return $"Zapisy: {Zapisy.Count}";
        yield return string.Empty;
        yield return "Przykładowi studenci:";

        foreach (var student in Studenci.Take(3))
        {
            yield return $"{student.NumerIndeksu} | {student.Imie} {student.Nazwisko} | {student.Miasto}";
        }

        yield return string.Empty;
        yield return "Przykładowe przedmioty:";

        foreach (var przedmiot in Przedmioty.Take(3))
        {
            yield return $"{przedmiot.Nazwa} | {przedmiot.Kategoria} | start: {przedmiot.DataStartu:yyyy-MM-dd}";
        }
    }
}
