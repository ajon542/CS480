using System;
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

        private double xMax = 2;
        private double xMin = -2;
        private double yMax = 2;
        private double yMin = -2;
        private double xDelta;
        private double yDelta;

        private ColorScheme colorScheme = ColorScheme.BlueToGold;
        private Color[,] colors;

        private IIterator quadraticIterator;

        /// <summary>
        /// Initializes a new instance of the <see cref="JuliaSet"/> class.
        /// </summary>
        public JuliaSet()
        {
            InitializeComponent();

            colors = new Color[DrawRegion.Width, DrawRegion.Height];

            // Set parameters for the numeric input controls.
            realUpDown.DecimalPlaces = 10;
            realUpDown.Increment = 0.01M;
            realUpDown.Maximum = 2;
            realUpDown.Minimum = -2;

            imagUpDown.Maximum = 2;
            imagUpDown.Minimum = -2;
            imagUpDown.DecimalPlaces = 10;
            imagUpDown.Increment = 0.01M;

            // Set the combo box data source for the color scheme.
            colorSchemeCombo.DataSource = Enum.GetValues(typeof(ColorScheme));

            // Create the iterator.
            quadraticIterator = new QuadraticIterator
            {
                MaxIterations = MaxIterations,
                MaxMagnitude = MaxMagnitude
            };

            // Add the paint, mouse click and mouse move event handlers.
            DrawRegion.Paint += new PaintEventHandler(JuliaSet_Paint);
            DrawRegion.MouseClick += new MouseEventHandler(JuliaSet_MouseClick);
            DrawRegion.MouseMove += new MouseEventHandler(JuliaSet_MouseMove);
        }

        #region Event Handlers

        /// <summary>
        /// Draw the JuliaSet set.
        /// </summary>
        private void JuliaSet_Paint(object sender, PaintEventArgs e)
        {
            // Determine the delta values for x and y.
            xDelta = (xMax - xMin) / (DrawRegion.Width - 1);
            yDelta = (yMax - yMin) / (DrawRegion.Height - 1);

            // Determine the color of each pixel.
            Parallel.For(0, DrawRegion.Width, x =>
            {
                for (int y = 0; y < DrawRegion.Height; ++y)
                {
                    // Calculate real and imaginary components for z.
                    double zReal = xMin + (x * xDelta);
                    double zImag = yMin + (y * yDelta);

                    // Perform the iterations.
                    Complex z = new Complex(zReal, zImag);
                    Complex c = new Complex(cReal, cImag);
                    int iterations = quadraticIterator.Iterate(z, c);

                    // Store pixel color.
                    colors[x, y] = ColorFactory.GetColor(colorScheme, iterations);
                }
            });

            // Fill the draw region with the calculated colors.
            for (int x = 0; x < DrawRegion.Width; ++x)
            {
                for (int y = 0; y < DrawRegion.Height; ++y)
                {
                    Brush color = new SolidBrush(colors[x, y]);
                    e.Graphics.FillRectangle(color, x, y, 1, 1);
                }
            }
        }

        /// <summary>
        /// Perform a simple zoom by dividing the view region in half.
        /// </summary>
        private void JuliaSet_MouseClick(Object sender, MouseEventArgs e)
        {
            // Convert mouse click screen coords to bounds coords.
            double boundsX = xMin + (e.X * xDelta);
            double boundsY = yMin + (e.Y * yDelta);

            // Zoom the bounds by a factor of 2.
            bounds /= 2;

            // Center view around that point.
            xMin = boundsX - (bounds / 2);
            xMax = boundsX + (bounds / 2);
            yMin = boundsY - (bounds / 2);
            yMax = boundsY + (bounds / 2);

            // Force re-draw.
            DrawRegion.Invalidate();
        }

        /// <summary>
        /// Handle the mouse move event for live updates on mouse position.
        /// </summary>
        private void JuliaSet_MouseMove(Object sender, MouseEventArgs e)
        {
            // Calculate the x-y bounds coords.
            double boundsX = xMin + (e.X * xDelta);
            double boundsY = yMin + (e.Y * yDelta);

            // Calculate the iterations.
            Complex z = new Complex(boundsX, boundsY);
            Complex c = new Complex(cReal, cImag);
            int iterations = quadraticIterator.Iterate(z, c);

            // Display the data.
            XCoord.Text = boundsX.ToString();
            YCoord.Text = boundsY.ToString();
            IterationCountLabel.Text = iterations.ToString();
        }

        #endregion

        #region Component Controls

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
        /// Reset the zoom.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            bounds = 2;
            xMin = -bounds;
            xMax = bounds;
            yMin = -bounds;
            yMax = bounds;

            // Force re-draw.
            DrawRegion.Invalidate();
        }

        /// <summary>
        /// Calculate the Julia set colors.
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // Force re-draw.
            DrawRegion.Invalidate();
        }

        /// <summary>
        /// Handle the color scheme change.
        /// </summary>
        private void ColorSchemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the color scheme based on the combo box selection.
            colorScheme = (ColorScheme)colorSchemeCombo.SelectedItem;

            // Force re-draw.
            DrawRegion.Invalidate();
        }

        #endregion
    }
}
