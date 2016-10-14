using System;
using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;


namespace SineCurve
{
    class SineCurveApp : GameApp
    {
        private Pen pen = new Pen(Color.White, 1);
        private Brush brush = new SolidBrush(Color.Red);
        private List<Vector2> controlPoints = new List<Vector2>();

        private Point[] xPoints;

        /// <summary>
        /// Setup a basic Bezier curve.
        /// </summary>
        public override void Initialize(int width, int height)
        {
            int halfWidth = width / 2;
            int halfHeight = height / 2;

            for (double x = -20; x <= 20; x += 0.1)
            {
                if (x != 0)
                {
                    controlPoints.Add(new Vector2(x * 15 + halfWidth, -(Math.Sin(x) / x) * 200 + halfHeight));
                }
            }

            Line xAxis = new Line(new Vector2(-20 * 15 + halfWidth, halfHeight), new Vector2(20 * 15 + halfWidth, halfHeight));

            xPoints = xAxis.GetPoints();

        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            foreach (Point point in xPoints)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }

            foreach (Vector2 vec in controlPoints)
            {
                Point point = new Point((int)vec.x, (int)vec.y);
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }
        }
    }
}
