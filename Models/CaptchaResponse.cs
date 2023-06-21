using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagazaWeb.Models
{
    public class CaptchaResponse
    {
        public bool Success { get; set; }

        public double Score { get; set; }
    }
}