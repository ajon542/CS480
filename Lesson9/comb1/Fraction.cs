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

        public double Value { get { return (double)Numerator / Denominator; } }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // TODO: Add and subtract two fractions
        // TODO: Multiply and divide two fractions
        // TODO: Reduce a fraction to the smallest numerator and denominator

        /// <summary>
        /// Equals override.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns>True if the object is the same; false otherwise.</returns>
        public override bool Equals(object other)
        {
            // If parameter is null return false.
            if (other == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Fraction fraction = other as Fraction;
            if ((object)fraction == null)
            {
                return false;
            }

            // Return true if the fractional value matches.
            return fraction.Value == Value;
        }

        /// <summary>
        /// Equals override.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns>True if the object is the same; false otherwise.</returns>
        public bool Equals(Fraction other)
        {
            // If parameter is null return false:
            if ((object)other == null)
            {
                return false;
            }

            // Return true if the fractional value matches.
            return other.Value == Value;
        }

        /// <summary>
        /// Convert the hash value of the card.
        /// </summary>
        /// <returns>The hash value of the card.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }
}
