using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.ViewModels
{
    public class UrunStokGrafikViewModel
    {
        public string UrunAdi { get; set; }
        public int? Stok { get; set; }
    }

    public class SiparisTutarGrafikViewModel
    {
        public DateTime SiparisTarihi { get; set; }
        public decimal? Tutar { get; set; }
    }

    public class SiparisUrunGrafikViewModel
    {
        public string UrunAdi { get; set; }
        public int SatisMiktari { get; set; }
    }
}