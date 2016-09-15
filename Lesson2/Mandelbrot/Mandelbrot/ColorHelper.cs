using System.Drawing;

namespace Mandelbrot
{
    /// <summary>
    /// Provides some basic interpolation methods.
    /// </summary>
    public static class ColorHelper
    {
        public static double GetPerc(double start, double end, double mid)
        {
            return (mid - start) / (end - start);
        }

        public static double Lerp(double a, double b, double value)
        {
            return (a * (1 - value)) + (b * value);
        }

        public static Color Lerp(Color c1, Color c2, double value)
        {
            double r = Lerp(c1.R, c2.R, value);
            double g = Lerp(c1.G, c2.G, value);
            double b = Lerp(c1.B, c2.B, value);
            return Color.FromArgb(255, (int)r, (int)g, (int)b);
        }
    }
}
