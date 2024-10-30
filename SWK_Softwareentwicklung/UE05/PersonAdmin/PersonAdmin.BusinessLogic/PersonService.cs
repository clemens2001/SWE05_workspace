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
        public void TestFindAll()
        {
            writer.WriteLine("TestFindAll");
            personDao.FindAll()
                .ToList()
                .ForEach(p => writer.WriteLine(
                    $"{p.Id,5} | {p.FirstName,-10} | {p.LastName,-15} | {p.DateOfBirth,10:dd.MM.yyyy}"));

            writer.WriteLine();
        }
        public void TestFindById()
        {
            Person? person1 = personDao.FindById(1);
            writer.WriteLine($"FindById(1): {person1?.ToString() ?? "<null>"}");

            Person? person2 = personDao.FindById(10);
            writer.WriteLine($"FindById(10): {person2?.ToString() ?? "<null>"}");

            writer.WriteLine();
        }

        public void TestUpdate()
        {
            Person? person = personDao.FindById(1);
            writer.WriteLine($"before update: {person?.ToString() ?? "<null>"}");

            if (person != null) {
                person.DateOfBirth = person.DateOfBirth.AddDays(1);

                bool success = personDao.Update(person);

                person = personDao.FindById(1);
                writer.WriteLine($"after update: {person?.ToString() ?? "<null>"}");
            }
            else {
                writer.WriteLine("Person not found");
            }
        }

        public void TestTransactions()
        {
            writer.WriteLine("TestTransactions");

            try
            {
                // we want to make sure that either both updates are persisted, or none

                using (var transaction = new TransactionScope())
                {
                    personDao.Update(new Person(2, "Before", "Exception", DateTime.Now));
                    throw new Exception();
                    personDao.Update(new Person(3, "After", "Exception", DateTime.Now));

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
