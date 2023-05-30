using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
    public class SifreDegistirViewModel
    {
        [Required]
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string EskiSifre { get; set; }
        [Required]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string YeniSifre { get; set; }
        [Required]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("YeniSifre")]
        public string YeniSifreTekrar { get; set; }
    }
}