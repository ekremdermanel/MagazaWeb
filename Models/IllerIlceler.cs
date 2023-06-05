using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Il
    {
        public int Id { get; set; }
        public string IlAdi { get; set; }
        public List<Ilce> Ilceler { get; set; }
    }

    public class Ilce
    {
        public int Id { get; set; }
        public string IlceAdi { get; set; }
        public int IlId { get; set; }
        public Il Il { get; set; }
    }
}