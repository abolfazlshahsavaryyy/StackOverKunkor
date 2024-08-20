using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Konkor.Models;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Talk> Talks { get; set; }
        // Add DbSet properties for other entities here as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Username = "Student", Password = "Student", FirstName = "Abolfazl", LastName = "Shahsavary" }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Name = "a", RamsShab = "a" }
            );
            modelBuilder.Entity<Talk>().HasData(
                new Talk { Id = 2,Question="چگونه ساعت مطالعه را افزایش دهم" }
            );
        }
    }
}
