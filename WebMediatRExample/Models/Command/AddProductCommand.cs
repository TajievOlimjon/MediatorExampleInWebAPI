using MediatR;

namespace WebMediatRExample.Models.Command
{
    public record AddProductCommand(Product product ): IRequest<Product>;
}

