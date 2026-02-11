using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartialView.Domein.EntitiesDB;
using PartialView.Repositories.Interfaces;
using PartialView.Services.Interfaces;

namespace PartialView.Services
{
    public class PersonDbService : IPersonDbService
    {
        private readonly IPersonDBDAO _personDbDao;

        public PersonDbService(IPersonDBDAO personDbDao)
        {
            _personDbDao = personDbDao;
        }

        public async Task<IEnumerable<Adult>> GetAllAdultsAsync()
        {
            return await _personDbDao.GetAllAdultsAsync();
        }
    }
}
