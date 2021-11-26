using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Models;
using basic_api.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace basic_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heroes = await _superHeroService.GetAll();

            if (heroes == null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(long id)
        {
            var hero = await  _superHeroService.GetOne(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SuperHero hero)
        {
            var newHero = _superHeroService.AddOne(hero);

            return Ok(newHero);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
            var dbHero = await _superHeroService.UpdateOne(request);

            return Ok(dbHero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(long id)
        {
            var dbHero = await _superHeroService.DeleteOne(id);
            if (dbHero == null){
                return BadRequest("Hero not found.");
            }
            return Ok(await _superHeroService.GetAll());
        }
    }
}