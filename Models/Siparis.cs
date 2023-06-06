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
        public decimal? OdemeTutariIndirimsiz { get; set; }
        public decimal? OdemeTutari { get; set; }
        public DateTime Tarih { get; set; }
        public SiparisDurumu Durum { get; set; }
        public string KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public string? PromosyonKodu { get; set; }
        public string? PromosyonAciklama { get; set; }
        public string? PromosyonDetay { get; set; }
        public decimal? UygulananIndirim { get; set; }

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