using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BDH.Data
{
    public interface IAsyncService :IUnitOfWork
    {
        Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task AddAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;
        Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task UpdateAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;
        Task DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task DeleteAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;

    }
}
