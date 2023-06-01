using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class SepetUrunu
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string? ResimAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal? Toplam { get { return Fiyat * Adet; } }
    }
}