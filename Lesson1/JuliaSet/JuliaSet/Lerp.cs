using System.Drawing;

namespace JuliaSet
{
    public static class ColorExtensions
    {
        private static float Lerp(float a, float b, float value)
        {
            Clamp(ref value);
            return (a * (1 - value)) + (b * value);
        }

        private static void Clamp(ref float value)
        {
            if (value < 0)
            {
                value = 0;
            }
            if (value > 1)
            {
                value = 1;
            }
        }

        public static Color Lerp(this Color color, Color other, float value)
        {
            float r = Lerp(color.R, other.R, value);
            float g = Lerp(color.G, other.G, value);
            float b = Lerp(color.B, other.B, value);

            return Color.FromArgb(255, (int)r, (int)g, (int)b);
        }
    }
}
