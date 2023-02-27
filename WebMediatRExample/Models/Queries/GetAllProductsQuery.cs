using MediatR;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Queries.QueryResponse;

namespace WebMediatRExample.Models.Queries
{
   public record GetAllProductsQuery(): IRequest<List<ProductQueryResponse>>;
}
