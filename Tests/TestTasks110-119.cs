using System;
using NUnit.Framework;
using Tasks;

namespace Tests
{
    class TestTasks110_119
    {
        private Task110_119 _tasks110119;
        private const double Delta = 0.0001;

        [SetUp]
        public void SetUp()
        {
            _tasks110119 = new Task110_119();
        }

        [TestCase(5, 0.7619047619)]
        [TestCase(3, 0.75)]
        [TestCase(1, 1)]
        public void Test110(int n, double expectedResult)
        {
            double actual = _tasks110119.Task110(n);
            Assert.AreEqual(expectedResult, actual, Delta);
        }
    }
}
