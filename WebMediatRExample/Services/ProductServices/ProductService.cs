using WebMediatRExample.Models;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Command.ResponseCommand;
using WebMediatRExample.Models.Queries.QueryResponse;
using WebMediatRExample.Repozitories.IRepozitory;

namespace WebMediatRExample.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductCommandResponse> CreateAsync(AddProductCommand addProductCommand)
        {
            var model = new Product
            {
                Name = addProductCommand.Name
            };
            await _unitOfWork.Products.CreateAsync(model);

            var response = new ProductCommandResponse
            {
                Id = model.Id,
                Name = model.Name
            };
            return response;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id == id);
            if(product is null)
            {
                return 0;
            }
             var result=  await _unitOfWork.Products.RemoveAsync(product);
            if (result == true) return 1;
            return 0;
        }

        public async Task<List<ProductQueryResponse>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var queryResponse = products.Select(x => new ProductQueryResponse
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
            return queryResponse;
        }

        public async Task<ProductQueryResponse> GetAsync(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id == id);
            if (product is null) return null;
            var response = new ProductQueryResponse
            {
                Id=product.Id,
                Name=product.Name
            };
            return response;
        }

        public async Task<ProductCommandResponse> UpdateAsync(UpdateProductCommand updateProductCommand)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id ==updateProductCommand.Id);
            if (product is null) return null;
            product.Name = updateProductCommand.Name;
            await _unitOfWork.Products.UpdateAsync(product);
            var response = new ProductCommandResponse
            {
                Id = product.Id,
                Name = product.Name
            };
            return response;
        }
    }
}
