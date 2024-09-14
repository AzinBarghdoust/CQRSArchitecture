namespace CQRSArchitecture.Features.Orders.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

