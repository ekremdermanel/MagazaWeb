using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Functions
{
    public static class Tarih
    {
        public static string KisaTarih(this DateTime tarih)
        {
            return tarih.ToString("dd.MM.yyyy");
        }

        public static string KisaTarih2(this DateTime tarih)
        {
            return tarih.ToString("yyyy-MM-dd");
        }

        public static string KisaTarihSaat(this DateTime tarih)
        {
            return tarih.ToString("dd.MM.yyyy HH:mm");
        }

        public static string UzunTarih(this DateTime tarih)
        {
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;

            string strAy = null;
            switch (ay)
            {
                case 1: strAy = "Ocak"; break;
                case 2: strAy = "Şubat"; break;
                case 3: strAy = "Mart"; break;
                case 4: strAy = "Nisan"; break;
                case 5: strAy = "Mayıs"; break;
                case 6: strAy = "Haziran"; break;
                case 7: strAy = "Temmuz"; break;
                case 8: strAy = "Ağustos"; break;
                case 9: strAy = "Eylül"; break;
                case 10: strAy = "Ekim"; break;
                case 11: strAy = "Kasım"; break;
                case 12: strAy = "Aralık"; break;
            }

            string strGun = null;
            switch (tarih.DayOfWeek)
            {
                case DayOfWeek.Monday: strGun = "Pazartesi"; break;
                case DayOfWeek.Tuesday: strGun = "Salı"; break;
                case DayOfWeek.Wednesday: strGun = "Çarşamba"; break;
                case DayOfWeek.Thursday: strGun = "Perşembe"; break;
                case DayOfWeek.Friday: strGun = "Cuma"; break;
                case DayOfWeek.Saturday: strGun = "Cumartesi"; break;
                case DayOfWeek.Sunday: strGun = "Pazar"; break;
            }
            return gun + " " + strAy + " " + yil + " " + strGun;
        }

        public static string UzunTarihSaat(this DateTime tarih)
        {
            return tarih.UzunTarih() + " " + tarih.ToString("HH:mm");
        }

        public static string GecenZaman(this DateTime tarih)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - tarih.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1)
                return "Şimdi";

            if (delta < 1 * MINUTE)
                return ts.Seconds + " saniye önce";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " dakika önce";

            if (delta < 24 * HOUR)
                return ts.Hours + " saat önce";

            if (delta < 48 * HOUR)
                return "Dün";

            if (delta < 30 * DAY)
                return ts.Days + " gün önce";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "Geçen ay" : months + " ay önce";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "Geçen yıl" : years + " yıl önce";
            }
        }
    }
}