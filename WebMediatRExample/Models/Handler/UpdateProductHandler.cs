using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Command.ResponseCommand;
using WebMediatRExample.Services.ProductServices;

namespace WebMediatRExample.Models.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductCommandResponse>
    {
        private readonly IProductService _productService;
        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
          return  await _productService.UpdateAsync(request);
        }
    }
}
