using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APiBearerTokenExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        public TestController()
        {
                
        }

        private readonly string Url = "http://localhost:5028/swagger/index.html";

        [HttpGet]
        [Route("logincheck")]
        public IActionResult logincheck()
        {
            string userName = "kapil", passwod = "Kapil@12";
            var accessToken = string.Empty;
            var keyvalues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("passwrd", passwod),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            //var KeyValuePair<string, string>

            var requst = new HttpRequestMessage(HttpMethod.Post, Url + "Token");
            requst.Content = new FormUrlEncodedContent(keyvalues);

            var client = new HttpClient();
            var response = client.SendAsync(requst).Result;
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync();
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(json.Result);
                var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
                accessToken = jwtDynamic.Value<string>("access_token");
                var usernm = jwtDynamic.Value<string>("userName");
                var AccessTokenExpirationDate = accessTokenExpiration;
            }

            return Ok();
        }

        
    }
}
