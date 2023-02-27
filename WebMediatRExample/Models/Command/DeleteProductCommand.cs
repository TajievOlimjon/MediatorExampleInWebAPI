using MediatR;

namespace WebMediatRExample.Models.Command
{
    public record DeleteProductCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
