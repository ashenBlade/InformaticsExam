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
    }

}