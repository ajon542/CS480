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
        private const int MaxMagnitudeSquared = 4;
        private const int MaxIterations = 256;
        private List<Color> colors = new List<Color>();

        /// <summary>
        /// Generate a color to match the number of iterations.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Mandelbrot"/> class.
        /// </summary>
        public Mandelbrot()
        {
            InitializeComponent();

            // Generate some colors for the plot.
            FillColor();

            // Add the paint event handler.
            Paint += new PaintEventHandler(Mandelbrot_Paint);
        }

        /// <summary>
        /// The event handler for drawing the scene.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            // Ensure the graphics context is disposed.
            using (Graphics graphics = CreateGraphics())
            {
                // For Mandelbrot, iterate from 0.
                double zReal = 0, zImag = 0;

                // Define the limits of the x-y coordinate system.
                double xMax = 1.1;
                double xMin = -2;
                double yMax = 1;
                double yMin = -1;

                // Scale to width and height of the form.
                double real = (xMax - xMin) / (Width - 1);
                double imag = (yMax - yMin) / (Height - 1);

                // Determine the color of each pixel.
                double c = xMin;
                for (int x = 0; x < Width; ++x)
                {
                    double d = yMin;
                    for (int y = 0; y < Height; ++y)
                    {
                        double a = zReal;
                        double b = zImag;
                        double a2 = 0;
                        double b2 = 0;
                        int iteration = 0;

                        // If we start the initial values of z at zero, and plot the values
                        // that we're using for the two components of c on the horizontal
                        // and vertical axes of a graph – if we set AB to zero – graphing CD
                        // gives us the Mandelbrot Set.
                        //  Z = a + ib;
                        //  C = c + id;
                        // Zn = Z^2 + C;
                        //    = (a + ib)^2 + (c + id);
                        //    = ((a * a) - (b * b) + c) + (i * ((2 * a * b) + d));
                        //    = (a2 - b2 + c) + (i * ((2 * a * b) + d));
                        while (iteration < MaxIterations && (a2 + b2 < MaxMagnitudeSquared))
                        {
                            a2 = a * a;
                            b2 = b * b;
                            b = 2 * a * b + d;
                            a = a2 - b2 + c;
                            iteration++;
                        }

                        // Draw color.
                        SolidBrush brush = new SolidBrush(colors[iteration % colors.Count]);
                        Rectangle rect = new Rectangle(x, y, 1, 1);
                        graphics.FillRectangle(brush, rect);

                        d += imag;
                    }
                    c += real;
                }
            }
        }
    }
}
