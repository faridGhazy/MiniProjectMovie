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
    public class SutradaraController : Controller
    {
        private readonly ISutradaraService sutradaraService;

        public SutradaraController(ISutradaraService sutradaraService)
        {
            this.sutradaraService = sutradaraService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSutradara([FromBody] Sutradara model)
        {
            var result = await sutradaraService.CreateSutradara(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<Sutradara>> GetSutradara()
        {
            var result = await sutradaraService.GetSutradara();
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Sutradara model)
        {
            var result = await sutradaraService.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Sutradara>> Delete(int id)
        {
            var result = await sutradaraService.Delete(id);
            return Ok(result);
        }
    }
}
