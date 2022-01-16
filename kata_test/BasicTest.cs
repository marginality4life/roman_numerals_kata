using System.Collections.Generic;
using System.Linq;
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
    public void ReadLongFile()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/package-lock.json";
        var contentsString = ReadJson.ReadJsonString(fileName);
        Assert.True(contentsString.Length > 0);
    }

    [Fact]
    public void ReadDbFile()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/db.json";
        var contentsString = ReadJson.ReadJsonString(fileName);
        Assert.True(contentsString.Length > 0);
    }
    
    [Fact]
    public void DeserializesToDbList()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/db.json";

        var outputClientList = ReadJson.DeserializeIntoClientList(fileName);
        Assert.True(outputClientList.GetType() == typeof(List<Client>));
    }
    
    
    [Fact]
    public void DeserializesThenUseLinq()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/db.json";
        var outputClientList = ReadJson.DeserializeIntoClientList(fileName);

        var activeClientQuery = ReadJson.LinqQuery(outputClientList);
        Assert.Equal(4, activeClientQuery!.Count);
    }
    
    [Fact]
    public void DeserializesThenUseSimpleLinq()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/db.json";
        var outputClientList = ReadJson.DeserializeIntoClientList(fileName);

        var activeClientQuerySimple = ReadJson.SimpleLinqQuery(outputClientList);
        Assert.Equal(4, activeClientQuerySimple!.Count);
    }
    
    [Fact]
    public void DeserializesToGlossaryObject()
    {
        var fileName = "/home/simon/RiderProjects/roman_numerals_kata/glossary.text";

        var outputGlossary = ReadJson.DeserializeIntoGlossaryObject(fileName);
        Assert.True(outputGlossary.GetType() == typeof(Glossary));
    }

    class City 
    {
        public string Name { get; set; }
        public int Population { get; set; }
    }

    class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
    
        List<Country> _countries = new List<Country>
        {
            new Country
            {
                Name = "New Zealand",
                Cities = new List<City>
                {
                    new City {Name = "Dunedin", Population = 100000},
                    new City {Name = "Christchurch", Population = 400000},
                    new City {Name = "Wellington", Population = 350000},
                    new City {Name = "Auckland", Population = 1000000}
                }
            },
            new Country
            {
                Name = "United States of Canada",
                Cities = new List<City>
                {
                    new City {Name = "Vancouver", Population = 4000000},
                    new City {Name = "Denver", Population = 5000000},
                    new City {Name = "New Orleans", Population = 12000000},
                    new City {Name = "Tulsa", Population = 500000}
                }
            }
        };
    [Fact]
    public void PlayAroundWithLinq()
    {
        var LargeCityNameList = 
            (from country in _countries
            from city in country.Cities
            where city.Population > 500000
                select city.Name).ToList();

        var LargeCityNameListMethod = 
            (_countries.SelectMany(country => country.Cities, (country, city) => new {country, city})
                .Where(x => x.city.Population > 500000)
                .Select(x => x.city.Name)).ToList();

        var AllCityNameListMethod =
            (_countries.SelectMany(country => country.Cities, (country, city) => new {country, city})).ToList();
    }
}