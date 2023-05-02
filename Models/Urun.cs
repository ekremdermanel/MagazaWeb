using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagazaWeb.Models
{
  [Table("tblUrunler")]
  public class Urun
  {
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public decimal Fiyat { get; set; }
    [Column("Bilgi")]
    public string? Aciklama { get; set; }

    public int Stok { get; set; }

    public DateTime EklenmeTarihi { get; set; }

  }
}