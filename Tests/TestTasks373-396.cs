using System.Collections.Generic;
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


        [Test]
        public void Task393a()
        {
            var matrix = new int[,] {{6, 2, 5, 4}, {8, 12, -4, 2}, {-10, 2, 11, 8}, {64, 52, 0, 1}};
            var expected = new int[] {6, 8, -10, 0};
            var actual = _tasks373.Task393a(matrix);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Task393b()
        {
            var matrix = new int[,] {{2, 3, 1}, {-2, 0, 1}, {-3, -4, -5}};
            var expected = new int[] {2, 1, 1};
            var actual = _tasks373.Task393b(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task393c()
        {
            var matrix = new int[,] {{2, 3, 1}, {-2, 0, 1}, {-3, -4, -5}};
            var expected = new int[] {100, 1, -9};
            var actual = _tasks373.Task393c(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task393d()
        {
            var matrix = new int[,] {{6, 2, 5, 4}, {8, 12, -4, 2}, {-10, 2, 11, 8}, {64, 52, 0, 1}};
            var expected = new int[] {-1, 20, 0, -1};
            var actual = _tasks373.Task393d(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task394a()
        {
            var matrix = new int[,] {{0, 0, 0, 0}, {8, 12, -4, 2}, {-10, 2, 11, 8}, {64, 52, 0, 1}};
            var expected = new List<int>(){0};
            var actual = _tasks373.Task394a(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task394b()
        {
            var matrix = new int[,] {{0, 0, 0, 0}, {1, 1, 1, 1}, {-10, 2, 11, 8}, {64, 52, 0, 1}};
            var expected = new List<int>() {0, 1};
            var actual = _tasks373.Task394b(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task394c()
        {
            var matrix = new int[,] {{0, 0, 0, 0}, {1, 1, 1, 1}, {10, 2, 4, 8}, {64, 52, 0, 4444}};
            var expected = new List<int>() {0, 2, 3};
            var actual = _tasks373.Task394c(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task394d()
        {
            var matrix = new int[,] {{0, 0, 0, 0}, {1, 2, 3, 4}, {10, 9, 8, 7}, {64, 52, 0, 4444}};
            var expected = new List<int>() {0, 1, 2};
            var actual = _tasks373.Task394d(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task394e()
        {
            var matrix = new int[,] {{0, 0, 0, 0}, {1, 2, 2, 1}, {10, 9, 8, 7}, {64, 52, 0, 4444}};
            var expected = new List<int>() {0, 1};
            var actual = _tasks373.Task394e(matrix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task395()
        {
            double x = 3;
            var matrix = new double[,] {{1, 1, 2, 2, 0, 1}, {4, 2, 4, -1, 2, 4}, {0, 1, -4, 2, -10, 2}};
            var expected = new double[] {1, 0, 1};
            var actual = _tasks373.Task395(matrix, x);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Task396()
        {
            var matrix = new double[,] {{-1, 6, 2, 7}, {2, -1, 0, 0}, {-2, 3, 1, 4}, {6, 4, 8, 5}};
            var expected = new double[] {0, 2, 8, 23};
            var actual = _tasks373.Task396(matrix);
            Assert.AreEqual(expected, actual);
        }
    }
}