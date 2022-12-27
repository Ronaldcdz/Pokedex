using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must type the Type")]
        public string Name { get; set; }

    }
}
