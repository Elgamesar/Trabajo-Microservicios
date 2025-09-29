using Microsoft.EntityFrameworkCore;
using MSProductApplication.Interfaces.IRepositories;
using MSProductApplication.Validators;
using MSProductDomain.Entities;
using MSProductInfra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductInfra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Where(p => p.Stock > 0).ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            Product newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            if (newProduct != null)
            {
                _context.Products.Add(newProduct);
                _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await  _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {        
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct != null)
            {
                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
         
        }

        public async Task UpdateProductStockAsync(int productId, int quantity)
        {
            var existingProduct = await _context.Products.FindAsync(productId);

            if (existingProduct != null)
            {
                if (quantity < 0)
                {
                    throw new ArgumentException("Stock quantity cannot be negative.", nameof(quantity));
                }

                existingProduct.Stock = quantity;
                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}