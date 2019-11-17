using System.Data;

namespace FromTheFuture.Domain.Shared
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
