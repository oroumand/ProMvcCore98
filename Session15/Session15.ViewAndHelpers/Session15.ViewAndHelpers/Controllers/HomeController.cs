using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session15.ViewAndHelpers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session15.ViewAndHelpers.Controllers
{

    //[ViewComponent(Name ="TestHybrid")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new BlogHomePage
            {

                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        Description ="Bad Post"
                    }
                }
            };
            return View(model);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //public ViewComponentResult Invoke()
        //{

        //}
    }
}
