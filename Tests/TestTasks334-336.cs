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
    }
}