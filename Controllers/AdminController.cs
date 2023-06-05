using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;
using MagazaWeb.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MagazaWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly MagazaContext context;
        private readonly UserManager<Kullanici> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(MagazaContext context, UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
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

            string resimAdi = null;
            if (viewModel.Resim != null)
            {
                resimAdi = Resim.Ekle(viewModel.Resim);
            }

            Urun model = new Urun
            {
                UrunAdi = viewModel.UrunAdi,
                Fiyat = viewModel.Fiyat,
                Stok = viewModel.Stok,
                Aciklama = viewModel.Aciklama,
                EklenmeTarihi = DateTime.Now,
                ResimAdi = resimAdi,
                KategoriId = viewModel.KategoriId
            };

            context.Urunler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            Resim.Sil(kayit.ResimAdi);
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
                ResimAdi = kayit.ResimAdi,
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

            string resimAdi;
            if (viewModel.Resim != null)
            {
                Resim.Sil(viewModel.ResimAdi);
                resimAdi = Resim.Ekle(viewModel.Resim);
            }
            else
            {
                resimAdi = viewModel.ResimAdi;
            }

            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == viewModel.Id);
            kayit.UrunAdi = viewModel.UrunAdi;
            kayit.Fiyat = viewModel.Fiyat;
            kayit.Stok = viewModel.Stok;
            kayit.ResimAdi = resimAdi;
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
            List<string> resimAdlari = context.Urunler.Where(x => x.KategoriId == id).Select(x => x.ResimAdi).ToList();
            foreach (var item in resimAdlari)
            {
                Resim.Sil(item);
            }

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

        public IActionResult ResimSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            Resim.Sil(kayit.ResimAdi);
            kayit.ResimAdi = null;
            context.Urunler.Update(kayit);
            context.SaveChanges();
            return RedirectToAction("UrunGuncelle", new { id });
        }

        public IActionResult Kullanici()
        {
            return View(userManager.Users.ToList());
        }

        public async Task<IActionResult> KullaniciSil(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == id)
            {
                return RedirectToAction("Kullanici");
            }
            Kullanici kayit = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(kayit);
            return RedirectToAction("Kullanici");
        }

        [HttpGet]
        public async Task<IActionResult> KullaniciRolleri(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var roles = roleManager.Roles.ToList();
            var userRoles = (List<string>)await userManager.GetRolesAsync(user);

            var viewModel = new KullaniciRolleriViewModel
            {
                KullaniciId = id,
                KullaniciAdi = user.UserName,
                AdSoyad = user.AdSoyad,
                Roller = roles,
                KullaniciRolleri = userRoles
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciRolleri(KullaniciRolleriViewModel viewModel)
        {
            var user = await userManager.FindByIdAsync(viewModel.KullaniciId);
            var userRoles = await userManager.GetRolesAsync(user);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (viewModel.SecilenRoller == null)
            {
                viewModel.SecilenRoller = new List<string>();
            }

            if (viewModel.KullaniciId == userId && !viewModel.SecilenRoller.Contains("Admin"))
            {
                viewModel.SecilenRoller.Add("Admin");
            }

            var result = await userManager.AddToRolesAsync(user, viewModel.SecilenRoller.Except(userRoles));

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Roller kullanıcıya atanırken bir hata oluştu.");
                return View(viewModel);
            }


            result = await userManager.RemoveFromRolesAsync(user, userRoles.Except(viewModel.SecilenRoller));
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Roller kullanıcıdan kaldırılırken bir hata oluştu.");
                return View(viewModel);
            }

            return RedirectToAction("Kullanici");
        }

        public IActionResult Degerlendirme(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            ViewBag.UrunAdi = kayit.UrunAdi;
            return View(context.Degerlendirmeler.Where(x => x.UrunId == id).ToList());
        }

        public IActionResult DegerlendirmeOnay(int id)
        {
            Degerlendirme kayit = context.Degerlendirmeler.FirstOrDefault(x => x.Id == id);
            kayit.Onay = !kayit.Onay;
            context.Degerlendirmeler.Update(kayit);
            context.SaveChanges();
            return RedirectToAction("Degerlendirme", new { id = kayit.UrunId });
        }

        public IActionResult DegerlendirmeSil(int id)
        {
            Degerlendirme kayit = context.Degerlendirmeler.FirstOrDefault(x => x.Id == id);
            int urunId = kayit.UrunId;
            context.Degerlendirmeler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Degerlendirme", new { id = urunId });
        }

        public IActionResult Siparis()
        {
            return View(context.Siparisler.Include(x => x.Kullanici).OrderByDescending(x => x.Tarih).ToList());
        }

        public IActionResult SiparisDetay(int id)
        {
            SiparisDetayViewModel viewModel = new SiparisDetayViewModel();
            Siparis kayit = context.Siparisler.Include(x => x.Kullanici).Include(x => x.SiparisUrunleri).FirstOrDefault(x => x.Id == id);
            viewModel.Siparis = kayit;
            viewModel.SiparisDurumlari = Enum.GetValues(typeof(Siparis.SiparisDurumu)).Cast<Siparis.SiparisDurumu>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SiparisDurum(SiparisDetayViewModel viewModel)
        {
            Siparis kayit = context.Siparisler.FirstOrDefault(x => x.Id == viewModel.Siparis.Id);
            kayit.Durum = viewModel.Siparis.Durum;
            context.Siparisler.Update(kayit);
            context.SaveChanges();
            return RedirectToAction("SiparisDetay", new { id = viewModel.Siparis.Id });
        }

        public IActionResult SiparisIptal(int id)
        {
            Siparis kayit = context.Siparisler.FirstOrDefault(x => x.Id == id);
            context.Siparisler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Siparis");
        }
    }
}