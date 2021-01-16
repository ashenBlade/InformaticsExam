using NUnit.Framework;
using System;
using Tasks;

namespace Tests
{
    class TestTasks676_693
    {
        private Tasks676_693 _tasks676693;
        private const double Delta = 0.0001;

        [SetUp]
        public void SetUp()
        {
            _tasks676693 = new Tasks676_693();
        }

        [Test]
        public void Test676A()
        {
            int[,] matrix = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };
            int[,] expectedResult = new[,]
            {
                {9, 8, 7, 6, 5, 4, 3, 2, 1 },
                {9, 8, 7, 6, 5, 4, 3, 2, 1 },
                {9, 8, 7, 6, 5, 4, 3, 2, 1 },
                {9, 8, 7, 6, 5, 4, 3, 2, 1 },
                {9, 8, 7, 6, 5, 4, 3, 2, 1 },
                {9, 8, 7, 6, 5, 4, 3, 2, 1 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task676A(matrix), expectedResult));
        }

        [Test]
        public void Test676B()
        {
            int[,] matrix = new[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1, 1 },
                {2, 2, 2, 2, 2, 2, 2, 2, 2 },
                {3, 3, 3, 3, 3, 3, 3, 3, 3 },
                {4, 4, 4, 4, 4, 4, 4, 4, 4 },
                {5, 5, 5, 5, 5, 5, 5, 5, 5 },
                {6, 6, 6, 6, 6, 6, 6, 6, 6 }
            };
            int[,] expectedResult = new[,]
            {
                {6, 6, 6, 6, 6, 6, 6, 6, 6 },
                {5, 5, 5, 5, 5, 5, 5, 5, 5 },
                {4, 4, 4, 4, 4, 4, 4, 4, 4 },
                {3, 3, 3, 3, 3, 3, 3, 3, 3 },
                {2, 2, 2, 2, 2, 2, 2, 2, 2 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task676B(matrix), expectedResult));
        }

        [Test]
        public void Test677A()
        {
            double[,] matrixA = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] expectedResult = new double[,]
            {
                {28, 26, 24 },
                {22, 20, 18 },
                {16, 14, 12 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task677A(matrixA), expectedResult));
        }

        [Test]
        public void Test678()
        {
            double[,] matrix = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] expectedResult = new double[,]
            {
                {1, 2, 7 },
                {4, 5, 8 },
                {3, 6, 9 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task678(matrix), expectedResult));
        }

        [Test]
        public void Test679A()
        {
            double[,] matrixA = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] matrixB = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] expectedResult = new double[,]
            {
                {3, 6, 9 },
                {24, 30, 36 },
                {63, 72, 81 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task679A(matrixA, matrixB), expectedResult));
        }

        [Test]
        public void Test679B()
        {
            double[,] matrixA = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] matrixB = new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            double[,] expectedResult = new double[,]
            {
                {7, 122, 507 },
                {10, 125, 510},
                {13, 128, 513 }
            };
            Assert.IsTrue(IsEqualMatrixs(_tasks676693.Task679B(matrixA, matrixB), expectedResult));
        }

        public bool IsEqualMatrixs(Array firstMatrix, Array secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) ||
                firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
                return false;
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    if (!firstMatrix.GetValue(i, j).Equals(secondMatrix.GetValue(i, j)))
                        return false;
                }
            }
            return true;
        }
    }
}
