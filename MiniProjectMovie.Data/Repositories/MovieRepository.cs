using MiniProjectMovie.Data.Interface.Repositories;
using MiniProjectMovie.Model.Entities;
using MiniProjectMovie.Service.Interface.Services;
using MiniProjectMovie.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbService _dbService;

        public MovieRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(Movie model)
        {
            await _dbService.ModifyData("INSERT INTO tablemovie " +
                " values (@id, @namaMovie, @rating, @tahun, @sutradaraId, @aktorUtamaId)", model);
            return true;
        }
    }
}
