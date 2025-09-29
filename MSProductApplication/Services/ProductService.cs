using MSProductApplication.DTOs;
using MSProductApplication.Interfaces.IRepositories;
using MSProductApplication.Interfaces.IServices;
using MSProductApplication.Validators;
using MSProductDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductValidator _validator;

        public ProductService(IProductRepository productRepository, ProductValidator validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task AddProductAsync(CreateProductDTO product)
        {
           CreateProductDTO productDTO = new CreateProductDTO
           {
               Name = product.Name,
               Description = product.Description,
               Price = product.Price,
               Stock = product.Stock
           };

           Product newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            var validationResult = _validator.Validate(newProduct);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid product data");
            }
            await _productRepository.AddProductAsync(newProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
              
            Product existingProduct = await _productRepository.GetProductByIdAsync(id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"product with id: {id} does not exists in database");
            }
            else
            {
                await _productRepository.DeleteProductAsync(id);
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if(product == null)
            {
                throw new KeyNotFoundException($"product with id: {id} does not exists in database");
            }
            return product;
        }

        public async Task UpdateProductAsync(int id, UpdateProductDTO productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id)
                ?? throw new KeyNotFoundException($"product with id: {id} does not exists in database");

            if (!string.IsNullOrWhiteSpace(productDto.Name))
                existingProduct.Name = productDto.Name;
            if (!string.IsNullOrWhiteSpace(productDto.Description))
                existingProduct.Description = productDto.Description;
            if (productDto.Price.HasValue)
                existingProduct.Price = productDto.Price.Value;
            if (productDto.Stock.HasValue)
                existingProduct.Stock = productDto.Stock.Value;

            var validationResult = _validator.Validate(existingProduct);
            if (!validationResult.IsValid)
                throw new ArgumentException("Invalid product data");

            await _productRepository.UpdateProductAsync(id, existingProduct);
        }

        public async Task UpdateProductStockAsync(int productId, int quantity)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productId);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"product with id: {productId} does not exists in database");
            }

            existingProduct.Stock = quantity;

            await _productRepository.UpdateProductAsync(productId, existingProduct);
        }
    }
}