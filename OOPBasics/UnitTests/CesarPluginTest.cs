using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPBasicsCesarEncoder;
using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class CesarPluginTest
    {
        private String expectedResultName = "Cesar";

        [TestMethod]
        public void TestGetName()
        {
            IEncoderPlugin cesarPlugin = new CesarEncoderPlugin();

            String result = cesarPlugin.GetName();

            Assert.AreEqual(expectedResultName, result);
        }
    }
}
