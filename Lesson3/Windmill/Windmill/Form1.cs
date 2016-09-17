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
        private int i = 0;
        private float elapsedTime = 0;
        private int frames = 0;
        private float fps = 0;
        private Stopwatch stopWatch;

        private BufferedGraphicsContext currentContext;
        private BufferedGraphics buffer;

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        public Form1()
        {
            InitializeComponent();

            Application.ApplicationExit += OnApplicationExit;
            Application.Idle += OnApplicationIdle;

            // Get a reference to the current BufferedGraphicsContext.
            currentContext = BufferedGraphicsManager.Current;

            // Create a BufferedGraphics instance associated with the DrawRegion.
            buffer = currentContext.Allocate(DrawRegion.CreateGraphics(), DrawRegion.DisplayRectangle);

            stopWatch = new Stopwatch();
        }

        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        private void OnApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                stopWatch.Reset();
                stopWatch.Start();

                // Clear the buffer.
                buffer.Graphics.Clear(Color.Black);

                // Draw an ellipse to the graphics buffer.
                for (int j = 0; j < 100; ++j)
                    buffer.Graphics.DrawEllipse(Pens.Blue, new Rectangle(i, 100, 400, 400));
                i++;
                if (i > 400)
                    i = 0;
                // Render the contents of the buffer to the drawing surface.
                buffer.Render();

                stopWatch.Stop();

                // Calculate and display frames per second.
                float renderTime = stopWatch.ElapsedMilliseconds;
                elapsedTime += renderTime;
                if (elapsedTime > 500)
                {
                    fps = 1000f / (elapsedTime / frames);
                    DrawTimeLabel.Text = string.Format("fps: {0:000.00}", fps);
                    frames = 0;
                    elapsedTime = 0;
                }
                frames++;
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            buffer.Dispose();
        }
    }
}
