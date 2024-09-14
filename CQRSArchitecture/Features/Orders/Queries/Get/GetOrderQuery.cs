using CQRSArchitecture.Features.Orders.DTOs;
using CQRSArchitecture.Features.Products.DTOs;
using MediatR;

namespace CQRSArchitecture.Features.Orders.Queries.Get
{
    public record GetOrderQuery(Guid Id) : IRequest<OrderDto>;
}
