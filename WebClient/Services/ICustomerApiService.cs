using WebClient.DTOs;

namespace WebClient.Services
{
    public interface ICustomerApiService
    {
        Task<HttpResponseMessage> GetAllCustomersAsync();
        Task<HttpResponseMessage> GetCustomerByIdAsync(int customerId);
        Task<HttpResponseMessage> CreateCustomerAsync(CreateCustomerDto customer);
    }
}