using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using GameEngine.Core;

namespace Bezier
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();

        private GameApp gameApp = new BezierApp();

        public Form1()
        {
            InitializeComponent();

            // Setup the event handlers.
            Application.ApplicationExit += OnApplicationExit;
            Paint += new PaintEventHandler(DrawRegion_Paint);
            MouseClick += new MouseEventHandler(DrawRegion_MouseClick);
            MouseDown += new MouseEventHandler(DrawRegion_MouseDown);
            MouseUp += new MouseEventHandler(DrawRegion_MouseUp);

            // Enable double buffering.
            DoubleBuffered = true;

            // Initialize the game application.
            gameApp.Initialize();
        }

        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            // Clear the buffer.
            e.Graphics.Clear(Color.Black);

            // Render the game application.
            gameApp.Render(e.Graphics);

            // Update the game application.
            gameApp.Update(stopwatch.ElapsedMilliseconds);

            // Restart the stopwatch.
            stopwatch.Restart();

            // Invalidate the draw region.
            Invalidate();
        }

        private void DrawRegion_MouseClick(Object sender, MouseEventArgs e)
        {
            gameApp.MouseClick(e.X, e.Y);
        }

        private void DrawRegion_MouseDown(Object sender, MouseEventArgs e)
        {
            gameApp.MouseDown(e.X, e.Y);
        }

        private void DrawRegion_MouseUp(Object sender, MouseEventArgs e)
        {
            gameApp.MouseUp(e.X, e.Y);
        }

        /// <summary>
        /// Dispose of the buffer and notify application to shutdown.
        /// </summary>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            gameApp.Shutdown();
        }
    }
}
