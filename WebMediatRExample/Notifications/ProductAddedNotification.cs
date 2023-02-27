using MediatR;
using WebMediatRExample.Models;

namespace WebMediatRExample.Notifications
{
    public record ProductAddedNotification(Product product):INotification;
}
