using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public class TempDataController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private void Write(string key,string value)
        {
            TempData[key] = value;
        }
        private string Get(string key)
        {
            return TempData[key].ToString();
        }
        private string Peek(string key)
        {
            TempData.Keep("");
            return TempData.Peek(key).ToString();
        }
    }
}
