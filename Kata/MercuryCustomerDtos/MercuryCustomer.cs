namespace roman_numerals_kata.MercuryCustomerDtos;

public class MercuryCustomer
{
    public int CompanyId { get; set; }
    public List<User> Users { get; set; }
    public string TradeName { get; set; }
    public string LegalName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhoneNumber { get; set; }
}