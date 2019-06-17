using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace Session11.UrlAndRouts
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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

            app.UseMvc(routs =>
            {
                routs.MapRoute("default", "/{controller=home}/{action=index}/{id:int:Range(1,100)}");
            });
        }
    }
}
