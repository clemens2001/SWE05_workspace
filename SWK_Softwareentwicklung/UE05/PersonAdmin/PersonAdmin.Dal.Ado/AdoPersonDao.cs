using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;

namespace PersonAdmin.Dal.Ado
{
    public class AdoPersonDao : IPersonDao
    {
        public IEnumerable<Person> FindAll()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=person_db;Persist Security Info=True;User ID=sa;Password=Swk5-rocks!;Trust Server Certificate=True";
            using DbConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            
            DbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM person";
            
            using DbDataReader reader = command.ExecuteReader();
            
            var persons = new List<Person>();
            while (reader.Read()) {
                /*yield return new Person {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    DateOfBirth = reader.GetDateTime(3)
                };*/
                
                // no yield return!!!
                persons.Add(new Person(
                    (int)reader["id"],
                    (string)reader["first_name"],
                    (string)reader["last_name"],
                    (DateTime)reader["date_of_birth"]));
            }

            return persons;
        }
    }
}
