using Microsoft.EntityFrameworkCore;
using SlankaToys.Infrastructure;
using System.Threading.Tasks;

namespace SlankaToys.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(SlankaToysDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return (await Context.SaveChangesAsync());
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await Context.DisposeAsync();
        }
    }
}