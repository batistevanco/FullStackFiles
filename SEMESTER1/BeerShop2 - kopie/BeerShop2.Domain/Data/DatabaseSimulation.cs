using BeerShop2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Domain.Data
{
    public class DatabaseSimulation : DbContext
    {
        public DatabaseSimulation(DbContextOptions<DatabaseSimulation> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
