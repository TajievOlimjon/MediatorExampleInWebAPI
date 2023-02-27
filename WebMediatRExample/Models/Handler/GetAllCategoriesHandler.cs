using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Queries;

namespace WebMediatRExample.Models.Handler
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryResponse>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetAllCategoriesHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<List<GetAllCategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _fakeDataStore.GetAllCategories();

            var response = categories.Select(x => new GetAllCategoryResponse
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();

            return response;
        }
    }
}
