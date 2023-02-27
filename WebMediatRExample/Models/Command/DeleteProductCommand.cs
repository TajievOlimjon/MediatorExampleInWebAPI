using MediatR;

namespace WebMediatRExample.Models.Command
{
    public record DeleteProductCommand(int id) : IRequest<int>;
}
