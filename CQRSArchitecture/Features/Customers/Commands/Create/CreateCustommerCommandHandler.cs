using Azure.Core;
using CQRSArchitecture.Domain;
using CQRSArchitecture.Features.Orders.Commands.Create;
using CQRSArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CQRSArchitecture.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler(AppDbContext context) : IRequestHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            context.Customers.Add(customer);
            await context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
