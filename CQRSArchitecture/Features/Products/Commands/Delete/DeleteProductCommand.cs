using MediatR;

namespace CQRSArchitecture.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest;

}
