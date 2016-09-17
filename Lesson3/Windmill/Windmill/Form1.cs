using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

            gameApp.DeltaTime = stopwatch.Elapsed.TotalSeconds;

            // Update the game application.
            gameApp.Update();

            stopwatch.Restart();

            // Calculate and display frames per second.
            frames++;
            //gameApp.DeltaTime = stopWatch.ElapsedMilliseconds;
            elapsedTime += gameApp.DeltaTime;
            if (elapsedTime > 1)
            {
                fps = 1f / (elapsedTime / frames);
                DrawTimeLabel.Text = string.Format("fps: {0:000.00}", fps);
                frames = 0;
                elapsedTime = 0;
            }

            DrawRegion.Invalidate();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            buffer.Dispose();
            gameApp.Shutdown();
        }
    }
}
