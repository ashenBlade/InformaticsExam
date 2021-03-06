﻿using System;

namespace Tasks
{
    public class Tasks676_693
    {
        void SwapColumns(int[,] matrix, int i, int j)
        {
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                (matrix[k, i], matrix[k, j]) = (matrix[k, j], matrix[k, i]);
            }
        }

        void SwapLines(int[,] matrix, int i, int j)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                (matrix[i, k], matrix[j, k]) = (matrix[j, k], matrix[i, k]);
            }
        }

        public int[,] Task676A(int[,] matrix)
        {
            int columnsCount = matrix.GetLength(1);
            for (int k = 0; k < columnsCount / 2; k++)
            {
                SwapColumns(matrix, k, columnsCount - k - 1);
            }
            return matrix;
        }

        public int[,] Task676B(int[,] matrix)
        {
            int linesCount = matrix.GetLength(0);
            for (int k = 0; k < linesCount / 2; k++)
            {
                SwapLines(matrix, k, linesCount - k - 1);
            }
            return matrix;
        }

        public double[,] Task677A(double[,] matrixA)
        {
            int n = matrixA.GetLength(0);
            double[] sumByLines = new double[n];
            double[] sumByColumns = new double[n];
            double sumOfAll = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sumOfAll += matrixA[i, j];
                    sumByLines[i] += matrixA[i, j];
                    sumByColumns[j] += matrixA[i, j];
                }
            }

            double[,] matrixB = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixB[i, j] = sumOfAll - sumByLines[i] - sumByColumns[j] + matrixA[i, j];
                }
            }

            return matrixB;
        }

        public double[,] Task678(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                (matrix[i, n - 1], matrix[n - 1, i]) = (matrix[n - 1, i], matrix[i, n - 1]);
            }
            return matrix;
        }

        public double[,] Task679A(double[,] matrixA, double[,] matrixB)
        {
            int n = matrixA.GetLength(0);
            double[] maxValuesByLinesB = new double[n];
            for (int i = 0; i < n; i++)
            {
                double max = double.MinValue;
                for (int j = 0; j < n; j++)
                {
                    if (matrixB[i, j] > max)
                        max = matrixB[i, j];
                }
                maxValuesByLinesB[i] = max;
            }

            double[,] result = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrixA[i, j] * maxValuesByLinesB[i];
                }
            }

            return result;
        }

        public double[,] Task679B(double[,] matrixA, double[,] matrixB)
        {
            int n = matrixA.GetLength(0);
            double[] productByLinesB = new double[n];
            for (int i = 0; i < n; i++)
            {
                double product = 1;
                for (int j = 0; j < n; j++)
                {
                    product *= matrixB[i, j];
                }
                productByLinesB[i] = product;
            }

            double[,] result = new double[n, n];

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    result[j, i] = matrixA[j, i] + productByLinesB[i];
                }
            }

            return result;
        }

        public int[,] Task682(int[,] matrix, int k, int l)
        {
            k -= 1;
            l -= 1;
            int s = Math.Max(k, l);
            int p = k + l - s;

            for (int i = p; i < s - 1; i++)
            {
                SwapLines(matrix, i, i + 1);
            }

            if (k < l)
                SwapLines(matrix, l - 1, l);

            return matrix;
        }

        public double Task692A(double[,] matrix)
        {
            double max = double.MinValue;
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
            }
            return max;
        }

        public double Task692C(double[,] matrix)
        {
            double max = double.MinValue;
            int n = matrix.GetLength(0);
            int middle = (int)Math.Round(n / 2d);

            for (int i = 0; i < middle; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
            }
            return max;
        }

        public double Task692E(double[,] matrix)
        {
            double max = double.MinValue;
            int n = matrix.GetLength(0);
            int middle = (int)Math.Round(n / 2d);

            for (int i = 0; i < middle; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                    if (matrix[n - i - 1, j] > max)
                        max = matrix[n - i - 1, j];
                }
            }
            return max;
        }

        public double[,] Task693A(double[,] matrix)
        {
            int n = matrix.GetLength(0) / 2;
            double[,] result = new double[2*n, 2*n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrix[i + n, j + n];
                    result[i + n, j + n] = matrix[i, j];
                    result[i, j + n] = matrix[i + n, j];
                    result[i + n, j] = matrix[i, j + n];
                }
            }
            return result;
        }

        public double[,] Task693B(double[,] matrix)
        {
            int n = matrix.GetLength(0) / 2;
            double[,] result = new double[2 * n, 2 * n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrix[i + n, j];
                    result[i, j + n] = matrix[i, j];
                    result[i + n, j + n] = matrix[i, j + n];
                    result[i + n, j] = matrix[i + n, j + n];
                }
            }
            return result;
        }
    }
}
