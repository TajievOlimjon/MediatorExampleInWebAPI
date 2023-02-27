using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Queries;

namespace WebMediatRExample.Models.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return await _fakeDataStore.GetProductById(request.id);
        }
    }
}
