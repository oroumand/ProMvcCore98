using Microsoft.AspNetCore.Mvc.Filters;
using Session16.Filters.Infrastructures;
using System.Diagnostics;

namespace Session16.Filters.Filters
{
    public class MyHybridFilter:ActionFilterAttribute
    {
        private Stopwatch stopwatch;
        private readonly ILogger _logger;
        private long actionStartTime, actionEndTime,resultStartTime,resultEndTime;
        public MyHybridFilter(ILogger logger)
        {
            _logger = logger;
            stopwatch = Stopwatch.StartNew();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Log($"Action Start {context.ActionDescriptor.DisplayName}");
            actionStartTime = stopwatch.ElapsedMilliseconds;
        }



        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log($"Action End {context.ActionDescriptor.DisplayName}");

            actionEndTime = stopwatch.ElapsedMilliseconds;

        }


        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.Log($"Result Start {context.ActionDescriptor.DisplayName}");

            resultStartTime = stopwatch.ElapsedMilliseconds;
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.Log($"Result End {context.ActionDescriptor.DisplayName}");

            stopwatch.Stop();
            resultEndTime = stopwatch.ElapsedMilliseconds;
            string response = $"<div>request start: {actionStartTime} ms and request end: {actionEndTime} ms and response start: {resultStartTime} and response End : {resultEndTime} ms </div>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
    }
}
