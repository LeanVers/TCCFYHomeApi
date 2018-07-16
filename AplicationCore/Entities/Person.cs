using AplicationCore.Sevices.Dtos;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace AplicationCore.Entities
{
    public class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Passphrase { get; set; }
        public string KeyPassphrase { get; set; }

        public void CriptografarSenha()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            KeyPassphrase = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Passphrase,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Passphrase = hashed;
        }
    }
}
