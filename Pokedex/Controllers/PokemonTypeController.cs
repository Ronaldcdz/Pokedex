using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonTypeController : Controller
    {

        private readonly PokemonTypeService _pokemonTypeService;

        public PokemonTypeController(ApplicationContext dbContext)
        {
            _pokemonTypeService = new(dbContext);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _pokemonTypeService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            return View("SavePokemonType", new SavePokemonTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonTypeViewModel type)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", type);
            }

            await _pokemonTypeService.Add(type);
            return RedirectToRoute(new { controller = "PokemonType", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {


            return View("SavePokemonType", await _pokemonTypeService.GetByIdSavePokemonTypeViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonTypeViewModel type)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", type);
            }


            await _pokemonTypeService.Update(type);
            return RedirectToRoute(new { controller = "PokemonType", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {

            return View(await _pokemonTypeService.GetByIdSavePokemonTypeViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _pokemonTypeService.Delete(id);
            return RedirectToRoute(new { controller = "PokemonType", action = "Index" });
        }



    }
}
