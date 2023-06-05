using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagazaWeb.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        private readonly MagazaContext context;
        private readonly UserManager<Kullanici> userManager;

        public SepetController(MagazaContext context, UserManager<Kullanici> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        List<SepetUrunu> GetSepet()
        {
            List<SepetUrunu> sepet;
            string strSepet = HttpContext.Session.GetString("Sepet");

            if (strSepet != null)
            {
                sepet = JsonConvert.DeserializeObject<List<SepetUrunu>>(strSepet);
            }
            else
            {
                sepet = new List<SepetUrunu>();
            }
            return sepet;
        }

        void SetSepet(List<SepetUrunu> sepet)
        {
            string strSepet = JsonConvert.SerializeObject(sepet);
            HttpContext.Session.SetString("Sepet", strSepet);
        }

        public IActionResult Index()
        {
            List<SepetUrunu> sepet = GetSepet();
            return View(sepet);
        }

        public IActionResult SepeteEkle(int id)
        {
            List<SepetUrunu> sepet = GetSepet();

            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.UrunId == id);
            if (sepetUrunu != null)
            {
                sepetUrunu.Adet++;
            }
            else
            {
                Urun urun = context.Urunler.FirstOrDefault(x => x.Id == id);
                sepetUrunu = new SepetUrunu
                {
                    UrunId = urun.Id,
                    UrunAdi = urun.UrunAdi,
                    ResimAdi = urun.ResimAdi,
                    Fiyat = urun.Fiyat,
                    Adet = 1
                };
                sepet.Add(sepetUrunu);
            }

            SetSepet(sepet);

            return RedirectToAction("Index");
        }

        public IActionResult SepettenSil(int id)
        {
            List<SepetUrunu> sepet = GetSepet();
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.UrunId == id);
            if (sepetUrunu == null)
            {
                return RedirectToAction("Index");
            }
            sepet.Remove(sepetUrunu);
            SetSepet(sepet);
            return RedirectToAction("Index");
        }

        public IActionResult SepetiBosalt()
        {
            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("Index");
        }

        public IActionResult Arttir(int id)
        {
            List<SepetUrunu> sepet = GetSepet();
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.UrunId == id);
            if (sepetUrunu == null)
            {
                return RedirectToAction("Index");
            }
            sepetUrunu.Adet++;
            SetSepet(sepet);
            return RedirectToAction("Index");
        }

        public IActionResult Azalt(int id)
        {
            List<SepetUrunu> sepet = GetSepet();
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.UrunId == id);
            if (sepetUrunu == null)
            {
                return RedirectToAction("Index");
            }
            sepetUrunu.Adet--;
            if (sepetUrunu.Adet == 0)
            {
                return RedirectToAction("SepettenSil", new { id });
            }
            SetSepet(sepet);
            return RedirectToAction("Index");
        }

        public IActionResult SiparisOnay()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userManager.FindByIdAsync(userId).Result;

            List<SiparisUrunu> siparisUrunleri = new List<SiparisUrunu>();
            siparisUrunleri.AddRange(GetSepet().ConvertAll(x => new SiparisUrunu()
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Fiyat = x.Fiyat,
                Adet = x.Adet,
                Toplam = x.Toplam
            }));

            Siparis model = new Siparis()
            {
                SiparisUrunleri = siparisUrunleri,
                KullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                AdSoyad = user.AdSoyad,
                OdemeTutari = siparisUrunleri.Sum(x => x.Toplam)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SiparisOnay(Siparis model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userManager.FindByIdAsync(userId).Result;

            List<SiparisUrunu> siparisUrunleri = new List<SiparisUrunu>();
            siparisUrunleri.AddRange(GetSepet().ConvertAll(x => new SiparisUrunu()
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Fiyat = x.Fiyat,
                Adet = x.Adet,
                Toplam = x.Toplam
            }));

            Siparis kayit = new Siparis()
            {
                SiparisUrunleri = siparisUrunleri,
                KullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                AdSoyad = model.AdSoyad,
                Telefon = model.Telefon,
                Adres = model.Adres,
                Il = model.Il,
                Ilce = model.Ilce,
                OdemeTutari = siparisUrunleri.Sum(x => x.Toplam),
                Tarih = DateTime.Now,
                Durum = Siparis.SiparisDurumu.Beklemede
            };

            context.Siparisler.Add(kayit);
            context.SaveChanges();

            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("Index", "Siparis");
        }
    }
}