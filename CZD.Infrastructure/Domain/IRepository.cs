using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CZD.Infrastructure
{
	public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
