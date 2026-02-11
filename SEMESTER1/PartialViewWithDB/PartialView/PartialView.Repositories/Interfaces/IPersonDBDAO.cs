using PartialView.Domein.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories.Interfaces
{
    public interface IPersonDBDAO
    {
        Task<IEnumerable<Adult>> GetAllAdultsAsync();
    }
}
