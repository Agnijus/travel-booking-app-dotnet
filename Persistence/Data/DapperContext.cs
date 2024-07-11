using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Domain.Exceptions;



namespace Persistence.Data
{
    public class DapperContext
    {
        private readonly IConfiguration? _configuration;
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration?.GetConnectionString("DefaultConnection");
        }



        public IDbConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to create a database connection.", ex);
            }
        }
    }
}
