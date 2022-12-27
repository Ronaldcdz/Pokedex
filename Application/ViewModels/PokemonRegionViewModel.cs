using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonRegionViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation Property

        public ICollection<Pokemon> Pokemons { get; set; }

    }
}
