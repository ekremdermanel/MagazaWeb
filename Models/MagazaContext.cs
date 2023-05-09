using Microsoft.EntityFrameworkCore;

namespace MagazaWeb.Models
{
  public class MagazaContext : DbContext
  {
    public MagazaContext() { }
    public MagazaContext(DbContextOptions<MagazaContext> options) : base(options) { }

    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
  }
}