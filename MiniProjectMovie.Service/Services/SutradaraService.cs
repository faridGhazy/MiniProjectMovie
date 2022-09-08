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
    class SutradaraService : ISutradaraService
    {
        private readonly ISutradaraRepository sutradaraRepository;

        public SutradaraService(ISutradaraRepository sutradaraRepository)
        {
            this.sutradaraRepository = sutradaraRepository;
        }

        public async Task<bool> CreateSutradara(Sutradara sutradara)
        {
            var result = await sutradaraRepository.CreateSutradara(sutradara);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await sutradaraRepository.Delete(id);
            return result;
        }

        public async Task<List<Sutradara>> GetSutradara()
        {
            var result = await sutradaraRepository.GetSutradara();
            return result;
        }

        public async Task<Sutradara> Update(Sutradara model)
        {
            var result = await sutradaraRepository.Update(model);
            return result;
        }
    }
}
