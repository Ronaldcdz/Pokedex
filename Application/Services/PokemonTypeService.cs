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
    public class PokemonTypeService
    {

        private readonly PokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeService(ApplicationContext dbContext)
        {
            _pokemonTypeRepository = new(dbContext);
        }


        public async Task Add(SavePokemonTypeViewModel pokemonType)
        {

            PokemonType type = new();

            type.Name = pokemonType.Name;



            await _pokemonTypeRepository.AddAsync(type);
        }

        public async Task Update(SavePokemonTypeViewModel pokemonType)
        {
            PokemonType type = new();

            type.Id = pokemonType.Id;
            type.Name = pokemonType.Name;



            await _pokemonTypeRepository.UpdateAsync(type);
        }

        public async Task Delete(int id)
        {
            var type = await _pokemonTypeRepository.GetByIdAsync(id);

            await _pokemonTypeRepository.DeleteAsync(type);
        }

        public async Task<SavePokemonTypeViewModel> GetByIdSavePokemonTypeViewModel(int id)
        {

            var pokemonType = await _pokemonTypeRepository.GetByIdAsync(id);

            SavePokemonTypeViewModel type = new SavePokemonTypeViewModel();

            type.Id = pokemonType.Id;
            type.Name = pokemonType.Name;



            return type;
        }


        public async Task<List<PokemonTypeViewModel>> GetAllViewModel()
        {

            var pokemonTypeList = await _pokemonTypeRepository.GetAllAsync();

            return pokemonTypeList.Select(type => new PokemonTypeViewModel
            {

                Id = type.Id,
                Name = type.Name,


            }).ToList();


        }

    }
}
