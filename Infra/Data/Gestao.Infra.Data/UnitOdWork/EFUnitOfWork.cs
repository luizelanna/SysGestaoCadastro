using System;
using Gestao.Infra.Data.Context;
using Gestao.Infra.Data.Interfaces;

namespace Gestao.Infra.Data.UnitOdWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly GestaoContext _dbContext;
        private bool _disposed;

        public EfUnitOfWork(GestaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
