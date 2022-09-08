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

        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteData("DELETE FROM tablemovie where id=@id", new { id = @id });
            return true;
        }

        //menampilkan semua data movie
        /*public async Task<List<Movie>> GetAll()
        {
            var result = await _dbService.GetData<Movie>("SELECT * FROM tablemovie", new { });
            return result;
        }*/

        //menampilkan data movie berdasarkan id
        public async Task<List<Movie>> GetById(int id)
        {
            var result = await _dbService.GetData<Movie>("SELECT * FROM tablemovie where id=@id", new { id=@id });
            //ingin memunculkan data movie yang terhubung ke table lain.... belum berhasil
            /*var result = await _dbService.GetData<Movie>("SELECT m.id, m.namaMovie, m.rating, m.tahun, s.namaSutradara, " +
                "a.namaAktor FROM tablemovie m " +
                "JOIN tablesutradara s on m.sutradaraId = s.id " +
                "JOIN tableaktor a on m.aktorUtamaId = a.id " +
                "WHERE m.id=@id", new { id = @id });*/
            return result;
        }

        public async Task<Movie> Update(Movie model)
        {
            await _dbService.ModifyData("UPDATE tablemovie " +
                "SET namaMovie=@namaMovie, rating=@rating, tahun=@tahun, sutradaraId=@sutradaraId, " +
                "aktorUtamaId=@aktorUtamaId WHERE id=@id", model);
            return model;
        }
    }
}
