using System.ComponentModel.DataAnnotations;

namespace Loyalty_System.Dtos.Customer
{
    public class CreateCustomerRequestDto
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string PersonalNumber { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string PhoneNumber { get; set; }
    }
}
