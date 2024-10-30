using Dal.Common;
using Microsoft.Extensions.Configuration;
using PersonAdmin.BusinessLogic;
using PersonAdmin.Dal.Ado;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Dal.Simple;
using PersonAdmin.Domain;


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionFactory = 
    DefaultConnectionFactory.FromConfiguration(configuration, "PersonDbConnection");

var tokenSource = new CancellationTokenSource();

await TestAsync(new SimplePersonDao(), tokenSource.Token);
await TestAsync(new AdoPersonDao(connectionFactory), tokenSource.Token);

// tokenSource.Cancel();

async Task TestAsync(IPersonDao dao, CancellationToken cancellationToken = default)
{
    Console.WriteLine(dao.GetType());
    var service = new PersonService(dao, Console.Out);

    await service.TestFindAllAsync(cancellationToken);
    await service.TestFindByIdAsync(cancellationToken);
    await service.TestUpdateAsync(1, cancellationToken);
    await service.TestTransactionsAsync(cancellationToken);
    await service.TestFindAllAsync(cancellationToken);
}

