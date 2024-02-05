using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer
    {
        #region Fields
        public int Id { get; set; }
        [Required]
        public required DateTime Horodatage { get; set; }
        #endregion
        #region Relative Fields
        [Required]
        public required int QuestionId { get; set; }
        public Question Question { get; set; }
        [Required]
        public required int ChoiceId { get; set; }
        public Choice Choice { get; set; }
        [Required]
        public int AnonymousId { get; set; }
        public Anonymous Anonymous { get; set; }
        #endregion
    }
}
