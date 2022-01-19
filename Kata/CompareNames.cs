using roman_numerals_kata.MercuryCustomerDtos;
using roman_numerals_kata.ThirdPartyCustomerDtos;

namespace roman_numerals_kata;

public static class CompareNames
{
    public static LinkMatch EvaluateName(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        var match = new LinkMatch();
        match.LinkId = thirdPartyCustomer.LinkId;
        match.Match = NamesMatch(mercuryCustomer, thirdPartyCustomer);
        return match;
    }

    public static bool NamesMatch(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        var thirdPartyNameList = ThirdPartyNames(thirdPartyCustomer);
        var mercuryNames = MercuryNames(mercuryCustomer);

        
        foreach (var name in thirdPartyNameList)
        {
            if (mercuryNames.Any(x => x.Equals(name)))
                return true;
        }

        return false;
    }

    private static List<string> ThirdPartyNames(ThirdPartyCustomer customer)
    {
        var thirdPartyNamesList = new List<string>();
        foreach (var name in customer.Names)
        {
            var splitNames = name.Split();
            foreach (var splitName in splitNames)
            {
                thirdPartyNamesList.Add(splitName);
            }
        }

        return thirdPartyNamesList;
    }

    public static List<string> MercuryNames(MercuryCustomer mercuryCustomer)
    {
        var namesList = new List<string>();
        foreach (var name in mercuryCustomer.TradeName.Split())
        {
            namesList.Add(name);
        }
        foreach (var name in mercuryCustomer.LegalName.Split())
        {
            namesList.Add(name);
        }

        foreach (var user in mercuryCustomer.Users)
        {
            namesList.Add(user.FirstName);
            namesList.Add(user.LastName);
        }

        return namesList;
    }
}