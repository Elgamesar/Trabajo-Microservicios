using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSCustomerApplication.DTOs;
using MSCustomerApplication.Interfaces.IServices;

namespace APICustomers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService _customerService) : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return StatusCode(200, customers);

            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return StatusCode(200, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerDto customer)
        {
            try
            {
                await _customerService.AddCustomerAsync(customer);
                return StatusCode(201, "Customer created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto customer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(id, customer);
                return StatusCode(200, "Customer updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return StatusCode(200, "Customer deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

    }
}