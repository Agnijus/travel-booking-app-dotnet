

using System.Data;

namespace Domain.Repository_Interfaces
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
