using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Ensure roles are created
            string[] roleNames = { "Manager", "Employee" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a test user with the "Manager" role
            var managerEmail = "manager@example.com";
            if (await userManager.FindByEmailAsync(managerEmail) == null)
            {
                var managerUser = new User { UserName = managerEmail, Email = managerEmail };
                await userManager.CreateAsync(managerUser, "Password123!");
                await userManager.AddToRoleAsync(managerUser, "Manager");
            }
        }
    }

}
