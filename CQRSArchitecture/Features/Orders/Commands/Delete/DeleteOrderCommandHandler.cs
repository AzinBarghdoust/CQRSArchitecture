using CQRSArchitecture.Features.Products.Commands.Delete;
using CQRSArchitecture.Persistence;
using MediatR;

namespace CQRSArchitecture.Features.Orders.Commands.Delete
{
    public class DeleteOrderCommandHandler(AppDbContext context) : IRequestHandler<DeleteOrderCommand>
    {
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(request.Id);
            if (order == null) return;
            context.Products.Remove(order);
            await context.SaveChangesAsync();
        }
    }
}
