using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Queries;
using WebMediatRExample.Models.Queries.QueryResponse;
using WebMediatRExample.Services.ProductServices;

namespace WebMediatRExample.Models.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductQueryResponse>
    {
        private readonly IProductService _productService;
        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return await _productService.GetAsync(request.Id);
        }
    }
}
