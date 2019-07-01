using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session13.ControllersAndActions.Controllers
{
    public class RedirectController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //return Redirect("");
            //return RedirectToRoute(new { controller = "", action = "" });
            //return RedirectToAction("Index", "Home");
            //return LocalRedirect("");
            //return RedirectPermanent();
            return View();
        }
    }
}
