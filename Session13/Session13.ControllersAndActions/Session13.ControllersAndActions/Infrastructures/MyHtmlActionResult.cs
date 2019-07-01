using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions.Infrastructures
{
    public class MyHtmlActionResult : IActionResult
    {
        public string Content { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes(Content);
            return context.HttpContext.Response.Body.WriteAsync(content,
            0, content.Length);
        }
    }
    public class MyJsonResult : IActionResult
    {
        public object Content { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "text/json";
            var jsonData = JsonConvert.SerializeObject(Content);
            byte[] content = Encoding.ASCII.GetBytes(jsonData);
            return context.HttpContext.Response.Body.WriteAsync(content,
            0, content.Length);
        }
    }
}
