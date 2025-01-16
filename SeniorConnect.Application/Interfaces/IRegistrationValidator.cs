using SeniorConnect.Domain;
using System.Transactions;

namespace SeniorConnect.Application.Interfaces;

internal interface IRegistrationValidator
{
    Task<bool> CanRegister(User user);

}
