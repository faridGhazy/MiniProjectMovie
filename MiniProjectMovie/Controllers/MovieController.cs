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
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie model)
        {
            var result = await movieService.Create(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<Movie>> GetAll()
        {
            var result = await movieService.GetAll();
            return result;
        }
    }
}
