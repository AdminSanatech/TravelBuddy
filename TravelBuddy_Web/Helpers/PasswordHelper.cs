using System;
using System.Security.Cryptography;
using System.Text;

namespace TravelBuddy_Web.Helpers
{   
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool VerifyPassword(string password, string storedHash)
        {
         
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }

}
