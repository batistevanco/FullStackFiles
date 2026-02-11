using BeerShop2.Services.Integration.CountryAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Services.Interfaces
{
    public interface ITravelService_API
    {
        Task<List<CountryItem>?> GetCountriesAsync();
    }
}
