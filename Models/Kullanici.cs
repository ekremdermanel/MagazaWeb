using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MagazaWeb.Models
{
  public class Kullanici : IdentityUser
  {
    public string AdSoyad { get; set; }
  }
}