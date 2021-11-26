using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basic_api.Data;
using basic_api.Models;
using basic_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace basic_api.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly Basic_ApiDBContext _dbContext;
        public SuperHeroService(Basic_ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
           return await _dbContext.SuperHeroes.ToListAsync();
        }

        public async Task<ActionResult<SuperHero>> GetOne(long id)
        {
            return await _dbContext.SuperHeroes.FindAsync(id);
        }

        public async Task<SuperHero> AddOne(SuperHero hero)
        {
            // _dbContext.SuperHeroes.Add(hero);
            var newHero = await _dbContext.SuperHeroes.AddAsync(hero);  
            _dbContext.SaveChanges();
            return newHero.Entity;        
        }

        public async Task<ActionResult<List<SuperHero>>> UpdateOne(SuperHero request)
        {
            var dbHero = await _dbContext.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
                return default;

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.SuperHeroes.ToListAsync();
        }

        public async Task<string> DeleteOne(long id)
        {
            var dbHero = await _dbContext.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return default;

            _dbContext.Remove(dbHero);
            _dbContext.SaveChanges();
            var msg = $"Deleted {dbHero.Name}";

            return msg;

        }
    }
}
