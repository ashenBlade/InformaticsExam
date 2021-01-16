using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualBasic;

namespace Tasks
{
    public class Tasks88_104
    {
        public bool Task88a(int number, int search)
        {
            number *= number;
            var currentDigit = 0;
            while (number != 0)
            {
                currentDigit = number % 10;
                if (currentDigit == search)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        public int Task88b(int number)
        {
            int inverted = 0;
            while (number != 0)
            {
                inverted = inverted * 10 + number % 10;
                number /= 10;
            }

            return inverted;
        }

        private int Task88c(int n)
        {
            var lastNum = n % 10;
            var rank = 1;
            var tmp = n;
            while (n > 9)
            {
                rank *= 10;
                n /= 10;
            }

            return tmp - n * rank + lastNum * rank - lastNum + n;
        }

        public int Task88d(int number)
        {
            number *= 10;
            number++;
            int length = 10;
            while (number / length != 0)
                length *= 10;
            return number + length;
        }

        // GCD
        public int Task89a(int n, int m)
        {
            if (n < m)
            {
                int tmp = n;
                n = m;
                m = tmp;
            }
            return m == 0
                       ? n
                       : Task89a(m, n % m);
        }

        // LCM
        public int Task89b(int n, int m)
        {
            return n * m / Task89a(n, m);
        }


        public (int, int) Task90(int n, int m)
        {
            var gcd = Task89a(n, m);
            return (n / gcd, m / gcd);
        }

        public double Task91(int n)
        {
            var fact = 1;
            var sum = 0.0;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
                sum += 1 / (float) i;
            }

            return sum + fact;
        }

        public double Task92(int n)
        {
            var vi1 = 1.5; // v(i - 1)
            var vi2 = 0.0; // v(i - 2)
            var vi3 = 0.0; // v(i - 3)
            if (n == 1 || n == 2)
            {
                return 0;
            }
            if (n == 3)
            {
                return 1.5;
            }

            double vi = 0;
            for (int i = 4; i <= n; i++)
            {
                var c = (double) (i + 1) / (i * i + 1);
                vi = c * vi1 - vi2 * vi3;

                // Shift for index
                vi3 = vi2;
                vi2 = vi1;
                vi1 = vi;
            }

            return vi;
        }

        public double Task93(int n, double q, double r, double b, double c, double d)
        {
            if (n == 0)
            {
                return c;
            }
            if (n == 1)
            {
                return d;
            }

            var xi1 = d; // x(i - 1)
            var xi2 = c; // x(i - 2)
            var xi = 0.0;
            for (int i = 2; i <= n; i++)
            {
                xi = q * xi1 + r * xi2 + b;
                xi2 = xi1;
                xi1 = xi;
            }

            return xi;
        }

        public double Task94(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            double vi1 = 1, vi2 = 1, ui1 = 0, ui2 = 0;
            double vi = 0, ui = 0;
            for (int i = 3; i < n; i++)
            {
                ui = (ui1 - ui2 * vi1 - vi2) / (1 + ui1 * ui1 + vi1 * vi1);
                vi = (ui1 - vi1) / (Math.Abs(ui2 + vi2) + 2);

                // Index shift
                vi2 = vi1;
                vi1 = vi;
                ui2 = ui1;
                ui1 = ui;
            }
            return (ui1 - vi1) / (Math.Abs(ui2 + vi1) + 2);
        }

        public double Task95(int n)
        {
            int e = 2;
            if (n < 2)
                return 1;
            var ai2 = 1.0; // a(i - 2)
            var ai1 = 1.0; // a(i - 1)
            var ai = ai2 + ai1 / e;
            var product = ai;
            for (int i = 2; i < n; i++)
            {
                ai2 = ai1;
                ai1 = ai;
                ai = ai2 + ai1 / e;
                e *= 2;
                product *= ai;
            }

            return product;
        }

        public double Task96(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            double ai1 = 1, bi1 = 1; // a(i - 1), b(i - 1)
            double ai = 0, bi = 0;   // ai, bi
            double sum = 1;
            for (int i = 1; i < n; i++)
            {
                ai = 0.5 * (Math.Sqrt(bi1) + 0.5 * Math.Sqrt(ai1));
                bi = 2 * ai1 * ai1 + bi1;
                sum += ai * bi;
                ai1 = ai;
                bi1 = bi;
            }

            return sum;
        }

        public double Task97(int n)
        {
            double xi1 = 1, yi1 = 1; // x(i - 1), y(i - 1)
            double xi = 0, yi = 0;
            double sum = 0.5;
            for (int i = 1; i < n; i++)
            {
                xi = 0.3 * xi1;
                yi = xi1 + yi1;
                // Reduced excess abs from yi (yi can't be negative)
                sum += xi / (1 + yi);
                xi1 = xi;
                yi1 = yi;
            }

            return sum;
        }

        public double Task98(int n)
        {
            double ai1, bi1; // a(i - 1), b(i - 1)
            double ai = 1, bi = 1;
            double sum = 0;
            int fact = 1;  // Factorial
            int power = 2; // Power of 2

            for (int i = 1; i <= n; i++)
            {
                sum += power / ((1 + ai * ai + bi * bi) * fact);
                ai1 = ai;
                bi1 = bi;
                ai = 3 * bi1 + 2 * ai1;
                bi = 2 * ai1 + bi1;
                fact *= i+1;
                power *= 2;
            }

            return sum;
        }


        public double Task99(int n, int u, int v)
        {
            double ai = u, bi = v;
            double fact = 2;
            double ai1, bi1; // a(i - 1), b(i - 1)
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += ai * bi / fact;
                fact *= (i + 2);
                ai1 = ai;
                bi1 = bi;
                ai = 2 * bi1 + ai1;
                bi = 2 * ai1 * ai1 + bi1;
            }

            return sum;
        }

