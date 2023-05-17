using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MVP.Date;
using MVP.Date.Interfaces;
using System;
using MVP.Date.Repository;

namespace MVP
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ITitle, TitleRep>();

            services.AddDbContext<AppDB>(
                   options =>
                   {
                       options.UseMySql($"server=localhost;userid=root;pwd=root;port=3306;database=geo_farm");
                   });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession(p => {
                p.IdleTimeout = TimeSpan.FromHours(9);
            });

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDB context)
        {
            


            app.UseHttpsRedirection();

            app.UseFileServer();


            context.Database.Migrate();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routs =>
            {
                routs.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");

            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDB content = scope.ServiceProvider.GetRequiredService<AppDB>();
                DBObjects.Initial(content);
            }
        }
    }

}
