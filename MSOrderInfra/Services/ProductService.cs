using MSOrderApplication.DTOs;
using MSOrderApplication.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderInfra.Services
{
    public class ProductService : IProductService
    {
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            HttpClient _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://localhost:8000/");

            var response = await _httpClient.GetAsync($"api/Product/GetProductById/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new KeyNotFoundException("product");
            }
            var product = await response.Content.ReadFromJsonAsync<ProductDto>();

            return product;
        }

        public async Task UpdateProductStockAfterOrder(int productId, int quantity)
        {

            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:8000/");

            if (quantity < 0)
            {
                throw new InvalidOperationException("new product stock can not be less than 0");
            }

            var updateResponse = await _httpClient.PutAsync($"api/Product/UpdateStock/{productId}/{quantity}", null);

            if (!updateResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update product stock.");
            }
        }
    }
}