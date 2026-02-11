using BeerShop2.Domain.DataDB;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories;
using BeerShop2.Repositories.Interfaces;
using BeerShop2.Services;
using BeerShop2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext toevoegen (belangrijk!)
builder.Services.AddDbContext<BierDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO's
builder.Services.AddScoped<IBeerDAO, BeerDAO>();

// Services
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IService<Brewery>, BreweryService>();
builder.Services.AddScoped<IDAO<Brewery>, BreweryDAO>();

builder.Services.AddScoped<IDAO<Variety>, VarietyDAO>();
builder.Services.AddScoped<IService<Variety>, VarietyService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Static files (.css, .js, images)
app.UseStaticFiles();
app.MapStaticAssets();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Beer}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();