using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Interface.Repositories
{
    public interface IGenreMovieRepository
    {
        //public Task<bool> Create(GenreMovie model);
        public Task<bool> Create(int Id, string NamaMovie, float Rating, int Tahun, int SutradaraId, 
            int AktorUtamaId);
        public Task<List<AllData>> GetData();
        public Task<List<AllData>> GetDataPage(int page);
        public Task<List<AllData>> GetDataByGenre(string namaGenre);
        public Task<bool> Update(int id, string namaMovie, float rating, int tahun, int sutradaraId,
            int aktorUtamaId);
        public Task<bool> Delete(int id);
        public Task<bool> DeleteGenreMovie(int id);
        public Task<bool> CreateGenreMovie(int Id, int GenreId);
        public Task<bool> UpdateGenreMovie(int id, int genreId);
    }
}
