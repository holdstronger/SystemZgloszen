using System.ComponentModel.DataAnnotations;

public class Uzytkownik
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Imie { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Haslo { get; set; }

    public string Rola { get; set; } = "Zglaszajacy";
    public List<Komentarz> Komentarze { get; set; } = new List<Komentarz>();
}