using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Mandelbrot : Form
    {
        public double Zr, Zim, Z2r, Z2im;

        private const int MaxMagnitudeSquared = 4;
        private const int MaxIterations = 256;
        private Graphics graphics;
        private List<Color> colors = new List<Color>();

        /// <summary>
        /// Number of colors should match number of max iterations.
        /// Each color will represent the number of iterations it took.
        /// </summary>
        private void FillColor()
        {
            int gb = 0;
            for (int i = 0; i < MaxIterations; ++i)
            {
                if (i % 3 == 0)
                {
                    gb += 2;
                }
                colors.Add(Color.FromArgb(255, gb, gb, i));
            }
        }

        private void Fn(ref double a, ref double b, double x, double y)
        {
            a = (a * a) - (b * b) + x;
            b = (2 * a * b) + y;
        }

        private double MagnitudeSquared(double a, double b)
        {
            return (a * a) + (b * b);
        }

        public Mandelbrot()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            FillColor();

            Paint += new PaintEventHandler(Mandelbrot_Paint);
        }

        private void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            // Define the limits of the x-y coordinate system.
            double xMax = 1.1;
            double xMin = -2;
            double yMax = 1;
            double yMin = -1;

            // Scale to width and height of the form.
            double real = (xMax - xMin) / (Width - 1);
            double imag = (yMax - yMin) / (Height - 1);

            double realC = xMin;
            for (int x = 0; x < Width; ++x)
            {
                double imagC = yMin;

                for (int y = 0; y < Height; ++y)
                {
                    double realZ = Zr;
                    double imagZ = Zim;
                    double ReaZ2 = Z2r;
                    double ImaZ2 = Z2im;
                    int iteration = 0;

                    // Zn = (a + ib)^2 + (c + id);
                    //    = ((a * a) - (b * b) + c) + (i * ((2 * a * b) + d));

                    while (iteration < MaxIterations && (ReaZ2 + ImaZ2 < MaxMagnitudeSquared))
                    {
                        ReaZ2 = realZ * realZ;
                        ImaZ2 = imagZ * imagZ;
                        imagZ = 2 * imagZ * realZ + imagC;
                        realZ = ReaZ2 - ImaZ2 + realC;

                        iteration++;
                    }

                    // Draw color.
                    SolidBrush brush = new SolidBrush(colors[iteration % colors.Count]);
                    Rectangle rect = new Rectangle(x, y, 1, 1);
                    graphics.FillRectangle(brush, rect);

                    imagC += imag;
                }
                realC += real;
            }
        }
    }

    public class Point
    {
        public readonly float x;
        public readonly float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
