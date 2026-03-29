namespace LinqConsoleLab.PL.Models;

public sealed class Przedmiot
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = string.Empty;

    public string Kategoria { get; set; } = string.Empty;

    public int Ects { get; set; }

    public int ProwadzacyId { get; set; }

    public DateTime DataStartu { get; set; }

    public DateTime DataZakonczenia { get; set; }
}
