using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Dal.Common
{
    public class AdoTemplate(string connectionString)
    {
        public string ConnectionString { get; }

        public IEnumerable<T> Query<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            using (var connection = new SqlConnection(this.ConnectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = sql;
                    foreach (var parameter in parameters) {
                        command.Parameters.Add(new SqlParameter(parameter.Name, parameter.Value));
                    }

                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            yield return rowMapper(reader);
                        }
                    }
                }
            }
        }

        public int Execute(string sql, params QueryParameter[] parameters)
        {
            using (var connection = new SqlConnection(this.ConnectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = sql;
                    foreach (var parameter in parameters) {
                        command.Parameters.Add(new SqlParameter(parameter.Name, parameter.Value));
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
