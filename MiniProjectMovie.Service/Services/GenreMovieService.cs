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
    public class GenreMovieService : IGenreMovieService
    {
        private readonly IGenreMovieRepository genreMovieRepository;

        public GenreMovieService(IGenreMovieRepository genreMovieRepository)
        {
            this.genreMovieRepository = genreMovieRepository;
        }

        /*public async Task<bool> Create(int Id, string NamaMovie, float Rating,
            int Tahun, int SutradaraId, int AktorUtamaId, int[] GenreId)
        {
            var result = await genreMovieRepository.Create(Id, NamaMovie,Rating,
                Tahun,SutradaraId,AktorUtamaId);
            foreach(int x in GenreId)
            {
                int genreId = x;
                await genreMovieRepository.CreateGenreMovie(Id, SutradaraId, AktorUtamaId, genreId);
            }
            return result;
        }*/

        public async Task<bool> Create(GenreMovie model)
        {
            var result = await genreMovieRepository.Create(model.id, model.namaMovie, model.rating,
                model.tahun, model.sutradaraId, model.aktorUtamaId);
            foreach (int genre in model.genreId)
            {
                await genreMovieRepository.CreateGenreMovie(model.id, genre);
            }
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await genreMovieRepository.Delete(id);
            return result;
        }

        public async Task<List<AllData>> GetData()
        {
            var result = await genreMovieRepository.GetData();
            return result;
        }

        public async Task<List<AllData>> GetDataPage(int page)
        {
            int offset = (page-1) * 10;
            var result = await genreMovieRepository.GetDataPage(offset);
            return result;
        }

        public async Task<List<AllData>> GetDataByGenre(string namaGenre)
        {
            var result = await genreMovieRepository.GetDataByGenre(namaGenre);
            return result;
        }

        /*public async Task<bool> Update(GenreMovie model)
        {
            var result = await genreMovieRepository.Update(model.id, model.namaMovie, model.rating, model.tahun,
                model.sutradaraId, model.aktorUtamaId);
            foreach (int genre in model.genreId)
            {
                int x = genre;
                await genreMovieRepository.UpdateGenreMovie(model.id, model.sutradaraId, model.aktorUtamaId, x);
            }
            return result;
        }*/
        public async Task<bool> Update(GenreMovie model)
        {
            var result = await genreMovieRepository.Update(model.id, model.namaMovie, model.rating, model.tahun,
                model.sutradaraId, model.aktorUtamaId);
            await genreMovieRepository.DeleteGenreMovie(model.id);
            foreach (int genre in model.genreId)
            {
                await genreMovieRepository.CreateGenreMovie(model.id, genre);
            }
            return result;
        }
    }
}
