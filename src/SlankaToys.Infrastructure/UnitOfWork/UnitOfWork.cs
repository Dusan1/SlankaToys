using System;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Application.Contracts;

namespace SlankaToys.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context;

        public UnitOfWork(SlankaToysDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}