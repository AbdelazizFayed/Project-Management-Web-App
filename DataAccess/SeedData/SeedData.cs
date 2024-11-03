using DataAccess.Context;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;

            var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scopedServices.GetRequiredService<UserManager<User>>();
            var context = scopedServices.GetRequiredService<AppDbContext>();

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Ensure roles are created
                    string[] roleNames = { "Manager", "Employee" };
                    foreach (var roleName in roleNames)
                    {
                        if (!await roleManager.RoleExistsAsync(roleName))
                        {
                            await roleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }

                    // Create users with roles
                    var users = new[]
                    {

                        new { Email = "AlicJohnson@manager.com", Role = "Manager", Name = "Alic Johnson" },
                        new { Email = "BobSmith@manager.com", Role = "Manager", Name = "Bob Smith" },
                        new { Email = "CharlieBrown@manager.com", Role = "Manager", Name = "Charlie Brown" },
                        new { Email = "DavidWilson@employee.com", Role = "Employee", Name = "David Wilson" },
                        new { Email = "EvaTaylor@employee.com", Role = "Employee", Name = "Eva Taylor" },
                        new { Email = "FrankMartin@employee.com", Role = "Employee", Name = "Frank Martin" }
                    };

                    foreach (var user in users)
                    {
                        if (await userManager.FindByEmailAsync(user.Email) == null)
                        {
                            var newUser = new User { UserName = user.Email, Email = user.Email, FullName = user.Name };
                            await userManager.CreateAsync(newUser, "Password123!");
                            await userManager.AddToRoleAsync(newUser, user.Role);
                        }
                    }

                    // Seed Projects and Tasks if they don't already exist
                    if (!context.Projects.Any())
                    {
                        var projects = new[]
                        {
                            new { Name = "E-commerce Platform", Description = "Develop an online platform for buying and selling products." },
                            new { Name = "Inventory Management System", Description = "Create a system for tracking and managing inventory levels." },
                            new { Name = "Mobile Banking App", Description = "Develop a secure app for banking transactions on mobile devices." },
                            new { Name = "Social Networking Site", Description = "Build a social platform for connecting and sharing content." },
                            new { Name = "Learning Management System", Description = "Design a platform for managing and delivering educational content." }
                        };

                        foreach (var project in projects)
                        {
                            var newProject = new Project
                            {
                                ProjectName = project.Name,
                                Description = project.Description,
                                StartDate = DateTime.UtcNow.AddDays(-30)
                            };

                            context.Projects.Add(newProject);

                            var tasks = new List<TaskEntity>
                            {
                                new TaskEntity{ TaskName = "Planning", Description = "Define the project scope, goals, and objectives.", Status = TasksStatus.Completed, StartDate = DateTime.UtcNow.AddDays(-30) },
                                new TaskEntity{ TaskName = "Requirements Analysis", Description = "Gather and analyze functional requirements for the project.", Status = TasksStatus.Completed, StartDate = DateTime.UtcNow.AddDays(-25) },
                                new TaskEntity{ TaskName = "Design", Description = "Create wireframes, mockups, and design prototypes.", Status = TasksStatus.InProgress, StartDate = DateTime.UtcNow.AddDays(-20) },
                                new TaskEntity{ TaskName = "Development", Description = "Implement core features and functionality.", Status = TasksStatus.Pending, StartDate = DateTime.UtcNow.AddDays(-10) },
                                new TaskEntity{ TaskName = "Testing", Description = "Perform unit, integration, and system testing.", Status = TasksStatus.Pending, StartDate = DateTime.UtcNow.AddDays(-5) },
                                new TaskEntity{ TaskName = "Deployment", Description = "Deploy the project to production environment.", Status = TasksStatus.Pending, StartDate = DateTime.UtcNow }
                            };
                            newProject.Tasks = new List<TaskEntity>();

                            foreach (var task in tasks)
                            {
                                newProject.Tasks.Add(task);
                            }
                        }

                        await context.SaveChangesAsync();
                    }

                    // Commit transaction if everything is successful
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine("An error occurred while seeding the database: " + ex.Message);
                }
            }
        }
    }
}
