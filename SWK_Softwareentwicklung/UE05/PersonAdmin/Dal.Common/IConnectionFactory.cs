using System.Data.Common;

namespace Dal.Common
{
    public interface IConnectionFactory
    {
        DbConnection OpenConnection();
        Task<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default);

    }
}
