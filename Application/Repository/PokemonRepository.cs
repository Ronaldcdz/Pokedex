using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
             _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            
            return await _dbContext.Set<Pokemon>().Include(p => p.Type).Include(p => p.Region).ToListAsync();
        }

        
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }

        public async Task<List<PokemonRegion>> GetRegionAsync()
        {
            return await _dbContext.Set<PokemonRegion>().ToListAsync();
        }

        public async Task<List<PokemonType>> GetTypeAsync()
        {
            return await _dbContext.Set<PokemonType>().ToListAsync();
        }


    }
}
