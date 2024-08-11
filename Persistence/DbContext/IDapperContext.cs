using System.Data;

namespace Persistence.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
