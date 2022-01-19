using Xunit;
using roman_numerals_kata;

namespace kata_test;

public class BasicTest
{
    
    [Fact]
    public void TestReadFile()
    {
        var mercuryString = FileReader.ReadMercuryCustomers();
        Assert.True(mercuryString.Length > 0);
        
        var thirdPartyString = FileReader.ReadThirdPartyBanks();
        Assert.True(thirdPartyString.Length > 0);
    }

    [Fact]
    public void TestMercuryDeserialization()
    {
        var mercuryCustomerList = FileReader.DeserializeMercuryCustomers();
        Assert.True(mercuryCustomerList.Count > 0);
    }
    
    [Fact]
    public void TestThirdPartyDeserialization()
    {
        var mercuryCustomerList = FileReader.DeserializeThirdParty();
        Assert.True(mercuryCustomerList.Count > 0);
    }
    
}