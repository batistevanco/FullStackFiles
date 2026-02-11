using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vancoillie_batiste.Domain.EntitiesDB;

namespace vancoillie_batiste.Services.Interfaces
{
    public interface ILiedjeService : IService<Liedje>
    {
        Task<IEnumerable<Liedje>> GetLiedjeByGenreType(int genreID);

    }
}
