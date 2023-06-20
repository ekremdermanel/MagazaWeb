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
            string[] yazilar = {
                "Merhaba, Sitemize Hoşgeldiniz!",
                "Alışverişin Yeni Adresi",
                "Her Türlü İhtiyacınız İçin Doğru Adres",
                "Uygun Fiyat Garantisi",
                "Güvenli Alışveriş",
                "Hızlı Güvenilir Teslimat"
            };
            Random random = new Random();
            int sayi = random.Next(yazilar.Length);
            ViewBag.Yazi = yazilar[sayi];
            ViewData["Baslik"] = "Ana Sayfa";
            int toplam = context.Urunler.Count();
            return View(toplam);
        }

        public IActionResult Vitrin(int gosterilen)
        {
            var liste = context.Urunler.OrderByDescending(x => x.Id).Skip(gosterilen).Take(3).ToList();
            return PartialView("_Vitrin", liste);
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

        public void SetGorunumModu(bool check)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMonths(3);
            string mod = check ? "gece" : "gündüz";
            Response.Cookies.Append("gorunum", mod, cookie);
        }

        public string GetGorunumModu()
        {
            return Request.Cookies["gorunum"];
        }

    }
}