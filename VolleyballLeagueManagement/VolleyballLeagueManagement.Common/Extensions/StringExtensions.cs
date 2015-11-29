using System;
using System.Security.Cryptography;
using System.Text;

namespace VolleyballLeagueManagement.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Encrypt password to hash using md5 algorithm 
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Return hash of password</returns>
        public static string Encrypt(this string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder hash = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return hash.ToString();
            }
        }

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hash"></param>
        /// <returns>Return result of compare passwords</returns>
        public static bool CompareWithHash(this string password, string hash)
        {
            // Hash the input password.
            string hashOfInput = password.Encrypt();

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
