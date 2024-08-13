namespace roman_numerals_kata.Dtos;

public class MercuryCustomer
{
    public int companyId;
    public List<user> users;
    public string tradeName;
    public string legalName;
    public string contactEmail;
    public string contactPhoneNumber;
}

public class user
{
    public string firstName;
    public string lastName;
    public string email;
}