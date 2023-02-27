using MediatR;
using WebMediatRExample.Data;
using WebMediatRExample.Models.Command;

namespace WebMediatRExample.Models.Handler
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddCategoryHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name=request.Name
            };
            await _fakeDataStore.AddCategory(category);

            return Unit.Value;
        }
    }
}
