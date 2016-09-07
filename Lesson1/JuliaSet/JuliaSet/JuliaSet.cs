using System;
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
        private double bounds = 2;
        private const int MaxMagnitude = 20;
        private const int MaxIterations = 1024;

        private double xMax;
        private double xMin;
        private double yMax;
        private double yMin;
        private double xDelta;
        private double yDelta;

        private IIterator quadraticIterator;

        /// <summary>
        /// Initializes a new instance of the <see cref="JuliaSet"/> class.
        /// </summary>
        public JuliaSet()
        {
            InitializeComponent();

            // Set parameters for the numeric input controls.
            realUpDown.DecimalPlaces = 10;
            realUpDown.Increment = 0.01M;
            realUpDown.Maximum = 2;
            realUpDown.Minimum = -2;

            imagUpDown.Maximum = 2;
            imagUpDown.Minimum = -2;
            imagUpDown.DecimalPlaces = 10;
            imagUpDown.Increment = 0.01M;

            // Define the limits of the x-y coordinate system.
            xMax = bounds;
            xMin = -bounds;
            yMax = bounds;
            yMin = -bounds;

            // Determine the delta values for x and y.
            xDelta = (xMax - xMin) / (Width - 1);
            yDelta = (yMax - yMin) / (Height - 1);

            // Create the iterator.
            quadraticIterator = new QuadraticIterator
            {
                MaxIterations = MaxIterations,
                MaxMagnitude = MaxMagnitude
            };

            // Add the paint event handler.
            Paint += new PaintEventHandler(JuliaSet_Paint);
        }


        /// <summary>
        /// Draw the JuliaSet set.
        /// The idea behind drawing the JuliaSet is an iterative process
        /// where we take a parameter 'z', we square it and then add a constant
        /// 'c'. We continue squaring the result and adding the constant until the
        /// maximum number of iterations has been met, or the magnitude of the vector
        /// grows too large. It should be noted that 'z' and 'c' are complex numbers.
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

            // Ensure the bitmap is disposed after using.
            using (Bitmap bitmap = new Bitmap(Width, Height))
            {
                // Determine the color of each pixel.
                double zReal = xMin;
                for (int x = 0; x < Width; ++x)
                {
                    double zImag = yMin;
                    for (int y = 0; y < Height; ++y)
                    {
                        // Perform the iterations.
                        Complex z = new Complex(zReal, zImag);
                        Complex c = new Complex(cReal, cImag);
                        int iterations = quadraticIterator.Iterate(z, c);

                        // Set pixel color on bitmap.
                        bitmap.SetPixel(x, y, GetColor(iterations));

                        zImag += yDelta;
                    }
                    zReal += xDelta;
                }

                // Draw bitmap image.
                e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            }

            dirty = false;
        }

        /// <summary>
        /// Generate a color to match the number of iterations.
        /// http://www.fractalforums.com/programming/newbie-how-to-map-colors-in-the-mandelbrot-set/
        /// A linear color band is not good for julia sets.
        /// </summary>
        /// <remarks>
        /// The graph is colored so that the brighter areas indicate
        /// complex numbers that are bounded. The black area represents
        /// numbers that diverge to infinity. The numbers along the boundaries
        /// are colored darker because they diverge slowly.
        /// </remarks>
        private Color GetColor(int iteration)
        {
            double v = 3.5 * iteration;
            int component = (int)(v % 255);

            if (v > 900)
            {
                // High iterations.
                return Color.FromArgb(255, 255, 255, component);
            }
            else if (v > 255)
            {
                // Medium iterations.
                return Color.FromArgb(255, 255, component, 0);
            }
            else
            {
                // Low iterations.
                return Color.FromArgb(255, component, 0, 0);
            }
        }

        #region Form Controls

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

        #endregion
    }
}
