using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagazaWeb.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        private readonly MagazaContext context;

        public SepetController(MagazaContext context)
        {
            this.context = context;
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

            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.Id == id);
            if (sepetUrunu != null)
            {
                sepetUrunu.Adet++;
            }
            else
            {
                Urun urun = context.Urunler.FirstOrDefault(x => x.Id == id);
                sepetUrunu = new SepetUrunu
                {
                    Id = urun.Id,
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
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.Id == id);
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
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.Id == id);
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
            SepetUrunu sepetUrunu = sepet.FirstOrDefault(x => x.Id == id);
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
    }
}