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

            // Create the iterator.
            quadraticIterator = new QuadraticIterator
            {
                MaxIterations = MaxIterations,
                MaxMagnitude = MaxMagnitude
            };

            // Add the paint event handler.
            DrawRegion.Paint += new PaintEventHandler(JuliaSet_Paint);
            DrawRegion.MouseClick += new MouseEventHandler(JuliaSet_MouseClick);
        }

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
                    colors[x, y] = GetColor(iterations);
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

        private static double Lerp(double a, double b, double value)
        {
            return (a * (1 - value)) + (b * value);
        }

        private static Color Lerp(Color c1, Color c2, double value)
        {
            double r = Lerp(c1.R, c2.R, value);
            double g = Lerp(c1.G, c2.G, value);
            double b = Lerp(c1.B, c2.B, value);
            return Color.FromArgb(255, (int)r, (int)g, (int)b);
        }

        private double GetPerc(double start, double end, double mid)
        {
            return (mid - start) / (end - start);
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
            //double log = Math.Log(iteration, 2);

            //double r = Lerp(Color.Yellow.R, Color.Black.R, log / 16);
            //double g = Lerp(Color.Yellow.G, Color.Black.G, log / 16);
            //double b = Lerp(Color.Yellow.B, Color.Black.B, log / 16);

            Color color;

            if (iteration < 20)
            {
                color = Lerp(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 200, 0), GetPerc(0, 20, iteration));
                return color;
            } 
            else if (iteration < 40)
            {
                color = Lerp(Color.FromArgb(255, 255, 200, 0), Color.FromArgb(255, 255, 255, 255), GetPerc(20, 40, iteration));
                return color;
            } 
            else if (iteration < 80)
            {
                color = Lerp(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 0, 0, 255), GetPerc(40, 80, iteration));
                return color;
            }
            else if (iteration < 200)
            {
                color = Lerp(Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 128), GetPerc(80, 200, iteration));
                return color;
            }
            else
            {
                color = Lerp(Color.FromArgb(255, 0, 0, 128), Color.FromArgb(255, 255, 255, 255), GetPerc(200, 1024, iteration));
            }

            return color;
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

            // Calculate iterations on that point for display.
            Complex z = new Complex(boundsX, boundsY);
            Complex c = new Complex(cReal, cImag);
            int iterations = quadraticIterator.Iterate(z, c);

            // Display the point. Debug.
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("Screen ({0}, {1})", e.X, e.Y);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("Actual ({0}, {1})", boundsX, boundsY);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("Iterations {0}", iterations);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "Zoom");

            // Force re-draw.
            DrawRegion.Invalidate();
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
    }
}
