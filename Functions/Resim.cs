using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Functions
{
  public static class Resim
  {
    public static string Ekle(IFormFile resim)
    {
      string resimUzantisi = Path.GetExtension(resim.FileName);
      string resimAdi = Guid.NewGuid() + resimUzantisi;
      string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{resimAdi}");
      var img = Image.Load(resim.OpenReadStream());
      img.Mutate(x => x.Resize(800, 600));
      img.Save(resimYolu);
      return resimAdi;
    }

    public static void Sil(string resimAdi)
    {
      string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{resimAdi}");
      FileInfo file = new FileInfo(resimYolu);
      if (file.Exists)
      {
        file.Delete();
      }
    }

    public static string Goster(this string resimAdi)
    {
      if (resimAdi != null)
      {
        return "/image/" + resimAdi;
      }
      else
      {
        return "/image/urun.png";
      }
    }
  }
}