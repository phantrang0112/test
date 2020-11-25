using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace BDH.Data.EFService
{
    public abstract class EfService<TContext> : IAsyncService,IUnitOfWork 
        where TContext:DbContext
    {
        protected readonly TContext dbContext;
        protected readonly IServiceProvider serviceProvider;
        public EfService(IServiceProvider serviceProvider)
        {
            this.dbContext = serviceProvider.GetService<TContext>();
            this.serviceProvider = serviceProvider;
        }

        public virtual async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return;
        }

        public virtual async  Task AddAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class
        {
            await dbContext.Set<T>().AddRangeAsync(entity, cancellationToken);
            return;
        }

        public virtual Task DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class
        {
            dbContext.Set<T>().RemoveRange(entity);
            return Task.CompletedTask;
        }
        private bool disposedValue = false;
        protected bool _commited = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //if (!disposing)
                //{
                //    if (_commited)
                //    {
                //       //
                //    }
                //}
                disposedValue = true;
            }
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            var affecterRecords = await dbContext.SaveChangesAsync(cancellationToken);
            _commited = true;
            return affecterRecords;
        }

        public virtual Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            dbContext.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class
        {
            dbContext.UpdateRange(entity);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
