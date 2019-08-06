using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Session16.Filters.Filters
{
    public class MyExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            
            base.OnException(context);
        }
    }
    public class MyResultFilter:ResultFilterAttribute
    {
        private Stopwatch stopwatch;
        private long startTime, endTime;
        public MyResultFilter()
        {
            stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            startTime = stopwatch.ElapsedMilliseconds;
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if(context.Result is ViewResult)
            {
                var result = context.Result as ViewResult;
                var viewName = result.ViewName;
                var model = result.Model;
              
            }
            stopwatch.Stop();
            endTime = stopwatch.ElapsedMilliseconds;
            string response = $"<div>request start: {startTime} ms and ent: {endTime} ms</div>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
    }
}
