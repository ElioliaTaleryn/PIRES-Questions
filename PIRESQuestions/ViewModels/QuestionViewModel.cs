using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class QuestionViewModel
    {
        [Required(ErrorMessage = "Le champ Label est requis.")]
        public required string Label { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Le champ FormId est requis.")]
        public required int FormId { get; set; }

        public List<ChoiceViewModel> Choices { get; set; } = new List<ChoiceViewModel>();
    }
}
