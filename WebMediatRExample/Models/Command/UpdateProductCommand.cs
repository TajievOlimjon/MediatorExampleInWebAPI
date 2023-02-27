using MediatR;

namespace WebMediatRExample.Models.Command
{
    public record UpdateProductCommand(Product product) : IRequest<Product>;
}
