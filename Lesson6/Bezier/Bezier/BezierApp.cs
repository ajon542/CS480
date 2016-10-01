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
        private List<Vector2> control;

        public override void Initialize()
        {
            control = new List<Vector2>();
        }

        /// <summary>
        /// Allow the user to define the start and end points of the line.
        /// </summary>
        public override void MouseClick(int x, int y)
        {
            // Add the control points.
            if (control.Count < 4)
            {
                control.Add(new Vector2(x, y));
                return;
            }

            // Generate the bezier curve.
            bezier = new BezierCurve(control[0], control[1], control[2], control[3]);
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw control points.
            foreach (Vector2 point in control)
            {
                graphics.DrawRectangle(pen, (float)point.x, (float)point.y, 1, 1);
            }

            if (bezier == null)
            {
                return;
            }

            // Draw the bezier curve.
            Point[] points = bezier.GetPoints();

            foreach (Point point in points)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }
        }
    }
}
