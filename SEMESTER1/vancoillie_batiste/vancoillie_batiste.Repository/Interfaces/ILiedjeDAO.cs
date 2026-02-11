using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vancoillie_batiste.Domain.EntitiesDB;

namespace vancoillie_batiste.Repository.Interfaces
{
    public interface ILiedjeDAO : IDAO<Liedje>
    {
        Task<IEnumerable<Liedje>> GetLiedjeByGenreType(int genreID);
    }
}
