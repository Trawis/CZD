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
        public DbSet<Model.Podaci.Podaci> Podaci { get; set; }

        public PodaciContext() : base("name=PodaciConnection")
        {

        }
    }
}
