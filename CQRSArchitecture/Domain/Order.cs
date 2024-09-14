using CQRSArchitecture.Domain.Entities;

namespace CQRSArchitecture.Domain
{
    public class Order : BaseEntity
    {
        public List<OrderDetails> OrderDetails { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

    }
    public class OrderDetails : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price {  get; set; }
        public int Amount {  get; set; }
        

    }
}
