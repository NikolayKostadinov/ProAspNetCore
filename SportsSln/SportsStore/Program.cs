using Microsoft.EntityFrameworkCore;
using SportsStore.Configurations;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddServices();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.MapControllerRoute("pagination",
                       "Products/Page{productPage}",
                       new { Controller = "Home", action = "Index" });

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
