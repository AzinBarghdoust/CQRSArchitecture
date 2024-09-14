using CQRSArchitecture.Features.Products.DTOs;
using MediatR;

namespace CQRSArchitecture.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;

}
