using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IBaseServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity GetById(string id);

        Task<TEntity> GetByIdAsync(string id);

        Task Remove(TEntity entity);

        Task  RemoveByIdAsync(string id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
