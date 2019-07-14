using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Session13.ControllersAndActions.Infrastructures;
using System.Linq;

namespace Session13.ControllersAndActions
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    var simpleTypeModelBinder = options.ModelBinderProviders.FirstOrDefault(x => x.GetType() == typeof(Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinderProvider));
                    if (simpleTypeModelBinder != null)
                    {
                        var simpleTypeModelBinderIndex = options.ModelBinderProviders.IndexOf(simpleTypeModelBinder);
                        options.ModelBinderProviders.Insert(simpleTypeModelBinderIndex, new YeKeStringModelBinderProvider());
                    }

                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
