using System.Drawing;

namespace JuliaSet
{
    /// <summary>
    /// Default color schemes.
    /// </summary>
    public enum ColorScheme
    {
        BlueToGold,
        BlackToWhite,
        BlackToGreen,
        Red
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

            if (colorScheme == ColorScheme.BlackToWhite)
            {
                colorGen = new BlackToWhiteColorGenerator();
            }
            else if (colorScheme == ColorScheme.BlackToGreen)
            {
                colorGen = new BlackToGreenColorGenerator();
            }
            else if (colorScheme == ColorScheme.BlueToGold)
            {
                colorGen = new BlueToGoldColorGenerator();
            }
            else
            {
                colorGen = new RedColorGenerator();
            }

            return colorGen.GetColor(iterations);
        }
    }
}
