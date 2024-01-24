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

        public string? Description { get; set; }
        #endregion
        #region Relative Fields
        public List<Choice>? Choices { get; set; }

        [Required]
        public required int FormId { get; set; }
        public Form Form { get; set; }

        public int? TimerCDId { get; set; }
        public TimerCD TimerCD { get; set; }
        #endregion
    }
}
