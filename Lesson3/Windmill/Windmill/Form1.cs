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

            DrawRegion.Paint += new PaintEventHandler(DrawRegion_Paint);
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
