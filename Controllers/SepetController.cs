using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MagazaWeb.Functions;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            SiparisOnayViewModel viewModel = new SiparisOnayViewModel()
            {
                Siparis = model,
                Iller = new SelectList(context.Iller, "IlAdi", "IlAdi").ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SiparisOnay(SiparisOnayViewModel viewModel)
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

            decimal? odemeTutariIndirimsiz = siparisUrunleri.Sum(x => x.Toplam);

            Siparis kayit = new Siparis()
            {
                SiparisUrunleri = siparisUrunleri,
                KullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                AdSoyad = viewModel.Siparis.AdSoyad,
                Telefon = viewModel.Siparis.Telefon,
                Adres = viewModel.Siparis.Adres,
                Il = viewModel.Siparis.Il,
                Ilce = viewModel.Siparis.Ilce,
                OdemeTutariIndirimsiz = odemeTutariIndirimsiz,
                OdemeTutari = odemeTutariIndirimsiz,
                Tarih = DateTime.Now,
                Durum = Siparis.SiparisDurumu.Beklemede
            };

            Promosyon promosyon = context.Promosyonlar.FirstOrDefault(x => x.PromosyonKodu == viewModel.Siparis.PromosyonKodu);
            if (promosyon != null)
            {
                decimal? indirim = odemeTutariIndirimsiz * promosyon.IndirimOrani / 100;
                if (indirim > promosyon.MaksimumIndirim)
                {
                    indirim = promosyon.MaksimumIndirim;
                }

                kayit.OdemeTutari = odemeTutariIndirimsiz - indirim;
                kayit.PromosyonKodu = viewModel.Siparis.PromosyonKodu;
                kayit.PromosyonAciklama = promosyon.Aciklama;
                kayit.PromosyonDetay = "%" + promosyon.IndirimOrani + " indirim, maksimum " + promosyon.MaksimumIndirim + " TL";
                kayit.UygulananIndirim = indirim.Value;
            }

            context.Siparisler.Add(kayit);
            context.SaveChanges();

            Eposta.SiparisEpostasiGonder(user.Email, kayit);

            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("Index", "Siparis");
        }

        [HttpPost]
        public JsonResult IlceleriGetir(string ilAdi)
        {
            List<Ilce> ilceler = context.Ilceler.Where(x => x.Il.IlAdi == ilAdi).ToList();
            return Json(ilceler);
        }

        [HttpPost]
        public JsonResult PromosyonKoduKullan(string kod)
        {
            List<SepetUrunu> sepet = GetSepet();
            decimal? odemeTutari = sepet.Sum(x => x.Toplam);
            decimal dolarKuru = Doviz.GetDolarKuru().Value;

            PromosyonKoduKullanViewModel viewModel = new PromosyonKoduKullanViewModel()
            {
                KodGecerli = false,
                PromosyonKodu = kod,
                UygulananIndirim = "0",
                OdenecekTutar = odemeTutari.ParaBirimi(),
                OdenecekTutarIndirimsiz = odemeTutari.ParaBirimi(),
                DolarKuru = ((decimal?)dolarKuru).ParaBirimi(),
                OdenecekTutarDolar = (odemeTutari / dolarKuru).ParaBirimi()
            };

            Promosyon kayit = context.Promosyonlar.FirstOrDefault(x => x.PromosyonKodu == kod);
            if (kayit == null)
            {
                viewModel.Aciklama = "Hatalı Kod";
            }
            else if (kayit.GecerlilikTarihi < DateTime.Today)
            {
                viewModel.Aciklama = "Süresi Dolmuş Kod";
            }
            else
            {
                decimal? indirim = odemeTutari * kayit.IndirimOrani / 100;
                if (indirim > kayit.MaksimumIndirim)
                {
                    indirim = kayit.MaksimumIndirim;
                }

                viewModel.KodGecerli = true;
                viewModel.UygulananIndirim = indirim.ParaBirimi();
                viewModel.OdenecekTutar = (odemeTutari - indirim).ParaBirimi();
                viewModel.OdenecekTutarIndirimsiz = odemeTutari.ParaBirimi();
                viewModel.OdenecekTutarDolar = (((odemeTutari - indirim)) / dolarKuru).ParaBirimi();
                viewModel.Aciklama = kayit.Aciklama;
            }
            return Json(viewModel);
        }

        public JsonResult PromosyonIptal()
        {
            List<SepetUrunu> sepet = GetSepet();
            decimal? odemeTutari = sepet.Sum(x => x.Toplam);
            decimal? dolarKuru = Doviz.GetDolarKuru();

            PromosyonKoduKullanViewModel viewModel = new PromosyonKoduKullanViewModel()
            {
                UygulananIndirim = "0",
                OdenecekTutar = odemeTutari.ParaBirimi(),
                OdenecekTutarIndirimsiz = odemeTutari.ParaBirimi(),
                DolarKuru = dolarKuru.ParaBirimi(),
                OdenecekTutarDolar = (odemeTutari / dolarKuru).ParaBirimi(),
            };
            return Json(viewModel);
        }

    }
}