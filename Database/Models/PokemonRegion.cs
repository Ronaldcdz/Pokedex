using System;
namespace Database.Models
{
    public class PokemonRegion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation Property

        public ICollection<Pokemon> Pokemons {get; set;}



    }
}

