﻿using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IActivityRepository
{
    public Task SaveUserToDBAsync(User user);
    public Task<List<User>> GetUsersAsync();
    public bool IsDuplicateEmail(string email);
    public Task UpdateUserAsync(User user, Address address);

}

