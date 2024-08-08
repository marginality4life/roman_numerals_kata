namespace roman_numerals_kata;

public class Numerals
{
    public static string ToRoman(int input)
    {
        return "0";
    }
    
    private Dictionary<int, int> FibCache = new Dictionary<int, int>();
    
    public int Fibbonacci(int input)
    {
        if (FibCache.ContainsKey(input))
            return FibCache[input];
        
        if (input < 1)
            return -1;
        if (input == 1)
            return 1;
        if (input == 2)
            return 1;
        
        var result = Fibbonacci(input - 1) + Fibbonacci(input - 2);
        FibCache[input] = result;
        return result;
    }

}