namespace Loyalty_System.Dtos.AccumulatePoints
{
    public class AccumulatePointsLogDto
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
