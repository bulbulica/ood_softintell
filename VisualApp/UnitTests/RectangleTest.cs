using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VisualApp;

namespace UnitTests
{
    [TestClass]
    public class RectangleTest
    {
        private Dictionary<String, object> values = new Dictionary<string, object>();

        private double expectedResultComputeArea = 24.91;

        [TestMethod]
        public void TestRectangleComputeArea()
        {
            values.Add("Latura1", (double)5.3);
            values.Add("Latura2", (double)4.7);

            Shape rectangle = new Rectangle(values, 1);

            Assert.AreEqual(expectedResultComputeArea, rectangle.ComputeArea());
        }
    }
}
