using PartialView.Domein.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Services.Interfaces
{
    public interface IPersonDbService
    {
        Task<IEnumerable<Adult>> GetAllAdultsAsync();
    }
}
