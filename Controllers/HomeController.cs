using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

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
      return View();
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