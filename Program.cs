using linkHomeApp.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using linkHomeApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AuthConnection") ?? throw new InvalidOperationException("Connection string 'AuthConnection' not found.");;

builder.Services.AddDbContext<linkHomeContext>(options =>
{
    options.UseMySql(
        Env.GetString("CONNECTION_STRING"),
        ServerVersion.AutoDetect(Env.GetString("CONNECTION_STRING"))
    );
});

builder.Services.AddDbContext<Auth>(options =>
{
    options.UseMySql(
        Env.GetString("CONNECTION_STRING"),
        ServerVersion.AutoDetect(Env.GetString("CONNECTION_STRING"))
    );
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Auth>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=PublicIndex}/{id?}")
    .WithStaticAssets();


app.Run();
