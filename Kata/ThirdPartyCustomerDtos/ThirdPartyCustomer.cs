namespace roman_numerals_kata.ThirdPartyCustomerDtos;

public class ThirdPartyCustomer
{
    public int CompanyId { get; set; }
    public int LinkId { get; set; }
    public string Bank { get; set; }
    public List<string> Names { get; set; }
    public List<string> Emails { get; set; }
    public List<string> PhoneNumbers { get; set; }
    public string MercuryFraudTeamComments { get; set; }
}