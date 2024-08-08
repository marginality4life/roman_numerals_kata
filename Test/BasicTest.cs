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
    
   
    [Fact]
    public void Fibbonacci()
    {
        var numerals = new Numerals();
        
        Assert.Equal(1,numerals.Fibbonacci(1));
        Assert.Equal(1,numerals.Fibbonacci(2));
        Assert.Equal(2,numerals.Fibbonacci(3));
        Assert.Equal(3,numerals.Fibbonacci(4));
        Assert.Equal(5,numerals.Fibbonacci(5));
    }
}