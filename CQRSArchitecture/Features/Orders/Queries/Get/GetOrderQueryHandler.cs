using CQRSArchitecture.Features.Orders.DTOs;
using CQRSArchitecture.Features.Products.DTOs;
using CQRSArchitecture.Features.Products.Queries.Get;
using CQRSArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSArchitecture.Features.Orders.Queries.Get
{
    public class GetOrderQueryHandler(AppDbContext context)
    : IRequestHandler<GetOrderQuery, OrderDto?>
    {
        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            // Fetch the order along with related customer and order details
            var order = await context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.Id == request.Id)
                .Select(o => new OrderDto
                {
                    OrderId = o.Id,
                    CustomerId = o.Customer.Id,
                    CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
                    OrderedDate = (DateTime)o.OrderedDate,
                    DeliveredDate = (DateTime)o.DeliveredDate,
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailsDto
                    {
                        ProductId = od.Product.Id,
                        ProductName = od.Product.Name,
                        Amount = od.Amount,
                        Price = od.Price
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return order;
        }
    }
}
