using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Services.ProductServices;

namespace WebMediatRExample.Models.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           return await _productService.DeleteAsync(request.Id);
        }
    }
}
