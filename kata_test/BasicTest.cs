using Xunit;
using roman_numerals_kata;
using roman_numerals_kata.GlossaryDtos;

namespace kata_test;

public class BasicTest
{
    [Fact]
    public void ReturnsZero()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/glossary.text";
        Assert.True(ReadJson.ReadJsonString(fileName).Length > 0);
    }

    [Fact]
    public void DeserializesToObject()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/glossary.text";

        var outputGlossary = ReadJson.DeserializeFromFile(fileName);
        Assert.True(outputGlossary.GetType() == typeof(Glossary));
    }
}