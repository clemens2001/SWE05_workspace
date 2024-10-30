using Dal.Common;
using PersonAdmin.BusinessLogic;
using PersonAdmin.Dal.Ado;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Dal.Simple;

var connectionString =
    @"Data Source=localhost;Initial Catalog=person_db;Persist Security Info=True;User ID=sa;Password=Swk5-rocks!;Encrypt=True;Trust Server Certificate=True";

var connectionFactory = new DefaultConnectionFactory(connectionString, "Microsoft.Data.SqlClient"); 

Test(new SimplePersonDao());
Test(new AdoPersonDao(connectionFactory));
void Test(IPersonDao dao)
{
    Console.WriteLine(dao.GetType());
    var service = new PersonService(dao, Console.Out);

    service.TestFindAll();
}