using MediatR;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Queries.QueryResponse;

 namespace WebMediatRExample.Models.Queries
{
    public class GetProductByIdQuery: IRequest<ProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
