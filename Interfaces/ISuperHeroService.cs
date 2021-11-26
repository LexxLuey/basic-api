using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ISuperHeroService
    {
        Task<ActionResult<List<SuperHero>>> GetAll();
        Task<ActionResult<SuperHero>> GetOne(long id);
        Task<SuperHero> AddOne(SuperHero hero);
        Task<ActionResult<List<SuperHero>>> UpdateOne(SuperHero request);
        Task<string> DeleteOne(long id);
    }
}