using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Repository.Podaci
{
    public class PodaciRepository : Repository<Model.Podaci.Podaci>, IPodaciRepository
    {
        private DbContext _dbContext;

        public PodaciRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void InsertWithProcedure(Model.Podaci.Podaci podatak)
        {
            var ime = new SqlParameter("@Ime", podatak.Ime);
            var prezime = new SqlParameter("@Prezime", podatak.Prezime);
            var grad = new SqlParameter("@Grad", podatak.Grad);
            var postanskiBroj = new SqlParameter("@PostanskiBroj", podatak.PostanskiBroj);
            var telefon = new SqlParameter("@Telefon", podatak.Telefon);

            _dbContext.Database.ExecuteSqlCommand("exec dbo.InsertPodaci @Ime, @Prezime, @Grad, @PostanskiBroj, @Telefon",
                                                                          ime, prezime, grad, postanskiBroj, telefon);
        }
    }
}
