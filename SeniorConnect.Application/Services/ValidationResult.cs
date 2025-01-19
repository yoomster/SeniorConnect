namespace SeniorConnect.Application.Services
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set;  }
        public List<string> Messages { get; set; } = new();
    }
}
