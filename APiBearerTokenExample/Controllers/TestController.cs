using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APiBearerTokenExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        public TestController()
        {
                
        }

        string Url = "";

        public IActionResult logincheck()
        {
            string userName = "kapil", passwod = "kapil@12";

            var keyvalues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("passwrd", passwod),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            //var KeyValuePair<string, string>

            var requst = new HttpRequestMessage(HttpMethod.Post, Url + "Token");

            return Ok();
        }

        
    }
}
