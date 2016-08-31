﻿using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Mandelbrot
{
    /// <summary>
    /// Class for displaying the Mandelbrot set in a form.
    /// </summary>
    public partial class Mandelbrot : Form
    {
        private const int MaxMagnitude = 2;
        private const int MaxIterations = 256;
        private List<Color> colors = new List<Color>();

        /// <summary>
        /// Generate a color to match the number of iterations.
        /// The colors generated here tend to be more reddish.
        /// The lower the number of iterations, the darker the color.
        /// The highest number of iteration will be very bright.
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
                colors.Add(Color.FromArgb(255, i, gb, gb));
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
        /// Perform quadratic iteration.
        /// Zn = Z^2 + C
        /// </summary>
        /// <param name="z">Complex number.</param>
        /// <param name="c">Constant complex number.</param>
        /// <returns>The number of iterations.</returns>
        private int QuadraticIteration(Complex z, Complex c)
        {
            int iteration = 0;
            while (iteration < MaxIterations && (Complex.Abs(z) < MaxMagnitude))
            {
                z = z * z + c;
                iteration++;
            }
            return iteration;
        }

        /// <summary>
        /// Draw the Mandelbrot set.
        /// The idea behind drawing the Mandelbrot set is an iterative process
        /// where we take a parameter 'z', we square it and then add a constant
        /// 'c'. We continue squaring the result and adding the constant until the
        /// maximum number of iterations has been met, or the number grows too
        /// large. It should be noted that 'z' and 'c' are complex numbers.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            // Ensure the graphics context is disposed.
            using (Graphics graphics = CreateGraphics())
            {
                // Ensure the bitmap is disposed after using.
                using (Bitmap bitmap = new Bitmap(Width, Height))
                {
                    // Define the limits of the x-y coordinate system.
                    double xMax = 1.1;
                    double xMin = -2;
                    double yMax = 1.3;
                    double yMin = -1.3;

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
                            // Perform the iterations. For Mandelbrot, iterate from z = 0.
                            Complex Z = new Complex(0, 0);
                            Complex C = new Complex(c, d);
                            int iterations = QuadraticIteration(Z, C);

                            // Set pixel color on bitmap.
                            bitmap.SetPixel(x, y, colors[iterations % colors.Count]);

                            d += imag;
                        }
                        c += real;
                    }

                    // Draw bitmap image.
                    e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                }
            }
        }
    }
}
