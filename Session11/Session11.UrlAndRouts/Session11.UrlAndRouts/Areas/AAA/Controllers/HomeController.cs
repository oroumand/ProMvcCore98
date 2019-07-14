using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session11.UrlAndRouts.Areas.AAA.Controllers
{
    [Area("AAA")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index),
            
            };
            result.Data["Area"] = "AAA";
            //result.Data["id"] = id;// RouteData.Values["id"];
            //result.Data["catchall"] = RouteData.Values["catchall"];// RouteData.Values["id"];
            return View("Result", result);
        }
    }
}
