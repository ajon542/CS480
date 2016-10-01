using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;

namespace Bezier
{
    /// <summary>
    /// Simple application to display a cubic Bezier curve.
    /// </summary>
    public class BezierApp : GameApp
    {
        private Pen pen = new Pen(Color.White, 1);
        private BezierCurve bezier;

        public override void Initialize()
        {
            Vector2 a = new Vector2(100, 100);
            Vector2 b = new Vector2(600, 100);
            Vector2 c1 = new Vector2(200, 400);
            Vector2 c2 = new Vector2(400, 200);
            bezier = new BezierCurve(a, b, c1, c2);
        }

        /// <summary>
        /// Allow the user to define the start and end points of the line.
        /// </summary>
        public override void MouseClick(int x, int y)
        {

        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            Point[] points = bezier.GetPoints();
            foreach (Point point in points)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }
        }
    }
}
