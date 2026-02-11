using Microsoft.EntityFrameworkCore;
using VacationTUI.Domain.Entitites;

namespace VacationTUI.Domain.Data
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