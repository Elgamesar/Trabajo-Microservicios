using MSOrderApplication.DTOs;
using MSOrderApplication.Interfaces.IService;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderInfra.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            HttpClient client = new HttpClient();   
            client.BaseAddress = new Uri("https://localhost:8100/");

            var response = await client.GetAsync($"api/Customer/GetCustomerById/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new KeyNotFoundException("no se encontro el customer con id " + id);
            }
                var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();
                return customer;
        }
    }
}