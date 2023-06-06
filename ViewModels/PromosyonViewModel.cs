using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
    public class PromosyonViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Promosyon Kodu")]
        [Required(ErrorMessage = "{0} giriniz")]
        public string PromosyonKodu { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "İndirim Oranı (%)")]
        [Range(0, 100, ErrorMessage = "{0} {1}-{2} arası olmalı")]
        public int IndirimOrani { get; set; }
        [Display(Name = "Maksimum İndirim (TL)")]
        public decimal MaksimumIndirim { get; set; }
        [Display(Name = "Geçerlilik Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime GecerlilikTarihi { get; set; }
    }
}