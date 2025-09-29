using MSOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderApplication.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}