using roman_numerals_kata.MercuryCustomerDtos;
using roman_numerals_kata.ThirdPartyCustomerDtos;

namespace roman_numerals_kata;

public class Evaluate
{
    private List<MercuryCustomer> _mercuryCustomers;
    private List<ThirdPartyCustomer> _thirdPartyCustomers;

    public Evaluate()
    {
        _mercuryCustomers = FileReader.DeserializeMercuryCustomers();
        _thirdPartyCustomers = FileReader.DeserializeThirdParty();
    }

    public MercuryCustomer FindMercuryCustomerToCompare(ThirdPartyCustomer customer)
    {
        foreach (var mercuryCustomer in _mercuryCustomers)
        {
            if (customer.CompanyId == mercuryCustomer.CompanyId)
                return mercuryCustomer;
        }

        return null;
    }

    private List<LinkMatch> EvaluateBasedOnPhoneNumbers()
    {
        var output = new List<LinkMatch>();
        foreach (var thirdPartyCustomer in _thirdPartyCustomers)
        {
            var cust = EvaluatePhoneNumber(FindMercuryCustomerToCompare(thirdPartyCustomer), thirdPartyCustomer);
            output.Add(cust);
        }

        return output;
    }

    private List<LinkMatch> EvaluateBasedOnEmails()
    {
        var output = new List<LinkMatch>();
        foreach (var thirdPartyCustomer in _thirdPartyCustomers)
        {
            var cust = CompareEmails.EvaluateEmail(FindMercuryCustomerToCompare(thirdPartyCustomer), thirdPartyCustomer);
            output.Add(cust);
        }

        return output;
    }
    
    private List<LinkMatch> EvaluateBasedOnNames()
    {
        var output = new List<LinkMatch>();
        foreach (var thirdPartyCustomer in _thirdPartyCustomers)
        {
            var cust = CompareNames.EvaluateName(FindMercuryCustomerToCompare(thirdPartyCustomer), thirdPartyCustomer);
            output.Add(cust);
        }

        return output;
    }
    
    public void EvaluatePrintOutputNames()
    {
        var matchList = EvaluateBasedOnNames();
        
        Console.WriteLine($"Total matches: {matchList.Count(x => x.Match)}");
        Console.WriteLine($"Total mismatches: {matchList.Count(x => !x.Match)}");
        Console.WriteLine();
        foreach (var item in matchList)
        {
            Console.WriteLine($"Link {item.LinkId}: {BoolToMatch(item.Match)}");
        }
    }
    
    public void EvaluatePrintOutputEmail()
    {
        var matchList = EvaluateBasedOnPhoneNumbers();
        
        Console.WriteLine($"Total matches: {matchList.Count(x => x.Match)}");
        Console.WriteLine($"Total mismatches: {matchList.Count(x => !x.Match)}");
        Console.WriteLine();
        foreach (var item in matchList)
        {
            Console.WriteLine($"Link {item.LinkId}: {BoolToMatch(item.Match)}");
        }
    }

    public void EvaluatePrintOutputPhone()
    {
        var matchList = EvaluateBasedOnPhoneNumbers();
        
        Console.WriteLine($"Total matches: {matchList.Count(x => x.Match)}");
        Console.WriteLine($"Total mismatches: {matchList.Count(x => !x.Match)}");
        Console.WriteLine();
        foreach (var item in matchList)
        {
            Console.WriteLine($"Link {item.LinkId}: {BoolToMatch(item.Match)}");
        }
    }

    private string BoolToMatch(bool match)
    {
        return match ? "Match" : "Mismatch";
    }

    private LinkMatch EvaluatePhoneNumber(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        var match = new LinkMatch();
        match.LinkId = thirdPartyCustomer.LinkId;
        match.Match = ComparePhone.CompareListPhoneNumbers(mercuryCustomer.ContactPhoneNumber, thirdPartyCustomer.PhoneNumbers);

        return match;
    }
}