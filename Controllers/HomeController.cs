using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;

namespace MagazaWeb.Controllers
{
  public class HomeController : Controller
  {
    private readonly MagazaContext context;
    public HomeController(MagazaContext context)
    {
      this.context = context;
    }

    public IActionResult Index()
    {
      ViewBag.Yazi = "Merhaba, Sitemize Hoşgeldiniz!";
      ViewData["Baslik"] = "Ana Sayfa";
      return View(context.Urunler.OrderByDescending(x => x.Id).Take(3).ToList());
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

    public IActionResult Arama(string p)
    {
      ViewBag.ListeBasligi = p + " ile ilgili arama sonuçları";
      AramaViewModel viewModel = new AramaViewModel();
      viewModel.Urunler = context.Urunler.Where(x => x.UrunAdi.Contains(p)).ToList();
      viewModel.Kategoriler = context.Kategoriler.Where(x => x.KategoriAdi.Contains(p)).ToList();
      return View(viewModel);
    }


  }
}