using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;

namespace WebMediatRExample.Models.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public UpdateProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.UpdateProduct(request.product);

            return request.product;
        }
    }
}
