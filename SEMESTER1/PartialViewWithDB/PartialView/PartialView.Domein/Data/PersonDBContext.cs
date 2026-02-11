using Microsoft.EntityFrameworkCore;
using PartialView.Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Domein.Data
{
    public class PersonDbContext : DbContext // DbContext is de klasse die Entity Framework Core gebruikt om toegang te krijgen tot de database.
    {

        // (DbContextOptions<PersonDbContext> options) bevat configuratieopties voor de DbContext.
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        // : base(options) -> base constructor call", wat betekent dat deze constructor de options-parameter doorgeeft aan de constructor van de basis- of parent-klasse (DbContext).
        {
        }

        public DbSet<Person> Persons { get; set; }

        // Install-Package Microsoft.EntityFrameworkCore.InMemory




    }
}
