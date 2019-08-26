using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Session17.StateManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            bool useDistributed = true;

            //services.AddTransient<ICacheProvider>(c =>
            //{
            //    if (useDistributed)
            //    {
            //        return new DistributedCache();
            //    }
            //    return new InMemory();

            //});
            //services.AddMemoryCache();
            //services.AddDistributedSqlServerCache(c =>
            //{
            //    c.ConnectionString = "Data Source=.\\SQL2017;Initial Catalog=DistCache;Integrated Security=True;";
            //    c.TableName = "CacheTable";
            //    c.SchemaName = "dbo";
            //});
            services.AddStackExchangeRedisCache(c =>
            {
               
            });
            services.AddSession(c =>
            {

            });
            services.AddMvc().AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

        }
    }
}
