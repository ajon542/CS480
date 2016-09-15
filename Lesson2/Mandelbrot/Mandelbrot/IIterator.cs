using System.Numerics;

namespace Mandelbrot
{
    public interface IIterator
    {
        int Iterate(Complex z, Complex c);
    }

    public class QuadraticIterator : IIterator
    {
        public int MaxIterations { get; set; }
        public int MaxMagnitude { get; set; }

        /// <summary>
        /// Perform quadratic iteration.
        /// Zn = Z^2 + C
        /// </summary>
        /// <param name="z">Complex number.</param>
        /// <param name="c">Constant complex number.</param>
        /// <returns>The number of iterations.</returns>
        public int Iterate(Complex z, Complex c)
        {
            int iteration = 0;
            while (iteration < MaxIterations && (Complex.Abs(z) < MaxMagnitude))
            {
                z = z * z + c;
                iteration++;
            }
            return iteration;
        } 
    }
}
