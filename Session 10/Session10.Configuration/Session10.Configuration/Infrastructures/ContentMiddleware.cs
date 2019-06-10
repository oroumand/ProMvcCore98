using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Session10.Configuration.Infrastructures
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response
                .WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                .WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }


    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private readonly UptimeService uptimeService;

        public ContentMiddleware(RequestDelegate next, UptimeService uptimeService)
        {
            nextDelegate = next;
            this.uptimeService = uptimeService;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                $"This is from the content middleware. uptime is {uptimeService.GetUptime}", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }

    }

}
