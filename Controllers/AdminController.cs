using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;

namespace MagazaWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly MagazaContext context;
        public AdminController(MagazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urun()
        {
            return View(context.Urunler.ToList());
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(UrunViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Urun model = new Urun
            {
                UrunAdi = viewModel.UrunAdi,
                Fiyat = viewModel.Fiyat,
                Stok = viewModel.Stok,
                Aciklama = viewModel.Aciklama,
                EklenmeTarihi = DateTime.Now
            };

            context.Urunler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            context.Urunler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        [HttpGet]
        public IActionResult UrunGuncelle(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            UrunViewModel viewModel = new UrunViewModel
            {
                Id = kayit.Id,
                UrunAdi = kayit.UrunAdi,
                Fiyat = kayit.Fiyat,
                Stok = kayit.Stok,
                Aciklama = kayit.Aciklama
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(UrunViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == viewModel.Id);
            kayit.UrunAdi = viewModel.UrunAdi;
            kayit.Fiyat = viewModel.Fiyat;
            kayit.Stok = viewModel.Stok;
            kayit.Aciklama = viewModel.Aciklama;

            context.Urunler.Update(kayit);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

    }
}