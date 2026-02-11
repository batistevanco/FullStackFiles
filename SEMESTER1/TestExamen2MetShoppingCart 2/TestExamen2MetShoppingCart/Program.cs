using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.DataDB;
using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Repository;
using ShoppingCart.Repository.Interfaces;
using ShoppingCart.Services;
using ShoppingCart.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
// DbContext toevoegen (belangrijk!)
builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO's
builder.Services.AddScoped<IDAO<Product>, ProductDAO>();
builder.Services.AddScoped<ICartDAO, CartDAO>();

// Services
builder.Services.AddScoped<IService<Product>, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

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
