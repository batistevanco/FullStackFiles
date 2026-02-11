




using BeerShop.Domain.Data;
using BeerShop.Domain.Entities;
using BeerShop.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Beershop.Repositories
{
    public class BeerDAO : IDAO<Beer>
    {

    

        private readonly BeerDbContext dbContext; // database context


        public BeerDAO(BeerDbContext context)
        {
            dbContext = context;
        }

        public Task AddAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Beer?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Beers
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}




