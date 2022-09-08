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

    public class GenreMovieRepository : IGenreMovieRepository
    {
        private readonly IDbService _dbService;

        public GenreMovieRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(int Id, string NamaMovie, float Rating, int Tahun, int SutradaraId, int AktorUtamaId)
        {
            await _dbService.ModifyData("INSERT INTO tablemovie " +
                            " values (@id, @namaMovie, @rating, @tahun, @sutradaraId, @aktorUtamaId)", new
                            {
                                id = Id,
                                namaMovie = NamaMovie,
                                rating = Rating,
                                tahun = Tahun,
                                sutradaraId = SutradaraId,
                                aktorUtamaId = AktorUtamaId
                            });
            return true;
        }

        public async Task<bool> CreateGenreMovie(int Id, int GenreId)
        {
            await _dbService.ModifyData("INSERT INTO tablegenremovie " +
                            "VALUES (@id, @genreId)", new {id=Id, genreId=GenreId});
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteData("DELETE FROM tablegenremovie WHERE movieId=@id", new { id = @id });
            await _dbService.DeleteData("DELETE FROM tablemovie where id=@id", new { id = @id });            
            return true;
        }

        public async Task<bool> DeleteGenreMovie(int id)
        {
            await _dbService.DeleteData("DELETE FROM tablegenremovie WHERE movieId=@id", new { id = @id });
            return true;
        }

        public async Task<List<AllData>> GetData()
        {
            var result = await _dbService.GetData<AllData>("SELECT gm.movieId, m.namaMovie, m.rating, m.tahun, " +
                "s.namaSutradara, a.namaAktor, GROUP_CONCAT(g.namaGenre) as namaGenre " +
                "FROM tablegenremovie gm " +
                "join tablemovie m on gm.movieId = m.id " +
                "join tablesutradara s on  m.sutradaraId = s.id " +               
                "join tableaktor a on m.aktorUtamaId = a.id " +                
                "join tablegenre g on gm.genreId = g.id " +
                "group by gm.movieId ORDER BY gm.movieId ASC; ", new { });
            return result;
        }

        public async Task<List<AllData>> GetDataPage(int page)
        {
            var result = await _dbService.GetData<AllData>("SELECT gm.movieId, m.namaMovie, m.rating, m.tahun, " +
                "s.namaSutradara, a.namaAktor, GROUP_CONCAT(DISTINCT g.namaGenre) as namaGenre " +
                "FROM tablegenremovie gm " +
                "join tablemovie m on gm.movieId = m.id " +
                "join tablesutradara s on  m.sutradaraId = s.id " +
                "join tableaktor a on m.aktorUtamaId = a.id " +                
                "join tablegenre g on gm.genreId = g.id " +
                "group by gm.movieId ORDER BY gm.movieId ASC " +
                "limit 10 offset @page", new { page=@page });
            return result;
        }

        public async Task<List<AllData>> GetDataByGenre(string namaGenre)
        {
            var result = await _dbService.GetData<AllData>("SELECT gm.movieId, m.namaMovie, m.rating, m.tahun, " +
                "s.namaSutradara, a.namaAktor, g.namaGenre " +
                "FROM tablegenremovie gm " +
                "join tablemovie m on gm.movieId = m.id " +
                "join tablesutradara s on  m.sutradaraId = s.id " +
                "join tableaktor a on m.aktorUtamaId = a.id " +                
                "join tablegenre g on gm.genreId = g.id " +
                "WHERE g.namaGenre Like @namaGenre " +
                "GROUP BY gm.movieId ORDER BY gm.movieId ASC; ", new { namaGenre=namaGenre });
            return result;
        }
        
        public async Task<bool> Update(int id, string namaMovie, float rating, int tahun, int sutradaraId,
            int aktorUtamaId)
        {
            await _dbService.ModifyData("UPDATE tablemovie " +
                "SET namaMovie=@namaMovie, rating=@rating, tahun=@tahun, sutradaraId=@sutradaraId, " +
                "aktorUtamaId=@aktorUtamaId WHERE id=@id ", new {
                    id = @id,
                    namaMovie = @namaMovie,
                    rating = @rating,
                    tahun = @tahun,
                    sutradaraId = @sutradaraId,
                    aktorUtamaId = @aktorUtamaId
                });
            return true;
        }

        public async Task<bool> UpdateGenreMovie(int id, int genreId)
        {
            await _dbService.ModifyData("UPDATE tablegenremovie " +
                "SET sutradaraId=@sutradaraId, " +
                "aktorUtamaId=@aktorUtamaId, genreId=@genreId WHERE movieId=@id ", new
                {
                    id = @id,
                    genreId = @genreId
                });
            return true;
        }
    }
}
