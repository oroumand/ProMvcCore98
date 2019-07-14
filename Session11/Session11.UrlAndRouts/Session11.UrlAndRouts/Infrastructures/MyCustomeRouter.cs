using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UrlsAndRoutes.Infrastructure
{
    //public class LegacyRoute : IRouter
    //{
    //    private string[] urls;
    //    public LegacyRoute(params string[] targetUrls)
    //    {
    //        this.urls = targetUrls;
    //    }
    //    public Task RouteAsync(RouteContext context)
    //    {
    //        string requestedUrl = context.HttpContext.Request.Path
    //        .Value.TrimEnd('/');
    //        if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
    //        {
    //            context.Handler = async ctx => {
    //                HttpResponse response = ctx.Response;
    //                byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
    //                await response.Body.WriteAsync(bytes, 0, bytes.Length);
    //            };
    //        }

    //        return Task.CompletedTask;
    //    }
    //    public VirtualPathData GetVirtualPath(VirtualPathContext context)
    //    {
    //        return null;
    //    }
    //}


    public class LegacyRoute : IRouter
    {
        private string[] urls;
        private IRouter mvcRoute;
        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            this.urls = targetUrls;
            mvcRoute = services.GetRequiredService<MvcRouteHandler>();
        }
        public async Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path
            .Value.TrimEnd('/');
            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);
            }
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}