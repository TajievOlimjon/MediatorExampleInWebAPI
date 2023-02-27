using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;

namespace WebMediatRExample.Models.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);

            return request.product;
        }
    }
}
