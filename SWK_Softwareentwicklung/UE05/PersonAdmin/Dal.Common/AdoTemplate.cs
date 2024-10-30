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
        public IEnumerable<T> Query<T>(string sql, RowMapper<T> rowMapper)
        {
            using DbConnection connection = connectionFactory.OpenConnection();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sql;

            using DbDataReader reader = command.ExecuteReader();


            var items = new List<T>();

            while (reader.Read()) {
                items.Add(rowMapper(reader));
            }

            return items;
        }
    }
}