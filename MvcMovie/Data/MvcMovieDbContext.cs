using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieDbContext : DbContext
    {
        public MvcMovieDbContext (DbContextOptions<MvcMovieDbContext> options) : base(options)
    { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Tempat> Tempats { get; set; }
    
    }
}