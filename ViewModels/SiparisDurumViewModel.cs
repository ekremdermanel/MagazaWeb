using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagazaWeb.ViewModels
{
    public class SiparisDetayViewModel
    {
        public Siparis Siparis { get; set; }
        public List<SelectListItem> SiparisDurumlari { get; set; } = new List<SelectListItem>();
    }
}