using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatMash.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : ControllerBase
    {
       
        private readonly ICatsDataService catsDataService;

        public CatsController(ICatsDataService catsDataService)
        {
            this.catsDataService = catsDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await catsDataService.GetCats());
        }

        [HttpPost]
        public async Task<IActionResult> AddVote([FromBody] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await catsDataService.AddVote(id.Value);

            if (cat == null)
            {
                return Problem("Update problem in the server, please check server log");
            }

            return Ok(cat);
        }
    }
}
