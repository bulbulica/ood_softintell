using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPBasicsCesarEncoder;
using OOPBasicsShared;
using System;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class CesarEncoderTest
    {
        private String input = "Anaaremere";

        private byte[] expectedResult = new byte[] { 68, 113, 100, 100, 117, 104, 112, 104, 117, 104 };

        [TestMethod]
        public void TestEncodeLength()
        {
            IEncoder cesarEncoder = new CesarEncoder();

            byte[] result = cesarEncoder.Encode(Encoding.ASCII.GetBytes(input));

            Assert.AreEqual(expectedResult.Length, result.Length);
        }

        [TestMethod]
        public void TestEncodeBytes()
        {
            IEncoder cesarEncoder = new CesarEncoder();

            byte[] result = cesarEncoder.Encode(Encoding.ASCII.GetBytes(input));

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
