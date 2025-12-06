using linkHomeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace linkHomeApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
    }

}