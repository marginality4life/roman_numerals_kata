using Newtonsoft.Json;
using roman_numerals_kata.Dtos;

namespace roman_numerals_kata;

public static class FileReader
{
    private const string ThirdPartyBanks =
        "/home/simon/RiderProjects/roman_numerals_kata/third-party-banks.json";

    private const string MercuryCustomers = "/home/simon/RiderProjects/roman_numerals_kata/mercury-customers.json";
    
    private const string NickNames = "/home/simon/RiderProjects/roman_numerals_kata/extra-questions/nicknames.txt";

    public static List<MercuryCustomer> DeserializeMercuryCustomers()
    {
        var customerString = File.ReadAllText(MercuryCustomers);
        return JsonConvert.DeserializeObject<List<MercuryCustomer>>(customerString);
    }
    
    public static List<ThirdPartyCustomer> DeserializeThirdParty()
    {
        var customerString = File.ReadAllText(ThirdPartyBanks);
        return JsonConvert.DeserializeObject<List<ThirdPartyCustomer>>(customerString);
    }
    
    public static Dictionary<string, List<string>> DeserializeNickNames()
    {
        var nickNames = new Dictionary<string, List<string>>();
        var lines = File.ReadAllLines(NickNames);
        foreach (var line in lines)
        {
            var names = line.Split(",");
            if (nickNames.ContainsKey(names[0]))
            {
                nickNames[names[0]].AddRange(names.Skip(1));
            }
            else
            {
                nickNames.Add(names[0], names.Skip(1).ToList());
            }
        }

        return nickNames;
    }
}