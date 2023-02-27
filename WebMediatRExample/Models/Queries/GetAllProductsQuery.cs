using MediatR;
using WebMediatRExample.Models;

namespace WebMediatRExample.Models.Queries
{
   public record GetAllProductsQuery(): IRequest<IEnumerable<Product>>;
}
