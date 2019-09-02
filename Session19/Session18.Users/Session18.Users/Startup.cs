using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Session18.Users.Infrastructures;
using Session18.Users.Models;

namespace Session18.Users
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator2>();
            //services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            //services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IClaimsTransformation,LocationClaimsProvider>();
            services.AddIdentity<AppUser, IdentityRole>(c=>
            {
                c.Password.RequireDigit = false;
                c.Password.RequiredLength = 3;
                c.Password.RequiredUniqueChars = 2;
                c.Password.RequireLowercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;
                //c.User.AllowedUserNameCharacters = "qazwsxedc"
                //c.User.RequireUniqueEmail = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(c =>
            //{
            //    c.LoginPath
            //});
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();

            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();

            

            services.AddAuthorization(opts => {
                opts.AddPolicy("AllState", policy => {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince);
                });
                opts.AddPolicy("Tehran", policy => {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince, "Tehran");
                });
                opts.AddPolicy("DC", policy => {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince,"DC");
                });
                opts.AddPolicy("NotMahdi", policy => {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement("Mahdi"));
                });

                opts.AddPolicy("AuthorsAndEditors", policy => {
                    policy.AddRequirements(new DocumentAuthorizationRequirement
                    {
                        AllowAuthors = true,
                        AllowEditors = false
                    });
                });
                //opts.AddPolicy("NotMahdi", policy => {
                //    policy.RequireAuthenticatedUser();
                //    policy.AddRequirements(new BlockUsersRequirement("Mahdi"));
                //});
                //opts.AddPolicy("AuthorsAndEditors", policy => {
                //    policy.AddRequirements(new DocumentAuthorizationRequirement
                //    {
                //        AllowAuthors = true,
                //        AllowEditors = true
                //    });
                //});
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
