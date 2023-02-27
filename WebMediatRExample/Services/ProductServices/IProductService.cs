using System.Linq.Expressions;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Command.ResponseCommand;
using WebMediatRExample.Models.Queries.QueryResponse;

namespace WebMediatRExample.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductQueryResponse>> GetAllAsync();
        Task<ProductQueryResponse> GetAsync(int id);
        Task<ProductCommandResponse> UpdateAsync(UpdateProductCommand updateProductCommand);
        Task<ProductCommandResponse> CreateAsync(AddProductCommand addProductCommand);
        Task<int> DeleteAsync(int id);
    }
}
