using System;
using System.Drawing;

namespace JuliaSet
{
    public enum ColorScheme
    {
        BlueToGold,
        BlackToWhite,
        Red
    }

    public static class ColorHelper
    {
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

        public static double GetPerc(double start, double end, double mid)
        {
            return (mid - start) / (end - start);
        }

        /// <summary>
        /// Generate a color to match the number of iterations.
        /// </summary>
        /// <remarks>
        /// The graph is colored so that the brighter areas indicate
        /// complex numbers that are bounded. The black area represents
        /// numbers that diverge to infinity. The numbers along the boundaries
        /// are colored darker because they diverge slowly.
        /// </remarks>
        public static Color GetColor(ColorScheme colorScheme, int iteration)
        {
            Color color;

            if (colorScheme == ColorScheme.BlackToWhite)
            {
                double log = Math.Log(iteration, 2);

                double r = Lerp(Color.Black.R, Color.White.R, log / 16);
                double g = Lerp(Color.Black.G, Color.White.G, log / 16);
                double b = Lerp(Color.Black.B, Color.White.B, log / 16);
                color = Color.FromArgb(255, (int)r, (int)g, (int)b);
            }
            else if (colorScheme == ColorScheme.BlueToGold)
            {
                if (iteration < 20)
                {
                    color = Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 200, 0), GetPerc(0, 20, iteration));
                    return color;
                }
                else if (iteration < 40)
                {
                    color = Lerp(Color.FromArgb(255, 255, 200, 0), Color.FromArgb(255, 255, 255, 255), GetPerc(20, 40, iteration));
                    return color;
                }
                else if (iteration < 80)
                {
                    color = Lerp(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 0, 0, 255), GetPerc(40, 80, iteration));
                    return color;
                }
                else if (iteration < 200)
                {
                    color = Lerp(Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 128), GetPerc(80, 200, iteration));
                    return color;
                }
                else
                {
                    color = Lerp(Color.FromArgb(255, 0, 0, 128), Color.FromArgb(255, 255, 255, 255), GetPerc(200, 1024, iteration));
                }
            }
            else
            {
                if (iteration > 100)
                {
                    color = Color.FromArgb(255, 128, 0, 0);
                }
                else
                {
                    color = Color.FromArgb(255, 0, 0, 0);
                }
            }

            return color;
        }
    }
}
