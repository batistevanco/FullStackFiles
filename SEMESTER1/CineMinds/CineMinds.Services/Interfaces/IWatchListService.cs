using CineMinds.Domains.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMinds.Services.Interfaces
{
    public interface IWatchListService : IService<WatchlistItem>
    {
        Task AddMovieToWatchListAsync(int id);
    }
}
