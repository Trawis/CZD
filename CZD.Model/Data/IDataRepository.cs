using CZD.Infrastructure;

namespace CZD.Model
{
	public interface IDataRepository : IRepository<Data>
    {
        void InsertWithProcedure(Data podatak);
    }
}