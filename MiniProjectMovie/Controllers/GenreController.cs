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
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Genre model)
        {
            var result = await genreService.Create(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<Genre>> GetData()
        {
            var result = await genreService.GetData();
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Genre model)
        {
            var result = await genreService.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Genre>> Delete(int id)
        {
            var result = await genreService.Delete(id);
            return Ok(result);
        }
    }
}
