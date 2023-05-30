using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;

namespace MagazaWeb.ViewModels
{
  public class AramaViewModel
  {
    public List<Urun> Urunler { get; set; }
    public List<Kategori> Kategoriler { get; set; }
  }
}