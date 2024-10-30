using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Dal.Common
{
    public class AdoTemplate(IConnectionFactory connectionFactory)
    {
        private void AddParameters(DbCommand command, QueryParameter[] parameters)
        {
            foreach (var parameter in parameters) {
                var dbParameter = command.CreateParameter();
                dbParameter.ParameterName = parameter.Name;
                dbParameter.Value = parameter.Value;
                command.Parameters.Add(dbParameter);
            }
        }

        public async Task<T?> QuerySingleAsync<T> (
            string sql, 
            RowMapper<T> rowMapper, 
            CancellationToken cancellationToken = default, 
            params QueryParameter[] parameters)
            => (await QueryAsync(sql, rowMapper, cancellationToken, parameters)).SingleOrDefault();

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sql, 
            RowMapper<T> rowMapper,
            CancellationToken cancellationToken = default,
            params QueryParameter[] parameters)
        {
            await using DbConnection connection = await connectionFactory.OpenConnectionAsync(cancellationToken);

            await using DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            AddParameters(command, parameters);

            await using DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);


            var items = new List<T>();

            while (await reader.ReadAsync(cancellationToken)) {
                items.Add(rowMapper(reader));
            }

            return items;
        }

        public async Task<int> ExecuteAsync(string sql,
            CancellationToken cancellationToken = default,
            params QueryParameter[] parameters)
        {
            await using DbConnection connection = await connectionFactory.OpenConnectionAsync(cancellationToken);

            await using DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            AddParameters(command, parameters);

            return await command.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}