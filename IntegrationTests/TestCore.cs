
namespace IntegrationTests
{
    public class TestCore : IClassFixture<TestFixture>
    {
        protected readonly TestFixture Fixture;
        protected readonly HttpClient Client;

        protected TestCore(TestFixture fixture)
        {
            Fixture = fixture;
            Client = fixture.Client;
        }
    }
}
