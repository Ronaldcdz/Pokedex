using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonRegionService
    {

        private readonly PokemonRegionRepository _pokemonRegionRepository;

        public PokemonRegionService(ApplicationContext dbContext)
        {
            _pokemonRegionRepository = new(dbContext);
        }

        public async Task Add(SavePokemonRegionViewModel pokemonRegion)
        {

            PokemonRegion region = new();

            region.Name = pokemonRegion.Name;



            await _pokemonRegionRepository.AddAsync(region);
        }

        public async Task Update(SavePokemonRegionViewModel pokemonRegion)
        {
            PokemonRegion region = new();

            region.Id = pokemonRegion.Id;
            region.Name = pokemonRegion.Name;



            await _pokemonRegionRepository.UpdateAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _pokemonRegionRepository.GetByIdAsync(id);

            await _pokemonRegionRepository.DeleteAsync(region);
        }

        public async Task<SavePokemonRegionViewModel> GetByIdSavePokemonRegionViewModel(int id)
        {

            var pokemonRegion = await _pokemonRegionRepository.GetByIdAsync(id);

            SavePokemonRegionViewModel region = new SavePokemonRegionViewModel();

            region.Id = pokemonRegion.Id;
            region.Name = pokemonRegion.Name;



            return region;
        }


        public async Task<List<PokemonRegionViewModel>> GetAllViewModel()
        {

            var pokemonRegionList = await _pokemonRegionRepository.GetAllAsync();

            return pokemonRegionList.Select(pokemon => new PokemonRegionViewModel
            {

                Id = pokemon.Id,
                Name = pokemon.Name,


            }).ToList();


        }

    }
}
