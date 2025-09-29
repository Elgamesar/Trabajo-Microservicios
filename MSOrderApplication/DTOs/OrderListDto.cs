using MSOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrderApplication.DTOs
{
    public class OrderListDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string CustomerName { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public List<OrderItemListDto> Items { get; set; } = new List<OrderItemListDto>();
    }
}