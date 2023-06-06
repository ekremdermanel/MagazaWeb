using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MagazaWeb.Functions
{
    public static class Doviz
    {
        public static decimal? GetDolarKuru()
        {
            try
            {
                string xmlUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlUrl);

                XmlNodeList currencyNodes = xmlDoc.SelectNodes("//Currency[@Kod='USD']");
                if (currencyNodes.Count > 0)
                {
                    XmlNode currencyNode = currencyNodes[0];
                    string rateString = currencyNode.SelectSingleNode("BanknoteSelling").InnerText;
                    if (decimal.TryParse(rateString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rate))
                    {
                        return rate;
                    }
                }
                throw new Exception("Dolar kuru alımında hata");
            }
            catch
            { return 1; }
        }
    }
}