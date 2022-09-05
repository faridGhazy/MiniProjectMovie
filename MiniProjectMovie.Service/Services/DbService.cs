using Dapper;
using Microsoft.Extensions.Configuration;
using MiniProjectMovie.Service.Interface.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new MySqlConnection(configuration.GetConnectionString("ConnectDatabaseMovie"));
        }


        public async Task<int> ModifyData(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }

    }
}
