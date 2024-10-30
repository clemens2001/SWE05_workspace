using PersonAdmin.BusinessLogic;
using PersonAdmin.Dal.Ado;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Dal.Simple;


Test(new SimplePersonDao());
Test(new AdoPersonDao());
void Test(IPersonDao dao)
{
    Console.WriteLine(dao.GetType());
    var service = new PersonService(dao, Console.Out);

    service.TestFindAll();
}