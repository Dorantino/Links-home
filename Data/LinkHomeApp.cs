using linkHomeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace linkHomeApp.Data
{
    public class linkHomeContext : DbContext
    {
        public linkHomeContext(DbContextOptions<linkHomeContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------------------
            // Seed Categories
            // ----------------------
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "News" },
                new Category { Id = 2, Title = "Social" },
                new Category { Id = 3, Title = "Education" },
                new Category { Id = 4, Title = "Entertainment" }
            );

            // ----------------------
            // Seed Links
            // ----------------------
            modelBuilder.Entity<Link>().HasData(
                // News category (Id = 1)
                new Link { Id = 1, Label = "CNN", Url = "https://www.cnn.com", Pinned = true, CategoryId = 1 },
                new Link { Id = 2, Label = "BBC", Url = "https://www.bbc.com", Pinned = true, CategoryId = 1 },
                new Link { Id = 3, Label = "Reuters", Url = "https://www.reuters.com", Pinned = true, CategoryId = 1 },

                // Social category (Id = 2)
                new Link { Id = 4, Label = "Facebook", Url = "https://www.facebook.com", Pinned = true, CategoryId = 2 },
                new Link { Id = 5, Label = "Twitter", Url = "https://www.twitter.com", Pinned = false, CategoryId = 2 },
                new Link { Id = 6, Label = "Instagram", Url = "https://www.instagram.com", Pinned = false, CategoryId = 2 },

                // Education category (Id = 3) - only 3 links as per requirement
                new Link { Id = 7, Label = "Khan Academy", Url = "https://www.khanacademy.org", Pinned = false, CategoryId = 3 },
                new Link { Id = 8, Label = "Coursera", Url = "https://www.coursera.org", Pinned = false, CategoryId = 3 },
                new Link { Id = 9, Label = "edX", Url = "https://www.edx.org", Pinned = false, CategoryId = 3 },

                // Entertainment category (Id = 4)
                new Link { Id = 10, Label = "YouTube", Url = "https://www.youtube.com", Pinned = true, CategoryId = 4 },
                new Link { Id = 11, Label = "Netflix", Url = "https://www.netflix.com", Pinned = false, CategoryId = 4 },
                new Link { Id = 12, Label = "Spotify", Url = "https://www.spotify.com", Pinned = false, CategoryId = 4 }
            );
        }


    }

}