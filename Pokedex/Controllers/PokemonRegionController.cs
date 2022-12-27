using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonRegionController : Controller
    {
        private readonly PokemonRegionService _pokemonRegionService;

        public PokemonRegionController(ApplicationContext dbContext)
        {
            _pokemonRegionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonRegionService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            return View("SavePokemonRegion", new SavePokemonRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonRegionViewModel region)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonRegion", region);
            }

            await _pokemonRegionService.Add(region);
            return RedirectToRoute(new { controller = "PokemonRegion", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {


            return View("SavePokemonRegion", await _pokemonRegionService.GetByIdSavePokemonRegionViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonRegionViewModel region)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonRegion", region);
            }


            await _pokemonRegionService.Update(region);
            return RedirectToRoute(new { controller = "PokemonRegion", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {


            return View(await _pokemonRegionService.GetByIdSavePokemonRegionViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {



            await _pokemonRegionService.Delete(id);
            return RedirectToRoute(new { controller = "PokemonRegion", action = "Index" });
        }

    }
}
