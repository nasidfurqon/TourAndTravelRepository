using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
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
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Tempat> Tempats { get; set; }
    }
}