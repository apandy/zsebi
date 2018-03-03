using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Zsebi2.Models
{
    public class UserModel
    {
        public UserModel(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }
        
        public void EncryptPassword(string passwrod)
        {
            byte[] salt = GenerateSalt();

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = HashPassword(passwrod, salt);

            PasswordHash = $"{ Convert.ToBase64String(salt) }:{ hashed }";

        }

        private static string HashPassword(string passwrod, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: passwrod,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8));
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public bool CheckPassword(string passwrod)
        {
            var parts = PasswordHash.Split(':');

            var salt = Convert.FromBase64String(parts[0]);

            var hashed = HashPassword(passwrod, salt);
            
            return parts[1].Equals(hashed);
        }

        public string Email { get; set; }
        public string PasswordHash { get; private set; }
    }
}