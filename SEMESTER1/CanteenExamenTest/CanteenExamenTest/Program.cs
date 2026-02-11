using Canteen.Domain.DataDB;
using Canteen.Repository;
using Canteen.Repository.Interfaces;
using Canteen.Services;
using Canteen.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
// DbContext toevoegen (belangrijk!)
builder.Services.AddDbContext<CanteenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO's
builder.Services.AddScoped<IProductDAO, ProductDAO>();
builder.Services.AddScoped<ICartDAO, CartDAO>();
builder.Services.AddScoped<IOrderDAO, OrderDAO>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IBeerDAO, BeerDAO>();
//builder.Services.AddScoped<IDAO<Brewery>, BreweryDAO>();

// Services
//builder.Services.AddScoped<IBeerService, BeerService>();
//builder.Services.AddScoped<IService<Brewery>, BreweryService>();

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
