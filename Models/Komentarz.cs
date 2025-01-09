using System.ComponentModel.DataAnnotations;

public class Komentarz
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Tresc { get; set; }

    public DateTime DataDodania { get; set; } = DateTime.Now;

    public int ZgloszenieId { get; set; }
    public Zgloszenie Zgloszenie { get; set; }

    public int UzytkownikId { get; set; }
    public Uzytkownik Uzytkownik { get; set; }
}