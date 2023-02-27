using MediatR;
using SQLitePCL;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Queries;
using WebMediatRExample.Models.Queries.QueryResponse;
using WebMediatRExample.Repozitories.IRepozitory;
using WebMediatRExample.Services.ProductServices;

namespace WebMediatRExample.Models.Handler 
{ 
    public class GetProductsHandler: IRequestHandler<GetAllProductsQuery, List<ProductQueryResponse>>
    {
        private readonly IProductService _productService;

        public GetProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductQueryResponse>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync();

        }
    }
}
