using System.Collections.Generic;
using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Theory]
    [InlineData(1,50)]
    [InlineData(2,100)]
    [InlineData(3,130)]
    [InlineData(4,180)]
    public void ReturnsCorrectPriceWithSpecialPrice(int quantity, int total)
    {
        var A = new Item("A", 50, new SpecialPrice(3, 130));

        for (int i = 0; i < quantity; i++)
        {
            A.Add();
        }

        Assert.Equal(total, A.Total());
    }
    
    [Theory]
    [InlineData(1,50)]
    [InlineData(2,100)]
    public void ReturnsCorrectPrice(int quantity, int total)
    {
        var A = new Item("A", 50);

        for (int i = 0; i < quantity; i++)
        {
            A.Add();
        }

        Assert.Equal(total, A.Total());
    }

    [Fact]
    public void TestIncremental()
    {
        var pricingRules = new List<Item>
        {
            new Item("A", 50, new SpecialPrice(3, 130)),
            new Item("B", 30, new SpecialPrice(2, 45)),
            new Item("C", 20),
            new Item("D", 15)
        };

        var checkout = new Checkout(pricingRules);
        
        checkout.Scan("A"); Assert.Equal(50, checkout.Total);
        checkout.Scan("B"); Assert.Equal(80, checkout.Total);
        checkout.Scan("A"); Assert.Equal(130, checkout.Total);
        checkout.Scan("A"); Assert.Equal(160, checkout.Total);
        checkout.Scan("B"); Assert.Equal(175, checkout.Total);
    }

    [Theory]
    [InlineData(0, "")]
    [InlineData(50, "A")]
    [InlineData(80, "AB")]
    [InlineData(115, "CDBA")]
    
    [InlineData(100, "AA")]
    [InlineData(130, "AAA")]
    [InlineData(180, "AAAA")]
    [InlineData(230, "AAAAA")]
    [InlineData(260, "AAAAAA")]
    
    [InlineData(160, "AAAB")]
    [InlineData(175, "AAABB")]
    [InlineData(190, "AAABBD")]
    [InlineData(190, "DABABA")]
    public void TestTotals(int total, string items)
    {
        var pricingRules = new List<Item>
        {
            new Item("A", 50, new SpecialPrice(3, 130)),
            new Item("B", 30, new SpecialPrice(2, 45)),
            new Item("C", 20),
            new Item("D", 15)
        };

        var checkout = new Checkout(pricingRules);

        foreach (var item in items.ToCharArray())
        {
          checkout.Scan(item.ToString()); 
        }
        
        Assert.Equal(total, checkout.Total);
    }
}