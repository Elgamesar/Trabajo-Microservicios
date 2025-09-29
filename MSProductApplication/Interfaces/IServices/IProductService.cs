using MSProductApplication.DTOs;
using MSProductDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductApplication.Interfaces.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDTO product);
        Task UpdateProductAsync(int id, UpdateProductDTO product);
        Task DeleteProductAsync(int id);

        Task UpdateProductStockAsync(int productId, int quantity);  
    }
}
