using linkHomeApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace linkHomeApp.Areas.Identity.Data;

public class Auth : IdentityDbContext<User>
{
    public Auth(DbContextOptions<Auth> options)
        : base(options)
    {
    }

    /** 
     * this seeds the database with a default admin user if it doesn't already exist 
     */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSeeding((context, _) =>
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == "admin@example.com");
            if (user == null)
            {
                user = new User
                {
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "admin");

                context.Set<User>().Add(user);
                context.SaveChanges();
            }
        });
}
