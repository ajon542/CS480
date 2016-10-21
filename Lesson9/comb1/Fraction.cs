using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comb1
{
    /// <summary>
    /// Class to represent rational numbers using a fraction.
    /// </summary>
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public double Value { get { return Numerator / Denominator; } }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // TODO: Add and subtract two fractions
        // TODO: Multiply and divide two fractions
        // TODO: Reduce a fraction to the smallest numerator and denominator
        // TODO: Equality of two fractions
    }
}
