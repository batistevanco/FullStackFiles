using CineMinds.Domains.DataDB;
using CineMinds.Domains.EntitiesDB;
using CineMinds.Repositories;
using CineMinds.Repositories.Interfaces;
using CineMinds.Services;
using CineMinds.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MoviesDbContext>(options =>
   options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDAO<Movie>, MovieDAO>();
builder.Services.AddScoped<IDAO<WatchlistItem>, WatchListDAO>();
builder.Services.AddScoped<IDAO<Genre>, GenreDAO>();
builder.Services.AddScoped<IDAO<Director>, DirectorDAO>();

builder.Services.AddScoped<IService<Movie>, MovieService>();
builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddScoped<IService<Genre>, GenreService>();
builder.Services.AddScoped<IService<Director>, DirectorService>();

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
    pattern: "{controller=Movie}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
