using WebMediatRExample.Data;
using WebMediatRExample.Models;
using WebMediatRExample.Repozitories.IRepozitory;

namespace WebMediatRExample.Repozitories.Repozitory
{
    public class ProductRepozitory : GenericRepozitory<Product>, IProductRepozitory
    {
        public ProductRepozitory(ApplicationDbContext context) : base(context)
        {
        }
    }
}
