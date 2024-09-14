using CQRSArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSArchitecture.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "iPhone 15 Pro", 
                    Description = "Apple's latest flagship smartphone with a ProMotion display and improved cameras", 
                    Price = 999.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name ="Dell XPS 15", 
                    Description="Dell's high-performance laptop with a 4K InfinityEdge display",
                    Price = 1899.99m 
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Sony WH-1000XM4",
                    Description = "Sony's top-of-the-line wireless noise-canceling headphones",
                    Price = 349.99m
                }
            );
        }
        public async Task<List<Order>> GetOrdersWithDeliveryGapLessThanThreeDaysAsync()
        {
            return await Orders
                .Where(o => !(!o.DeliveredDate.HasValue && !o.OrderedDate.HasValue))
                .Where(o => EF.Functions.DateDiffDay(o.OrderedDate, o.DeliveredDate) < 3) 
                .ToListAsync();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("codewithmukesh");
        //}
    }
}
