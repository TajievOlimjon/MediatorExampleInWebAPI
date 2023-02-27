using MediatR;

namespace WebMediatRExample.Models.Queries
{
    public class GetAllCategoryQuery : IRequest<List<GetAllCategoryResponse>> { }
}
