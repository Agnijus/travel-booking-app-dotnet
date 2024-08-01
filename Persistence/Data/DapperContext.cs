using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Domain.Exceptions;
using Application.Models;
using Domain.Repository_Interfaces;



namespace Persistence.Data
{
    public class DapperContext : IDapperContext
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
                throw new DatabaseConnectionException(Constant.DatabaseConnectionError);
            }
        }


    }
}
