using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly PokemonTypeRepository _pokemonTypeRepository;

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new (dbContext);
            _pokemonTypeRepository = new (dbContext);
        }

        public async Task Add(SavePokemonViewModel pk)
        {

            Pokemon pokemon = new();

            pokemon.Name = pk.Name;
            pokemon.ImagePath = pk.ImagePath;
            pokemon.RegionId = pk.RegionId;
            pokemon.TypePrimaryId = pk.TypePrimaryId;
            pokemon.TypeSecondaryId = pk.TypeSecondaryId;



            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task Update(SavePokemonViewModel pk)
        {
            Pokemon pokemon = new();
            
            pokemon.Id = pk.Id;
            pokemon.Name = pk.Name;
            pokemon.ImagePath = pk.ImagePath;
            pokemon.RegionId = pk.RegionId;
            pokemon.TypePrimaryId = pk.TypePrimaryId;
            pokemon.TypeSecondaryId = pk.TypeSecondaryId;



            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            await _pokemonRepository.DeleteAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSavePokemonViewModel(int id)
        {

            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel pk = new SavePokemonViewModel();

            pk.Id = pokemon.Id;
            pk.Name = pokemon.Name;
            pk.ImagePath = pokemon.ImagePath;
            pk.RegionId = pokemon.RegionId;
            pk.TypePrimaryId = pokemon.TypePrimaryId;
            pk.TypeSecondaryId = pokemon.TypeSecondaryId;



            return pk;
        }

            public async Task<List<PokemonViewModel>> GetAllViewModel()
        {

            var pokemonList = await _pokemonRepository.GetAllAsync();

            return pokemonList.Select(pokemon => new PokemonViewModel { 
            
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                TypePrimaryId = (int)pokemon.TypePrimaryId,
                TypeSecondaryId = (int)pokemon.TypeSecondaryId,
                Region = pokemon.Region,
                Types = pokemon.Type.ToList()
                
            
            }).ToList();


        }

       


    }
}
