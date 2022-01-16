using Newtonsoft.Json;
using roman_numerals_kata.GlossaryDtos;

namespace roman_numerals_kata;

public static class ReadJson
{
    public static string ReadJsonString(string fileLocation)
    {
        var readText = File.ReadAllText(fileLocation);
        return readText;
    }

    public static Glossary DeserializeIntoGlossaryObject(string fileLocation)
    {
        var fileString = ReadJsonString(fileLocation);

        var outputObject = JsonConvert.DeserializeObject<Glossary>(fileString);
        return outputObject;
    }

    public static List<Client> DeserializeIntoClientList(string fileLocation)
    {
        var fileString = ReadJsonString(fileLocation);

        var outputObject = JsonConvert.DeserializeObject<List<Client>>(fileString);
        return outputObject;
    }

    public static List<Client>? LinqQuery(IEnumerable<Client> enumerable)
    {
        var activeClientQuery =
            (from client in enumerable
                where client.isActive
                select client).ToList();
        return activeClientQuery;
    }
    
    public static List<Client>? SimpleLinqQuery(IEnumerable<Client> enumerable)
    {
        var activeClientQuerySimple = enumerable.Where(x => x.isActive).OrderByDescending(x => x.age).ToList();
        return activeClientQuerySimple;
    }
    
    public static List<Client>? LinqQueryPlay(IEnumerable<Client> enumerable)
    {
        //var activeClientQuerySimple = enumerable.Where(x => x.isActive).OrderByDescending(x => x.age).ToList();
        var activeClientQuerySimple = enumerable.Where(x => x.isActive).OrderByDescending(x => x.age).ToList();
        return activeClientQuerySimple;
    }
}