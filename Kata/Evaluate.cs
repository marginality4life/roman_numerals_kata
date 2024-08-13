using roman_numerals_kata.Dtos;

namespace roman_numerals_kata;

public class Evaluate
{
    private List<MercuryCustomer> _mercuryCustomers;
    private List<ThirdPartyCustomer> _thirdPartyCustomers;
    private Dictionary<string, List<string>> _nickNames;
    private const int NameMatchThreshold = 2;

    public Evaluate()
    {
        _mercuryCustomers = FileReader.DeserializeMercuryCustomers();
        _thirdPartyCustomers = FileReader.DeserializeThirdParty();
        _nickNames = FileReader.DeserializeNickNames();
    }
    
    public void EvaluateCustomers()
    {
        var mismatches = 0;
        var matches = 0;
        foreach (var thirdPartyCustomer in _thirdPartyCustomers)
        {
            foreach (var mercuryCustomer in _mercuryCustomers)
            {
                if (thirdPartyCustomer.companyId == mercuryCustomer.companyId)
                {
                    if (NamesMatch(mercuryCustomer, thirdPartyCustomer) && (emailsMatch(thirdPartyCustomer, mercuryCustomer) ||
                        phoneNumbersMatch(thirdPartyCustomer, mercuryCustomer)))
                    {
                        thirdPartyCustomer.matched = true;
                    }
                }
            }
            if (!thirdPartyCustomer.matched)
            {
                mismatches++;
            }
            else
            {
                matches++;
            }
        }
        
        Console.WriteLine($"Total matches: {matches}");
        Console.WriteLine($"Total mismatches: {mismatches}");
        foreach (var thirdPartyCustomer in _thirdPartyCustomers)
        {
            if (thirdPartyCustomer.matched)
            {
                Console.WriteLine($"Link {thirdPartyCustomer.linkId}: Match");
            }
            else
            {
                Console.WriteLine($"Link {thirdPartyCustomer.linkId}: Mismatch");
            }
        }
    }
    
    private bool emailsMatch(ThirdPartyCustomer thirdPartyCustomer, MercuryCustomer mercuryCustomer)
    {
        return thirdPartyCustomer.emails.Contains(mercuryCustomer.contactEmail);
    }
    
    private bool phoneNumbersMatch(ThirdPartyCustomer thirdPartyCustomer, MercuryCustomer mercuryCustomer)
    {
        var cleanedPhoneNumbers = thirdPartyCustomer.phoneNumbers.Select(x =>
            x.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")).ToList();
        
        return cleanedPhoneNumbers.Contains(mercuryCustomer.contactPhoneNumber);
    }
    
    private bool NamesMatch(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        var mercuryNames = GetMercuryNames(mercuryCustomer);
        var thirdPartyNames = GetThirdPartyNames(thirdPartyCustomer);
        var matches = 0;
        foreach (var mercuryName in mercuryNames)
        {
            foreach (var thirdPartyName in thirdPartyNames)
            {
                if ( mercuryName == thirdPartyName || (_nickNames.ContainsKey(thirdPartyName) && _nickNames[thirdPartyName].Contains(mercuryName)) )
                {
                    matches++;
                }
            }
        }
        return matches >= NameMatchThreshold;
    }
    
    private List<string> GetThirdPartyNames(ThirdPartyCustomer thirdPartyCustomer)
    {
        List<string> names = new();
        foreach (var name in thirdPartyCustomer.names)
        {
            names.AddRange(name.Split(' ').ToList());
        }
        return names;
    }
    
    private List<string> GetMercuryNames(MercuryCustomer mercuryCustomer)
    {
        List<string> names = new();
        foreach (var user in mercuryCustomer.users)
        {
            names.AddRange(user.firstName?.Split(' ').ToList() ?? new List<string>());
            names.AddRange(user.lastName?.Split(' ').ToList() ?? new List<string>());
        }
        names.AddRange(mercuryCustomer.legalName?.Split(' ').ToList() ?? new List<string>());
        names.AddRange(mercuryCustomer.tradeName?.Split(' ').ToList() ?? new List<string>());
        
        return names;
    }

}