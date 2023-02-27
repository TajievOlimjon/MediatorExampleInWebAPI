using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;

namespace WebMediatRExample.Models.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly FakeDataStore _fakeDataStore;
        public DeleteProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteProduct(request.id);
            return request.id;
        }
    }
}
