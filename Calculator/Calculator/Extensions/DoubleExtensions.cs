using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Extensions
{
    public static class DoubleExtensions
    {
        public static double Truncate(this double value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return result;
        }
    }
}

