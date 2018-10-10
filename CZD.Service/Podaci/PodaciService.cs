using CZD.Repository.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Service.Podaci
{
    public class PodaciService : IPodaciService
    {
        private readonly IPodaciRepository _podaciRepository;
        public PodaciService(IPodaciRepository podaciRepository)
        {
            _podaciRepository = podaciRepository;
        }
    }
}
