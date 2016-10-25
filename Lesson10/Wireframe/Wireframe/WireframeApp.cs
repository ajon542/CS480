using System;
using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;


namespace Wireframe
{
    class WireframeApp : GameApp
    {
        private Pen pen = new Pen(Color.LightBlue, 1);
        private Brush brush = new SolidBrush(Color.DarkGray);

        /// <summary>
        /// Setup a basic Bezier curve.
        /// </summary>
        public override void Initialize(int width, int height)
        {
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            DrawString(graphics, "Hello", 100, 100);
        }

        public void DrawString(Graphics graphics, string text, float x, float y)
        {
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            graphics.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
        }
    }
}
