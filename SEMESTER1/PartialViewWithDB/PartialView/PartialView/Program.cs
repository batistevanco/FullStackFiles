using Microsoft.EntityFrameworkCore;
using PartialView.Domein.Data;
using PartialView.Domein.DataDB;
using PartialView.Domein.Entities;
using PartialView.Repositories;
using PartialView.Repositories.Interfaces;
using PartialView.Services;
using PartialView.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<PersonDbContext>(options =>
   options.UseInMemoryDatabase("InMemoryDb") // Provide a name for the InMemory database
);

//SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonDAO, PersonDAO>();

builder.Services.AddScoped<IPersonDbService, PersonDbService>();
builder.Services.AddScoped<IPersonDBDAO, PersonDBDAO>();

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


// Seed demo?data bij opstarten
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

    if (!db.Persons.Any())
    {
        db.Persons.AddRange(
       new Person { Id = 1, Voornaam = "Isabella", Naam = "García", Job = JobType.Docent, EnrollDate = new DateTime(2021, 5, 12), ImagePath = "lecture1.png" },
       new Person { Id = 2, Voornaam = "Oliver", Naam = "Schmidt", Job = JobType.Docent, EnrollDate = new DateTime(2022, 3, 15), ImagePath = "lecture2.png" },
       new Person { Id = 3, Voornaam = "Camille", Naam = "Dubois", Job = JobType.Docent, EnrollDate = new DateTime(2020, 7, 9), ImagePath = "lecture3.png" },
       new Person { Id = 4, Voornaam = "Luca", Naam = "Rossi", Job = JobType.Docent, EnrollDate = new DateTime(2019, 11, 3), ImagePath = "lecture4.png" },
       new Person { Id = 5, Voornaam = "Sven", Naam = "Nielsen", Job = JobType.Student, EnrollDate = new DateTime(2023, 1, 20), ImagePath = "stud_1.png" },
       new Person { Id = 6, Voornaam = "Ana", Naam = "Silva", Job = JobType.Student, EnrollDate = new DateTime(2020, 6, 25), ImagePath = "stud_2.png" },
       new Person { Id = 7, Voornaam = "Emilia", Naam = "Novák", Job = JobType.Student, EnrollDate = new DateTime(2021, 9, 17), ImagePath = "stud_3.png" },
       new Person { Id = 8, Voornaam = "Marek", Naam = "Kowalski", Job = JobType.Student, EnrollDate = new DateTime(2023, 4, 10), ImagePath = "stud_4.png" }
   );

        db.SaveChanges();
    }
}

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
