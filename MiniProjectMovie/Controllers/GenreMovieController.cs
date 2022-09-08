using Microsoft.AspNetCore.Mvc;
using MiniProjectMovie.Model.Entities;
using MiniProjectMovie.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreMovieController : Controller
    {
        private readonly IGenreMovieService genreMovieService;

        public GenreMovieController(IGenreMovieService genreMovieService)
        {
            this.genreMovieService = genreMovieService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreMovie model)
        {
            var result = await genreMovieService.Create(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<AllData>> GetData()
        {
            var result = await genreMovieService.GetData();
            return result;
        }

        [HttpGet("{page:int}")]
        public async Task<List<AllData>> GetDataPage(int page)
        {
            var result = await genreMovieService.GetDataPage(page);
            return result;
        }

        [HttpGet("{namaGenre}")]
        public async Task<List<AllData>> GetDataByGenre(string namaGenre)
        {
            var result = await genreMovieService.GetDataByGenre(namaGenre);
            return result;
        }

        /*[HttpPut]
        public async Task<IActionResult> Update([FromBody] GenreMovie model)
        {
            var result = await genreMovieService.Update(model.id, model.namaMovie, 
                model.rating, model.tahun, model.sutradaraId, model.aktorUtamaId, model.genreId.ToArray());
            return Ok(result);
        }*/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GenreMovie model)
        {
            var result = await genreMovieService.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GenreMovie>> Delete(int id)
        {
            var result = await genreMovieService.Delete(id);
            return Ok(result);
        }
    }
}
