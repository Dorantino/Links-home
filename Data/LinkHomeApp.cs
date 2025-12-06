using linkHomeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace linkHomeApp.Data
{
    public class linkHomeContext : DbContext
    {
        public linkHomeContext(DbContextOptions<linkHomeContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
    }

}