        // Can't check correctness
        public double Task100()
        {
            double xi1 = 1, xi2 = 1, xi3 = 1;
            int power = 2;
            double sum = 0;
            sum += xi3 / power;
            sum += xi2 / (power *= 2);
            sum += xi1 / (power *= 2);
            for (int i = 4; i <= 100; i++)
            {
                double xi = xi1 + xi3;
                sum += xi / (power *= 2);
                xi3 = xi2;
                xi2 = xi1;
                xi1 = xi;
            }

            return sum;
        }

        public double Task101(double a, double x, double eps)
        {
            double yi1 = a;
            double yi = 0.5 * (yi1 + x / yi1);
            while (Math.Abs(yi * yi - yi1 * yi1) >= eps)
            {
                yi1 = yi;
                yi = 0.5 * (yi1 + x / yi1);
            }
            return yi;
        }

        public double Task102()
        {
            double xi1 = 1;
            double xi = (2 - xi1 * xi1 * xi1) / 5;
            const double eps = 1e-5;
            while (Math.Abs(xi - xi1) > eps)
            {
                xi1 = xi;
                xi = (2 - xi1 * xi1 * xi1) / 5;
            }

            return xi;
        }
        public double Task103(double eps)
        {
            double yi1 = 0;
            double yi = (yi1 + 1) / (yi1 + 2);
            while (Math.Abs(yi1 - yi) > eps)
            {
                yi1 = yi;
                yi = (yi1 + 1) / (yi1 + 2);
            }

            return yi;
        }

        public (double, double) Task104(double a)
        {
            var xi1 = a <= 1
                          ? Math.Min(2 * a, 0.95)
                          : a < 25
                              ? a / 5.0
                              : a / 25.0;
            var eps = 0.8 * 1e-6 / a;
            var diff = (a - xi1 * xi1 * xi1 * xi1 * xi1);
            var product = 5 * xi1 * xi1 * xi1 * xi1;
            while (Math.Abs( diff / product) >= eps)
            {
                xi1 = (4 * xi1 * xi1 * xi1 * xi1 * xi1 + a) / product;
                diff = (a - xi1 * xi1 * xi1 * xi1 * xi1);
                product = (5 * xi1 * xi1 * xi1 * xi1);
            }

            return (xi1, diff);
        }
    }
}