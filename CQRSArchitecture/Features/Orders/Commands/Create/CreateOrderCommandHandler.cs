using CQRSArchitecture.Domain;
using CQRSArchitecture.Features.Products.Commands.Create;
using MediatR;
using CQRSArchitecture.Persistence;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace CQRSArchitecture.Features.Orders.Commands.Create
{
    public class CreateOrderCommandHandler(AppDbContext context) : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FindAsync(command.Customer);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }
            var order = new Order
            {
                CustomerId = command.Customer,
                OrderedDate = command.OrderedDate,
                DeliveredDate = command.DeliveredDate,
                OrderDetails = command.orderItmes.Select(item => new OrderDetails
                {
                    ProductId = item.ProductId,
                    Price = (decimal)item.Price,
                    Amount = item.Amount,
                }).ToList()
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);

            return order.Id;
        } 

    }
}
