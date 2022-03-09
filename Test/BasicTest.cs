using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Fact]
    public void ReturnsZero()
    {
        Assert.Equal("0",Numerals.ToRoman(0));
    }
    
    [Theory]
    [InlineData(0)]
    public void ParameterizedReturnsZero(int input)
    {
        Assert.Equal("0",Numerals.ToRoman(input));
    }
    
}