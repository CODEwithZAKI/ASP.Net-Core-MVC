using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CODEwithZAKI.Data;
using CODEwithZAKI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CODEwithZAKI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { string conn = "Server=ZAKI" + @"\"+ "Omar;Database=BookStore;Integrated Security=True;";
            services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer(conn));
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<BookRepository, BookRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/omar", async context =>
                {
                    await context.Response.WriteAsync("Hello Omar cade!");
                });
            });*/

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("CODEwithZAKI");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync(" Web Application");
            //});
        }
    }
}
