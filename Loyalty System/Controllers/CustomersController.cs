using Loyalty_System.Dtos.Customer;
using Loyalty_System.Interfaces;
using Loyalty_System.Mappers;
using Loyalty_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequestDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Customer customer = customerDto.FromCreateDtoToCustomer();
            bool wasCreated = await _customerRepo.CreateAsync(customer);
            if (!wasCreated)
            {
                return BadRequest("Personal Number is used");
            }
            return Ok(customer);
        }

        [HttpGet]
        [Route("{personalNumber}")]
        public async Task<IActionResult> GetByPersonalNumber([FromRoute] string personalNumber)
        {
            Customer? customer = await _customerRepo.GetByPersonalNumberAsync(personalNumber);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut]
        [Route("{personalNumber}")]
        public async Task<IActionResult> Update([FromRoute] string personalNumber, [FromBody] UpdateCustomerRequestDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Customer? customer = await _customerRepo.UpdateAsync(personalNumber, customerDto);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{personalNumber}")]
        public async Task<IActionResult> Delete([FromRoute] string personalNumber)
        {
            Customer? customer = await _customerRepo.DeleteAsync(personalNumber);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok("Customer is deleted");
        }
    }
}
