using System;
using System.Security.Cryptography;
using System.Text;

namespace WebAPIService.Helpers
{
    public static class SecurityHelper
    {
        public static string EncodePasswordToSHA1(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
    }
}