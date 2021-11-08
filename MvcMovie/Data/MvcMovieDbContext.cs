using System;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MvcMovie.Data
{
    public class MvcMovieDbContext : IdentityDbContext<Customers>
    {
        public MvcMovieDbContext (DbContextOptions<MvcMovieDbContext> options) : base(options)
    { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Tempat> Tempats { get; set; }
   


    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new [] {
                    new IdentityRole("Admin"),
                    new IdentityRole("User")
                });

            var hasher = new PasswordHasher<Customers>();
            var admin = new Customers
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Test123!");
            builder.Entity<Customers>()
                .HasData(admin);
        }
    }
}