using System.ComponentModel.DataAnnotations;

namespace Loyalty_System.Dtos.Customer
{
    public class UpdateCustomerRequestDto
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string PhoneNumber { get; set; }
    }
}
