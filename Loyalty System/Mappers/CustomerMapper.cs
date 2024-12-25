using Loyalty_System.Dtos.Customer;
using Loyalty_System.Models;

namespace Loyalty_System.Mappers
{
    public static class CustomerMapper
    {
        public static Customer FromCreateDtoToCustomer(this CreateCustomerRequestDto createDto)
        {
            return new Customer
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                PersonalNumber = createDto.PersonalNumber,
                PhoneNumber = createDto.PhoneNumber
            };
        }
    }
}
