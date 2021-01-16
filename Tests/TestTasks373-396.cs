using NUnit.Framework;
using Tasks;

namespace Tests
{
    public class TestTasks373_396
    {
        private readonly Tasks373_396 _tasks373 = new Tasks373_396();

        [Test]
        public void Task391()
        {
            var matrix = new int[,] {{1, 2, 3, 0, -1, 3, 3}, {6, 5, 4, 2, 1, -6, 1}};
            var expected = -1;
            var actual = _tasks373.Task391(matrix);
            Assert.AreEqual(expected, actual);
        }
    }
}