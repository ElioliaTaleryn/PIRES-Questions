namespace Entities
{
    public class Gender
    {
        #region Fields
        public int Id { get; set; }
        public required string Label { get; set; }
        #endregion
        #region Relatives Fields
        public List<Anonymous>? Anonymous { get; set; }
        #endregion
    }
}
