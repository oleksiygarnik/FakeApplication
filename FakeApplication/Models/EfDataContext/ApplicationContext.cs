using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Models.EfDataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role adminRole = new Role() { Id = 1, Name = "admin" };
            Role userRole = new Role() { Id = 2, Name = "user" };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });

            User adminUser = new User()
            {
                Id = 1,
                Login = "alex27super",
                Password = "12345678",
                Email = "alex27super@gmail.com",
                RoleId = adminRole.Id,
                IsBlocked = BlockStatus.Unblocked
            };

            modelBuilder.Entity<User>().HasData(adminUser);

            base.OnModelCreating(modelBuilder);
        }
    }
}
