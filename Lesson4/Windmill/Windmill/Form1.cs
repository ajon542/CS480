using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Windmill
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();

        private GameApp gameApp = new WindmillApp();

        public Form1()
        {
            InitializeComponent();

            // Setup the event handlers.
            Application.ApplicationExit += OnApplicationExit;
            Paint += new PaintEventHandler(DrawRegion_Paint);

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

            // Keep track of the time taken to render the scene.
            gameApp.DeltaTime = stopwatch.ElapsedMilliseconds;

            // Update the game application.
            gameApp.Update();

            // Restart the stopwatch.
            stopwatch.Restart();

            // Invalidate the draw region.
            Invalidate();
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
