using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MagazaWeb.Models
{
    public class CaptchaService
    {
        private readonly IOptionsMonitor<CaptchaConfig> config;

        public CaptchaService(IOptionsMonitor<CaptchaConfig> config)
        {
            this.config = config;
        }
        public async Task<bool> VerifyToken(string token)
        {
            try
            {
                string url = $"https://www.google.com/recaptcha/api/siteverify?secret={config.CurrentValue.SecretKey}&response={token}";
                using (var client = new HttpClient())
                {
                    var httpResult = await client.GetAsync(url);
                    if (httpResult.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                    var responseString = await httpResult.Content.ReadAsStringAsync();
                    var googleResult = JsonConvert.DeserializeObject<CaptchaResponse>(responseString);
                    return googleResult.Success && googleResult.Score >= 0.5;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}