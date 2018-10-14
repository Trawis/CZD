using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Repository.Podaci
{
    public interface IPodaciRepository : IRepository<Model.Podaci.Podaci>
    {
        void InsertWithProcedure(Model.Podaci.Podaci podatak);
    }
}
