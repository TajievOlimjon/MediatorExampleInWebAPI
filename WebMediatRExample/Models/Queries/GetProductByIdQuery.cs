using MediatR;
using WebMediatRExample.Models;

 namespace WebMediatRExample.Models.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
