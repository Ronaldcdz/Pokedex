using Application.Services;
using Application.ViewModels;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Pkcs;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly PokemonRegionService _pokemonRegionService;
        private readonly PokemonTypeService _pokemonTypeService;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _pokemonRegionService = new(dbContext);
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

                        if (pokemon[i].TypePrimaryId == pokemon[i].TypeSecondaryId)
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

        public async Task<IActionResult> Create()
        {
            SavePokemonViewModel pk = new SavePokemonViewModel();

            pk.Regions = await _pokemonRegionService.GetAllViewModel();
            pk.Types = await _pokemonTypeService.GetAllViewModel();

            ViewBag.Regions = pk.Regions.Select(p => new SelectListItem {Value = p.Id.ToString()  ,Text = p.Name });
            ViewBag.Types = pk.Types.Select(p => new SelectListItem {Value = p.Id.ToString()  ,Text = p.Name });

            return View("SavePokemon", pk);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel pokemon)
        {
            if(!ModelState.IsValid)
            {
                pokemon.Regions = await _pokemonRegionService.GetAllViewModel();
                pokemon.Types = await _pokemonTypeService.GetAllViewModel();


                ViewBag.Regions = pokemon.Regions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
                ViewBag.Types = pokemon.Types.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

                return View("SavePokemon", pokemon);
            }

            await _pokemonService.Add(pokemon);
            return RedirectToRoute(new {controller = "Pokemon", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            SavePokemonViewModel pk = new SavePokemonViewModel();

            pk = await _pokemonService.GetByIdSavePokemonViewModel(id);

            pk.Regions = await _pokemonRegionService.GetAllViewModel();
            pk.Types = await _pokemonTypeService.GetAllViewModel();


            ViewBag.Regions = pk.Regions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
            ViewBag.Types = pk.Types.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });


            return View("SavePokemon", pk);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel pokemon)
        {
            if (!ModelState.IsValid)
            {
                pokemon.Regions = await _pokemonRegionService.GetAllViewModel();
                pokemon.Types = await _pokemonTypeService.GetAllViewModel();


                ViewBag.Regions = pokemon.Regions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
                ViewBag.Types = pokemon.Types.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

                return View("SavePokemon", pokemon);
            }



            await _pokemonService.Update(pokemon);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {


            return View( await _pokemonService.GetByIdSavePokemonViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
           


            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}
