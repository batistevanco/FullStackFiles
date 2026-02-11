using BeerShop2.Domain.Data;
using BeerShop2.Domain.DataDB;
using BeerShop2.Domain.Entities;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories;
using BeerShop2.Repositories.Interfaces;
using BeerShop2.Services;
using BeerShop2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

//EigenDatabaseSimulation
builder.Services.AddDbContext<DatabaseSimulation>(options =>
   options.UseInMemoryDatabase("InMemoryDb") // Provide a name for the InMemory database
);

builder.Services.AddScoped<IHotelService_simulationdatabase, HotelService_simulationdatabase>();
builder.Services.AddScoped<IHotelDAO_simulationdatabase, HotelDAO_simulationdatabase>();


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

//simulation database vullen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseSimulation>();

    if (!db.Hotels.Any())
    {
        db.Hotels.AddRange(

            // --- Vlaamse kust ---

            new Hotel
            {
                Id = 1,
                NameHotel = "TUI Seaside Resort",
                City = "Oostende",
                Stars = 4,
                Score = 8.7,
                Benefit = "Ontbijt inbegrepen & late check-out",
                Photo = "HotelEurope.jpg",
                Country = CountryType.Coast
            },
            new Hotel
            {
                Id = 2,
                NameHotel = "Beach & Spa Hotel",
                City = "Blankenberge",
                Stars = 3,
                Score = 8.2,
                Benefit = "Wellness en binnenzwembad",
                Photo = "ibisDeHaan_DeHaan.jpg",
                Country = CountryType.Coast
            },
            new Hotel
            {
                Id = 3,
                NameHotel = "Dune View Hotel",
                City = "De Panne",
                Stars = 4,
                Score = 8.9,
                Benefit = "Familiekamers & kinderanimatie",
                Photo = "DomeinWesthoek_Oostduinkerke.jpg",
                Country = CountryType.Coast
            },
            new Hotel
            {
                Id = 4,
                NameHotel = "Sunny Coast Suites",
                City = "Knokke-Heist",
                Stars = 5,
                Score = 9.1,
                Benefit = "Suite met zeezicht en privéparking",
                Photo = "C-HotelsExcelsior_Middelkerke.jpg",
                Country = CountryType.Coast
            },

            // --- Ardennen ---

            new Hotel
            {
                Id = 5,
                NameHotel = "Ardennen Lodge",
                City = "La Roche-en-Ardenne",
                Stars = 4,
                Score = 9.0,
                Benefit = "Wellness & natuurwandelingen",
                Photo = "HotelLeValDePoix_St-Hubert.jpg",
                Country = CountryType.Wallonia
            },
            new Hotel
            {
                Id = 6,
                NameHotel = "Forest Retreat Hotel",
                City = "Durbuy",
                Stars = 3,
                Score = 8.4,
                Benefit = "Rustige ligging in het bos",
                Photo = "HotelRadissonBluBalmoral_Spa.jpg",
                Country = CountryType.Wallonia
            },
            new Hotel
            {
                Id = 7,
                NameHotel = "River View Inn",
                City = "Bouillon",
                Stars = 3,
                Score = 8.1,
                Benefit = "Uitzicht op de Semois & ontbijt",
                Photo = "transparency_black_50p.png", // had geen hotel-foto, dus overlay PNG
                Country = CountryType.Wallonia
            },
            new Hotel
            {
                Id = 8,
                NameHotel = "Chalet du Soleil",
                City = "Spa",
                Stars = 4,
                Score = 8.8,
                Benefit = "Gratis toegang tot thermen",
                Photo = "HotelRadissonBluBalmoral_Spa.jpg",
                Country = CountryType.Wallonia
            }
        );

        db.SaveChanges();
    }
}

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