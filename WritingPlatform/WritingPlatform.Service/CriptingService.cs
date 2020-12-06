using System;
using System.Text;
using System.Security.Cryptography;

namespace WritingPlatform.Service
{
    public static class CriptingService
    {
        public static string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(passwordInBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
