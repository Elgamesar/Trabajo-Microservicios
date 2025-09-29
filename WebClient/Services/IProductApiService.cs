using WebClient.DTOs;

namespace WebClient.Services
{
    public interface IProductApiService
    {
        Task<HttpResponseMessage> GetAllProductsAsync();
        Task<HttpResponseMessage> GetProductByIdAsync(int productId);
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto product);
    }
}