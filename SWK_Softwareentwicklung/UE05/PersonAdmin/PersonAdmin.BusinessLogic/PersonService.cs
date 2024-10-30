using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;
namespace PersonAdmin.BusinessLogic
{
    public class PersonService(IPersonDao personDao,TextWriter writer)
    {
        public async Task TestFindAllAsync(CancellationToken cancellationToken = default)
        {
            writer.WriteLine("TestFindAll");

            var persons = await personDao.FindAllAsync(cancellationToken);

            persons.ToList().ForEach(p => writer.WriteLine(
                    $"{p.Id,5} | {p.FirstName,-10} | {p.LastName,-15} | {p.DateOfBirth,10:dd.MM.yyyy}"));

            writer.WriteLine();
        }
        public async Task TestFindByIdAsync(CancellationToken cancellationToken = default)
        {
            Person? person1 = await personDao.FindByIdAsync(1, cancellationToken);
            writer.WriteLine($"FindById(1): {person1?.ToString() ?? "<null>"}");

            Person? person2 = await personDao.FindByIdAsync(10, cancellationToken);
            writer.WriteLine($"FindById(10): {person2?.ToString() ?? "<null>"}");

            writer.WriteLine();
        }

        public async Task TestUpdateAsync(int id, CancellationToken cancellationToken = default)
        {
            Person? person = await personDao.FindByIdAsync(id, cancellationToken);
            writer.WriteLine($"before update (id={id}): {person?.ToString() ?? "<null>"}");

            if (person != null) {
                person.DateOfBirth = person.DateOfBirth.AddDays(1);

                bool success = await personDao.UpdateAsync(person, cancellationToken);

                person = await personDao.FindByIdAsync(id, cancellationToken);
                writer.WriteLine($"after update: {person?.ToString() ?? "<null>"}");
            }
        }

        public async Task TestTransactionsAsync(CancellationToken cancellationToken = default)
        {
            writer.WriteLine("TestTransactions");

            try
            {
                // we want to make sure that either both updates are persisted, or none

                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await personDao.UpdateAsync(new Person(2, "Before", "Exception", DateTime.Now), cancellationToken);
                    throw new Exception();
                    await personDao.UpdateAsync(new Person(3, "After", "Exception", DateTime.Now), cancellationToken);

                    transaction.Complete(); // commit
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            writer.WriteLine();
        }
    }
}
