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
    class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<bool> Create(Movie movie)
        {
            var result = await movieRepository.Create(movie);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await movieRepository.Delete(id);
            return result;
        }

        /*public async Task<List<Movie>> GetAll()
        {
            var result = await movieRepository.GetAll();
            return result;
        }*/

        public async Task<List<Movie>> GetById(int id)
        {
            var result = await movieRepository.GetById(id);
            return result;
        }

        public async Task<Movie> Update(Movie model)
        {
            var result = await movieRepository.Update(model);
            return result;
        }
    }
}
