using MSCustomerApplication.DTOs;
using MSCustomerApplication.Interfaces.IRepositories;
using MSCustomerApplication.Interfaces.IServices;
using MSCustomerDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCustomerApplication.Services
{
    public class CustomerService(ICustomerRepository _customerRepository) : ICustomerService
    {
        public async Task AddCustomerAsync(CreateCustomerDto customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Email))
            {
                throw new ArgumentException("Customer data cannot be null or empty");
            }
            else
            {
                await _customerRepository.AddCustomerAsync(new Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                });
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Customer existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} does not exists in database");
            }
            else
            {
                await _customerRepository.DeleteCustomerAsync(id);
            }
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();

            if (customers == null || !customers.Any())
            {
                throw new KeyNotFoundException("No customers found in database");
            }

            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                DateOfRegistration = c.DateOfRegistration
            }).ToList();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            Customer existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);

            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} does not exists in database");
            }
            else
            {
                return new CustomerDto
                {
                    Id = existingCustomer.Id,
                    Name = existingCustomer.Name,
                    Email = existingCustomer.Email
                };
            }
        }

        public async Task UpdateCustomerAsync(int id, UpdateCustomerDto customer)
        {
            Customer existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);


            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} does not exists in database");
            }
            else
            {
                if (!string.IsNullOrEmpty(customer.Name))
                {
                    existingCustomer.Name = customer.Name;
                }
                if (!string.IsNullOrEmpty(customer.Email))
                {
                    existingCustomer.Email = customer.Email;
                }
           
                await _customerRepository.UpdateCustomerAsync(existingCustomer);
            }
        }
    }
}