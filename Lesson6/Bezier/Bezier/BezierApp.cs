using System;
using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;

namespace Bezier
{
    /// <summary>
    /// Simple application to display an N degree Bezier curve while allowing
    /// the user to add and modify control points.
    /// </summary>
    public class BezierApp : GameApp
    {
        private Pen pen = new Pen(Color.White, 1);
        private Brush brush = new SolidBrush(Color.Red);
        private BezierCurve bezier;
        private List<Vector2> controlPoints = new List<Vector2>();
        private Vector2 selectedPoint;

        /// <summary>
        /// Setup a basic Bezier curve.
        /// </summary>
        public override void Initialize()
        {
            controlPoints.Add(new Vector2(100, 200));
            controlPoints.Add(new Vector2(400, 400));
            controlPoints.Add(new Vector2(600, 200));
            bezier = new BezierCurve(controlPoints);
        }

        /// <summary>
        /// Handle the control point selection.
        /// </summary>
        public override void MouseDown(int x, int y)
        {
            // Check to see if the mouse down occurs close to a control point.
            foreach (Vector2 point in controlPoints)
            {
                int dx = Math.Abs(x - (int)point.x);
                int dy = Math.Abs(y - (int)point.y);

                // In range of a control point, keep track of the selected point.
                // On the mouse up event, the new position will be set.
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
            }
            else
            {
                // No control point was selected, the mouse up event must be the
                // user clicking to add another control point.
                controlPoints.Add(new Vector2(x, y));
            }

            // Generate the bezier curve.
            bezier = new BezierCurve(controlPoints);
        }

        /// <summary>
        /// Handle the button click to reset the Bezier curve.
        /// </summary>
        public override void ButtonClick(string buttonId)
        {
            if (buttonId == "ResetButton")
            {
                controlPoints.Clear();
                controlPoints.Add(new Vector2(100, 200));
                controlPoints.Add(new Vector2(400, 400));
                controlPoints.Add(new Vector2(600, 200));
                bezier = new BezierCurve(controlPoints);
            }
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw the bezier curve.
            Point[] points = bezier.GetPoints();

            foreach (Point point in points)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }

            // Draw control points.
            foreach (Vector2 point in controlPoints)
            {
                graphics.FillEllipse(brush, (float)point.x - 5, (float)point.y - 5, 10, 10);
            }
        }
    }
}
