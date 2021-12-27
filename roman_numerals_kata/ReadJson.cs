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

    public static Glossary DeserializeFromFile(string fileLocation)
    {
        var fileString = ReadJsonString(fileLocation);

        var outputObject = JsonConvert.DeserializeObject<Glossary>(fileString);
        return outputObject;
    }

}