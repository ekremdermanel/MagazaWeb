using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
    public class ProfilViewModel
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }
        [Required]
        public string Eposta { get; set; }
    }

}