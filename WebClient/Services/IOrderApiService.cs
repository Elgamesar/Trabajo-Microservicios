using WebClient.DTOs;

namespace WebClient.Services
{
    public interface IOrderApiService
    {
        Task<HttpResponseMessage> CreateOrderAsync(CreateOrderDto orderDto);
        Task<HttpResponseMessage> GetAllOrdersAsync();
    }
}