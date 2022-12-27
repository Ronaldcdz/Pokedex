using System;
namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public int RegionId { get; set; }

        public int TypePrimaryId { get; set; }

        public int TypeSecondaryId { get; set; }

        //Navigation Property

        public PokemonRegion Region { get; set; }

        public ICollection<PokemonType> Type { get; set; }


    }
}

