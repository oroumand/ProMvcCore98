using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Session13.ControllersAndActions.Controllers
{
    public class PocoInheritedController:BaseController
    {
        public string Index() => "Hello From Poco Controller";


        public ViewResult MyActionResult()
        {
            return View("Result", "Hello from MyActionResult Inherited");
        }

        public IActionResult HeaderData()
        {
            //ControllerContext controllerContext = new ControllerContext();
            var dictionary =
               ControllerContext.HttpContext.Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());
            return View( "DictionaryResult",dictionary);
        }


        [NonAction]
        public string Not() => "Hello From Non Action";
    }
}
