using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagazaWeb.ViewModels
{
    public class SiparisOnayViewModel
    {
        public Siparis Siparis { get; set; }
        public List<SelectListItem> Iller { get; set; }
        public List<SelectListItem> Ilceler { get; set; }
    }
}