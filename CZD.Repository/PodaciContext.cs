using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Repository
{
    public class PodaciContext : DbContext
    {
        DbSet<Model.Podaci.Podaci> Podaci { get; set; }
    }
}
