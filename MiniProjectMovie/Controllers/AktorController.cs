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
    public class AktorController : Controller
    {
        private readonly IAktorService aktorService;
        public AktorController(IAktorService aktorService)
        {
            this.aktorService = aktorService;
        }
                     
        [HttpPost]
        public async Task<IActionResult> CreateAktor([FromBody] Aktor model)
        {
            var result = await aktorService.CreateAktor(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<Aktor>> GetAktorById()
        {
            var result = await aktorService.GetAktor();
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Aktor model)
        {
            var result = await aktorService.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Genre>> Delete(int id)
        {
            var result = await aktorService.Delete(id);
            return Ok(result);
        }
    }
}
