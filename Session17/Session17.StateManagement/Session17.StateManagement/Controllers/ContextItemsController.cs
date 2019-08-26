using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public class ContextItemsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            HttpContext.Items["FirstName"] = new
            {
                FirstName = "Alireza"
            };
            return View();
        }
    }
}
