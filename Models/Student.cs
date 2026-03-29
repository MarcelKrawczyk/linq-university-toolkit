namespace LinqConsoleLab.PL.Models;

public sealed class Student
{
    public int Id { get; set; }

    public string NumerIndeksu { get; set; } = string.Empty;

    public string Imie { get; set; } = string.Empty;

    public string Nazwisko { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Miasto { get; set; } = string.Empty;

    public DateTime DataUrodzenia { get; set; }
}
