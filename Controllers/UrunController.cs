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
using Microsoft.AspNetCore.Identity;

namespace MagazaWeb.Controllers
{
    public class UrunController : Controller
    {
        private readonly MagazaContext context;
        private readonly UserManager<Kullanici> userManager;

        public UrunController(MagazaContext context, UserManager<Kullanici> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.ListeBasligi = "Tüm Ürünler";
                if (User.Identity.IsAuthenticated)
                {
                    return View(context.Urunler.Include("Kategori").Include(y => y.Favoriler).ToList());
                }
                else
                {
                    return View(context.Urunler.Include("Kategori").ToList());
                }

            }
            else
            {
                Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == id);
                ViewBag.ListeBasligi = kayit.KategoriAdi + " - " + kayit.Slogan;
                if (User.Identity.IsAuthenticated)
                {
                    return View(context.Urunler.Include("Kategori").Where(x => x.KategoriId == id).Include(y => y.Favoriler).ToList());
                }
                else
                {
                    return View(context.Urunler.Include("Kategori").Where(x => x.KategoriId == id).ToList());
                }
            }
        }

        public IActionResult Detay(int id)
        {
            Urun urun;
            if (User.Identity.IsAuthenticated)
            {
                urun = context.Urunler.Include(y => y.Favoriler).FirstOrDefault(x => x.Id == id);
            }
            else
            {
                urun = context.Urunler.FirstOrDefault(x => x.Id == id);
            }
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

        public bool FavoriEkleCikar(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Favori kayit = context.Favoriler.FirstOrDefault(x => x.UrunId == id && x.KullaniciId == userId);
            if (kayit == null)
            {
                Favori model = new Favori
                {
                    UrunId = id,
                    KullaniciId = userId
                };
                context.Favoriler.Add(model);
                context.SaveChanges();
                return true;
            }
            else
            {
                context.Favoriler.Remove(kayit);
                context.SaveChanges();
                return false;
            }
        }

        [Authorize]
        public IActionResult Favori()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(context.Favoriler.Include(x => x.Urun).Include(y => y.Urun.Kategori).Where(x => x.KullaniciId == userId).ToList());
        }

    }
}