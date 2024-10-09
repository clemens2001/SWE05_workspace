

using HashDictionary.Impl;

IDictionary<string, int> TestIndexerAndAdd()
{
    var cityInfo = new HashDictionary<string, int>();
    try
    {
        cityInfo["Hagenberg"] = 2_500;
        cityInfo["Linz"] = 200_000;
        cityInfo["Linz"] = 210_000;

        cityInfo["Wien"] = 1_900_000;
        cityInfo.Add("Wien", 1_700_000); // ArgumentException
    }
    catch (ArgumentException e) {
        Console.WriteLine($"{e.GetType().Name}: {e.Message}");
    }

    try
    {
        Console.WriteLine($"cityInfo[\"Hagenberg\"]: {cityInfo["Hagenberg"]}");
        Console.WriteLine($"cityInfo[\"Linz\"]: {cityInfo["Linz"]}");
        Console.WriteLine($"cityInfo[\"Wien\"]: {cityInfo["Wien"]}");
        Console.WriteLine($"cityInfo[\"Graz\"]: {cityInfo["Graz"]}"); // KeyNotFoundException
    } catch(KeyNotFoundException e) {
        Console.WriteLine($"{e.GetType().Name}: {e.Message}");
    }

    return cityInfo;

}

void PrintDictionary<K, V>( Dictionary<K, V> dict)
{
    foreach (var item in dict) {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}



var cityInfo = TestIndexerAndAdd();