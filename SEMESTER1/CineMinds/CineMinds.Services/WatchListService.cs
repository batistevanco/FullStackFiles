using CineMinds.Domains.EntitiesDB;
using CineMinds.Repositories.Interfaces;
using CineMinds.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMinds.Services
{
    public class WatchListService : IWatchListService
    {
        private IDAO<WatchlistItem> _dao;
        public WatchListService(IDAO<WatchlistItem> dao)
        {
            _dao = dao;
        }
        public async Task AddAsync(WatchlistItem entity)
        {
            await _dao.AddAsync(entity);
        }

        public async Task AddMovieToWatchListAsync(int MovieId)
        {
            var allItems = await _dao.GetAllAsync();

            // 2. CHECK: Bestaat deze FILM al in de lijst? (Business Logic)
            // Let op: we checken op MovieId, niet op WatchlistItemId!
            bool exists = allItems.Any(w => w.MovieId == MovieId);

            if (!exists)
            {
                // 3. Maak het object aan (Dit hoeft de controller niet te doen)
                var newItem = new WatchlistItem
                {
                    MovieId = MovieId,
                    DateAdded = DateTime.Now
                };

                // 4. Sla op via de DAO
                await _dao.AddAsync(newItem);
            }
        }

        public async Task DeleteAsync(WatchlistItem entity)
        {
            await _dao.DeleteAsync(entity);
        }

        public async Task<WatchlistItem?> FindByIdAsync(int id)
        {
            return await _dao.FindByIdAsync(id);
        }

        public async Task<IEnumerable<WatchlistItem>?> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }

        public async Task UpdateAsync(WatchlistItem entity)
        {
            await _dao.UpdateAsync(entity);
        }
    }
}
