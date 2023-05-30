using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
  [Authorize]
  public class SepetController : Controller
  {
    public SepetController()
    {
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult SepeteEkle()
    {
      return RedirectToAction("Index");
    }
  }
}