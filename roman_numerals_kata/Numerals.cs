using System.Net.Http.Headers;

namespace roman_numerals_kata;

public static class Numerals
{
    public static string ToRoman(int input)
    {
        var returnString = "";
        
        returnString += ReturnNumber(input / 50, "l");
        input = input % 50;
        
        if (input + 10 >= 50)
        {
            returnString += "xl";
            input = input - 40;
        }
        
        if (input + 5 >= 50)
        {
            returnString += "vl";
            input = input - 45;
        }

        if (input + 1 == 50)
        {
            returnString += "il";
            input = input - 49;
        }
        
        
        
        returnString += ReturnNumber(input / 10, "x");
        input = input % 10;

        if (input + 1 == 10)
        {
            returnString += "ix";
            input = input - 9;
        }
        
        

        returnString += ReturnNumber(input / 5, "v");
        input = input % 5;
        
        
        if (input + 1 == 5)
        {
            returnString += "iv";
            input = input - 4;
        }
        
        
        
        
        returnString += ReturnNumber(input, "i");

        return returnString;
    }

    private static string ReturnNumber(int input, string number)
    {
        var returnString = "";
        for (int i = 0; i < input; i++)
        {
            returnString += number;
        }

        return returnString;
        
    }

}