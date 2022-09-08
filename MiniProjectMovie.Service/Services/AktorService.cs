using MiniProjectMovie.Data.Interface.Repositories;
using MiniProjectMovie.Model.Entities;
using MiniProjectMovie.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Services
{
    public class AktorService : IAktorService
    {
        private readonly IAktorRepository aktorRepository;

        public AktorService(IAktorRepository aktorRepository)
        {
            this.aktorRepository = aktorRepository;
        }

        public async Task<bool> CreateAktor(Aktor aktor)
        {
            var result = await aktorRepository.CreateAktor(aktor);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await aktorRepository.Delete(id);
            return result;
        }

        public async Task<List<Aktor>> GetAktor()
        {
            var result = await aktorRepository.GetAktor();
            return result;
        }

        public async Task<Aktor> Update(Aktor model)
        {
            var result = await aktorRepository.Update(model);
            return result;
        }
    }
}
