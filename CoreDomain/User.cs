namespace SeniorConnect.Domain;

public class User
{
    public int Id;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    private string _email;
    public required string Email
    {
        get { return _email; }
        init
        {
            if (IsAcceptableInput(value))
                _email = value;
        }
    }
    private bool IsAcceptableInput(string value)
    {
        //check for empty||null
        if (string.IsNullOrEmpty(value))
            return true;
        else
            return false;
    }

    private string _password;

    public required string Password
    {
        get { return _password; }
        set
        {
            HashPassword(value);
            _password = value;
        }
    }

    private bool HashPassword(string value)
    {
        throw new NotImplementedException();
    }

    public DateOnly DateOfBirth { get; set; }
    public required char Gender { get; set; }
    public required string Origin { get; set; }
    public DateOnly DateOfRegistration { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public required string StreetName { get; set; }
    public required string HouseNumber { get; set; }
    public required string Zipcode { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }

    public string GetAddress()
    {
        return $"{StreetName} {HouseNumber}, {Zipcode} {City}, {Country}";
    }

}