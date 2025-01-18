using SeniorConnect.Application.Services;
using SeniorConnect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Interfaces
{
    public interface IValidator
    {
        Task<ValidationResult> IsValid(User user);
    }
}
