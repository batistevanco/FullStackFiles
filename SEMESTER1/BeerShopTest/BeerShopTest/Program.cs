using BeerShopTest.Domain.DataDB;
using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.Repositories;
using BeerShopTest.Repositories.Interfaces;
using BeerShopTest.Services;
using BeerShopTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
// DbContext toevoegen (belangrijk!)
builder.Services.AddDbContext<BierDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO's
builder.Services.AddScoped<IBeerDAO, BeerDAO>();
builder.Services.AddScoped<IDAO<Brewery2>, BreweryDAO>();

// Services
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IService<Brewery2>, BreweryService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
