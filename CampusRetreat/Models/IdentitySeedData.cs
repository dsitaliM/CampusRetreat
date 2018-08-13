using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CampusRetreat.Models
{
    public static class IdentitySeedData
    {
        private const string AdminName = "admin";
        private const string AdminEmail = "admin";
        private const string AdminPassword = "$Retreat2017";

        public static async Task Seed(UserManager<Administrator> userManager)
        {
            if (await userManager.FindByEmailAsync(AdminEmail) == null)
            {
                var user = new Administrator
                {
                    UserName = AdminName,
                    Email = AdminEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}
