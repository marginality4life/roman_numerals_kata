namespace roman_numerals_kata;

public static class Numerals
{
    public static int Fibbonacci(int iter)
    {
        if (iter == 1 || iter == 2)
            return 1;
        return Fibbonacci(iter - 1) + Fibbonacci(iter - 2);
    }
}