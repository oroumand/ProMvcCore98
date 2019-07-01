using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session13.ControllersAndActions.Controllers
{
    public class HtmlController : Controller
    {
        public  IActionResult Index2()
        {
            return View("Result", "This is index 2");
        }
        public IActionResult Index()
        {
            var name = TempData["name"];
            var city = TempData["city"];
            return View("Result", $"username {TempData["name"]} city: {TempData["city"]}");
        }
        public IActionResult SimpleForm() => View("SimpleForm");

        public IActionResult ReceiveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return  RedirectToAction("Index2");
        }

    }
}
