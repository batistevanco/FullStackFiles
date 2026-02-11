using Microsoft.EntityFrameworkCore;
using PartialView.Domein.DataDB;
using PartialView.Domein.EntitiesDB;
using PartialView.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories
{
    public class PersonDBDAO : IPersonDBDAO
    {
        private readonly StudentDbContext _context;

        public PersonDBDAO(StudentDbContext context)

        {
           _context = context;
        }
        public async Task<IEnumerable<Adult>> GetAllAdultsAsync()
        {
            return await _context.Adults.AsNoTracking().Include(a => a.Department).ToListAsync();
        }
    }
}
