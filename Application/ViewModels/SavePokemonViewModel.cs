using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "You must type the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must choose the Image Url")]
        public string ImagePath { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must choose a region")]
        public int RegionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must choose a Type")]
        public int TypePrimaryId { get; set; }

        public int TypeSecondaryId { get; set; }

        public List<PokemonRegionViewModel>? Regions { get; set; }
        public List<PokemonTypeViewModel>? Types { get; set; }


    }
}
