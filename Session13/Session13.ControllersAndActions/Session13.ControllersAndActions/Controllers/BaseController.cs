using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Session13.ControllersAndActions.Controllers
{
    public abstract class BaseController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }
        public HttpRequest Request => ControllerContext.HttpContext.Request;
        public HttpResponse Response => ControllerContext.HttpContext.Response;
        public HttpContext HttpContext => ControllerContext.HttpContext;
        public ClaimsPrincipal User => ControllerContext.HttpContext.User;


        public ViewResult View()
        {
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            return View(actionName, null);
        }
        public ViewResult View(object model)
        {
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            return View(actionName, model);
        }
        public ViewResult View(string viewName)
        {
            return View(viewName, null);
        }

        public ViewResult View(string viewName,object model)
        {
            return new ViewResult
            {
                ViewName = viewName,
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                }
            };
        }
    }
}
