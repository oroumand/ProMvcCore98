using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session13.ControllersAndActions.Controllers
{
    public class FileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //return File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css");
            //return File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css","testfileResult.css");
            var bytes = System.IO.File.ReadAllBytes(@"D:\ProMvcCore98\Session13\Session13.ControllersAndActions\Session13.ControllersAndActions\wwwroot\lib\twitter-bootstrap\css\bootstrap.css");
            return File(bytes, "text/css");
        }

        public IActionResult Index2()
        {
            //return File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css");
            //return File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css","testfileResult.css");
            var bytes = System.IO.File.ReadAllBytes(@"D:\ProMvcCore98\Session13\Session13.ControllersAndActions\Session13.ControllersAndActions\wwwroot\lib\twitter-bootstrap\css\bootstrap.css");
            return File(bytes, "text/css");
        }



    }
}
