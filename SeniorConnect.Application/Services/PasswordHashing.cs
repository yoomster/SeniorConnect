﻿using System.Security.Cryptography;
using System.Text;

namespace SeniorConnect.Application.Services;

internal static class PasswordHashing
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}