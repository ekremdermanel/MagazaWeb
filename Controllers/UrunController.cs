using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
  public class UrunController : Controller
  {

    public UrunController()
    {
    }

    public IActionResult Index()
    {
      List<string> urunler = new List<string> { "Iphone14", "Samsung A22", "Xiaomi Note 9", "Noika 3310", "Huawei P40", "Oppo A15" };
      return View(urunler);
    }

    public IActionResult Detay()
    {
      string urunAdi = "Iphone 14";
      return View((object)urunAdi);
    }
  }
}