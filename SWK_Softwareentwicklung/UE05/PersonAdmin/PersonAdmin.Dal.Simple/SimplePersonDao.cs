﻿using PersonAdmin.Domain;
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

    public Task<IEnumerable<Person>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<Person>>(personList);
    }

    public Task<Person?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        //return personList.FirstOrDefault(p => p.Id == id);
        return Task.FromResult<Person?>(personList.SingleOrDefault(p => p.Id == id));
    }

    public async Task<bool> UpdateAsync(Person person, CancellationToken cancellationToken = default)
    {
        Person? existingPerson = await FindByIdAsync(person.Id, cancellationToken);
        if (existingPerson is null) {
            return false;
        }

        personList.Remove(existingPerson);
        personList.Add(person);
        return true;
    }
}
