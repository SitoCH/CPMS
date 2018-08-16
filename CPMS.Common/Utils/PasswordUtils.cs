using System;
using System.Linq;
using System.Text;

namespace CPMS.Common.Utils
{
    public static class PasswordUtils
    {
        public static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Convert.FromBase64String(storedSalt)))
            {
                var hash = Convert.FromBase64String(storedHash);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != hash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
