using WebMediatRExample.Data;
using WebMediatRExample.Repozitories.IRepozitory;

namespace WebMediatRExample.Repozitories.Repozitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepozitory(context);
        }
        public IProductRepozitory Products { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
