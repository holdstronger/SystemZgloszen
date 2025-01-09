using Microsoft.EntityFrameworkCore;

public class AplikacjaContext : DbContext
{
    public AplikacjaContext(DbContextOptions<AplikacjaContext> options) : base(options) { }

    public DbSet<Zgloszenie> Zgloszenia { get; set; }
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<Komentarz> Komentarze { get; set; }
}
