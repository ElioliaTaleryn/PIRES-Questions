using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question
    {
        #region Fields
        public int Id { get; set; }

        [Required]
        public required string Label { get; set; }

        [Required]
        public required string Description { get; set; }
        #endregion
        #region Relative Fields
        public List<Choice>? Choices { get; set; }

        [Required]
        public required int FormID { get; set; }
        public required Form Form { get; set; }

        public int? TimerID { get; set; }
        public Timer Timer { get; set; }
        #endregion
    }
}
