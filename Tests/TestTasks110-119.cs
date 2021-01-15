using NUnit.Framework;
using Tasks;

namespace Tests
{
    class TestTasks110_119
    {
        private Task110_119 _tasks110119;
        private const double delta = 0.0001;
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
            Assert.AreEqual(expectedResult, actual, delta);
        }

        [TestCase(3, 8, 0.3256386979639476)]
        [TestCase(3, 2, 0.3253012048192771)]
        [TestCase(1.5, 16, 0.532817004664049)]
        public void Test111(double x, int n, double expectedResult)
        {
            double actual = _tasks110119.Task111(x, n);
            Assert.AreEqual(expectedResult, actual, delta);
        }

        [TestCase(5, 3, 10)]
        [TestCase(6, 3, 20)]
        [TestCase(5, 0, 30)]
        [TestCase(6, 6, 1)]
        [TestCase(6, 1, 6)]
        public void Test112(int n, int k, double expectedResult)
        {
            double actual = _tasks110119.Task112(n, k);
            Assert.AreEqual(expectedResult, actual, delta);
        }

        [TestCase(5, 15)]
        [TestCase(6, 48)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void Test113(int n, int expectedResult)
        {
            int actual = _tasks110119.Task113A(n);
            Assert.AreEqual(expectedResult, actual);
        }

        [TestCase(5, 1.4636111111111112)]
        [TestCase(1, 1)]
        [TestCase(10, 1.5497677311665408)]
        public void Test114A(int n, double expectedResult)
        {
            double actual = _tasks110119.Task114A(n);
            Assert.AreEqual(expectedResult, actual, delta);
        }

        [TestCase(5, 1.7166666666666668)]
        [TestCase(3, 1.6666666666666665)]
        [TestCase(1, 1)]
        public void Test114C(int n, double expectedResult)
        {
            double actual = _tasks110119.Task114C(n);
            Assert.AreEqual(expectedResult, actual, delta);
        }

        [TestCase(1, 2)]
        [TestCase(2, 4.4)]
        [TestCase(3, 9.938461538461539)]
        public void Test115G(int n, double expectedResult)
        {
            double actual = _tasks110119.Task115G(n);
            Assert.AreEqual(expectedResult, actual, delta);
        }
    }
}
