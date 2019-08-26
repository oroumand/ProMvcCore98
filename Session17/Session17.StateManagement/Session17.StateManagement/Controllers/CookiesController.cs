using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public class CookiesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            WriteToCookie("FirstName", "Alireza");
            WriteToCookie("LastName", "Oroumand");
            return View();
        }
        public IActionResult ReadFromCookie()
        {
            ReadFromCookies();
            return View();
        }
        private void WriteToCookie(string key, string value)
        {
            var options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);                        
            Response.Cookies.Append(key, value, options);
        }

        private void ReadFromCookies()
        {

            ViewBag.FirstName = Request.Cookies["FirstName"];
            ViewBag.LastName = Request.Cookies["LastName"];
        }
    }
}
