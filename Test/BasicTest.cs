using System;
using System.Collections.Generic;
using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    [Fact]
    public void ReturnsEmpty()
    {
        var rack = new Rack();
        Assert.Equal(new List<int>(), rack.Balls);
    }

    [Fact]
    public void BallsAddWorks()
    {
        var rack = new Rack();
        
        rack.Add(3);
        Assert.Equal(new List<int>{3}, rack.Balls);
        
        rack.Add(1);
        Assert.Equal(new List<int>{1,3}, rack.Balls);
        
        rack.Add(8);
        Assert.Equal(new List<int>{1,3,8}, rack.Balls);
        
        rack.Add(5);
        Assert.Equal(new List<int>{1,3,5,8}, rack.Balls);
        
        rack.Add(4);
        Assert.Equal(new List<int>{1,3,4,5,8}, rack.Balls);
        
        rack.Add(22);
        Assert.Equal(new List<int>{1,3,4,5,8,22}, rack.Balls);
    }
}