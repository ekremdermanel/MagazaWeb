using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MagazaWeb.ViewComponents
{
  public class KategorilerViewComponent : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      List<string> kategoriler = new List<string> { "Telefon", "Notebook", "Televizyon", "Diğer" };
      return View(kategoriler);
    }
  }
}