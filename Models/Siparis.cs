using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public decimal? OdemeTutari { get; set; }
        public DateTime Tarih { get; set; }
        public SiparisDurumu Durum { get; set; }
        public string KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public List<SiparisUrunu> SiparisUrunleri { get; set; }

        public enum SiparisDurumu
        {
            Beklemede,
            Hazırlanıyor,
            Gönderildi,
            Tamamlandı
        }
    }
}