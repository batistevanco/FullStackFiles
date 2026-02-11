using BeerschopNET9_Identity.Areas.Identity.Data;
using BeerschopNET9_Identity.Data;
using Beershop.Repositories;
using Beershop.Services;
using BeerShop.Domain.Data;
using BeerShop.Domain.Entities;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//ApplicationDbContext is the default DbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(connectionString));

//This example register a DbContext subclass called BeerDbContext as a scoped service in
//the ASP.NET Core application service provider (a.k.a. the dependency injection container).
builder.Services.AddDbContext<BeerDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//----> Dependency Injection

// syntax services.AddScoped<service, implType>();
builder.Services.AddScoped<IService<Beer>, BeerService>();
builder.Services.AddScoped<IDAO<Beer>, BeerDAO>();



builder.Services.AddControllersWithViews();

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "be.VIVES.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
