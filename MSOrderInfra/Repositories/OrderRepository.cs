using Microsoft.EntityFrameworkCore;
using MSOrderApplication.Interfaces.IRepository;
using MSOrderDomain.Entities;
using MSOrderInfra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderInfra.Repositories
{
    public class OrderRepository(OrderDbContext _context) : IOrderRepository
    {
        public async Task CreateOrder(Order order)
        {
            if(order != null)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Items).ToListAsync();
        }
    }
}