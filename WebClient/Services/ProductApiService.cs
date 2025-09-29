using WebClient.DTOs;

namespace WebClient.Services
{
    public class ProductApiService : IProductApiService
    {
        HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDto product)
        {
            return await _httpClient.PostAsJsonAsync("api/Product/AddProduct", product);

        }
        public async Task<HttpResponseMessage> GetAllProductsAsync()
        {
           return await _httpClient.GetAsync("api/Product/GetAllProducts");
        }
        public async Task<HttpResponseMessage> GetProductByIdAsync(int productId)
        {
            return await _httpClient.GetAsync($"api/Product/GetProductById/{productId}");
        }
    }
}