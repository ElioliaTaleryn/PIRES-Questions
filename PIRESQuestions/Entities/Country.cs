using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Country
    {
        #region Fields
        public int Id { get; set; }
        public required string Name { get; set; }
        #endregion
        #region Relatives Fields
        public List<Anonymous>? Anonymous { get; set; }
        #endregion
    }
}
