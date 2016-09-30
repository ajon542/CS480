using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using GameEngine.Core;
using GameEngine.Core.Shapes;

namespace Bresenham
{
    public class BresenhamApp : GameApp
    {
        private Pen pen = new Pen(Color.White, 1);
        private List<Line> lines = new List<Line>();

        public override void Initialize()
        {
            lines.Add(new Line(new Vector2(10, 10), new Vector2(200, 100)));
        }

        public override void MouseClick(int x, int y)
        {
            // TODO: Update the list of lines
        }

        public override void Render(Graphics graphics)
        {
            foreach (Line line in lines)
            {
                Point[] points = line.GetPoints();
                foreach(Point point in points)
                {
                    graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
                }
            }
        }
    }
}
