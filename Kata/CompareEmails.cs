using roman_numerals_kata.MercuryCustomerDtos;
using roman_numerals_kata.ThirdPartyCustomerDtos;

namespace roman_numerals_kata;

public static class CompareEmails
{
    public static LinkMatch EvaluateEmail(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        var match = new LinkMatch();
        match.LinkId = thirdPartyCustomer.LinkId;
        match.Match = EmailsMatch(mercuryCustomer, thirdPartyCustomer);
        return match;
    }
    
    public static bool EmailsMatch(MercuryCustomer mercuryCustomer, ThirdPartyCustomer thirdPartyCustomer)
    {
        foreach (var email in thirdPartyCustomer.Emails)
        {
            foreach (var user in mercuryCustomer.Users)
            {
                if (user.Email.Equals(email))
                    return true;
            } 
        }

        foreach (var email in thirdPartyCustomer.Emails)
        {
            if (email.Equals(mercuryCustomer.ContactEmail))
                return true;
        }

        return false;
    }
    
}