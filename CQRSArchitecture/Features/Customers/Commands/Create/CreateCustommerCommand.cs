using MediatR;

namespace CQRSArchitecture.Features.Customers.Commands.Create
{
    public record CreateCustomerCommand(string FirstName, string LastName) : IRequest<Guid>;
}
