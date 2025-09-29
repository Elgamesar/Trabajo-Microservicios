namespace MSOrderDomain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            TotalAmount += item.UnitPrice * item.Quantity;
        }

        public void RemoveItem(OrderItem item)
        {
            if (Items.Remove(item))
            {
                TotalAmount -= item.UnitPrice * item.Quantity;
            }
        }
    }
}