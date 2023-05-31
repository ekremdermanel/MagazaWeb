using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MagazaWeb.ViewModels;

namespace MagazaWeb.Controllers
{
    public class UrunController : Controller
    {
        private readonly MagazaContext context;

        public UrunController(MagazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.ListeBasligi = "Tüm Ürünler";
                return View(context.Urunler.Include("Kategori").ToList());
            }
            else
            {
                Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == id);
                ViewBag.ListeBasligi = kayit.KategoriAdi + " - " + kayit.Slogan;
                return View(context.Urunler.Include("Kategori").Where(x => x.KategoriId == id).ToList());
            }
        }

        public IActionResult Detay(int id)
        {
            Urun urun = context.Urunler.FirstOrDefault(x => x.Id == id);
            List<Degerlendirme> degerlendirmeler = context.Degerlendirmeler.Where(x => x.UrunId == id && x.Onay == true).Include("Kullanici").OrderByDescending(x => x.EklenmeTarihi).ToList();

            double ortalamaPuan = 0;
            if (degerlendirmeler.Count > 0)
            {
                ortalamaPuan = degerlendirmeler.Select(x => x.Puan).Average();
            }

            UrunDetayViewModel viewModel = new UrunDetayViewModel()
            {
                Urun = urun,
                Degerlendirmeler = degerlendirmeler,
                OrtalamaPuan = ortalamaPuan
            };
            return View(viewModel);
        }

        public IActionResult Ekle()
        {
            Urun urun = new Urun();
            urun.UrunAdi = "Tester Ürün";
            urun.Fiyat = 50;
            urun.Aciklama = "Bu ürün test amaçlıdır.";

            context.Urunler.Add(urun);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DegerlendirmeYap(int UrunId, string Yorum, int Puan)
        {
            if (Yorum == null)
            {
                TempData["Mesaj"] = "Yorum alanı gerekli";
                TempData["Stil"] = "danger";
                return RedirectToAction("Detay", new { id = UrunId });
            }
            if (String.IsNullOrEmpty(Yorum.Trim()))
            {
                TempData["Mesaj"] = "Yorum alanı gerekli";
                TempData["Stil"] = "danger";
                return RedirectToAction("Detay", new { id = UrunId });
            }

            Degerlendirme model = new Degerlendirme()
            {
                KullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                UrunId = UrunId,
                Yorum = Yorum,
                Puan = Puan,
                EklenmeTarihi = DateTime.Now,
                Onay = false
            };

            if (User.IsInRole("Admin"))
            {
                model.Onay = true;
            }

            context.Degerlendirmeler.Add(model);
            context.SaveChanges();
            TempData["Mesaj"] = "Değerlendirmeniz için teşekkürler!";
            TempData["Stil"] = "success";
            return RedirectToAction("Detay", new { id = UrunId });
        }

    }
}