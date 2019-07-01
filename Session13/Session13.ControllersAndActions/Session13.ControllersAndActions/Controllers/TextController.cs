using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session13.ControllersAndActions.Controllers
{
    public class TextController : Controller
    {
        // GET: /<controller>/
        public IActionResult Json()
        {
            return Json(new { FirstName= "Alireza", LastName = "Oroumand"});
        }


        public IActionResult Test()
        {
            return Content("My name is alireza oroumand","text/text");
        }


        public IActionResult css()
        {
            return Content(".header{ background-color:red}", "text/css");
        }
    }
}
