using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Theory]
    [InlineData(new int[] {1,1, -1}, -1)]
    [InlineData(new int[] {1, -1}, -1)]
    [InlineData(new int[] {-1}, -1)]
    public void ReturnsArrayProduct(int[] inputArray, int product)
    {
        Assert.Equal(product,Numerals.GetProduct(inputArray));
    }

    [Fact]
    public void ReturnsLeftArraySlice()
    {
        var inputArray = new int[] {1, 2, 3};
        Assert.Equal(new int[] {1,2}, Numerals.GetLeftArraySlice(new int[] {1,2,3}));
    }

    [Fact]
    public void ReturnsRightArraySlice()
    {
        var inputArray = new int[] {1, 2, 3};
        Assert.Equal(new int[] {2,3}, Numerals.GetRightArraySlice(new int[] {1,2,3}));
    }
    
    [Theory]
    [InlineData(new int[] {1, -1, -1, 1, 1, -1}, 5)]
    [InlineData(new int[] {1, 1, -1, 1, 1}, 2)]
    public void ReturnsLongestSubArrayLength(int[] inputArray, int length)
    {
        Assert.Equal(length,Numerals.GetLength(inputArray));
    }
    
}