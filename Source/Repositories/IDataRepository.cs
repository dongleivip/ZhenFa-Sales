using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public interface IDataRepository<T> : IRepositoryService where T : class 
    {
        int Add(T entity);

        int Delete(T entity);

        int Update(T entity);

        T Get(object id);

        IEnumerable<T> GetAll();

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
