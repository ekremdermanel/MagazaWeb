using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      return View(context.Urunler.Include("Kategori").ToList());
    }

    [HttpGet]
    public IActionResult UrunEkle()
    {
      UrunViewModel viewModel = new UrunViewModel
      {
        Kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi")
      };
      return View(viewModel);
    }

    [HttpPost]
    public IActionResult UrunEkle(UrunViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        viewModel.Kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
        return View(viewModel);
      }

      Urun model = new Urun
      {
        UrunAdi = viewModel.UrunAdi,
        Fiyat = viewModel.Fiyat,
        Stok = viewModel.Stok,
        Aciklama = viewModel.Aciklama,
        EklenmeTarihi = DateTime.Now,
        KategoriId = viewModel.KategoriId
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
        Aciklama = kayit.Aciklama,
        KategoriId = kayit.KategoriId,
        Kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi")
      };
      return View(viewModel);
    }

    [HttpPost]
    public IActionResult UrunGuncelle(UrunViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        viewModel.Kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
        return View(viewModel);
      }

      Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == viewModel.Id);
      kayit.UrunAdi = viewModel.UrunAdi;
      kayit.Fiyat = viewModel.Fiyat;
      kayit.Stok = viewModel.Stok;
      kayit.Aciklama = viewModel.Aciklama;
      kayit.KategoriId = viewModel.KategoriId;

      context.Urunler.Update(kayit);
      context.SaveChanges();
      return RedirectToAction("Urun");
    }

    public IActionResult Kategori()
    {
      return View(context.Kategoriler.ToList());
    }

    [HttpGet]
    public IActionResult KategoriEkle()
    {
      return View();
    }

    [HttpPost]
    public IActionResult KategoriEkle(KategoriViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        return View(viewModel);
      }

      Kategori model = new Kategori
      {
        KategoriAdi = viewModel.KategoriAdi,
        Slogan = viewModel.Slogan
      };

      context.Kategoriler.Add(model);
      context.SaveChanges();
      return RedirectToAction("Kategori");
    }

    public IActionResult KategoriSil(int id)
    {
      Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == id);
      context.Kategoriler.Remove(kayit);
      context.SaveChanges();
      return RedirectToAction("Kategori");
    }

    [HttpGet]
    public IActionResult KategoriGuncelle(int id)
    {
      Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == id);
      KategoriViewModel viewModel = new KategoriViewModel
      {
        Id = kayit.Id,
        KategoriAdi = kayit.KategoriAdi,
        Slogan = kayit.Slogan
      };
      return View(viewModel);
    }

    [HttpPost]
    public IActionResult KategoriGuncelle(KategoriViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        return View(viewModel);
      }

      Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == viewModel.Id);
      kayit.KategoriAdi = viewModel.KategoriAdi;
      kayit.Slogan = viewModel.Slogan;

      context.Kategoriler.Update(kayit);
      context.SaveChanges();
      return RedirectToAction("Kategori");
    }

  }
}