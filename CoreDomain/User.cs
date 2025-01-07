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
            throw new ArgumentException("Invalid email address.", nameof(email));

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters long.", nameof(password));

        if (dateOfBirth >= DateOnly.FromDateTime(DateTime.Now))
            throw new ArgumentException("Date of birth must be in the past.", nameof(dateOfBirth));

        if (!new[] { 'M', 'F', 'O' }.Contains(gender))
            throw new ArgumentException("Gender must be 'M', 'F', or 'O'.", nameof(gender));

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