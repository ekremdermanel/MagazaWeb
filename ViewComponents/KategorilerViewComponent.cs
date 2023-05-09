using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.ViewComponents
{
  public class KategorilerViewComponent : ViewComponent
  {
    private readonly MagazaContext context;

    public KategorilerViewComponent(MagazaContext context)
    {
      this.context = context;
    }
    public IViewComponentResult Invoke()
    {
      return View(context.Kategoriler.ToList());
    }
  }
}