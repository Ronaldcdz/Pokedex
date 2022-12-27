using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public int? TypePrimaryId { get; set; }
        public string? TypePrimary { get; set; }
        public int? TypeSecondaryId { get; set; }
        public string? TypeSecondary { get; set; }

        public PokemonRegion Region { get; set; }

        public List<PokemonType> Types { get; set; }

    }
}
