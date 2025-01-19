namespace SeniorConnect.Application.Utilities
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}
