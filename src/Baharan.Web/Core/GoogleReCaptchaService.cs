using Azure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Security;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Baharan.Web.Core
{
    public class GoogleReCaptchaService
    {
        private readonly IOptionsMonitor<GoogleCaptchaConfig> _config;

        public GoogleReCaptchaService(IOptionsMonitor<GoogleCaptchaConfig> config)
        {
            _config = config;
        }
        public async Task<bool> VerifyToken(string token)
        {
            try
            {
                var url = $"https://www.google.com/recaptcha/api/siteverify?secret={_config.CurrentValue.SecretKey}&response={token}";
                using (var client =new HttpClient())
                {
                    var httpResult = await client.GetAsync(url);
                    if (httpResult.StatusCode!=System.Net.HttpStatusCode.OK)
                    {
                        return false;
                    }
                    var responeString = await httpResult.Content.ReadAsStringAsync();
                    var googleResult = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(responeString);
                    return googleResult.success && googleResult.score > 0.5;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
