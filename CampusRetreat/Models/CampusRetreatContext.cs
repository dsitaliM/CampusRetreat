using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CampusRetreat.Models
{
    public class CampusRetreatContext : IdentityDbContext<Administrator>
    {
        public CampusRetreatContext(DbContextOptions<CampusRetreatContext> options) : base(options) {}

        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    base.OnModelCreating(model);

        //    model.Entity<Administrator>().ToTable()
        //}

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<Administrator> userManager =
                serviceProvider.GetRequiredService<UserManager<Administrator>>();
            var userName = configuration["Data:AdminUser:Name"];
            var email = configuration["Data:AdminUser:Email"];
            var password = configuration["Data:AdminUser:Password"];

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new Administrator
                {
                    UserName = userName,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
            }
        }
        public DbSet<Guest> Guests { get; set; }

        // To enalber lazy loading : public *virtual* DbSet<T>...
    }
}