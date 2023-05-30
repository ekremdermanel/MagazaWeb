using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MagazaWeb.ViewModels
{
    public class KullaniciRolleriViewModel
    {
        public string KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public List<IdentityRole> Roller { get; set; }
        public List<string> KullaniciRolleri { get; set; }
        public List<string> SecilenRoller { get; set; }
    }
}