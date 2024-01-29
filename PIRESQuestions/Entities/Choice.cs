using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Choice
    {
        #region Fields
        public int Id { get; set; }

        [Required]
        public required string Label { get; set; }
        #endregion
        #region Relative Fields

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public List<UserPerson>? UserPersons { get; set;}
        #endregion
    }
}
