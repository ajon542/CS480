using System;
using System.Drawing;

namespace JuliaSet
{
    /// <summary>
    /// Intrface to the color generator.
    /// </summary>
    public interface IColorGenerator
    {
        Color GetColor(int iterations);
    }

    /// <summary>
    /// Default red color generator.
    /// </summary>
    public class RedColorGenerator : IColorGenerator
    {
        /// <summary>
        /// Provides the red color if the number of iterations is > 100.
        /// </summary>
        public Color GetColor(int iterations)
        {
            Color color;

            if (iterations < 20)
            {
                color = Color.FromArgb(255, 40, 0, 0);
            }
            else if (iterations < 40)
            {
                color = Color.FromArgb(255, 80, 0, 0);
            }
            else if (iterations < 80)
            {
                color = Color.FromArgb(255, 160, 0, 0);
            }
            else if (iterations < 160)
            {
                color = Color.FromArgb(255, 200, 0, 0);
            }
            else if (iterations < 320)
            {
                color = Color.FromArgb(255, 210, 0, 0);
            }
            else if (iterations < 640)
            {
                color = Color.FromArgb(255, 220, 0, 0);
            }
            else
            {
                color = Color.FromArgb(255, 255, 0, 0);
            }

            return color;
        }
    }

    /// <summary>
    /// Default color generator the provides interpolation between gold, blue, white and black.
    /// The values come from experimentation.
    /// </summary>
    public class BlueToGoldColorGenerator : IColorGenerator
    {
        private double GetPerc(double start, double end, double mid)
        {
            return (mid - start) / (end - start);
        }

        /// <summary>
        /// Provides interpolation between gold, blue, white and black.
        /// </summary>
        public Color GetColor(int iterations)
        {
            Color color;

            // TODO: There has to be a nicer way to do this. It is terrible code.
            if (iterations < 20)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 200, 0), GetPerc(0, 20, iterations));
            }
            else if (iterations < 40)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 255, 200, 0), Color.FromArgb(255, 255, 255, 255), GetPerc(20, 40, iterations));
            }
            else if (iterations < 80)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 0, 0, 255), GetPerc(40, 80, iterations));
            }
            else if (iterations < 200)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 128), GetPerc(80, 200, iterations));
            }
            else
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 128), Color.FromArgb(255, 255, 255, 255), GetPerc(200, 1024, iterations));
            }

            return color;
        }
    }

    /// <summary>
    /// Default color generator the provides interpolation between gold, blue, white and black.
    /// The values come from experimentation.
    /// </summary>
    public class BlackToGreenColorGenerator : IColorGenerator
    {
        private double GetPerc(double start, double end, double mid)
        {
            return (mid - start) / (end - start);
        }

        /// <summary>
        /// Provides interpolation between black and green.
        /// </summary>
        public Color GetColor(int iterations)
        {
            Color color;

            // TODO: There has to be a nicer way to do this. It is terrible code.
            if (iterations < 20)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 40, 0), GetPerc(0, 20, iterations));
            }
            else if (iterations < 40)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 40, 0), Color.FromArgb(255, 0, 60, 0), GetPerc(20, 40, iterations));
            }
            else if (iterations < 80)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 60, 0), Color.FromArgb(255, 0, 80, 0), GetPerc(40, 80, iterations));
            }
            else if (iterations < 160)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 80, 0), Color.FromArgb(255, 0, 100, 0), GetPerc(80, 160, iterations));
            }
            else if (iterations < 320)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 100, 0), Color.FromArgb(255, 0, 150, 0), GetPerc(160, 320, iterations));
            }
            else if (iterations < 640)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 150, 0), Color.FromArgb(255, 0, 200, 0), GetPerc(320, 640, iterations));
            }
            else
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 200, 0), Color.FromArgb(255, 255, 255, 255), GetPerc(40, 1024, iterations));
            }

            return color;
        }
    }

    /// <summary>
    /// Default color generator to interpolate between black and white.
    /// </summary>
    public class BlackToWhiteColorGenerator : IColorGenerator
    {
        /// <summary>
        /// Provides interpolation between gold, blue, white and black.
        /// Uses log base 2 on the iterations.
        /// The whiter the color, the more iterations performed.
        /// </summary>
        public Color GetColor(int iterations)
        {
            Color color;
            double log = Math.Log(iterations, 2);

            double r = ColorHelper.Lerp(Color.Black.R, Color.White.R, log / 16);
            double g = ColorHelper.Lerp(Color.Black.G, Color.White.G, log / 16);
            double b = ColorHelper.Lerp(Color.Black.B, Color.White.B, log / 16);
            color = Color.FromArgb(255, (int)r, (int)g, (int)b);
            return color;
        }
    }
}
