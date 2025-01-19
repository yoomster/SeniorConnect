﻿using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces
{
    public interface IValidator
    {
        Task<ValidationResult> IsValid(User user);
    }
}
