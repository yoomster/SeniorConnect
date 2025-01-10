﻿using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    public Task CreateAccountToDBAsync(User user);

    public Task<User?> GetByIdAsync(int id);

    public Task<List<User>> GetAllAsync();

    public Task<bool> UpdateAccountAsync(User user);

    public Task<bool> DeleteAccountAsync(int userId);

    //public Task<bool> IsEmailRegistered(string email);

}