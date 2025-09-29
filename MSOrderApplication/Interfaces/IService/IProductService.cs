using MSOrderApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderApplication.Interfaces.IService
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);

        Task UpdateProductStockAfterOrder(int productId, int quantity);
    }
}