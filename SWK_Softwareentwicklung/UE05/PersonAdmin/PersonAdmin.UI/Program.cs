using Dal.Common;
using Microsoft.Extensions.Configuration;
using PersonAdmin.BusinessLogic;
using PersonAdmin.Dal.Ado;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Dal.Simple;


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionFactory = 
    DefaultConnectionFactory.FromConfiguration(configuration, "PersonDbConnection");

Test(new SimplePersonDao());
Test(new AdoPersonDao(connectionFactory));

void Test(IPersonDao dao)
{
    Console.WriteLine(dao.GetType());
    var service = new PersonService(dao, Console.Out);

    service.TestFindAll();
}