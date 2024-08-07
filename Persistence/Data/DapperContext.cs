using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Domain.Exceptions;
using Application.Models;
using Polly;


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
                var connection = new SqlConnection(_connectionString);
                OpenConnectionWithPolicies(connection).Wait(); 
                return connection;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException(Constant.DatabaseConnectionError);
            }
        }



        private async Task OpenConnectionWithPolicies(IDbConnection connection)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .RetryAsync(3);

            var circuitBreakerPolicy = Policy.Handle<Exception>()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

            await retryPolicy.ExecuteAsync(async () =>
            {
                await circuitBreakerPolicy.ExecuteAsync(async () =>
                {
                    await Task.Run(() => connection.Open());
                });
            });
        }
    }


}
