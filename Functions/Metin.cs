using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Functions
{
  public static class Metin
  {
    public static string Bicimlendir(this string metin)
    {
      metin = "<p>" + metin + "</p>";
      metin = metin.Replace("\n", "</p><p>");
      metin = metin.Replace("[onemli]", "<strong style='color:red'>");
      metin = metin.Replace("[/onemli]", "</strong>");
      return metin;
    }

    public static string Kisalt(this string metin, int uzunluk)
    {
      if (metin == null)
      {
        return "";
      }
      metin = metin.Replace("[onemli]", "");
      metin = metin.Replace("[/onemli]", "");
      if (metin.Length > uzunluk)
      {
        return metin.Substring(0, uzunluk - 3) + "...";
      }
      return metin;
    }
  }
}