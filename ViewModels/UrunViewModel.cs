using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MagazaWeb.ViewModels
{
  public class UrunViewModel
  {
    public int Id { get; set; }

    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "{0} giriniz")]
    [StringLength(20, ErrorMessage = "{0} {2}-{1} karakter olmalı", MinimumLength = 3)]
    public string UrunAdi { get; set; }

    [Display(Name = "Ürün Fiyatı")]
    [Required(ErrorMessage = "{0} giriniz")]
    public decimal? Fiyat { get; set; }

    [Display(Name = "Açıklama")]
    public string? Aciklama { get; set; }

    [Display(Name = "Stok Adedi")]
    [Required(ErrorMessage = "{0} giriniz")]
    [Range(0, 100, ErrorMessage = "{0} {1}-{2} arası olmalı")]
    public int? Stok { get; set; }

    public DateTime EklenmeTarihi { get; set; }
  }
}