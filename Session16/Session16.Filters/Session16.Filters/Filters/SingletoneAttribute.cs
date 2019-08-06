using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session16.Filters.Controllers
{
    public class SingletoneAttribute:ActionFilterAttribute
    {
        private int counter = 0;
        public SingletoneAttribute()
        {
            counter = 0;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            counter++;
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string response = $"<h1>{counter}</h1>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
    }
}
