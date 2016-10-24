using System;

namespace comb1
{
    /// <summary>
    /// Class to represent rational numbers using a fraction.
    /// </summary>
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public double Value { get { return (double)Numerator / Denominator; } }

        #region Contructors

        public Fraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("denominator cannot be zero");
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public static implicit operator Fraction(int value)
        {
            return new Fraction(value);
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Overload the addition operator.
        /// </summary>
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;

            Fraction result = new Fraction(numerator, denominator);
            result.Reduce();
            return result;
        }

        /// <summary>
        /// Overload the subtraction operator.
        /// </summary>
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;

            Fraction result = new Fraction(numerator, denominator);
            result.Reduce();
            return result;
        }

        /// <summary>
        /// Overload the multiplication operator.
        /// </summary>
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
            result.Reduce();
            return result;
        }

        /// <summary>
        /// Overload the division operator.
        /// </summary>
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
            result.Reduce();
            return result;
        }

        #endregion

        /// <summary>
        /// Returns a fraction that if multiplied by the first argument will result
        /// in a fraction that equals the second argument.
        /// </summary>
        public static Fraction Convert(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Denominator * f2.Numerator, f1.Numerator * f2.Denominator);
            result.Reduce();
            return result;
        }

        /// <summary>
        /// Invert the fraction.
        /// </summary>
        public void Invert()
        {
            if (Numerator == 0)
            {
                throw new ArgumentException("numerator cannot be zero when inverting");
            }

            int temp = Numerator;
            Numerator = Denominator;
            Denominator = temp;
        }

        /// <summary>
        /// Reduce the fraction to the smallest possible numerator and denominator.
        /// </summary>
        public void Reduce()
        {
            int gcd = Gcd(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;
        }

        /// <summary>
        /// Find the greatest common divisor.
        /// </summary>
        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int t = b; 
                b = a % b; 
                a = t; 
            }
            return a;
        }

        #region Equality

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
            // If parameter is null return false.
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

        #endregion

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }
    }
}
