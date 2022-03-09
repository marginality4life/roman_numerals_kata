using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    public void FibbonacciTest(int iter, int result)
    {
        Assert.Equal(result, Numerals.Fibbonacci(iter));
        
    }
}