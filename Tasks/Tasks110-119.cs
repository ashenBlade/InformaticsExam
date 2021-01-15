using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
