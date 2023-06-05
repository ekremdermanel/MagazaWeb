using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MagazaWeb.Controllers
{
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly MagazaContext context;
        private readonly UserManager<Kullanici> userManager;

        public SiparisController(MagazaContext context, UserManager<Kullanici> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = context.Siparisler.Include(s => s.SiparisUrunleri).Where(x => x.KullaniciId == userId).OrderByDescending(x => x.Tarih).ToList();
            return View(model);
        }
    }
}