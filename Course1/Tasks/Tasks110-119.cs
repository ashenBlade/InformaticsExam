using System;

namespace Tasks
{
    public class Task110_119
    {
        public double Task110(int n)
        {
            double intermediateResult = 1d / n;
            for (int i = n - 2; i > 0; i -= 2)
            {
                intermediateResult = 1 / (i + intermediateResult);
            }
            double result = intermediateResult;
            return result;
        }

        public double Task111(double x, int n)
        {
            double squaredX = x * x;
            double intermediateResult = n / squaredX;

            while (n > 2)
            {
                n /= 2;
                intermediateResult = n / (squaredX + intermediateResult);
            }
            double result = x / (squaredX + intermediateResult);
            return result;
        }

        public double Task112(int n, int k)
        {
            if (k == 0)
                return n * (n + 1);

            double intermediateResult = (double)n / k;
            for (int i = 1; i < k; i++)
            {
                intermediateResult = intermediateResult * (n - i) / i;
            }
            double result = intermediateResult;
            return result;
        }

        public int Task113A(int n)
        {
            int product = 1;
            int firstNum = n % 2 + 2;
            for (int i = firstNum; i <= n; i += 2)
            {
                product *= i;
            }
            return product;
        }

        public int Task113B(int n)
        {
            int product = Task113A(n);
            return n % 2 == 0 ? -product : product;
        }

        public double Task114A(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += 1d / (i * i);
            }
            return sum;
        }

        public double Task114C(int n)
        {
            double sum = 0;
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
                sum += 1d / fact;
            }
            return sum;
        }

        public double Task115G(int n)
        {
            int fact = 1;
            double sum = 0;
            double sumOfFractions = 0;
            for (int k = 1; k <= n; k++)
            {
                fact *= k;
                sumOfFractions += 1d / (k + 1);
                sum += fact / sumOfFractions;
            }
            return sum;
        }
    }
}
