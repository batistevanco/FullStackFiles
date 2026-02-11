using BeerShop2.Domain.EntitiesDB;

namespace BeerShop2.Services.Interfaces
{
    public interface IBeerService : IService<Beer>
    {
        Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerId);



    }
}