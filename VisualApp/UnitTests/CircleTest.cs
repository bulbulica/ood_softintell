using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VisualApp;

namespace UnitTests
{
    [TestClass]
    public class CircleTest
    {
        private Dictionary<String, object> values = new Dictionary<string, object>();

        private double expectedResultComputeArea = 50.264;

        [TestMethod]
        public void TestCircleComputeArea()
        {
            values.Add("Raza", (double)4.0);

            Shape circle = new Circle(values, 1);

            Assert.AreEqual(expectedResultComputeArea, circle.ComputeArea());
        }
    }
}
