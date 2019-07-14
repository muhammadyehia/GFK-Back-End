using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Interfaces
{
   public interface IRepository<T> where T : class
    {
        IQueryable<T> Query(List<Expression<Func<T, bool>>> filters = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null);
        void Add(T entity);
        void Update(T entity);
        void AddBulk(IEnumerable<T> entities);
    }
}
