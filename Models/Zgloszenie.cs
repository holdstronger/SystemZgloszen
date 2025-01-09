using System;
using System.ComponentModel.DataAnnotations;

public class Zgloszenie
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Tytul { get; set; }

    [Required]
    public string Opis { get; set; }

    [Required]
    public string Priorytet { get; set; }

    [Required]
    public string Status { get; set; } = "Nowe";

    public DateTime DataZgloszenia { get; set; } = DateTime.Now;
    public List<Komentarz> Komentarze { get; set; } = new List<Komentarz>();
}