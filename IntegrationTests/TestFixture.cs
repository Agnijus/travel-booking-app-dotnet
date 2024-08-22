using Microsoft.Extensions.Configuration;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace IntegrationTests;
public class TestFixture : IDisposable
{
    public DbContextMembers Context { get; private set; }
    public HttpClient Client { get; private set; }
    private readonly IDbContextTransaction _transaction;
    private readonly IConfiguration _configuration;

    public TestFixture()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Testing.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();
        var options = new DbContextOptionsBuilder<DbContextMembers>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            .Options;

        Context = new DbContextMembers(options);
        Context.Database.EnsureCreated();
       

        var factory = new CustomWebApplicationFactory();
        Client = factory.CreateClient();
    }

    public void Dispose()
    {
        Context.Database.ExecuteSqlRaw(@"
        DELETE FROM Booking; DBCC CHECKIDENT('Booking', RESEED, 0);
        DELETE FROM HotelReservation; DBCC CHECKIDENT('HotelReservation', RESEED, 0);
        DELETE FROM HotelImage; DBCC CHECKIDENT('HotelImage', RESEED, 0);
        DELETE FROM Room; DBCC CHECKIDENT('Room', RESEED, 0);
        DELETE FROM GuestAccount; DBCC CHECKIDENT('GuestAccount', RESEED, 0);
        DELETE FROM PopularDestination; DBCC CHECKIDENT('PopularDestination', RESEED, 0);
        DELETE FROM Hotel; DBCC CHECKIDENT('Hotel', RESEED, 0);
        DELETE FROM RoomType; DBCC CHECKIDENT('RoomType', RESEED, 0);
        DELETE FROM TransactionStatus; DBCC CHECKIDENT('TransactionStatus', RESEED, 0);
    ");
         var scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData.sql");
        if (File.Exists(scriptPath))
        {
            var script = File.ReadAllText(scriptPath);
            Context.Database.ExecuteSqlRaw(script);
        }
        else
        {
            throw new FileNotFoundException($"Could not find file at {scriptPath}");
        }

        Context.Dispose();
    }
}
