using PersonAdmin.Domain;
using PersonAdmin.Dal.Interface;

namespace PersonAdmin.Dal.Simple;

public class SimplePersonDao : IPersonDao
{
    private static IList<Person> personList = new List<Person>
    {
        new Person(1, "John", "Doe", DateTime.Now.AddYears(-10)),
        new Person(2, "Jane", "Doe", DateTime.Now.AddYears(-20)),
        new Person(3, "Max", "Mustermann", DateTime.Now.AddYears(-30))
    };

    public IEnumerable<Person> FindAll()
    {
        return personList;
    }

    public Person? FindById(int id)
    {
        //return personList.FirstOrDefault(p => p.Id == id);
        return personList.SingleOrDefault(p => p.Id == id);
    }

    public bool Update(Person person)
    {
        Person? existingPerson = FindById(person.Id);
        if (existingPerson is null) {
            return false;
        }

        personList.Remove(existingPerson);
        personList.Add(person);
        return true;
    }
}
