using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptamajigCore
{
    public static class SHA256Encryptamajig
    {
        /// <summary>
        /// Hashes the given plain text using SHA256        
        /// </summary>
        /// <param name="plainText">The plain text to be hashed</param>        
        /// <returns>SHA256 hash, each byte is transformed into hex, so the size of the resulting string is 64 ASCII characters</returns>
        public static string HashToHex(string plainText)
        {
            var result = HashToBinary(plainText);
            var resStrBuilder = new StringBuilder(2 * result.Length);
            for (int i = 0; i < result.Length; i++)
            {
                resStrBuilder.Append(result[i].ToString("X2"));
            }
            return resStrBuilder.ToString();
        }
        /// <summary>
        /// Hashes the given plain text using SHA256        
        /// </summary>
        /// <param name="plainText">The plain text to be hashed</param>        
        /// <returns>SHA256 hash</returns>
        public static byte[] HashToBinary(string plainText)
        {
            //User Error Checks
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            }
        }
    }
}
