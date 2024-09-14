using MediatR;

namespace CQRSArchitecture.Features.Orders.Commands.Delete
{
    public record DeleteOrderCommand(Guid Id) : IRequest;
}
