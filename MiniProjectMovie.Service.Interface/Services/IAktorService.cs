using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Interface.Services
{
    public interface IAktorService
    {
        public Task<bool> CreateAktor(Aktor aktor);
        public Task<List<Aktor>> GetAktor();
        public Task<Aktor> Update(Aktor model);
        public Task<bool> Delete(int id);
    }
}
