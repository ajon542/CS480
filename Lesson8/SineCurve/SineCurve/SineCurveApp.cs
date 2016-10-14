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

        private Point[] xPoints;
        private Point[] yPoints;
        private Point[] linePoints;

        /// <summary>
        /// Setup a basic Bezier curve.
        /// </summary>
        public override void Initialize(int width, int height)
        {
            int halfWidth = width / 2;
            int halfHeight = height / 2;

            // Add the control points.
            List<Vector2> controlPoints = new List<Vector2>();
            for (double x = -20; x <= 20; x += 0.1)
            {
                if (x != 0)
                {
                    controlPoints.Add(new Vector2(x * 15 + halfWidth, -(Math.Sin(x) / x) * 200 + halfHeight));
                }
            }

            // Generate the line segments.
            List<Point> points = new List<Point>();
            for (int i = 0; i < controlPoints.Count - 1; ++i)
            {
                Line line = new Line(controlPoints[i], controlPoints[i + 1]);
                points.AddRange(line.GetPoints());
            }

            linePoints = points.ToArray();

            // Create the x axis and y axis.
            Line xAxis = new Line(new Vector2(-30 * 15 + halfWidth, halfHeight), new Vector2(30 * 15 + halfWidth, halfHeight));
            Line yAxis = new Line(new Vector2(halfWidth, halfHeight - 2 * 120), new Vector2(halfWidth, halfHeight + 2 * 120));

            xPoints = xAxis.GetPoints();
            yPoints = yAxis.GetPoints();
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw the x axis and y axis.
            foreach (Point point in xPoints)
            {
                // FillRectangle gives you a thinner line which is better for the axes.
                graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
            }

            // Draw the x axis and y axis.
            foreach (Point point in yPoints)
            {
                // FillRectangle gives you a thinner line which is better for the axes.
                graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
            }

            // Draw the line segments.
            foreach (Point point in linePoints)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }
        }
    }
}
