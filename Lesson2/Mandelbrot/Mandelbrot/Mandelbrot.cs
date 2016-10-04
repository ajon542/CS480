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

        private const int MaxMagnitude = 20;
        private const int MaxIterations = 1024;

        private double xMax = 2;
        private double xMin = -2;
        private double yMax = 2;
        private double yMin = -2;
        private double xDelta;
        private double yDelta;

        private Coord clickCoord;

        private ColorScheme colorScheme = ColorScheme.BlueToGold;
        private Color[,] colors;
        private Bitmap myBitmap;

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

            DoubleBuffered = true;

            colors = new Color[DrawRegion.Width, DrawRegion.Height];

            // Set parameters for the numeric input controls.
            zoomFactor.DecimalPlaces = 3;
            zoomFactor.Increment = 0.01M;
            zoomFactor.Maximum = 2;
            zoomFactor.Minimum = 0.001M;
            zoomFactor.Value = 0.25M;

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

            // Create a Bitmap object from a file.
            myBitmap = new Bitmap(DrawRegion.Width - 1, DrawRegion.Height - 1, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Fill the draw region with the calculated colors.
            //SolidBrush brush = new SolidBrush(Color.Black);
            for (int x = 0; x < DrawRegion.Width - 1; ++x)
            {
                for (int y = 0; y < DrawRegion.Height - 1; ++y)
                {
                    myBitmap.SetPixel(x, y, colors[x, y]);
                    //brush.Color = colors[x, y];
                    //e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);

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
            clickCoord = ScreenToBound(new Coord(e.X, e.Y));

            // Zoom the bounds by a factor the specified value.
            double factor = (((xMax - xMin) * (double)zoomFactor.Value) / 2);

            // Determine the rectangle region to draw around the mouse click in screen coords.
            Coord topLeft = BoundToScreen(new Coord(clickCoord.x - factor, clickCoord.y - factor));
            Coord botRight = BoundToScreen(new Coord(clickCoord.x + factor, clickCoord.y + factor));

            // Draw rectangle around mouse click screen coords.
            using (Graphics graphics = DrawRegion.CreateGraphics())
            {
                Pen pen = new Pen(Color.Red, 2);

                graphics.Clear(Color.Black);

                graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);

                graphics.DrawRectangle(
                    pen,
                    (int)topLeft.x,
                    (int)topLeft.y,
                    (int)(botRight.x - topLeft.x),
                    (int)(botRight.y - topLeft.y));
            }
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
        /// Reset the zoom.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            xMin = -2;
            xMax = 2;
            yMin = -2;
            yMax = 2;

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

        /// <summary>
        /// Handle the zoom button click.
        /// </summary>
        private void ZoomButton_Click(object sender, EventArgs e)
        {
            if (clickCoord == null)
            {
                return;
            }

            // Determine the zoom factor in bounds coords.
            double factor = (xMax - xMin) * (double)zoomFactor.Value;

            // Center view around the click point.
            xMin = clickCoord.x - (factor / 2);
            xMax = clickCoord.x + (factor / 2);
            yMin = clickCoord.y - (factor / 2);
            yMax = clickCoord.y + (factor / 2);

            // Force redraw.
            DrawRegion.Invalidate();
        }

        #endregion

        private Coord ScreenToBound(Coord screenCoord)
        {
            // Convert screen coords to bounds coords.
            Coord boundCoord = new Coord
            {
                x = xMin + (screenCoord.x * ((xMax - xMin) / (DrawRegion.Width - 1))),
                y = yMin + (screenCoord.y * ((xMax - xMin) / (DrawRegion.Width - 1)))
            };
            return boundCoord;
        }

        private Coord BoundToScreen(Coord boundCoord)
        {
            // Convert bounds coord to screen coords.
            Coord screenCoord = new Coord
            {
                x = xMin + ((boundCoord.x - xMin) * (DrawRegion.Width - 1)) / (xMax - xMin),
                y = yMin + ((boundCoord.y - yMin) * (DrawRegion.Height - 1)) / (yMax - yMin)
            };
            return screenCoord;
        }

        public class Coord
        {
            public double x;
            public double y;

            public Coord()
            {

            }

            public Coord(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
