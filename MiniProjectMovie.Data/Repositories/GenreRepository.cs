using MiniProjectMovie.Data.Interface.Repositories;
using MiniProjectMovie.Model.Entities;
using MiniProjectMovie.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IDbService _dbService;

        public GenreRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(Genre model)
        {
            await _dbService.ModifyData("INSERT INTO tablegenre " +
                " values (@id, @namaGenre)", model);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteData("DELETE FROM tablegenre where id=@id", new { id = @id });
            return true;
        }

        public async Task<List<Genre>> GetData()
        {
            var result = await _dbService.GetData<Genre>("SELECT * FROM tablegenre", new {});
            return result;
        }

        public async Task<Genre> Update(Genre model)
        {
            await _dbService.ModifyData("UPDATE tablegenre " +
                "SET namaGenre=@namaGenre WHERE id=@id", model);
            return model;
        }
    }
}
