using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Common;
using MySql.Data.MySqlClient;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;

namespace PersonAdmin.Dal.Ado
{
    public class AdoPersonDao : IPersonDao
    {
        private readonly AdoTemplate template;

        public AdoPersonDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Person> FindAll() =>
            template.Query("SELECT * FROM Person", MapRowToPerson);

        public Person? FindById(int id) =>
            template.Query(
                $"SELECT * FROM Person WHERE id = @id",
                MapRowToPerson, new QueryParameter("@id", id)).SingleOrDefault();

        private Person MapRowToPerson(IDataRecord row) =>
            new Person(
                (int)row["id"],
                (string)row["first_name"],
                (string)row["last_name"],
                (DateTime)row["date_of_birth"]);
    }
}
