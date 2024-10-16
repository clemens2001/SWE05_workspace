namespace PersonManagement;

public class PersonRepository
{
    private readonly IList<Person> persons = new List<Person>();

    public void AddPerson(Person person)
    {
        persons.Add(person);
    }

    public void AddPersons(IEnumerable<Person> persons)
    {
        //persons.ToList().ForEach(AddPerson);

        //CollectionExtensions.AddAll(this.persons, persons);

        this.persons.AddAll(persons);
    }

    public void PrintPersons(TextWriter textWriter)
    {
        //foreach (var person in persons) {
        //    textWriter.WriteLine(person);
        //}

        //persons.ForEach(p => textWriter.WriteLine(p));
        persons.ForEach(textWriter.WriteLine);

    }

    public IEnumerable<(string?, string?)> GetPersonNames()
    {
        foreach (var person in persons) {
            yield return (person.FirstName, person.LastName);
        }
    }

    public IEnumerable<Person> FindPersonsByCity(string city)
    {
        //foreach(var person in persons) {
        //    if (person.City == city) {
        //        yield return person;
        //    }
        //}
        return persons.Filter(p => p.City == city);
    }

    public Person FindYoungestPerson()
    {
        return persons.OrderBy(p => p.DateOfBirth).First();
    }


    public IEnumerable<Person> FindPersonsSortedByAgeAscending()
    {
        foreach (var person in persons.OrderBy(p => p.DateOfBirth)) {
            yield return person;
        }
    }
}
