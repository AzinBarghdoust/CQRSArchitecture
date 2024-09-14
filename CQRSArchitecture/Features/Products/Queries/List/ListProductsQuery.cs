using CQRSArchitecture.Features.Products.DTOs;
using MediatR;

namespace CQRSArchitecture.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;

}
