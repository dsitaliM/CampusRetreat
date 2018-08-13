using CampusRetreat.Models;
using CampusRetreat.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CampusRetreat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // For SQLServer
            services.AddDbContext<CampusRetreatContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CampusDB1")));


            //For SQLLite
            //services.AddDbContext<CampusRetreatContext>(options =>
            //    options.UseSqlite(Configuration.GetConnectionString("CampusDB0")));

            services.AddIdentity<Administrator, IdentityRole>()
                .AddEntityFrameworkStores<CampusRetreatContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddTransient<IGuestRepository, GuestService>();

            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //CampusRetreatContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();

        }
    }
}