using System.Text.Json;
using PersonManagement;

PersonRepository personRepository = new PersonRepository();
IEnumerable<Person>? persons = new List<Person>();

try
{
    string json = File.ReadAllText("persons.json");
    persons = JsonSerializer.Deserialize<IEnumerable<Person>>(
        json, 
        new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
    if(persons == null) {
        Console.WriteLine("No persons found in file");
        return;
    }
}
catch (FileNotFoundException fnfEx)
{
	Console.WriteLine(fnfEx.Message);
	return;
}

personRepository.AddPersons(persons);


TextWriter textWriter = Console.Out;
//TextWriter textWriter = new StreamWriter("result.txt")
textWriter.WriteLine("=====================================================");
textWriter.WriteLine("Person list");
textWriter.WriteLine("=====================================================");

personRepository.PrintPersons(textWriter);


textWriter.WriteLine();
textWriter.WriteLine("Persons in Hagenberg");
textWriter.WriteLine("=====================================================");
textWriter.WriteLine("=====================================================");
//
// TODO
//

//textWriter.WriteLine();
//textWriter.WriteLine("=====================================================");
//textWriter.WriteLine("Person names");
//textWriter.WriteLine("=====================================================");
//
// TODO
//

//textWriter.WriteLine();
//textWriter.WriteLine("=====================================================");
//textWriter.WriteLine($"Youngest person");
//textWriter.WriteLine("=====================================================");
//
// TODO
//

//textWriter.WriteLine();
//textWriter.WriteLine("=====================================================");
//textWriter.WriteLine("Persons sorted by age ascending");
//textWriter.WriteLine("=====================================================");
//
// TODO
//
