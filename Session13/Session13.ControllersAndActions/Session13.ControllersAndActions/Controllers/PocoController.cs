using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions.Controllers
{
    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }


        public string Index() => "Hello From Poco Controller";


        public ViewResult MyActionResult()
        {
            return new ViewResult
            {
                ViewName = "Result",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = "Hello from MyActionResult"
                }
            };
        }

        public IActionResult HeaderData()
        {
            //ControllerContext controllerContext = new ControllerContext();
            var dictionary =
               ControllerContext.HttpContext.Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());
            return new ViewResult
            {
                ViewName = "DictionaryResult",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = dictionary
                }
            };
        }


        [NonAction]
        public string Not() => "Hello From Non Action";

    }
}
