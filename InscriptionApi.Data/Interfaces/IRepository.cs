using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data.Interfaces
{
    public interface IRepository<T> 
        where T : class, IEntity
    {
        Task<T> Create(T entity, CancellationToken cancellation = default);
        Task<int> Update(T entity, CancellationToken cancellation = default);
        Task<int> Delete(long entityId, CancellationToken cancellation = default);
        IQueryable<T> All(CancellationToken cancellation = default);
        Task<T> Single(Expression<Func<T, bool>> expression, CancellationToken cancellation = default);
        Task<int> CreateRange(IEnumerable<T> items, CancellationToken cancellation = default);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
