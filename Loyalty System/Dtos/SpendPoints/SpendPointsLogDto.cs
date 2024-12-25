namespace Loyalty_System.Dtos.SpendPoints
{
    public class SpendPointsLogDto
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
