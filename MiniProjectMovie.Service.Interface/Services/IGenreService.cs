using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Interface.Services
{
    public interface IGenreService
    {
        public Task<bool> Create(Genre genre);
        public Task<List<Genre>> GetData();
        public Task<Genre> Update(Genre model);
        public Task<bool> Delete(int id);
    }
}
