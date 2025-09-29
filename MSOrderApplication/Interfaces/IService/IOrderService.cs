using MSOrderApplication.DTOs;
using MSOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderApplication.Interfaces.IService
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto order);

        Task<List<OrderListDto>> GetAllOrdersAsync();
    }
}