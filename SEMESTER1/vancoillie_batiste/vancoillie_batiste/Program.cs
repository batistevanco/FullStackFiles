using Microsoft.EntityFrameworkCore;
using vancoillie_batiste.Domain.DataDB;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.Repository;
using vancoillie_batiste.Repository.Interfaces;
using vancoillie_batiste.Services;
using vancoillie_batiste.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
// DbContext toevoegen (belangrijk!)
builder.Services.AddDbContext<LiedjesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO's
builder.Services.AddScoped<ILiedjeDAO, LiedjeDAO>();
builder.Services.AddScoped<IDAO<Genre>, GenreDAO>();


// Services
builder.Services.AddScoped<ILiedjeService, LiedjeService>();
builder.Services.AddScoped<IService<Genre>, GenreService>();


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
    pattern: "{controller=Liedje}/{action=GetSongsByGenreVM}/{id?}")
    .WithStaticAssets();


app.Run();
