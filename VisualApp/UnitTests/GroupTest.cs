using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VisualApp;

namespace UnitTests
{
    [TestClass]
    public class GroupTest
    {
        private Group group;

        private double expectedResultComputeArea = 72.414;

        [TestMethod]
        public void TestGroupComputeArea()
        {
            group = new Group(3);

            Dictionary<String, object> valuess = new Dictionary<string, object>();
            valuess.Add("Latura1", (double)5);
            valuess.Add("Latura2", (double)4.43);
            Shape rectangle = new Rectangle(valuess, 2);

            Dictionary<String, object> values = new Dictionary<string, object>();
            values.Add("Raza", 4.0);
            values.Add("Centrul cercului", new Tuple<double, double>(2, 3));
            Shape circle = new Circle(values, 1);

            group.AddShape(rectangle);
            group.AddShape(circle);

            double computedTest = expectedResultComputeArea - group.ComputeArea();
            Assert.AreEqual( computedTest < Double.Epsilon, true);
        }
    }
}
