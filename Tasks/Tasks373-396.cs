using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;

namespace Tasks
{
    public class Tasks373_396
    {
        public double[] Task390a(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            var sequence = new double[n];
            for (int i = 0; i < n; i++)
            {
                double largest = double.MinValue;
                for (int j = 0; j < m; j++)
                    if (largest < matrix[i, j])
                        largest = matrix[i, j];
                sequence[i] = largest;
            }
            return sequence;
        }

        public double[] Task390b(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            var sequence = new double[n];
            for (int i = 0; i < n; i++)
            {
                double max = double.MinValue;
                double min = double.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[n, m] < min)
                        min = matrix[n, m];
                    if (max < matrix[n, m])
                        max = matrix[n, m];
                }
                sequence[n] = max + min;
            }

            return sequence;
        }

        public int[] Task390c(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            var sequence = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }

                sequence[i] = count;
            }

            return sequence;
        }

        public double[] Task390d(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            var sequence = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    double e = matrix[i, j];
                    if ((-1.5 <= e && e <= -1) ||
                        (1 <= e && e <= 1.5))
                        sum += e * e;
                }

                sequence[i] = sum;
            }

            return sequence;
        }

        public int Task391(int[,] matrix)
        {
            var m = matrix.GetLength(1);
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                if (max == matrix[0, i])
                    sum += matrix[1, i];

                if (max < matrix[0, i])
                {
                    max = matrix[0, i];
                    sum = matrix[1, i];
                }
            }

            return sum;
        }

        public int Task392(int[,] matrix)
        {
            const int n = 8;
            int minNum = int.MaxValue;
            int maxSum = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int currentMinNum = matrix[0, i];
                int currentSum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j, i] < currentMinNum)
                        currentMinNum = matrix[j, i];
                    currentSum += matrix[j, i] < 0
                                      ? -matrix[j, i]
                                      : matrix[j, i];
                }

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    minNum = currentMinNum;
                }
            }

            return minNum;
        }

        public int[] Task393a(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            var sequence = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, 0];
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }

                sequence[i] = min;
            }

            return sequence;
        }

        public int[] Task393b(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new int[n];
            for (int i = 0; i < n; i++)
            {
                int num = 1;
                for (int j = 0; j < n; j++)
                {
                    if (0 < matrix[i, j])
                    {
                        num = matrix[i, j];
                        break;
                    }
                }

                sequence[i] = num;
            }

            return sequence;
        }

        public int[] Task393c(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            var sequence = new int[n];
            for (int i = 0; i < n; i++)
            {
                bool wasNegative = false;
                int sum = 100;
                for (int j = 0; j < n; j++)
                {
                    sum += wasNegative
                               ? matrix[i, j]
                               : 0;
                    if (!wasNegative && matrix[i, j] < 0)
                    {
                        sum = 0;
                        wasNegative = true;
                    }
                }

                sequence[i] = sum;
            }

            return sequence;
        }

        public int[] Task393d(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = -1;
                int j = n - 1;
                while (-1 < j && 0 <= matrix[i, j]) j--;
                if (j != -1)
                {
                    sum = 0;
                    for (int k = 0; k < j; k++)
                    {
                        sum += matrix[i, k];
                    }
                }

                sequence[i] = sum;
            }
            return sequence;
        }

        public List<int> Task394a(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        break;
                    }

                    if (j == n - 1)
                    {
                        sequence.Add(i);
                    }
                }
            }

            return sequence;
        }

        public List<int> Task394b(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var number = matrix[i, 0];
                for (int j = 0; j < n; j++)
                {
                    if (number != matrix[i, j])
                        break;
                    if (j == n - 1)
                    {
                        sequence.Add(i);
                    }
                }
            }

            return sequence;
        }

        public List<int> Task394c(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] % 2 != 0)
                    {
                        break;
                    }

                    if (j == n - 1)
                    {
                        sequence.Add(i);
                    }
                }
            }

            return sequence;
        }

        public List<int> Task394d(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int delta = 0;
                for (int j = 1; j < n; j++)
                {
                    if (delta == 0)
                    {
                        delta = matrix[i, j] - matrix[i, j - 1];
                    }
                    else if (Math.Sign(delta) != Math.Sign(matrix[i, j] - matrix[i, j - 1]))
                    {
                        break;
                    }

                    if (j == n - 1)
                    {
                        sequence.Add(i);
                    }
                }
            }

            return sequence;
        }

        public List<int> Task394e(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var sequence = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    if (matrix[i, j] != matrix[i, n - j - 1])
                    {
                        break;
                    }

                    if (j == n / 2 - 1)
                    {
                        sequence.Add(i);
                    }
                }
            }

            return sequence;
        }
    }
}