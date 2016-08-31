using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace JuliaSet
{
    /// <summary>
    /// Class for displaying the Julia set in a form.
    /// </summary>
    public partial class JuliaSet : Form
    {
        private const int MaxMagnitude = 2;
        private const int MaxIterations = 256;
        private List<Color> colors = new List<Color>();

        /// <summary>
        /// Generate a color to match the number of iterations.
        /// </summary>
        private void FillColor()
        {
            int col = 0;
            for (int i = 0; i < MaxIterations; ++i)
            {
                if (i < 50)
                {
                    col += 3;
                }
                colors.Add(Color.FromArgb(255, col, col, col));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JuliaSet"/> class.
        /// </summary>
        public JuliaSet()
        {
            InitializeComponent();

            // Set parameters for the numeric input controls.
            realUpDown.DecimalPlaces = 3;
            realUpDown.Increment = 0.001M;
            realUpDown.Maximum = 5;
            realUpDown.Minimum = -5;

            imagUpDown.Maximum = 5;
            imagUpDown.Minimum = -5;
            imagUpDown.DecimalPlaces = 3;
            imagUpDown.Increment = 0.001M;

            // Generate some colors for the plot.
            FillColor();

            // Add the paint event handler.
            Paint += new PaintEventHandler(JuliaSet_Paint);
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
        /// Draw the JuliaSet set.
        /// The idea behind drawing the JuliaSet is an iterative process
        /// where we take a parameter 'z', we square it and then add a constant
        /// 'c'. We continue squaring the result and adding the constant until the
        /// maximum number of iterations has been met, or the number grows too
        /// large. It should be noted that 'z' and 'c' are complex numbers.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void JuliaSet_Paint(object sender, PaintEventArgs e)
        {
            // No need to update if nothing has changed.
            if (dirty == false)
            {
                return;
            }

            // Ensure the graphics context is disposed.
            using (Graphics graphics = CreateGraphics())
            {
                // Ensure the bitmap is disposed after using.
                using (Bitmap bitmap = new Bitmap(Width, Height))
                {
                    // Define the limits of the x-y coordinate system.
                    double xMax = 2;
                    double xMin = -2;
                    double yMax = 2;
                    double yMin = -2;

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
                            // Perform the iterations. For JuliaSet, iterate from z = 0.
                            Complex Z = new Complex(c, d);

                            // Interesting defaults:
                            // -0.52 + 0.57
                            // 0.295 + 0.55
                            // -0.624 + 0.435
                            // -1.037, 0.17

                            Complex C = new Complex(cReal, cImag);
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

            dirty = false;
        }

        /// <summary>
        /// Update the value of the real component.
        /// </summary>
        private double cReal = 0;
        private void RealUpDown_ValueChanged(object sender, EventArgs e)
        {
            cReal = (double)realUpDown.Value;
        }

        /// <summary>
        /// Update the value of the imaginary component.
        /// </summary>
        private double cImag = 0;
        private void ImagUpDown_ValueChanged(object sender, EventArgs e)
        {
            cImag = (double)imagUpDown.Value;
        }

        /// <summary>
        /// Mark the region as dirty and force the re-draw.
        /// </summary>
        private bool dirty = true;
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Invalidate();
            dirty = true;
        }
    }
}
