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
    public class PokemonTypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonTypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PokemonType type)
        {
            await _dbContext.AddAsync(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PokemonType type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PokemonType type)
        {
            _dbContext.Set<PokemonType>().Remove(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PokemonType>> GetAllAsync()
        {

            return await _dbContext.Set<PokemonType>().ToListAsync();
        }

        public async Task<PokemonType> GetByIdAsync(int id)
        {
            return await _dbContext.Set<PokemonType>().FindAsync(id);
        }

    }
}
