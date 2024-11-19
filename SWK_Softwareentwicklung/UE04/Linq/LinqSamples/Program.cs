using LinqSamples.Data;

var respository = new CustomerRepository();
var customers = respository.GetCustomers();

var customersWithA = 
    from c in customers
    where c.Name.StartsWith("A", StringComparison.CurrentCultureIgnoreCase)
    select c;

Print("Customers with A", customersWithA);

var customersByRevenue = 
    from c in customers
    where c.Revenue > 1_000_000
    orderby c.Revenue descending
    select c;
// an dieser ^ Stelle wird noch keine Abfrage ausgeführt
// erst wenn auf die Ergebnisse zugegriffen wird, wird die Abfrage ausgeführt

Print("Customers by Revenue", customersByRevenue);

customers
    .Where((Customer c) => c.Revenue > 1_000_000)
    .OrderByDescending(c => c.Revenue)
    .Select(c => c);

// wird zu:

//Enumerable.Select(
//    Enumerable.OrderByDescending(
//        Enumerable.Where(
//            customers,
//            c => c.Revenue > 1_000_000),
//        c => c.Revenue),
//    c => c);


var largestCustomers =
    (from c in customers
        orderby c.Revenue descending
        select c).Take(3);

Print("Largest Customers", largestCustomers);


var aCustomers =
    from c in customers
    where c.Rating == Rating.A
    select c;

if(aCustomers.Any()) {
    Console.WriteLine($"Average revenue of A customers: {aCustomers.Average(c => c.Revenue):N2}");
} else {
    Console.WriteLine("No A customers found");
}
Console.WriteLine();

var famia = customers.FirstOrDefault(c => c.Name.Equals("famia", StringComparison.CurrentCultureIgnoreCase));
if (famia is not null)
{
    Console.WriteLine(famia);
}
Console.WriteLine();

var customersPerCountry =
    from c in customers
    group c by c.Location.Country
    into g
    select new { Country = g.Key, Customers = (IEnumerable<Customer>)g };

Console.WriteLine("Customers per country:");
foreach (var group in customersPerCountry.OrderBy(g => g.Country))
{
    Console.WriteLine(group.Country);
    foreach (var customer in group.Customers) {
        Console.WriteLine($"  {customer.Name}");

    }
    Console.WriteLine();
}

void Print<T>(string title, IEnumerable<T> items)
{
    Console.WriteLine($"{title}:");
    Console.WriteLine();
    
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }    

    Console.WriteLine();
    Console.WriteLine();
}