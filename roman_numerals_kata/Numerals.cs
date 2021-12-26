namespace roman_numerals_kata;

public static class Numerals
{
    public static int FindPowerConsumption(int[] bootingPower, int[] processingPower)
    {
        return FindProcessingPower(processingPower) + FindBootingPower(bootingPower);
    }

    public static int FindProcessingPower(int[] processingPower)
    {
        var power = 0;
        foreach (var t in processingPower)
        {
            power += t;
        }
        return power * processingPower.Length;
    }

    public static int FindBootingPower(int[] bootingPower)
    {
        var power = 0;
        foreach (var t in bootingPower)
        {
            if (t > power)
                power = t;
        }
        return power;
    }

    public static int FindMaximumSustainableClusterSize(int[] processingPower, int[] bootingPower, int powerMax)
    {
        if (FindPowerConsumption(bootingPower, processingPower) <= powerMax)
            return processingPower.Length;
        
        if (processingPower.Length == 1 && FindPowerConsumption(bootingPower, processingPower) > powerMax)
            return 0;

        var leftArrayMax = FindMaximumSustainableClusterSize(GetLeftArraySlice(processingPower),
            GetLeftArraySlice(bootingPower), powerMax);
        var rightArrayMax = FindMaximumSustainableClusterSize(GetRightArraySlice(processingPower),
            GetRightArraySlice(bootingPower), powerMax);
        
        if (leftArrayMax > rightArrayMax)
            return leftArrayMax;
        return rightArrayMax;
    }

    public static int[] GetLeftArraySlice(int[] inputArray)
    {
        var outputArray = new int[inputArray.Length - 1];
        for (var i = 0; i < inputArray.Length - 1; i++)
        {
            outputArray[i] = inputArray[i];
        }
        return outputArray;
    }

    public static int[] GetRightArraySlice(int[] inputArray)
    {
        var outputArray = new int[inputArray.Length - 1];
        for (var i = 1; i < inputArray.Length; i++)
        {
            outputArray[i-1] = inputArray[i];
        }
        return outputArray;
    }
} 