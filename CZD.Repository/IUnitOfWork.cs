using CZD.Repository.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPodaciRepository PodaciRepository { get; }
        int Commit();
    }
}
