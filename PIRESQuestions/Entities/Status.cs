using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Status
    {
        #region Fields
        public int Id { get; set; }
        [Required]
        public required string Label { get; set; }
        #endregion
        #region Relative Fields N-N
        public List<Form>? Forms { get; set; }
        #endregion
    }
}
