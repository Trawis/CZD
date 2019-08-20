using System;

namespace CZD.Infrastructure
{
	public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
