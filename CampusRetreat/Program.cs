using System;
using System.Threading.Tasks;
using CampusRetreat.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CampusRetreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        // NullReferencePointer Exception
        //public static async void  MainAsync(string[] args)
        //{
        //    var host = BuildWebHost(args);

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        try
        //        {
        //            var context = services.GetRequiredService<CampusRetreatContext>();
        //            context.Database.Migrate();
        //            await AdminSeeder.Initialize(services);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services.GetRequiredService<ILogger<Program>>();
        //            logger.LogError(ex, "Couldn't seed the database");
        //        }
        //    }

        //    await host.RunAsync();
        //}

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>()
                .Build();
    }
}