using Core.Interfaces.IRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly IdentityDbContext _context;

        private readonly DbSet<TEntity> dbset;
        private DbContext context;

        public Repository(IdentityDbContext context)
        {
            _context = context;
            dbset = context.Set<TEntity>();
        }

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.Any(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.AnyAsync(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return dbset.Count(predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return  dbset.CountAsync(predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(string id)
        {

            return dbset.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await AnyAsync(predicate);
        }

        public async Task Remove(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            await Task.Run(() =>
            {
                dbset.Remove(entity);
            });
        }

        public async Task RemoveByIdAsync(string id)
        {

            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            await Remove(entity);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.SingleOrDefault(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbset.SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
           
            _context.Entry(entity).State = EntityState.Modified;
        }


        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;

            if (filter != null)
            {
                query = dbset.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
    }
}
