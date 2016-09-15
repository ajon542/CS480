using System.Drawing;

namespace Mandelbrot
{
    /// <summary>
    /// Default color schemes.
    /// </summary>
    public enum ColorScheme
    {
        BlueToGold,
        BlackToWhite,
        Red,
        Green,
        Blue,
    }

    /// <summary>
    /// The purpose of the color factory is to generate a color
    /// based on the color scheme selected that corresponds to the
    /// number of iterations.
    /// </summary>
    public static class ColorFactory
    {
        /// <summary>
        /// Generate a color based on the color scheme.
        /// </summary>
        public static Color GetColor(ColorScheme colorScheme, int iterations)
        {
            IColorGenerator colorGen;

            if (colorScheme == ColorScheme.BlueToGold)
            {
                colorGen = new BlueToGoldColorGenerator();
            }
            else if (colorScheme == ColorScheme.BlackToWhite)
            {
                colorGen = new BlackToWhiteColorGenerator();
            }
            else if (colorScheme == ColorScheme.Red)
            {
                colorGen = new RedColorGenerator();
            }
            else if (colorScheme == ColorScheme.Green)
            {
                colorGen = new GreenColorGenerator();
            }
            else
            {
                colorGen = new BlueColorGenerator();
            }

            return colorGen.GetColor(iterations);
        }
    }
}
