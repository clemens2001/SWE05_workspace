using Microsoft.Data.SqlClient;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Dal.Common
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        public string ConnectionString { get; }
        public string ProviderName { get; }

        private readonly DbProviderFactory dbProviderFactory;
        public DefaultConnectionFactory(string connectionString, string providerName)
        {
            ConnectionString = connectionString;
            ProviderName = providerName;

            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("MySql.Data.SqlClient", MySqlClientFactory.Instance);

            dbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        public DbConnection OpenConnection()
        {
            DbConnection connection = dbProviderFactory.CreateConnection()
                ?? throw new InvalidOperationException(
                    $"Failed to create connection to provider {ProviderName}");

            connection.ConnectionString = ConnectionString;
            connection.Open();

            return connection;
        }
    }
}
