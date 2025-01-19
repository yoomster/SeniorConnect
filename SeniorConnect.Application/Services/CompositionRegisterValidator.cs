using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class CompositionRegisterValidator : IValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public CompositionRegisterValidator(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public async Task<ValidationResult> IsValid(User user)
        {
            var validationResult = new ValidationResult { IsSuccess = true };

            foreach (var validator in _validators)
            {
                var result = await validator.IsValid(user);

                if (!result.IsSuccess)
                {
                    validationResult.IsSuccess = false;
                    validationResult.Messages.AddRange(result.Messages);
                }
            }

            return validationResult;
        }
    }
}
