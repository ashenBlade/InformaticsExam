using System;
using System.Collections.Generic;
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

        public int Task88c(int number)
        {
            int length = 10;

            // Find number length
            while (number / length > 9)
            {
                length *= 10;
            }

            int lastDigit = number % 10;

            // Replace last digit with first
            number += (number / length - number % 10);

            // Replace first digit with last
            number += (lastDigit * length - length);

            return number;
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
            double ai = 0, bi = 0; // ai, bi
            double sum = 1;
            for (int i = 1; i < n; i++)
            {
                ai = 0.5 * (Math.Sqrt(bi1) + 0.5 * Math.Sqrt(ai1));
                bi = 2 * ai1 * ai1 + bi1;
                sum += ai * bi;
            }

            return sum;
        }
    }
}