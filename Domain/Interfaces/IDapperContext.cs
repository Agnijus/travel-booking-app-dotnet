using System.Data;

namespace Domain.Repository_Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
