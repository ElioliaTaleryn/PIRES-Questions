using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ChoiceViewModel
    {
        [Required(ErrorMessage = "Le champ Label est requis.")]
        public required string Label { get; set; }
    }
}
