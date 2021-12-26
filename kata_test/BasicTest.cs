using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Fact]
    public void FindMaxClusterSize()
    {
        var bootingPower = new int[] {3, 6, 1, 3, 4};
        var processingPower = new int[] {2, 1, 3, 4, 5};
        var powerMax = 25;
        
        Assert.Equal(3, Numerals.FindMaximumSustainableClusterSize(processingPower, bootingPower, powerMax));
    }
    
    [Fact]
    public void FindClusterSizeZero()
    {
        var bootingPower = new int[] {3, 6, 7, 3, 4};
        var processingPower = new int[] {3, 8, 3, 4, 5};
        var powerMax = 2;
        
        Assert.Equal(0, Numerals.FindMaximumSustainableClusterSize(processingPower, bootingPower, powerMax));
    }
    
    [Fact]
    public void FindBootingPowerReturnsMax()
    {
        Assert.Equal(5, Numerals.FindBootingPower(new int[] {3,2,4,5}));
    }

    [Fact]
    public void FindProcessingPower()
    {
        Assert.Equal(56, Numerals.FindProcessingPower(new int[] {3,2,4,5}));
    }

    [Fact]
    public void FindPowerConsumption()
    {
        var bootingPower = new int[] {3, 6, 1};
        var processingPower = new int[] {2, 1, 3};
        Assert.Equal(24, Numerals.FindPowerConsumption(bootingPower, processingPower));
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
}