using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.Repository.Interfaces;
using vancoillie_batiste.Services.Interfaces;

namespace vancoillie_batiste.Services
{
    public class LiedjeService : ILiedjeService
    {
        private readonly ILiedjeDAO _liedjeDAO;

        public LiedjeService(ILiedjeDAO liedjeDAO)
        {
            _liedjeDAO = liedjeDAO;
        }

        public async Task AddAsync(Liedje entity)
        {
            await _liedjeDAO.AddAsync(entity);
        }

        public async Task<Liedje?> FindByIdAsync(int id)
        {
            return await _liedjeDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Liedje>?> GetAllAsync()
        {
            return await _liedjeDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Liedje>> GetLiedjeByGenreType(int genreID)
        {
            return await _liedjeDAO.GetLiedjeByGenreType(genreID);
        }

        public async Task UpdateAsync(Liedje entity)
        {
            await _liedjeDAO.UpdateAsync(entity);
        }
    }
}
