using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Core.Interfaces.IRepository;
using Infrastructure.Data.Repository;
using UnitOfWork.Interfaces.IUnitOfWork;

namespace Infrastructure.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();
        private DbContextTransaction _transaction;
        private bool _disposed;
        public void Commit()
        {
            _transaction.Commit();
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }


        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void Save()
        {
            try
            {
                CreateTransaction();
               _context.SaveChanges();
                Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.Reload();
                }

            }

            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.InnerException?.Message);
            }



        }

        public async Task SaveAsync()
        {
            try
            {
                CreateTransaction();
                await _context.SaveChangesAsync();
                Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.Reload();
                }

            }



            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.InnerException?.Message);
            }


        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var entityName = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityName))
            {
                _repositories.Add(entityName, new Repository<TEntity>(_context));
            }

            return _repositories[entityName] as IRepository<TEntity>;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
