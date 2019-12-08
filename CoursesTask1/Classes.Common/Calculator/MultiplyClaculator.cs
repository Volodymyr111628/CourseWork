using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Common.Calculator
{
    public class MultiplyClaculator : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }
}
