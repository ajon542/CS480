using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;

namespace Bezier
{
    /// <summary>
    /// Simple application to display lines based on the Bresenham line algorithm.
    /// The application allows the user to click on the screen to define the start
    /// and end points of each line.
    /// </summary>
    public class BezierApp : GameApp
    {
        private Pen pen = new Pen(Color.White, 1);
        private List<Line> lines = new List<Line>();
        private Vector2 startPoint;

        /// <summary>
        /// Allow the user to define the start and end points of the line.
        /// </summary>
        public override void MouseClick(int x, int y)
        {
            if (startPoint == null)
            {
                // Define the start point.
                startPoint = new Vector2(x, y);
            }
            else
            {
                // Define the end point.
                Vector2 endPoint = new Vector2(x, y);

                // Add the line and clear the start point.
                lines.Add(new Line(startPoint, endPoint));
                startPoint = null;
            }
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            foreach (Line line in lines)
            {
                Point[] points = line.GetPoints();
                foreach (Point point in points)
                {
                    graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
                }
            }
        }
    }
}
