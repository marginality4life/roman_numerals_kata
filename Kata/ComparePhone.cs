namespace roman_numerals_kata;

public static class ComparePhone
{
    public static bool CompareListPhoneNumbers(string mercuryNumber, List<string> thirdPartyNumbers)
    {
        return thirdPartyNumbers.Any(number => ComparePhoneNumbers(number, mercuryNumber));
    }
    
    public static bool ComparePhoneNumbers(string number1, string number2)
    {
        return NormalizePhoneNumber(number1).Equals(NormalizePhoneNumber(number2));
    }

    private static string NormalizePhoneNumber(string number)
    {
        var numArray = number.ToCharArray().Where(NumberAllowed);
        var output = "";
        foreach (var num in numArray)
        {
            output += num.ToString();
        }
        return output;
    }

    private static bool NumberAllowed(char number)
    {
        switch (number)
        {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                return true;
        }
        return false;
    }
}