using Loyalty_System.Data;
using Loyalty_System.Dtos.Customer;
using Loyalty_System.Interfaces;
using Loyalty_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_System.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Customer customer)
        {
            if (_context.Customers.Any(c => c.PersonalNumber.Equals(customer.PersonalNumber)))
            {
                return false;
            }
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer?> DeleteAsync(string personalNumber)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.PersonalNumber.Equals(personalNumber));
            if (customer == null)
            {
                return null;
            }
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetByPersonalNumberAsync(string personalNumber)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.PersonalNumber.Equals(personalNumber));
            return customer;
        }

        public async Task<Customer?> UpdateAsync(string personalNumber, UpdateCustomerRequestDto customerDto)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.PersonalNumber.Equals(personalNumber));
            if (customer == null)
            {
                return null;
            }
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.PhoneNumber = customerDto.PhoneNumber;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
