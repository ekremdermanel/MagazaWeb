using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
  public class Kategori
  {
    public int Id { get; set; }
    public string KategoriAdi { get; set; }
    public string? Slogan { get; set; }

    public List<Urun> Urunler { get; set; }
  }
}