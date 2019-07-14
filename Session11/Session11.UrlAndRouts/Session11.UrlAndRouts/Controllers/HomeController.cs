using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session11.UrlAndRouts.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string id)
        {
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index),
            };
            result.Data["id"] = id;// RouteData.Values["id"];
            //result.Data["catchall"] = RouteData.Values["catchall"];// RouteData.Values["id"];
            return View("Result",result);
        }
        [Route("/testattr")]
        public ViewResult Index2(string id)
        {

           // Url.Action("", "", new { });
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index2),
            };
            result.Data["id"] = id;// RouteData.Values["id"];
            //result.Data["catchall"] = RouteData.Values["catchall"];// RouteData.Values["id"];
            return View("Result", result);
        }

    }
}
