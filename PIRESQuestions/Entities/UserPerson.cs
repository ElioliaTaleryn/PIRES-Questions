using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class UserPerson : IdentityUser
    {
        #region Fields
        [Required]
        [MaxLength(150)]
        public override required string UserName { get; set; }
        [Required]
        public override required string Email { get; set; }
        [MaxLength(150)]
        public string? FirstName { get; set; }
        [MaxLength(150)]
        public string? LastName { get; set; }
        [Required]
        public required DateOnly DateOfBirth { get; set; }
        #endregion
        #region Relatives Fields
        public List<Form>? Forms { get; set; }
        #endregion 
    }
}
