namespace Loyalty_System.Models
{
    public class AccumulatePointsLog
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
    }
}
