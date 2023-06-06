using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;
using MagazaWeb.Functions;

namespace MagazaWeb.ViewModels
{
    public class PromosyonKoduKullanViewModel
    {
        public bool KodGecerli { get; set; }
        public string PromosyonKodu { get; set; }
        public string Aciklama { get; set; }
        public string UygulananIndirim { get; set; }
        public string OdenecekTutarIndirimsiz { get; set; }
        public string OdenecekTutar { get; set; }
        public string OdenecekTutarDolar { get; set; }
        public string DolarKuru { get; set; }
    }
}