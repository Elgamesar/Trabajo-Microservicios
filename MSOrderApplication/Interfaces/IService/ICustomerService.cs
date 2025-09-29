using MSOrderApplication.DTOs;

namespace MSOrderApplication.Interfaces.IService
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int id);
    }
}