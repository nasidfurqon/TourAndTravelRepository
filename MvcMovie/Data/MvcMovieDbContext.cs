using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieDbContext : DbContext
    {
        public MvcMovieDbContext (DbContextOptions<MvcMovieDbContext> options) : base(options)
    { }
    public DbSet<Category> categories { get; set; }
    public DbSet<Customers> customers { get; set; }
    public DbSet<Destination> destinations { get; set; }
    public DbSet<Transaction> transactions { get; set; }
    public DbSet<Contact> contacts { get; set; }
    public DbSet<Tempat> tempats { get; set; }
    
    }
}