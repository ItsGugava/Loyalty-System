using Loyalty_System.Dtos.Customer;
using Loyalty_System.Models;

namespace Loyalty_System.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CreateAsync(Customer customer);
        Task<Customer?> DeleteAsync(string personalNumber);
        Task<Customer?> GetByPersonalNumberAsync(string personalNumber);
        Task<Customer?> UpdateAsync(string personalNumber, UpdateCustomerRequestDto customerDto);
    }
}
