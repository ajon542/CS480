using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    /// <summary>
    /// Class for displaying the Mandelbrot set in a form.
    /// </summary>
    public partial class Mandelbrot : Form
    {
        #region Mandelbrot Set Members

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

        private TimeSpan paintTime;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Mandelbrot"/> class.
        /// </summary>
        public Mandelbrot()
        {
            InitializeComponent();

            colors = new Color[DrawRegion.Width, DrawRegion.Height];

            // Set parameters for the numeric input controls.
            realUpDown.DecimalPlaces = 10;
            realUpDown.Increment = 0.01M;
            realUpDown.Maximum = 2;
            realUpDown.Minimum = -2;

            // Set the combo box data source for the color scheme.
            colorSchemeCombo.DataSource = Enum.GetValues(typeof(ColorScheme));

            // Create the iterator.
            quadraticIterator = new QuadraticIterator
            {
                MaxIterations = MaxIterations,
                MaxMagnitude = MaxMagnitude
            };

            // Add the paint, mouse click and mouse move event handlers.
            DrawRegion.Paint += new PaintEventHandler(Mandelbrot_Paint);
            DrawRegion.MouseClick += new MouseEventHandler(Mandelbrot_MouseClick);
            DrawRegion.MouseMove += new MouseEventHandler(Mandelbrot_MouseMove);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Draw the Mandelbrot set.
        /// </summary>
        private void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            // Keep track of how long it takes to draw the scene.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Determine the delta values for x and y.
            xDelta = (xMax - xMin) / (DrawRegion.Width - 1);
            yDelta = (yMax - yMin) / (DrawRegion.Height - 1);

            // Determine the color of each pixel.
            Parallel.For(0, DrawRegion.Width, x =>
            {
                for (int y = 0; y < DrawRegion.Height; ++y)
                {
                    // Calculate real and imaginary components for c.
                    double cReal = xMin + (x * xDelta);
                    double cImag = yMin + (y * yDelta);

                    // Perform the iterations.
                    Complex z = new Complex(0, 0);
                    Complex c = new Complex(cReal, cImag);
                    int iterations = quadraticIterator.Iterate(z, c);

                    // Store pixel color.
                    colors[x, y] = ColorFactory.GetColor(colorScheme, iterations);
                }
            });

            // Fill the draw region with the calculated colors.
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int x = 0; x < DrawRegion.Width; ++x)
            {
                for (int y = 0; y < DrawRegion.Height; ++y)
                {
                    brush.Color = colors[x, y];
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            // Stop timing.
            stopwatch.Stop();
            paintTime = stopwatch.Elapsed;
        }

        /// <summary>
        /// Perform a simple zoom by dividing the view region in half.
        /// </summary>
        private void Mandelbrot_MouseClick(Object sender, MouseEventArgs e)
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
        /// Handle the mouse move event for live updates on mouse position and iteration count.
        /// </summary>
        private void Mandelbrot_MouseMove(Object sender, MouseEventArgs e)
        {
            // Convert mouse position screen coords to bounds coords.
            double boundsX = xMin + (e.X * xDelta);
            double boundsY = yMin + (e.Y * yDelta);

            // Calculate the iterations.
            Complex z = new Complex(0, 0);
            Complex c = new Complex(boundsX, boundsY);
            int iterations = quadraticIterator.Iterate(z, c);

            // Display the data.
            XLabel.Text = boundsX.ToString();
            YLabel.Text = boundsY.ToString();
            IterationCountLabel.Text = iterations.ToString();
            DrawTimeLabel.Text = paintTime.ToString(@"ss") + "s, " + paintTime.ToString(@"fff") + "ms";
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
