using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Interface.Services
{
    public interface ISutradaraService
    {
        public Task<bool> CreateSutradara(Sutradara sutradara);
        public Task<List<Sutradara>> GetSutradara();
        public Task<Sutradara> Update(Sutradara model);
        public Task<bool> Delete(int id);
    }
}
