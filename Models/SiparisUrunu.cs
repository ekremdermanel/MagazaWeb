using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class SiparisUrunu
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal? Toplam { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
    }
}