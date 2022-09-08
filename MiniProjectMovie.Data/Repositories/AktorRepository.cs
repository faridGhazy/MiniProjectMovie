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
    public class AktorRepository : IAktorRepository
    {
        private readonly IDbService _dbService;
        public AktorRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateAktor(Aktor model)
        {
            await _dbService.ModifyData("INSERT INTO tableaktor " +
                " values (@id, @namaAktor)", model);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteData("DELETE FROM tableaktor where id=@id", new { id = @id });
            return true;
        }

        public async Task<List<Aktor>> GetAktor()
        {
            var result = await _dbService.GetData<Aktor>("SELECT * FROM tableaktor ", new { });
            return result;
        }

        public async Task<Aktor> Update(Aktor model)
        {
            await _dbService.ModifyData("UPDATE tableaktor " +
                "SET namaAktor=@namaAktor WHERE id=@id", model);
            return model;
        }
    }
}
