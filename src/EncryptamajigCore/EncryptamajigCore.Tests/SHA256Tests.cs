using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptamajigCore.Tests
{
    [TestClass]
    public class SHA256Tests
    {
        public static readonly string[] RawData = { "test normal string", " ", ".", "test special 家, é" };
        //from https://passwordsgenerator.net/sha256-hash-generator/
        public static readonly string[] OnlineHashes =
            {
                "042D306BAF49AAA608B9D3A8A0B266C75ADD94E139A434D95517843952361BEA",
                "36A9E7F1C95B82FFB99743E0C5C4CE95D83C9A430AAC59F84EF3CBFAB6145068",
                "CDB4EE2AEA69CC6A83331BBE96DC2CAA9A299D21329EFB0336FC02A82E1839A8",
                "99E5783D8621C03B2206BEEF1C62979AD3DAD26BFAEBBBE1BB5688DE678F890D"
            };
        [TestMethod]
        public void SHA256CompareCurrentHashesToOnlineHashes()
        {
            for (int i = 0; i < RawData.Length; i++)
            {
                var raw = RawData[i];
                var res = SHA256Encryptamajig.HashToHex(raw);
                Assert.AreEqual(OnlineHashes[i], res);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "an ArgumentNullException should've been thrown")]
        public void RaiseExceptionWhenEmbtyStringIsInputted()
        {
            SHA256Encryptamajig.HashToHex(string.Empty);
        }
    }
}
