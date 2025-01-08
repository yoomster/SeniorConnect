using SeniorConnect.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        public string HashPassword(string plainPassword)
        {
            throw new NotImplementedException();


            //private static /*string*/ void HashPassword(string password, out byte[] salt)
            //{
            //    const int keySize = 64;
            //    const int iterations = 350000;
            //    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            //    salt = RandomNumberGenerator.GetBytes(keySize);

            //    var hash = Rfc2898DeriveBytes.Pbkdf2(
            //        Encoding.UTF8.GetBytes(password),
            //        salt,
            //        iterations,
            //        hashAlgorithm,
            //        keySize);

            //    return Convert.ToHexString(hash);
            //}
        }

        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
