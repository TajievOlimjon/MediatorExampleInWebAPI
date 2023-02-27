using WebMediatRExample.Models;

namespace WebMediatRExample.Data
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        
        public FakeDataStore()
        {
            _products = new List<Product>
            {
                 new Product  { Id =  1, Name = "Test Product 1" },
                 new Product  { Id =  2, Name = "Test Product 2" },
                 new Product  { Id =  3, Name = "Test Product 3" }
            };
        }
         List<Category> categories = new()
         {
             new Category{Id=1,Name="test"},
             new Category{Id=2,Name="test 2"}
         };
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await Task.FromResult(categories);
        }
        public async Task AddCategory(Category category)
        {
            categories.Add(category);
            await Task.CompletedTask;
        }
        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id.Equals(id));
            _products.Remove(product);
            await Task.CompletedTask;
        }
        public async Task UpdateProduct(Product product)
        {
            var x =  _products.FirstOrDefault(x => x.Id.Equals(product.Id));
            x.Name = product.Name;
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id.Equals(id));
            if(product is null)
            {
                return product = new Product();
            }
            return await Task.FromResult(product);
        }
        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
