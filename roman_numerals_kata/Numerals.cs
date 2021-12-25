namespace roman_numerals_kata;

public static class Numerals
{
    public static int GetProduct(int[] inputArray)
    {
        var product = inputArray[0];
        if (inputArray.Length > 1)
        {
            for (var i = 1; i < inputArray.Length; i++)
            {
                product = product * inputArray[i];
            }
        }

        return product;
    }

    public static int GetLength(int[] inputArray)
    {
        if (GetProduct(inputArray) == 1)
            return inputArray.Length;

        if (inputArray.Length == 1 && GetProduct(inputArray) == -1)
            return 0;

        var leftArray = GetLeftArraySlice(inputArray);
        var rightArray = GetRightArraySlice(inputArray);

        var leftArrayLength = GetLength(leftArray);
        var rightArrayLength = GetLength(rightArray);

        if (leftArrayLength > rightArrayLength)
            return leftArrayLength;
        return rightArrayLength;
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