using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Notifications;

namespace WebMediatRExample.Models.Handler
{
    public class EmailHandler: INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
    
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
