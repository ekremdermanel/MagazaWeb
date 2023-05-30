using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    [Display(Prompt = "Kullanıcı Adı")]
    public string KullaniciAdi { get; set; }

    [Required]
    [Display(Prompt = "Şifre")]
    [DataType(DataType.Password)]
    public string Sifre { get; set; }

    public string? ReturnUrl { get; set; }
  }
}