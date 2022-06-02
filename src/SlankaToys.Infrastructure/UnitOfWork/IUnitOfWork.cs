using Microsoft.EntityFrameworkCore;
using System;

namespace SlankaToys.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        void Commit();
    }
}