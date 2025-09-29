using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductApplication.DTOs;
using MSProductApplication.Interfaces.IServices;
using MSProductDomain.Entities;

namespace APIProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return StatusCode(200,products);
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);

                return StatusCode(200, product);


            }
            catch(Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDTO product)
        {
            try
            {
                await _productService.AddProductAsync(product);
                return StatusCode(201, "Producto creado exitosamente");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return StatusCode(203, "Producto eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO product)
        {
            try
            {
                await _productService.UpdateProductAsync(id, product);
                return StatusCode(200, "Producto actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
         
        }
        [HttpPut]   
        [Route("UpdateStock/{id}/{NewStock}")]
        public async Task<IActionResult> UpdateStock(int id, int NewStock)
        {
            try
            {
                await _productService.UpdateProductStockAsync(id, NewStock);
                return StatusCode(200, "Stock actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}