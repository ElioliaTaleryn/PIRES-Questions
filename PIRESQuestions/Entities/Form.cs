using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Form
    {
        #region  Fields
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public required string Title { get; set; }
        [Required]
        public required string Description { get; set; }
        #endregion
        #region Relative Fields N-N
        public List<Question>? Questions { get; set; }
        #endregion
        #region Relative Fields 0-1
        [ForeignKey("TimerCD")]
        public int? TimerCDId { get; set; }
        public TimerCD? TimerCD { get; set; }
        [ForeignKey("Period")]
        public int? PeriodId { get; set; }
        public Period? Period { get; set; }
        #endregion
        #region Relative Fields 1-1
        [Required]
        [ForeignKey("Status")]
        public required int StatusId { get; set; }
        public Status Status { get; set; }
        [Required]
        [ForeignKey("Category")]
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [ForeignKey("UserPerson")]
        public required string UserPersonId { get; set; }
        public UserPerson UserPerson { get; set; }
        #endregion
    }
}
