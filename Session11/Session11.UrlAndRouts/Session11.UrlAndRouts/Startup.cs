using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Session11.UrlAndRouts.Infrastructures;
using UrlsAndRoutes.Infrastructure;

namespace Session11.UrlAndRouts
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("weekday", typeof(WeekdayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
                
                }
            );

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            //Set Default with parameters
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller}/{action}",
            //        defaults: new { action = "Index",controller="Home"});
            //});



            //Static Segment
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/q{controller=home}/{action=index}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("old", "/news",
            //        defaults:  new { controller="content",action="index"});
            //    routs.MapRoute("default", "/{controller=home}/{action=index}");
            //});
            //catchall
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id}/{*catchall}");
            //});

            //Constraint
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:int}");
            //});
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:alpha}");
            //});
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", 
            //        "/{controller=home}/{action=index}/{id}",
            //        defaults:new { },
            //        constraints: new { id=new AlphaRouteConstraint()});
            //});

            //CustomConstrains
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:weekday=sat}",
            //        defaults: new { },
            //        constraints: new { id = new WeekdayConstraint() });
            //});

            app.UseMvc(routes =>
            {
                //routs.Routes.Add(new LegacyRoute(app.ApplicationServices, "/articles/Windows_3.1_Overview.html","/old/.NET_1.0_Class_Library"));

                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );
                routes.MapRoute("default", "/{action=index}/{controller=home}/{id?}");
            });
        }
    }
}
