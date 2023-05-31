using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;

namespace MagazaWeb.ViewModels
{
    public class UrunDetayViewModel
    {
        public Urun Urun { get; set; }
        public List<Degerlendirme> Degerlendirmeler { get; set; }
        public double OrtalamaPuan { get; set; }
    }
}