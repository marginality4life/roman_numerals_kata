using Newtonsoft.Json;
using roman_numerals_kata.MercuryCustomerDtos;
using roman_numerals_kata.ThirdPartyCustomerDtos;

namespace roman_numerals_kata;

public static class FileReader
{
    public static string ReadThirdPartyBanks() =>
        ReadFile("/home/simon/RiderProjects/roman_numerals_kata/third-party-banks.json");

    public static string ReadMercuryCustomers() =>
        ReadFile("/home/simon/RiderProjects/roman_numerals_kata/mercury-customers.json");

    private static string ReadFile(string fileLocation)
    {
        var readText = File.ReadAllText(fileLocation);
        return readText;
    }

    public static List<MercuryCustomer> DeserializeMercuryCustomers()
    {
        var customerString = ReadMercuryCustomers();
        return JsonConvert.DeserializeObject<List<MercuryCustomer>>(customerString);
    }
    
    public static List<ThirdPartyCustomer> DeserializeThirdParty()
    {
        var customerString = ReadThirdPartyBanks();
        return JsonConvert.DeserializeObject<List<ThirdPartyCustomer>>(customerString);
    }
}