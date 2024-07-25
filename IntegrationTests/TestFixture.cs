using Microsoft.Extensions.Configuration;
using Persistence.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;


namespace IntegrationTests;
public class TestFixture : IDisposable
{
    public DapperContext Context { get; private set; }
    public HttpClient Client { get; private set; }
    private readonly IConfiguration _configuration;


    public TestFixture()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Testing.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();

        Context = new DapperContext(_configuration);

        var factory = new WebApplicationFactory<Program>();

        Client = factory.CreateClient();

    }

    public void Dispose()
    {
        using (var connection = Context.CreateConnection())
        {
            connection.Execute("DELETE FROM Booking");
            connection.Execute("DELETE FROM HotelReservation");
            connection.Execute("DELETE FROM HotelImage");
            connection.Execute("DELETE FROM Room");
            connection.Execute("DELETE FROM GuestAccount");
            connection.Execute("DELETE FROM PopularDestination");
            connection.Execute("DELETE FROM Hotel");
            connection.Execute("DELETE FROM RoomType");
            connection.Execute("DELETE FROM TransactionStatus");
        }
    }
}