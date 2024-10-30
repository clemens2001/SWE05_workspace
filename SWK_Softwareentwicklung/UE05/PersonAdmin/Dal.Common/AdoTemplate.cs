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

        public T? QuerySingle<T> (string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
            => Query(sql, rowMapper, parameters).SingleOrDefault();

        public IEnumerable<T> Query<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            using DbConnection connection = connectionFactory.OpenConnection();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            AddParameters(command, parameters);

            using DbDataReader reader = command.ExecuteReader();


            var items = new List<T>();

            while (reader.Read()) {
                items.Add(rowMapper(reader));
            }

            return items;
        }
    }
}