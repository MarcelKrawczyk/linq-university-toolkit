namespace LinqConsoleLab.PL.Models;

public sealed class Prowadzacy
{
    public int Id { get; set; }

    public string Imie { get; set; } = string.Empty;

    public string Nazwisko { get; set; } = string.Empty;

    public string Katedra { get; set; } = string.Empty;

    public DateTime DataZatrudnienia { get; set; }
}
