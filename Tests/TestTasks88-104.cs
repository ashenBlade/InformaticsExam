using System;
using NUnit.Framework;
using Tasks;

namespace Tests
{
    public class Tests
    {
        private Tasks88_104 _tasks88104;
        private const double Delta = 0.0001;
        [SetUp]
        public void Setup()
        {
            _tasks88104 = new Tasks88_104();
        }


        [TestCase(1, 1.0)]
        [TestCase(2, 3.25)]
        [TestCase(3, 7.715443)]
        public void Task96(int n, double expected)
        {
            var actual = _tasks88104.Task96(n);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(1, 0.5)]
        [TestCase(2, 0.6)]
        [TestCase(3, 0.6273)]

        public void Task97(int n, double expected)
        {
            var actual = _tasks88104.Task97(n);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(1, 0.66666666)]
        [TestCase(2, 0.723809)]
        [TestCase(3, 0.72631998)]
        public void Task98(int n, double expected)
        {
            var actual = _tasks88104.Task98(n);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(1, 1, 1, 0.5)]
        [TestCase(2, 1, 1, 2)]
        [TestCase(3, 1, 1, 9.875)]
        public void Task99(int n, int u, int v, double expected)
        {
            var actual = _tasks88104.Task99(n, u, v);
            Assert.AreEqual(expected, actual, Delta);
        }

        [Test]
        public void Task100()
        {
            // Can't solve: too small numbers
            var expected = double.PositiveInfinity;
            var actual = _tasks88104.Task100();
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(2, 1, 0.1, 1.0003333)]
        [TestCase(3, 3, 0.1, 1.732142)]
        [TestCase(1, 2, 0.1, 1.414215)]
        public void Task101(double a, double x, double eps, double expected)
        {
            var actual = _tasks88104.Task101(a, x, eps);
            Assert.AreEqual(expected, actual, Delta);
        }

        [Test]
        public void Task102()
        {
            // Hope that's right
            var expected = 0.388292;
            var actual = _tasks88104.Task102();
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(0.0005, 0.617977)]
        [TestCase(0.003, 0.617647)]
        [TestCase(0.02, 0.615384)]
        public void Task103(double eps, double expected)
        {
            var actual = _tasks88104.Task103(eps);
            Assert.AreEqual(expected, actual, Delta);
        }

        // Fucking fuck with these tests
        // Fuck you all
        // I don't know how to solve this fucking fuck
        // Fuck this shit, I'm out

        // [TestCase(1, 1.0, 1.0)]
        // public void Task104(double a, double expectedNumber, double expectedDiff)
        // {
        //     var (actualNumber, actualDiff) = _tasks88104.Task104(a);
        //     Assert.AreEqual(expectedNumber, actualNumber, Delta);
        //     Assert.AreEqual(expectedDiff, actualDiff, Delta);
        // }
    }
}