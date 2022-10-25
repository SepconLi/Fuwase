using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Begin a new transaction.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commit the current transaction.
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rolls back the current transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves changes in entities without dispatching domain events.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Saves changes in entities and dispatches domain events within the same transaction.
        /// </summary>
        Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
