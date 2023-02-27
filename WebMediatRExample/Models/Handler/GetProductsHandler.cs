using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Queries;

namespace WebMediatRExample.Models.Handler 
{ 
    public class GetProductsHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
       
     
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
    }
}
