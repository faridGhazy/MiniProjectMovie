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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public async Task<bool> Create(Genre genre)
        {
            var result = await genreRepository.Create(genre);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await genreRepository.Delete(id);
            return result;
        }

        public async Task<List<Genre>> GetData()
        {
            var result = await genreRepository.GetData();
            return result;
        }

        public async Task<Genre> Update(Genre model)
        {
            var result = await genreRepository.Update(model);
            return result;
        }
    }
}
