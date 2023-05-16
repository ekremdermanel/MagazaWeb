using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Functions
{
  public static class Sayi
  {
    public static string ParaBirimi(this decimal? sayi)
    {
      return string.Format("{0:N0}", sayi);
    }
  }
}