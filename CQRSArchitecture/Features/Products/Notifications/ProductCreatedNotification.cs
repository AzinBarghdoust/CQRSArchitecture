using MediatR;

namespace CQRSArchitecture.Features.Products.Notifications
{
    public record ProductCreatedNotification(Guid Id) : INotification;
    

}
