using PartialView.Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories.Interfaces
{
    public interface IPersonDAO
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync(JobType type);

    }
}
