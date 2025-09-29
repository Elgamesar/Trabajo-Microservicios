using WebClient.DTOs;

namespace WebClient.Services
{
    public class OrderApiService : IOrderApiService
    {
        private readonly HttpClient _httpClient;
        public OrderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<HttpResponseMessage> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Order/CreateOrder/", orderDto);

            return response;
        }
        public async Task<HttpResponseMessage> GetAllOrdersAsync()
        {
            return await _httpClient.GetAsync("api/Order/GetAllOrders");
        }
    }
}