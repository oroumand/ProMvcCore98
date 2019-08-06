using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session16.Filters.Filters
{
    public class TestOutput:ResultFilterAttribute
    {
        public string Name { get; set; }
        public TestOutput(string name)
        {
            Name = name;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string response = $"<h1>My name is: {Name} Executin</h1>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string response = $"<h1>My name is: {Name} Executed</h1>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
    }
}
