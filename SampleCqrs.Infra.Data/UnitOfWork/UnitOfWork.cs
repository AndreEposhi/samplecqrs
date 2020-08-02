using SampleCqrs.Domain.Interfaces.UnitOfWork;
using SampleCqrs.Infra.Data.Contexts;
using System;

namespace SampleCqrs.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleCqrsDbContext context;
        private bool disposed = false;
        public UnitOfWork(SampleCqrsDbContext context)
        {
            this.context = context;
        }

        public bool Commit() => context.SaveChanges() > 0;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }
    }
}