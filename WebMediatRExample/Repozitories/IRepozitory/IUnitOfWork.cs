using System;
using System.Threading.Tasks;
using WebMediatRExample.Repozitories.Repozitory;

namespace WebMediatRExample.Repozitories.IRepozitory
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepozitory Products  {get; set;}

    }
}
