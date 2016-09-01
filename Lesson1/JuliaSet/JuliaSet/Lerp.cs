using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace JuliaSet
{
    public static class ColorExtensions
    {
        private static float Lerp(float a, float b, float value)
        {
            return (a * value) + (b * (1 - value));
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
            Clamp(ref value);
            float r = Lerp(color.R, other.R, value);
            float g = Lerp(color.G, other.G, value);
            float b = Lerp(color.B, other.B, value);

            return Color.FromArgb(255, (int)r, (int)g, (int)b);
        }
    }
}
