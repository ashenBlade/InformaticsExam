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

    }
}