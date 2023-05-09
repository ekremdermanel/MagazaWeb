using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
  public class KategoriViewModel
  {
    public int Id { get; set; }

    [Display(Name = "Kategori Adı")]
    [Required(ErrorMessage = "{0} giriniz")]
    public string KategoriAdi { get; set; }
    [Display(Name = "Kategori Sloganı")]
    public string? Slogan { get; set; }
  }
}