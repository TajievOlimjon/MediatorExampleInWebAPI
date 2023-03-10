using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Notifications;

namespace WebMediatRExample.Models.Handler
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public CacheInvalidationHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
