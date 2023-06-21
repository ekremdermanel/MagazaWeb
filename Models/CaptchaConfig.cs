using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class CaptchaConfig
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
    }
}