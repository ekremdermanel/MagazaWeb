using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
  public class KayitViewModel
  {
    [Required]
    [Display(Prompt = "Ad Soyad")]
    public string AdSoyad { get; set; }

    [Required]
    [Display(Prompt = "Kullanıcı Adı")]
    public string KullaniciAdi { get; set; }

    [Required]
    [Display(Prompt = "Şifre")]
    [DataType(DataType.Password)]
    public string Sifre { get; set; }

    [Required]
    [Display(Prompt = "Şifre Tekrar")]
    [DataType(DataType.Password)]
    [Compare("Sifre")]
    public string SifreTekrar { get; set; }

    [Required]
    [Display(Prompt = "Eposta")]
    public string Eposta { get; set; }
  }
}