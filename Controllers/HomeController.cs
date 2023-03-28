using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
  public class HomeController : Controller
  {
    public HomeController()
    {
    }

    public IActionResult Index()
    {
      ViewBag.Yazi = "Merhaba, Sitemize Hoşgeldiniz!";
      ViewData["Baslik"] = "Ana Sayfa";

      List<Urun> urunler = new List<Urun> {
        new Urun { Id = 1, UrunAdi = "Iphone 14", Fiyat = 40000, Aciklama = "Çok pahalı almayın" },
        new Urun { Id = 2, UrunAdi = "Samsung A22", Fiyat = 30000, Aciklama = "Güzel ürün" },
        new Urun { Id = 3, UrunAdi = "Xiaomi Note 9", Fiyat = 15000, Aciklama = "Çin malı  Lorem ipsum dolor, sit amet consectetur adipisicing elit. Magni, eligendi. Sit, quas! Tempora in odit perferendis! Fuga iusto similique nobis quidem vitae, architecto veritatis excepturi minus error molestiae, quae neque placeat voluptas nostrum blanditiis officia alias accusamus iste quaerat tenetur eaque. Omnis earum facilis, corrupti quam, accusamus voluptas odit explicabo dicta incidunt voluptatibus minima illum! Obcaecati rerum natus, cumque nisi deserunt nesciunt voluptatibus ab? Dolorum iure, veniam, assumenda nemo eaque nulla voluptas quam, accusamus culpa rerum adipisci? Officia blanditiis dignissimos libero pariatur modi sed. Impedit odit itaque optio perspiciatis animi qui reiciendis, ipsa repellendus provident, mollitia rem esse! Itaque, distinctio!" }
        };

      return View(urunler);
    }

    public IActionResult Hakkimizda()
    {
      ViewData["Baslik"] = "Hakkımızda";
      return View();
    }

    public IActionResult Profil()
    {
      TempData["Hata"] = "Profil Sayfası İçin Yetkiniz Yok";
      return RedirectToAction("Index");
    }





  }
}