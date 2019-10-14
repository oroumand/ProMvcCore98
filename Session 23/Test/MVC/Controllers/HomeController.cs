using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using IdentityModel.Client;

namespace MVC.Controllers
{

    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
             HttpClient client = new HttpClient();
            
            var accessToken = HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken).Result;

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var apiResult =  client.GetStringAsync("https://localhost:44324/api/Values").Result;

            return View();
        }
        public IActionResult GetIdentityInfo()
        {
            var identityToken =  HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken).Result;
            List<string> ls = new List<string>();
           ls.Add($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                ls.Add($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
            return Ok(ls);
        }

        public IActionResult signin()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public async Task Logout()
        {
            // Clears the  local cookie ("Cookies" must match the name of the scheme)
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
        public IActionResult signout()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
