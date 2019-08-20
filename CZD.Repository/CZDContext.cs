using System.Data.Entity;
using CZD.Model;

namespace CZD.Repository
{
	public class CZDContext : DbContext
    {
        public DbSet<Data> Data { get; set; }

        public CZDContext() : base("name=CZDConnection")
        {

        }
    }
}
