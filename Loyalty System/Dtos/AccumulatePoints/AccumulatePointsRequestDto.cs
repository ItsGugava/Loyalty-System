using System.ComponentModel.DataAnnotations;

namespace Loyalty_System.Dtos.AccumulatePoints
{
    public class AccumulatePointsRequestDto
    {
        [Required]
        public int CheckId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }
    }
}
