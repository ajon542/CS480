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
    public class WindmillApp : GameApp
    {
        private int i = 0;

        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public override void Initialize() { }

        /// <summary>
        /// Update the game application.
        /// </summary>
        public override void Update() { }

        /// <summary>
        /// Render the game application.
        /// </summary>
        /// <remarks>
        /// Normally I wouldn't want the graphics buffer to pervade the system
        /// but for this small application, it should be fine.
        /// </remarks>
        /// <param name="buffer">THe graphics buffer.</param>
        public override void Render(BufferedGraphics buffer) 
        {
            // Draw an ellipse to the graphics buffer.
            for (int j = 0; j < 100; ++j)
                buffer.Graphics.DrawEllipse(Pens.Blue, new Rectangle(i, 100, 400, 400));
            i++;
            if (i > 400)
                i = 0;
        }

        /// <summary>
        /// Shutdown the game application.
        /// </summary>
        public override void Shutdown() { }
    }
}
