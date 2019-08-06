using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session16.Filters.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session16.Filters.Controllers
{
    //[Singletone]
    //[TestOutput("Controller attribute")]
    public class HomeController : Controller
    {

        // GET: /<controller>/
        //[MyHttpsFilter]
        //[MyActionFilter]
        //[MyResultFilter]
        //[TypeFilter(typeof(MyHybridFilter))]
        //[ServiceFilter(typeof(SingletoneAttribute))]
       //[TestOutput("Action 01")]
       //[TestOutput("Action 02",Order = -1)]
        public IActionResult Index()
        {
            return View();

        }
        //[MyHttpsFilter]
        public IActionResult NewsList()
        {
            return View();
        }
    }
}
