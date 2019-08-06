using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Session16.Filters.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        private Stopwatch stopwatch;
        private long startTime, endTime;
        public MyActionFilter()
        {
            stopwatch = Stopwatch.StartNew();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            startTime = stopwatch.ElapsedMilliseconds;
        }



        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            endTime = stopwatch.ElapsedMilliseconds;
            string response = $"<div>request start: {startTime} ms and ent: {endTime} ms</div>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
         }
    }
}
