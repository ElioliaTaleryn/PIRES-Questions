using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Duration
    {
        //Attributs propres
        public int Id { get; set; }
        [Required]
        public required  DateTime Start {  get; set; }
        [Required]
        public required DateTime End { get; set; }

        //Liens des autres entités
        // n-n
        public List<Form>? Forms { get; set; }
    }
}
