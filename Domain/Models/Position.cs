namespace Domain.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }

        #region Reverse Navigation
        public ICollection<Worker> Workers { get; set; }
        #endregion
    }
}
