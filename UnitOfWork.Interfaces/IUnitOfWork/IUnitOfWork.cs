using Core.Interfaces.IRepository;
using System;
using System.Threading.Tasks;

namespace UnitOfWork.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        void CreateTransaction();
        void Commit();
        void RollBack();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
