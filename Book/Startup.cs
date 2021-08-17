using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Book.Bl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Book
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<StoreWebSite2Context>(options => options.UseSqlServer(config.GetConnectionString("DefultConnection")));
            services.AddScoped<IItemServes, ClsItem>();
            services.AddScoped<ICategoryServes, ClsCategory>();


            services.AddIdentity<AplicationUser, IdentityRole>(options =>//دس يتااعة تأكيد الأيميل 
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<StoreWebSite2Context>();
            services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = "/Admin/Home/Error";
                option.Cookie.Name = "Cookie";
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(600);
                option.LoginPath = "/Users/Login";
                option.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                option.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Item}/{action=List}");

                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
               
            });
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers(); //مع استخدام API
            });
        }
    }
}
