using MSOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderApplication.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);

        Task<List<Order>> GetAllOrdersAsync();
    }
}