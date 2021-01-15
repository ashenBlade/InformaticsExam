using NUnit.Framework;
using Tasks;

namespace Tests
{
    public class Tests
    {
        private Tasks88_104 _tasks88104;
        private const double Eps = 0.0001;
        [SetUp]
        public void Setup()
        {
            _tasks88104 = new Tasks88_104();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestCase(1, 1.0)]
        [TestCase(2, 3.25)]
        [TestCase(3, 7.715443)]
        public void Task96(int n, double expected)
        {
            var actual = _tasks88104.Task96(n);
            Assert.AreEqual(expected, actual, Eps);
        }

        [TestCase(1, 0.5)]
        [TestCase(2, 0.6)]
        [TestCase(3, 0.6273)]

        public void Task97(int n, double expected)
        {
            var actual = _tasks88104.Task97(n);
            Assert.AreEqual(expected, actual, Eps);
        }
    }
}