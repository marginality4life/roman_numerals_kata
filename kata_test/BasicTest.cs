using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Fact]
    public void FirstTest()
    {
        Assert.Equal("i",Numerals.ToRoman(1));
    }
    
    [Theory]
    [InlineData(1, "i")]
    [InlineData(2, "ii")]
    [InlineData(3, "iii")]
    [InlineData(4, "iv")]
    [InlineData(5, "v")]
    [InlineData(8, "viii")]
    [InlineData(9, "ix")]
    [InlineData(10, "x")]
    [InlineData(15, "xv")]
    [InlineData(18, "xviii")]
    [InlineData(23, "xxiii")]
    [InlineData(40, "xl")]
    [InlineData(43, "xliii")]
    [InlineData(45, "xlv")]
    [InlineData(49, "xlix")]
    [InlineData(53, "liii")]
    public void TestOnes(int input, string expected)
    {
        Assert.Equal(expected,Numerals.ToRoman(input));
    }
}