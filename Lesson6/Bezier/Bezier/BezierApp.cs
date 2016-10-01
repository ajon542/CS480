using System;
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
        private List<Vector2> controlPoints;
        private Vector2 selectedPoint;

        public override void Initialize()
        {
            controlPoints = new List<Vector2>();
        }

        /// <summary>
        /// Allow the user to define the points of the Bezier curve.
        /// </summary>
        public override void MouseClick(int x, int y)
        {
        }

        /// <summary>
        /// Handle the control point selection.
        /// </summary>
        public override void MouseDown(int x, int y)
        {
            foreach (Vector2 point in controlPoints)
            {
                int dx = Math.Abs(x - (int)point.x);
                int dy = Math.Abs(y - (int)point.y);

                // In range of a control point, handle the selection.
                if (dx < 10 && dy < 10)
                {
                    selectedPoint = point;
                    return;
                }
            }
        }

        /// <summary>
        /// Handle the drag and drop of the control point.
        /// </summary>
        public override void MouseUp(int x, int y)
        {
            if (selectedPoint != null)
            {
                // Update the selected point to the mouse button release location.
                selectedPoint.x = x;
                selectedPoint.y = y;
                selectedPoint = null;

                // Regenerate the bezier curve.
                bezier = new BezierCurve(controlPoints);
            }
            else
            {
                // No point was selected, add a new control point.
                controlPoints.Add(new Vector2(x, y));

                // Generate the bezier curve if there enough points.
                if (controlPoints.Count >= 3)
                {
                    bezier = new BezierCurve(controlPoints);
                }
            }
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw control points.
            foreach (Vector2 point in controlPoints)
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
