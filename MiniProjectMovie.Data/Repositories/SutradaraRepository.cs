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
    public class SutradaraRepository : ISutradaraRepository
    {
        private readonly IDbService _dbService;

        public SutradaraRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateSutradara(Sutradara model)
        {
            await _dbService.ModifyData("INSERT INTO tablesutradara " +
                " values (@id, @namaSutradara)", model);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteData("DELETE FROM tablesutradara where id=@id", new { id = @id });
            return true;
        }

        public async Task<List<Sutradara>> GetSutradara()
        {
            var result = await _dbService.GetData<Sutradara>("SELECT * FROM tablesutradara ", new { });
            return result;
        }

        public async Task<Sutradara> Update(Sutradara model)
        {
            await _dbService.ModifyData("UPDATE tablesutradara " +
                "SET namaSutradara=@namaSutradara WHERE id=@id", model);
            return model;
        }
    }
}
