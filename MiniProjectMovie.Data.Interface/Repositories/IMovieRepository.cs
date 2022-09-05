using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Interface.Repositories
{
    public interface IMovieRepository
    {
        public Task<bool> Create(Movie model);
        public Task<List<Movie>> GetAll();
    }
}
