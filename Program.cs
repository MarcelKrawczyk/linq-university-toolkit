using System.Text;
using LinqConsoleLab.PL.Data;
using LinqConsoleLab.PL.Exercises;

Console.OutputEncoding = Encoding.UTF8;
DaneUczelni.Inicjalizuj();

var zadania = new ZadaniaLinq();
var opcje = new List<(string Klucz, string Opis, Func<IEnumerable<string>> Akcja)>
{
    ("0", "Pokaż podsumowanie danych wejściowych", DaneUczelni.PobierzPodsumowanie),
    ("1", "Studenci z Warszawy", zadania.Zadanie01_StudenciZWarszawy),
    ("2", "Adresy e-mail studentów", zadania.Zadanie02_AdresyEmailStudentow),
    ("3", "Studenci posortowani alfabetycznie", zadania.Zadanie03_StudenciPosortowani),
    ("4", "Pierwszy przedmiot z kategorii Analytics", zadania.Zadanie04_PierwszyPrzedmiotAnalityczny),
    ("5", "Czy istnieje nieaktywne zapisanie", zadania.Zadanie05_CzyIstniejeNieaktywneZapisanie),
    ("6", "Czy wszyscy prowadzący mają przypisaną katedrę", zadania.Zadanie06_CzyWszyscyProwadzacyMajaKatedre),
    ("7", "Liczba aktywnych zapisów", zadania.Zadanie07_LiczbaAktywnychZapisow),
    ("8", "Unikalne miasta studentów", zadania.Zadanie08_UnikalneMiastaStudentow),
    ("9", "Trzy najnowsze zapisy", zadania.Zadanie09_TrzyNajnowszeZapisy),
    ("10", "Druga strona listy przedmiotów", zadania.Zadanie10_DrugaStronaPrzedmiotow),
    ("11", "Połączenie studentów z zapisami", zadania.Zadanie11_PolaczStudentowIZapisy),
    ("12", "Pary student-przedmiot", zadania.Zadanie12_ParyStudentPrzedmiot),
    ("13", "Grupowanie zapisów według przedmiotu", zadania.Zadanie13_GrupowanieZapisowWedlugPrzedmiotu),
    ("14", "Średnia ocena na przedmiot", zadania.Zadanie14_SredniaOcenaNaPrzedmiot),
    ("15", "Prowadzący i liczba ich przedmiotów", zadania.Zadanie15_ProwadzacyILiczbaPrzedmiotow),
    ("16", "Najwyższa ocena każdego studenta", zadania.Zadanie16_NajwyzszaOcenaKazdegoStudenta),
    ("17", "Wyzwanie: studenci z więcej niż jednym aktywnym przedmiotem", zadania.Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem),
    ("18", "Wyzwanie: przedmioty startujące w kwietniu bez ocen końcowych", zadania.Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych),
    ("19", "Wyzwanie: prowadzący i średnia ocen na ich przedmiotach", zadania.Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach),
    ("20", "Wyzwanie: miasta i liczba aktywnych zapisów", zadania.Wyzwanie04_MiastaILiczbaAktywnychZapisow)
};

var mapaOpcji = opcje.ToDictionary(opcja => opcja.Klucz, StringComparer.OrdinalIgnoreCase);

while (true)
{
    Console.Clear();
    Console.WriteLine("LINQ Console Lab - wersja PL");
    Console.WriteLine("==============================================");
    Console.WriteLine("Wybierz numer zadania, aby uruchomić metodę.");
    Console.WriteLine("Jeżeli metoda nie została jeszcze uzupełniona, aplikacja wyświetli komunikat TODO.");
    Console.WriteLine();

    foreach (var opcja in opcje)
    {
        Console.WriteLine($"{opcja.Klucz,2}. {opcja.Opis}");
    }

    Console.WriteLine();
    Console.Write("Wpisz numer zadania lub X, aby zakończyć: ");
    var wybor = Console.ReadLine()?.Trim();

    if (string.Equals(wybor, "x", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (wybor is null || !mapaOpcji.TryGetValue(wybor, out var wybranaOpcja))
    {
        Console.WriteLine();
        Console.WriteLine("Nieznana opcja. Naciśnij Enter, aby wrócić do menu.");
        Console.ReadLine();
        continue;
    }

    Console.WriteLine();
    Console.WriteLine($"=== {wybranaOpcja.Opis} ===");
    Console.WriteLine();

    try
    {
        WyswietlWynik(wybranaOpcja.Akcja());
    }
    catch (NotImplementedException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił nieoczekiwany błąd:");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
    Console.WriteLine("Naciśnij Enter, aby wrócić do menu.");
    Console.ReadLine();
}

static void WyswietlWynik(IEnumerable<string> wynik)
{
    var wiersze = wynik.ToList();

    if (wiersze.Count == 0)
    {
        Console.WriteLine("Brak wyników do wyświetlenia.");
        return;
    }

    for (var i = 0; i < wiersze.Count; i++)
    {
        Console.WriteLine($"{i + 1,2}. {wiersze[i]}");
    }
}
