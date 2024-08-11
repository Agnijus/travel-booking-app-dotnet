using Microsoft.Extensions.Configuration;
using Persistence.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


namespace IntegrationTests;
public class TestFixture : IDisposable
{
    public DbContextMembers Context { get; private set; }
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

        var options = new DbContextOptionsBuilder<DbContextMembers>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;

        Context = new DbContextMembers(options);

        var factory = new WebApplicationFactory<Program>()
                    .WithWebHostBuilder(builder =>
                    {
                        builder.UseEnvironment("Testing"); 
                    });

        Client = factory.CreateClient();

    }

    public void Dispose()
    {
        Context.Database.ExecuteSqlRaw("DELETE FROM Booking");
        Context.Database.ExecuteSqlRaw("DELETE FROM HotelReservation");
        Context.Database.ExecuteSqlRaw("DELETE FROM HotelImage");
        Context.Database.ExecuteSqlRaw("DELETE FROM Room");
        Context.Database.ExecuteSqlRaw("DELETE FROM GuestAccount");
        Context.Database.ExecuteSqlRaw("DELETE FROM PopularDestination");
        Context.Database.ExecuteSqlRaw("DELETE FROM Hotel");
        Context.Database.ExecuteSqlRaw("DELETE FROM RoomType");
        Context.Database.ExecuteSqlRaw("DELETE FROM TransactionStatus");

        Context.Dispose();
    }
}