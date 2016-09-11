using System;
using System.Collections.Generic;
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
    /// Interpolates the colors between the start and end iterations.
    /// </summary>
    public class ColorRange : IColorGenerator
    {
        public Range<int> Range { get; private set; }
        private Color startColor;
        private Color endColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRange"/> class.
        /// </summary>
        public ColorRange(int startIter, int endIter, Color startColor, Color endColor)
        {
            Range = new Range<int>(startIter, endIter);
            this.startColor = startColor;
            this.endColor = endColor;
        }

        /// <summary>
        /// Convert the number of iterations to a color.
        /// </summary>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The resulting color.</returns>
        public Color GetColor(int iterations)
        {
            if (!Range.ContainsValue(iterations))
            {
                throw new ArgumentOutOfRangeException("iterations");
            }

            return ColorHelper.Lerp(startColor, endColor, ColorHelper.GetPerc(Range.Minimum, Range.Maximum, iterations));
        }
    }

    /// <summary>
    /// Default red color generator.
    /// </summary>
    public class RedColorGenerator : IColorGenerator
    {
        private List<ColorRange> colorRanges = new List<ColorRange>();

        public RedColorGenerator()
        {
            colorRanges.Add(new ColorRange(0, 9, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 30, 0, 0)));
            colorRanges.Add(new ColorRange(10, 19, Color.FromArgb(255, 30, 0, 0), Color.FromArgb(255, 60, 0, 0)));
            colorRanges.Add(new ColorRange(20, 39, Color.FromArgb(255, 60, 0, 0), Color.FromArgb(255, 90, 0, 0)));
            colorRanges.Add(new ColorRange(40, 79, Color.FromArgb(255, 90, 0, 0), Color.FromArgb(255, 120, 0, 0)));
            colorRanges.Add(new ColorRange(80, 159, Color.FromArgb(255, 120, 0, 0), Color.FromArgb(255, 150, 0, 0)));
            colorRanges.Add(new ColorRange(160, 319, Color.FromArgb(255, 150, 0, 0), Color.FromArgb(255, 180, 0, 0)));
            colorRanges.Add(new ColorRange(320, 639, Color.FromArgb(255, 180, 0, 0), Color.FromArgb(255, 210, 0, 0)));
            colorRanges.Add(new ColorRange(640, 1024, Color.FromArgb(255, 210, 0, 0), Color.FromArgb(255, 255, 0, 0)));
        }

        /// <summary>
        /// Provides the red color if the number of iterations is > 100.
        /// </summary>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The resulting color.</returns>
        public Color GetColor(int iterations)
        {
            foreach (ColorRange range in colorRanges)
            {
                if (range.Range.ContainsValue(iterations))
                {
                    return range.GetColor(iterations);
                }
            }

            return Color.FromArgb(255, 0, 0, 0);
        }
    }

    /// <summary>
    /// Default color generator the provides interpolation between gold, blue, white and black.
    /// The values come from experimentation.
    /// </summary>
    public class BlueToGoldColorGenerator : IColorGenerator
    {
        /// <summary>
        /// Provides interpolation between gold, blue, white and black.
        /// </summary>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The resulting color.</returns>
        public Color GetColor(int iterations)
        {
            Color color;

            // TODO: There has to be a nicer way to do this. It is terrible code.
            if (iterations < 20)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 200, 0), ColorHelper.GetPerc(0, 20, iterations));
            }
            else if (iterations < 40)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 255, 200, 0), Color.FromArgb(255, 255, 255, 255), ColorHelper.GetPerc(20, 40, iterations));
            }
            else if (iterations < 80)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 0, 0, 255), ColorHelper.GetPerc(40, 80, iterations));
            }
            else if (iterations < 200)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 128), ColorHelper.GetPerc(80, 200, iterations));
            }
            else
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 128), Color.FromArgb(255, 255, 255, 255), ColorHelper.GetPerc(200, 1024, iterations));
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
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The resulting color.</returns>
        public Color GetColor(int iterations)
        {
            Color color;

            // TODO: There has to be a nicer way to do this. It is terrible code.
            if (iterations < 20)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 40, 0), ColorHelper.GetPerc(0, 20, iterations));
            }
            else if (iterations < 40)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 40, 0), Color.FromArgb(255, 0, 60, 0), ColorHelper.GetPerc(20, 40, iterations));
            }
            else if (iterations < 80)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 60, 0), Color.FromArgb(255, 0, 80, 0), ColorHelper.GetPerc(40, 80, iterations));
            }
            else if (iterations < 160)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 80, 0), Color.FromArgb(255, 0, 100, 0), ColorHelper.GetPerc(80, 160, iterations));
            }
            else if (iterations < 320)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 100, 0), Color.FromArgb(255, 0, 150, 0), ColorHelper.GetPerc(160, 320, iterations));
            }
            else if (iterations < 640)
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 150, 0), Color.FromArgb(255, 0, 200, 0), ColorHelper.GetPerc(320, 640, iterations));
            }
            else
            {
                color = ColorHelper.Lerp(Color.FromArgb(255, 0, 200, 0), Color.FromArgb(255, 255, 255, 255), ColorHelper.GetPerc(40, 1024, iterations));
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
        /// Provides interpolation between blakc and white.
        /// Uses log base 2 on the iterations.
        /// The whiter the color, the more iterations performed.
        /// </summary>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The resulting color.</returns>
        public Color GetColor(int iterations)
        {
            double log = Math.Log(iterations, 2);
            return ColorHelper.Lerp(Color.Black, Color.White, log / 16);
        }
    }
}
