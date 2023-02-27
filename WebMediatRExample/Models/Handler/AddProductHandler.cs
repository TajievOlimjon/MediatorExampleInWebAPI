using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Command.ResponseCommand;
using WebMediatRExample.Services.ProductServices;

namespace WebMediatRExample.Models.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductCommandResponse>
    {
        private readonly IProductService _productService;
        public AddProductHandler(IProductService productService) => _productService = productService;
        public async Task<ProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           return await _productService.CreateAsync(request);
        }
    }
}

