using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Favori
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public string KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}