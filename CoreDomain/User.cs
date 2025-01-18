namespace SeniorConnect.Domain;

public class User
{
    public User(
       string firstName,
       string lastName,
       string email,
       string password,
       DateOnly dateOfBirth,
       char gender,
       string origin,
       MaritalEnum maritalStatus,
       string streetName,
       string houseNumber,
       string zipcode,
       string city,
       string country)
    {
        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new ArgumentException("Email format is incorrect, moet @ bevatten.");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new ArgumentException("Wachtwoord is incorrect, deze moet minstens 6 characters bevatten.");

        if (dateOfBirth >= DateOnly.FromDateTime(DateTime.Now))
            throw new ArgumentException("Geboortedatum moet in het verleden zijn.");

        if (!new[] { 'M', 'F', 'O' }.Contains(gender))
            throw new ArgumentException("Uw geslacht moet 'M', 'F', of 'O' zijn.");

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Origin = origin;
        MaritalStatus = maritalStatus;
        StreetName = streetName;
        HouseNumber = houseNumber;
        Zipcode = zipcode;
        City = city;
        Country = country;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public char Gender { get; init; }
    public string Origin { get; init; }
    public MaritalEnum MaritalStatus { get; init; }
    public DateOnly DateOfRegistration { get; init; } = DateOnly.FromDateTime(DateTime.Now);
    public string StreetName { get; init; }
    public string HouseNumber { get; init; }
    public string Zipcode { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
}