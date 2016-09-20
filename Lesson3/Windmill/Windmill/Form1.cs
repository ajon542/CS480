using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Windmill
{
    public partial class Form1 : Form
    {
        private double elapsedTime = 0;
        private int frames = 0;
        private double fps = 0;
        private Stopwatch stopwatch = new Stopwatch();

        private BufferedGraphicsContext currentContext;
        private BufferedGraphics buffer;

        private GameApp gameApp = new WindmillApp();

        public Form1()
        {
            InitializeComponent();

            // Setup the event handlers.
            Application.ApplicationExit += OnApplicationExit;
            DrawRegion.Paint += new PaintEventHandler(DrawRegion_Paint);

            // Get a reference to the current BufferedGraphicsContext.
            currentContext = BufferedGraphicsManager.Current;

            // Create a BufferedGraphics instance associated with the DrawRegion.
            buffer = currentContext.Allocate(DrawRegion.CreateGraphics(), DrawRegion.DisplayRectangle);

            gameApp.Initialize();
        }

        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            // Clear the buffer.
            buffer.Graphics.Clear(Color.Black);

            // Render the game application.
            gameApp.Render(buffer);

            // Render the contents of the buffer to the drawing surface.
            buffer.Render(e.Graphics);

            // Keep track of the time taken to redner the scene.
            gameApp.DeltaTime = stopwatch.Elapsed.TotalSeconds;

            // Update the game application.
            gameApp.Update();

            // Restart the stopwatch.
            stopwatch.Restart();

            // Calculate and display frames per second.
            frames++;
            elapsedTime += gameApp.DeltaTime;
            if (elapsedTime > 1)
            {
                fps = 1f / (elapsedTime / frames);
                DrawTimeLabel.Text = string.Format("fps: {0:000.00}", fps);
                frames = 0;
                elapsedTime = 0;
            }

            // Invalidate the draw region.
            DrawRegion.Invalidate();
        }

        /// <summary>
        /// Dispose of the buffer and notify application to shutdown.
        /// </summary>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            buffer.Dispose();
            gameApp.Shutdown();
        }
    }
}
