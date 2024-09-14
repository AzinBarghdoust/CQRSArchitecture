using CQRSArchitecture.Domain.Entities;

namespace CQRSArchitecture.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
        public Product() { }
        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            
        }
    }
}
