using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Interface.Repositories
{
    public interface ISutradaraRepository
    {
        public Task<bool> CreateSutradara(Sutradara model);
        public Task<List<Sutradara>> GetSutradara();
        public Task<Sutradara> Update(Sutradara model);
        public Task<bool> Delete(int id);
    }
}
