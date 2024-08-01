using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Domain.Repository_Interfaces;

namespace Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDapperContext _context;
        private IDbTransaction _transaction;
        private IDbConnection _connection;

        public UnitOfWork(IDapperContext context)
        {
            _context = context;
            _connection = _context.CreateConnection();
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public IDbTransaction Transaction => _transaction;

        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
                _connection?.Dispose();
                _connection = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
                _connection?.Dispose();
                _connection = null;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(0);
        }
    }
}
