using System.Collections.Generic;
using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class ComparePhoneTest
{
    [Fact]
    public void PhoneNumberCompareList()
    {
        Assert.True(ComparePhone.CompareListPhoneNumbers("(555)-760-9870", new List<string>{"5557609870"}));
        Assert.False(ComparePhone.CompareListPhoneNumbers("(555)-760-9870", new List<string>()));
    }
    
    [Theory]
    [InlineData("(555)-760-9870", "5557609870", true)]
    [InlineData("1111111111", "5557609870", false)]
    public void PhoneNumberCompare(string number1, string number2, bool outcome)
    {
        Assert.Equal(outcome, ComparePhone.ComparePhoneNumbers(number1, number2));
    }
}