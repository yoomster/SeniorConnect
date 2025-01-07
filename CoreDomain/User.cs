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
       string maritalStatus,
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
    public required string FirstName { get; init;  }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required char Gender { get; init; }
    public required string Origin { get; init; }
    public required string MaritalStatus { get; init; }
    public DateOnly DateOfRegistration { get; init; } = DateOnly.FromDateTime(DateTime.Now);
    public required string StreetName { get; init; }
    public required string HouseNumber { get; init; }
    public required string Zipcode { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }

    private bool HashPassword(string value)
    {
        throw new NotImplementedException();
    }
}