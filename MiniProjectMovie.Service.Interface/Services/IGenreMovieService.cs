using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service.Interface.Services
{
    public interface IGenreMovieService
    {
/*        public Task<bool> Create(int id, string namaMovie, float rating,
            int tahun, int sutradaraId, int aktorUtamaId, int[] genreId);*/
        public Task<bool> Create(GenreMovie model);
        public Task<List<AllData>> GetData();
        public Task<List<AllData>> GetDataPage(int page);
        public Task<List<AllData>> GetDataByGenre(string namaGenre);
        public Task<bool> Update(GenreMovie model);
        public Task<bool> Delete(int id);
    }
}
