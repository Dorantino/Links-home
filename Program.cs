using linkHomeApp.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<linkHomeContext>(options =>
{
    options.UseMySql(
        Env.GetString("CONNECTION_STRING"),
        ServerVersion.AutoDetect(Env.GetString("CONNECTION_STRING"))
    );
});

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=PublicIndex}/{id?}")
    .WithStaticAssets();


app.Run();
