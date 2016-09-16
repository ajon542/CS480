using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windmill
{
    public partial class Form1 : Form
    {
        private TimeSpan paintTime;

        public Form1()
        {
            InitializeComponent();

            Paint += new PaintEventHandler(DrawRegion_Paint);
            DrawRegion.MouseMove += new MouseEventHandler(DrawRegion_MouseMove);
        }

        /// <summary>
        /// Draw the scene.
        /// </summary>
        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            // Keep track of how long it takes to draw the scene.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // This example assumes the existence of a form called Form1.
            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with Form1, and with 
            // dimensions the same size as the drawing surface of Form1.
            myBuffer = currentContext.Allocate(DrawRegion.CreateGraphics(),
               DrawRegion.DisplayRectangle);

            // Draws an ellipse to the graphics buffer.
            myBuffer.Graphics.DrawEllipse(Pens.Blue, new Rectangle(100, 100, 400, 400));

            // This example assumes the existence of a BufferedGraphics instance
            // called myBuffer.
            // Renders the contents of the buffer to the drawing surface associated 
            // with the buffer.
            myBuffer.Render();
            // Renders the contents of the buffer to the specified drawing surface.
            myBuffer.Render(DrawRegion.CreateGraphics());

            myBuffer.Dispose();

            // Stop timing.
            stopwatch.Stop();
            paintTime = stopwatch.Elapsed;
        }

        /// <summary>
        /// Handle the mouse move event for live updates on mouse position.
        /// </summary>
        private void DrawRegion_MouseMove(Object sender, MouseEventArgs e)
        {
            // Display the data.
            XLabel.Text = e.X.ToString();
            YLabel.Text = e.Y.ToString();
            DrawTimeLabel.Text = paintTime.ToString(@"ss") + "s, " + paintTime.ToString(@"fff") + "ms";
        }
    }
}
