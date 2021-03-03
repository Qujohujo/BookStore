using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookStoreDbContext>(options =>
            {
                //adds the connection string so that the database knows where to connect to the web app
                options.UseSqlServer(Configuration["ConnectionStrings:BookStoreConnection"]);
            });

            services.AddScoped<IBookStoreRepository, EFBookStoreRepository>();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    "page",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    "category",
                    "{category}",
                    new {Controller = "Home", action = "Index", page = 1 }
                );

                endpoints.MapControllerRoute(
                    "pagination",
                    "Books/P{page}",
                    new { Controller = "Home", action = "Index" }
                );

                endpoints.MapDefaultControllerRoute();
            });
            //ensures that the database is seeded with the seed data
            SeedData.EnsurePopulated(app);
        }
    }
}
