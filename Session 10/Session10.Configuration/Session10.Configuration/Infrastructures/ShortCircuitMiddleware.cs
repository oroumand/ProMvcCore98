using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Session10.Configuration.Infrastructures
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            bool isEdge = bool.Parse(httpContext.Items["EdgeBrowser"].ToString());
            if (isEdge)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }

}
