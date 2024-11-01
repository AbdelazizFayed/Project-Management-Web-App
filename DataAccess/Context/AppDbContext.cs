using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make sure you have registered the DbContext in the dependency injection container
            // You can do this in the Startup.cs file in your application

            // Add the following code to the ConfigureServices method:

          
            modelBuilder.Entity<Project>(entity =>
            {
                // Specify the precision and scale directly
                entity.Property(e => e.Budget)
                      .HasPrecision(18, 4);
            });

            base.OnModelCreating(modelBuilder);
        }


       public DbSet<Project>  Projects { get; set; }
       public DbSet<TaskEntity> Tasks { get; set; }
    }
}
