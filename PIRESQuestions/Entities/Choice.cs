using System.ComponentModel.DataAnnotations;

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

        [Required]
        public required int QuestionId { get; set; }
        public  Question Question { get; set; }
        public List<UserPerson>? UserPersons { get; set;}
        #endregion
    }
}
