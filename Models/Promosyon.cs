using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Promosyon
    {
        public int Id { get; set; }
        public string PromosyonKodu { get; set; }
        public string Aciklama { get; set; }
        public int IndirimOrani { get; set; }
        public decimal MaksimumIndirim { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
    }
}