using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class UserPerson : IdentityUser
    {
        #region Fields
        [MaxLength(150)]
        public string? FirstName { get; set; }
        [MaxLength(150)]
        public string? LastName { get; set; }
        [Required]
        public required DateOnly DateOfBirth { get; set; }
        #endregion
        #region Relatives Fields
        public List<Form>? Forms { get; set; }
        public int? GenderId { get; set; }
        public Gender? Gender {  get; set; } 
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        #endregion
    }
}
