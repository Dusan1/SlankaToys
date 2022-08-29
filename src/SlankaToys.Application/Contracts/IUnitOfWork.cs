using System;

namespace SlankaToys.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();
    }
}           