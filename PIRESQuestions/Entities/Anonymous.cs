using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Anonymous
    {
        #region Fields
        public int Id { get; set; }
        public int Age { get; set; }
        #endregion
        #region Relatives Fields
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        #endregion
    }
}
