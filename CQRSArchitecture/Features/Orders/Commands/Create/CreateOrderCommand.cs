using CQRSArchitecture.Domain;
using MediatR;

namespace CQRSArchitecture.Features.Orders.Commands.Create
{
    public record CreateOrderCommand(Guid Customer,List<OrderWithDetailsRequest> orderItmes, DateTime OrderedDate, DateTime DeliveredDate) : IRequest<Guid>;

    public class OrderWithDetailsRequest
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
    }
}
