using MSCustomerApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCustomerApplication.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();

        Task<CustomerDto> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(CreateCustomerDto customer);

        Task UpdateCustomerAsync(int id, UpdateCustomerDto customer);

        Task DeleteCustomerAsync(int id);
    }
}