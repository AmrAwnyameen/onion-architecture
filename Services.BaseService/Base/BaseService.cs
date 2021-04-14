using Core.Interfaces.IRepository;
using Services.Interfaces.IBaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitOfWork.Interfaces.IUnitOfWork;

namespace Services.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public IRepository<TEntity> Repository => _unitOfWork.Repository<TEntity>();
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual TEntity Add(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Add(entity);
            _unitOfWork.Save();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
            _unitOfWork.Save();
            return entity;
        }


        public TEntity GetById(string id)
        {
            var entity = _unitOfWork.Repository<TEntity>().GetById(id);
            _unitOfWork.SaveAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public virtual async Task Remove(TEntity entity)
        {
            await _unitOfWork.Repository<TEntity>().Remove(entity);
            await _unitOfWork.SaveAsync();
           
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _unitOfWork.Repository<TEntity>().RemoveByIdAsync(id);
            await _unitOfWork.SaveAsync();
          
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().FirstOrDefault(predicate);

        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().SingleOrDefaultAsync(predicate);

        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().AnyAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().Any(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Repository<TEntity>().GetAll();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _unitOfWork.Repository<TEntity>().Where(filter, orderBy, includeProperties);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _unitOfWork.Repository<TEntity>().Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _unitOfWork.Repository<TEntity>().CountAsync(predicate);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().IsExistAsync(predicate);
        }

       
    }
}
