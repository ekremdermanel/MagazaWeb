using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;

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
        return View(context.Urunler.Include("Kategori").ToList());
      }
      else
      {
        return View(context.Urunler.Include("Kategori").Where(x => x.KategoriId == id).ToList());
      }
    }

    public IActionResult Detay(int id)
    {
      Urun urun = context.Urunler.FirstOrDefault(x => x.Id == id);
      return View(urun);
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
  }
}