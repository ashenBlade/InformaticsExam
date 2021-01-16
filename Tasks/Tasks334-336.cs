using System;
using System.Runtime.InteropServices;

namespace Tasks
{
    public class Tasks334_336
    {
        public double Task334a()
        {
            double sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 50; j++)
                {
                    sum += 1 / (double) (i + j * j);
                }
            }

            return sum;
        }

        public double Task334b()
        {
            double sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 60; j++)
                {
                    sum += Math.Sin(i * i * i + j * j * j * j);
                }
            }

            return sum;
        }

        public double Task334c()
        {
            double sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    sum += (double)(j - i + 1) / (i + j);
                }
            }

            return sum;
        }

        public double Task334d()
        {
            double sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    sum += 1 / (double) (2 * j + i);
                }
            }

            return sum;
        }

        public int Task335a(int n)
        {
            int totalSum = 0;
            int currentMax = 0;
            int oldMax = 0;
            int sum = 0;
            int oldSum = 0;
            int currentProduct = 1;
            for (int i = 1; i <= n; i++)
            {
                currentMax = i * i;
                sum = oldSum;
                for (int j = oldMax + 1; j <= currentMax; j++)
                {
                    sum += currentProduct;
                    currentProduct *= j + 1;
                }

                totalSum += sum;
                oldSum = sum;
                oldMax = currentMax;
            }

            return totalSum;
        }

        public long Task335b(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                long number = 1;
                for (int j = 0; j < i; j++)
                {
                    number *= i;
                }

                sum += number;
            }

            return sum;
        }

        public double Task335c(int n)
        {
            double sum = 0;
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                int factorialEnd = i * i;
                for (int j = (i - 1) * (i - 1) + 1; j <= factorialEnd; j++)
                {
                    factorial *= j;
                }

                sum += 1 / (double) factorial;
            }

            return sum;
        }

        public long Task335d(int n)
        {
            long sum = 0;
            long factorial = 1;
            int coef = 1;
            for (int i = 1; i <= n; i++)
            {
                int factNumber = 2 * i * i + 1;
                int lastFactNumber = 2 * (i - 1) * (i - 1) + 1;
                for (int j = lastFactNumber + 1; j <= factNumber; j++)
                {
                    factorial *= j;
                }

                sum += (coef *= -1) * factorial;
            }

            return sum;
        }

        public double Task336a(int n, double x)
        {
            x = x >= 0
                    ? x
                    : -x;
            double sum = 0;
            long upperFact = 1;
            long lowerFact = 1;
            for (int i = 1; i <= n; i++)
            {
                upperFact *= (2 * i - 1) * (2 * i);
                lowerFact = CalculateLowerFactorial(lowerFact, i);
                sum += (upperFact + x) / (lowerFact);
            }

            return sum;
        }

        // i - new index
        private long CalculateLowerFactorial(long factorial, int i)
        {
            int factEnd = i * i;
            for (int j = (i - 1) * (i - 1) + 1; j <= factEnd; j++)
            {
                factorial *= j;
            }

            return factorial;
        }

        public double Task336b(int n, double x)
        {
            double sum = 0;
            long innerFact = 1;
            long outerFact = 1;
            double power = 1;
            int coef = 1;
            double totalFactorial = 1;
            for (int i = 1; i <= n; i++)
            {
                innerFact *= i;
                outerFact = CalculateFactorialOfFactorial(innerFact, i) * (innerFact + 1);
                sum += (coef *= -1) * (power *= x) / outerFact;
                totalFactorial = innerFact;
            }

            totalFactorial = 1 / totalFactorial;
            return sum * totalFactorial;
        }

        private long CalculateFactorialOfFactorial(long factorial, int i)
        {
            var oldFactorial = factorial;
            for (int j = i + 1; j <= oldFactorial; j++)
            {
                factorial *= j;
            }

            return factorial;
        }

        public double Task336c(int n, double x)
        {
            x *= x;
            double sum = 0;
            double power = 1;
            for (int i = 1; i <= n; i++)
            {
                long degree = 1;
                for (int j = 1; j <= i; j++)
                {
                    degree *= i;
                }

                sum += degree * (power *= x);
            }

            return sum;
        }

        // Просто охуеть оптимизация
        // +rep
        public double Task336d(int n, double x)
        {
            double sum = x * n;
            for (int i = 1; i <= n; i++)
            {
                sum += (double) (1 + i) / 2;
            }

            return sum;
        }
    }

}