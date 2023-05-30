using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MagazaWeb.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly UserManager<Kullanici> userManager;
        private readonly SignInManager<Kullanici> signInManager;
        public readonly RoleManager<IdentityRole> roleManager;

        public KullaniciController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kayit(KayitViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var kullanici = new Kullanici()
            {
                AdSoyad = model.AdSoyad,
                UserName = model.KullaniciAdi,
                Email = model.Eposta
            };

            var result = await userManager.CreateAsync(kullanici, model.Sifre);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(kullanici, "User");
                return RedirectToAction("Login", "Kullanici");
            }

            ModelState.AddModelError("", "Bilinmeyen Bir Hata Oluştu");
            return View(model);
        }


        public IActionResult Login(string? ReturnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var kullanici = await userManager.FindByNameAsync(model.KullaniciAdi);

            if (kullanici == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı Bulunamadı");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(kullanici, model.Sifre, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/");
            }

            ModelState.AddModelError("", "Girilen Kullanıcı Adı / Şifre Hatalı");
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Profil()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Kullanici user = userManager.FindByIdAsync(userId).Result;
            ProfilViewModel viewModel = new ProfilViewModel
            {
                AdSoyad = user.AdSoyad,
                Eposta = user.Email
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profil(ProfilViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userManager.FindByIdAsync(userId).Result;

            user.Email = viewModel.Eposta;
            user.AdSoyad = viewModel.AdSoyad;

            await userManager.UpdateAsync(user);
            return View(viewModel);
        }

        [Authorize]
        public IActionResult SifreDegistir()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SifreDegistir(SifreDegistirViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Kullanici user = await userManager.GetUserAsync(User);

            var result = await userManager.ChangePasswordAsync(user, viewModel.EskiSifre, viewModel.YeniSifre);
            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Şifreleri kontrol et");
            return View(viewModel);
        }

        public IActionResult Yetki()
        {
            return View();
        }
    }
}