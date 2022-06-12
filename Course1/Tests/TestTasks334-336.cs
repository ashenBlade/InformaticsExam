using System.Reflection;
using NUnit.Framework;
using Tasks;

namespace Tests
{
    public class TestTasks334_336
    {
        private readonly Tasks334_336 _tasks334 = new Tasks334_336();
        private const double Delta = 0.0001;

        [TestCase(2, 34)]
        [TestCase(3, 409147)]
        public void Task335a(int n, int expected)
        {
            var actual = _tasks334.Task335a(n);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, 5)]
        [TestCase(3, 32)]
        [TestCase(4, 288)]
        [TestCase(5, 3413)]
        public void Task335b(int n, long expected)
        {
            var actual = _tasks334.Task335b(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1.041666666)]
        [TestCase(3, 1.041669422)]
        public void Task335c(int n, double expected)
        {
            var actual = _tasks334.Task335c(n);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(1, -6)]
        [TestCase(2, 362874)]
        [TestCase(3, -121645100408469126)]
        public void Task335d(int n, long expected)
        {
            var actual = _tasks334.Task335d(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 1, 4.043653549)]
        [TestCase(3, 2, 5.0853229)]
        [TestCase(3, -2, 5.0853229)]
        public void Task336a(int n, double x, double expected)
        {
            var actual = _tasks334.Task336a(n, x);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(3, 2, -0.055820106)]
        [TestCase(2, 1, -0.166666666)]
        public void Task336b(int n, double x, double expected)
        {
            var actual = _tasks334.Task336b(n, x);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(3, 2, 1796)]
        [TestCase(3, 3, 20016)]
        public void Task336c(int n, double x, double expected)
        {
            var actual = _tasks334.Task336c(n, x);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestCase(3, 2, 10.5)]
        [TestCase(3, 3, 13.5)]
        [TestCase(4, 4, 23)]
        public void Task336d(int n, double x, double expected)
        {
            var actual = _tasks334.Task336d(n, x);
            Assert.AreEqual(expected, actual);
        }
    }
}