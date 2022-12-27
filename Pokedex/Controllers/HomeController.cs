using System.Diagnostics;
using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers;

public class HomeController : Controller
{
    private readonly PokemonService _pokemonService;
    private readonly PokemonTypeService _pokemonTypeService;

    public HomeController(ApplicationContext dbContext)
    {
        _pokemonService = new(dbContext);
        _pokemonTypeService = new(dbContext);
    }

    public async Task<IActionResult> Index()
    {
        SavePokemonViewModel pk = new SavePokemonViewModel();

        pk.Types = await _pokemonTypeService.GetAllViewModel();

        List<PokemonViewModel> list = pk.Types.Select(p => new PokemonViewModel
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();


        List<PokemonViewModel> pokemon = new();


        pokemon = await _pokemonService.GetAllViewModel();

        for (int i = 0; i < pokemon.Count; i++)
        {
            foreach (var item2 in list)
            {
                if (pokemon[i].TypePrimaryId == item2.Id)
                {
                    pokemon[i].TypePrimary = item2.Name.ToString();

                    if(pokemon[i].TypePrimaryId == pokemon[i].TypeSecondaryId)
                    {
                        pokemon[i].TypeSecondary = item2.Name.ToString();
                    }
                }
                else if (pokemon[i].TypeSecondaryId == item2.Id)
                {
                    pokemon[i].TypeSecondary = item2.Name.ToString();
                }



            }
        }
        return View(pokemon);
    }


   
}

