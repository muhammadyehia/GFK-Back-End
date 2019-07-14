using GfKTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GfKTask.Infrastructure
{
   public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddBulk(IEnumerable<T> entities)
        {
            _context.BulkInsert(entities);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Query(List<Expression<Func<T, bool>>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(p => true);
            if (filters != null)
            {
                query = filters.Aggregate(query, (current, item) => current.Where(item));
                if (includes != null)
                    query = includes.Aggregate(query, (current, item) => current.Include(item));
            }

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

    
    }
}
