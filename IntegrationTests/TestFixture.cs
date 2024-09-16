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
    }
}
