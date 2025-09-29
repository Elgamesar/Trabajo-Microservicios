using WebClient.DTOs;

namespace WebClient.Services
{
    public class CustomerApiService : ICustomerApiService
    {
        HttpClient _httpClient;
        public CustomerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<HttpResponseMessage> CreateCustomerAsync(CreateCustomerDto customer)
        {
            return await _httpClient.PostAsJsonAsync("api/Customer/AddCustomer", customer);
        }
        public async Task<HttpResponseMessage> GetAllCustomersAsync()
        {
            return await _httpClient.GetAsync("api/Customer/GetAllCustomers");
        }
        public async Task<HttpResponseMessage> GetCustomerByIdAsync(int customerId)
        {
            return await _httpClient.GetAsync($"api/Customer/GetCustomerById/{customerId}");
        }
    }
}