using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public async static Task SeedAsync(AppIdentityDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await db.Database.MigrateAsync();

            if (await roleManager.Roles.AnyAsync() || await userManager.Users.AnyAsync())
                return;

            var demoUser = new ApplicationUser()
            {
                UserName = AuthorizatinConstants.DEFAULT_DEMO_USER,
                Email = AuthorizatinConstants.DEFAULT_DEMO_USER,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(demoUser, AuthorizatinConstants.DEFAULT_PASSWORD);
            await roleManager.CreateAsync(new IdentityRole(AuthorizatinConstants.Roles.ADMINISTRATOR));

            var adminUser = new ApplicationUser()
            {
                UserName = AuthorizatinConstants.DEFAULT_ADMIN_USER,
                Email = AuthorizatinConstants.DEFAULT_ADMIN_USER,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, AuthorizatinConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(adminUser, AuthorizatinConstants.Roles.ADMINISTRATOR);

        }
    }
}
