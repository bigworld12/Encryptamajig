namespace Encryptamajig.Tester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using EncryptamajigCore;

    class Program
    {
        // A test credit card number
        private static readonly string _plainText = "4111111111111111";

        // The key should be a random string of characters that an attacker could never guess
        private static readonly string _key = "Something you can't guess";

        static void Main(string[] args)
        {
            Console.WriteLine("AES Test :");
            var encrypted = AesEncryptamajig.Encrypt(_plainText, _key);
            var roundtrip = AesEncryptamajig.Decrypt(encrypted, _key);            
            Console.WriteLine($"Plain Text : {_plainText}");
            Console.WriteLine($"Encrypted : {encrypted}");
            Console.WriteLine($"Roundtrip : {roundtrip}");
            Console.WriteLine("======================================");
            Console.WriteLine("SHA256 Test :");
            var hashed = SHA256Encryptamajig.HashToHex(_plainText);
            var resultFromOnlineHash = "9BBEF19476623CA56C17DA75FD57734DBF82530686043A6E491C6D71BEFE8F6E";
            Console.WriteLine($"Library Hash : {hashed}");
            Console.WriteLine($"Online Hash  : {resultFromOnlineHash}");
            Console.ReadLine();
        }
    }
}
