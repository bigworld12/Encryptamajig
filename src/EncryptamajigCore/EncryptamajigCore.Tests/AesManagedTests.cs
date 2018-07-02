using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
namespace Encryptamajig.Tests
{
    [TestClass]
    public class AesManagedTests
    {
        [TestMethod]
        public void AesManaged_NewInstances_ReturnsNewKeyAndIv()
        {
            // Arrange
            // Act
            var aesManaged = new AesManaged();
            var aesManaged2 = new AesManaged();

            Console.WriteLine(Convert.ToBase64String(aesManaged.Key));
            Console.WriteLine(Convert.ToBase64String(aesManaged2.Key));

            Console.WriteLine(Convert.ToBase64String(aesManaged.IV));
            Console.WriteLine(Convert.ToBase64String(aesManaged2.IV));

            // Assert
            Assert.AreNotEqual(aesManaged.Key, aesManaged2.Key);
            Assert.AreNotEqual(aesManaged.IV, aesManaged2.IV);
        }
    }
}
