using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;

namespace MagazaWeb.Functions
{
    public static class Eposta
    {
        public static void SendEmail(string toAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("gonderenepostaadresi"); // Gönderen e-posta adresi
            mail.To.Add(toAddress); // Alıcı e-posta adresi
            mail.Subject = subject; // E-posta konusu
            mail.Body = body; // E-posta içeriği
            mail.IsBodyHtml = true; // E-posta içeriği HTML formatında mı?

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // SMTP sunucusu ayarları
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("gonderenepostaadresi", "gonderensifre"); // SMTP kimlik doğrulama bilgileri
            smtpClient.EnableSsl = true; // SSL kullanacak mı?

            try
            {
                smtpClient.Send(mail); // E-postayı gönder
            }
            catch
            {
                //throw new Exception("Eposta gönderiminde hata");
            }
        }

        public static void SiparisEpostasiGonder(string eposta, Siparis model)
        {
            string icerik = "<h2>Siparişiniz Oluşturuldu</h2>";

            icerik += "<br><br><h4>Sipariş Bilgileri</h4>";
            icerik += String.Format("<p>Sipariş No: {0}</p>", model.Id);
            icerik += String.Format("<p>Sipariş Tarihi: {0}</p>", model.Tarih.KisaTarihSaat());
            icerik += String.Format("<p>Toplam {0} adet ürün <strong>{1} TL</strong></p>", model.SiparisUrunleri.Count, model.OdemeTutari.ParaBirimi());

            icerik += "<br><br><h4>Sipariş Detayları</h4>";
            icerik += "<ul>";
            foreach (var item in model.SiparisUrunleri)
            {
                icerik += String.Format("<li>{0} ({1} TL x {2} adet) Toplam: {3} TL", item.UrunAdi, item.Fiyat.ParaBirimi(), item.Adet, item.Toplam.ParaBirimi());
            }
            icerik += "</ul>";

            icerik += "<br><br><h4>Teslimat Bilgileri</h4>";
            icerik += String.Format("<p>Ad Soyad: {0}</p>", model.AdSoyad);
            icerik += String.Format("<p>Telefon: {0}</p>", model.Telefon);
            icerik += String.Format("<p>Adres: {0} {1} {2}</p>", model.Adres, model.Ilce, model.Il);

            SendEmail(eposta, "Mağaza Siparişiniz Oluşturuldu", icerik);
        }
    }
}