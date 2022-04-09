using Microsoft.EntityFrameworkCore;
using Ni_Soft.InscriptionApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected readonly DbContext _Context;
        public BaseRepository(DbContext context)
        {
            _Context = context;
        }

        public IQueryable<T> All(CancellationToken cancellation = default)
        {
            return _Context.Set<T>().AsQueryable();
        }

        public async Task<T> Create(T entity, CancellationToken cancellation = default)
        {
            DateTime now = DateTime.Now;
            entity.CreatedOn = now;

            var entry = _Context.Set<T>().Add(entity);
            int savedCount = await _Context.SaveChangesAsync(cancellation);
            return entity;
        }

        public async Task<int> CreateRange(IEnumerable<T> items, CancellationToken cancellation = default)
        {
            DateTime now = DateTime.Now;

            foreach (var item in items)
            {
                item.CreatedOn = now;
            }
            _Context.Set<T>().AddRange(items);
            int saveCount = await _Context.SaveChangesAsync(cancellation);

            return saveCount;
        }

        public async Task<int> Delete(long entityId, CancellationToken cancellation = default)
        {
            DateTime now = DateTime.Now;
            int savedCount = 0;
            var entity = await _Context.Set<T>().FindAsync(entityId, cancellation);
            if (entity != null)
            {
                entity.DeletedOn = now;
                entity.UpdatedOn = now;

                _Context.Set<T>().Update(entity);
                savedCount = await _Context.SaveChangesAsync(cancellation);
            }
            return savedCount;
        }

        public async Task<T> Single(Expression<Func<T, bool>> expression, CancellationToken cancellation = default)
        {

            var entity = await All().Where(expression).SingleOrDefaultAsync(cancellation);
            return entity;
        }

        public async Task<int> Update(T entity, CancellationToken cancellation = default)
        {
            int savedCount = 0;
            DateTime now = DateTime.Now;
            var item = await All().Where(e => e.Id == entity.Id).SingleOrDefaultAsync(cancellation);

            if (item != null)
            {
                _Context.Set<T>().Update(entity);
                savedCount = await _Context.SaveChangesAsync(cancellation);
            }
            return savedCount;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression);
        }
    }
}
