﻿using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
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
            xDelta = (xMax - xMin) / (DrawRegion.Width - 1);
            yDelta = (yMax - yMin) / (DrawRegion.Height - 1);

            // Create the iterator.
            quadraticIterator = new QuadraticIterator
            {
                MaxIterations = MaxIterations,
                MaxMagnitude = MaxMagnitude
            };

            // Add the paint event handler.
            DrawRegion.Paint += new PaintEventHandler(JuliaSet_Paint);
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
            // Get the width and height of draw region.
            int width = DrawRegion.Width;
            int height = DrawRegion.Height;

            Color[,] colors = new Color[width, height];

            // Determine the color of each pixel.
            for (int x = 0; x < width; ++x)
            //Parallel.For(0, width, x =>
            {
                //for (int y = 0; y < height; ++y)
                Parallel.For(0, height, y =>
                {
                    // Calculate real and imaginary components for z.
                    double zReal = -bounds + (x * xDelta);
                    double zImag = -bounds + (y * yDelta);

                    // Perform the iterations.
                    Complex z = new Complex(zReal, zImag);
                    Complex c = new Complex(cReal, cImag);
                    int iterations = quadraticIterator.Iterate(z, c);

                    // Store pixel color.
                    colors[x, y] = GetColor(iterations);
                });
            }

            // Fill the draw region with the previously calculated colors.
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    Brush color = new SolidBrush(colors[x, y]);
                    e.Graphics.FillRectangle(color, x, y, 1, 1);
                }
            }
        }

        /// <summary>
        /// Generate a color to match the number of iterations.
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
        /// Force the re-draw.
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            DrawRegion.Invalidate();
        }

        #endregion
    }
}
