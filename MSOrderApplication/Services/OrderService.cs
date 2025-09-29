using MSOrderApplication.DTOs;
using MSOrderApplication.Interfaces.IRepository;
using MSOrderApplication.Interfaces.IService;
using MSOrderDomain.Entities;

namespace MSOrderApplication.Services
{
    public class OrderService(
        IOrderRepository _orderRepository,
        IProductService _productService,
        ICustomerService _customerService
        ) : IOrderService
    {
        public async Task<Order> CreateOrderAsync(CreateOrderDto orderDto)
        {
            try
            {
            
            var customer = await _customerService.GetCustomerByIdAsync(orderDto.CustomerId);

                Order newOrder = new();
                newOrder.CustomerId = orderDto.CustomerId;
                newOrder.OrderDate = DateTime.Now;
                newOrder.CustomerName = customer.Name;

                foreach (var itemDto in orderDto.Items)
                {
                    var product = await _productService.GetProductByIdAsync(itemDto.ProductId);

                    var orderItemDto = new OrderItemDto
                    {
                        ProductId = product.Id,
                        Quantity = itemDto.Quantity
                        
                    };

                    var orderItem = new OrderItem
                    {
                        ProductId = orderItemDto.ProductId,
                        Quantity = orderItemDto.Quantity,
                        UnitPrice = product.Price,
                        OrderId = newOrder.Id,
                        ProductName = product.Name
                    };

                    newOrder.AddItem(orderItem);

                    await _productService.UpdateProductStockAfterOrder(product.Id, (product.Stock - itemDto.Quantity));
                }

                await _orderRepository.CreateOrder(newOrder);

                return newOrder;
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating order: {ex.Message}");
            }   
        }

        public async Task<List<OrderListDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();  

            var orderListDtos = orders.Select(o => new OrderListDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CustomerName = o.CustomerName,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Items = o.Items.Select(i => new OrderItemListDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    ProductName = i.ProductName,
                    UnitPrice = i.UnitPrice
                }).ToList()
            }).ToList();

            return orderListDtos;

        }
    }
}