using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Mandelbrot : Form
    {
        private const int MaxMagnitude = 2;
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
        /// The event handler for drawing the scene.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            // Ensure the graphics context is disposed.
            using (Graphics graphics = CreateGraphics())
            {
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
                        // Perform the iterations. For Mandelbrot, iterate from z = 0.
                        Complex Z = new Complex(0, 0);
                        Complex C = new Complex(c, d);
                        int iterations = QuadraticIteration(Z, C);

                        // Draw color.
                        SolidBrush brush = new SolidBrush(colors[iterations % colors.Count]);
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
