using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRegionRepository
    {

        private readonly ApplicationContext _dbContext;

        public PokemonRegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PokemonRegion region)
        {
            await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PokemonRegion region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PokemonRegion region)
        {
            _dbContext.Set<PokemonRegion>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PokemonRegion>> GetAllAsync()
        {

            return await _dbContext.Set<PokemonRegion>().ToListAsync();
        }

        public async Task<PokemonRegion> GetByIdAsync(int id)
        {
            return await _dbContext.Set<PokemonRegion>().FindAsync(id);
        }
    }
}
