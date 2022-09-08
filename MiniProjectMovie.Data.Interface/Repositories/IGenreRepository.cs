using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Interface.Repositories
{
    public interface IGenreRepository
    {
        public Task<bool> Create(Genre model);
        public Task<List<Genre>> GetData();
        public Task<Genre> Update(Genre model);
        public Task<bool> Delete(int id);
    }
}
