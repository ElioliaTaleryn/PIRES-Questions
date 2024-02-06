using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Choice
    {
        #region Fields
        public int Id { get; set; }

        [Required(ErrorMessage = "la réponse est requise")]
        public required string Label { get; set; }
        #endregion
        #region Relative Fields

        public List<Question>? Questions { get; set; }
        public List<UserPerson>? UserPersons { get; set; }
        #endregion
    }
}
